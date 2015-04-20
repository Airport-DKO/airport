using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;

namespace Logger
{
    public partial class FormMain : Form
    {
        private DataTable _dataTable = null;
        private DataSet _dataSet = null;

        private SortedDictionary<int, string> _filtersaved = new SortedDictionary<int, string>();
        private SortedDictionary<int, string> _sortsaved = new SortedDictionary<int, string>();

        public FormMain()
        {
            InitializeComponent();

            //set filter and sort saved
            _filtersaved.Add(0, "");
            _sortsaved.Add(0, "");

            m_DelegateAddString = new DelegateAddString(this.AddString);
            m_DelegateThreadFinished = new DelegateThreadFinished(this.ThreadFinished);

            m_EventStopThread = new ManualResetEvent(false);
            m_EventThreadStopped = new ManualResetEvent(false);
            
            _dataTable = new DataTable();
            _dataSet = new DataSet();

            //initialize bindingsource
            bindingSource_main.DataSource = _dataSet;

            //initialize datagridview
            advancedDataGridView_main.DataSource = bindingSource_main;

            //set bindingsource
            SetTestData();
        }

        public delegate void DelegateAddString(String s);
        public delegate void DelegateThreadFinished();

        Thread m_WorkerThread;

        ManualResetEvent m_EventStopThread;
        ManualResetEvent m_EventThreadStopped;

        public DelegateAddString m_DelegateAddString;
        public DelegateThreadFinished m_DelegateThreadFinished;

        public static FileStream fs = new FileStream(@"C:\airport\log.csv", FileMode.OpenOrCreate, FileAccess.Write);
        public static StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("Windows-1251"));


        private void SetTestData()
        {
            _dataTable = _dataSet.Tables.Add("Logger");
            _dataTable.Columns.Add("Дата", typeof(string));
            _dataTable.Columns.Add("Время", typeof(string));
            _dataTable.Columns.Add("Тип", typeof(string));
            _dataTable.Columns.Add("Компонента", typeof(string));
            _dataTable.Columns.Add("Сообщение", typeof(string));

            bindingSource_main.DataMember = _dataTable.TableName;

            advancedDataGridViewSearchToolBar_main.SetColumns(advancedDataGridView_main.Columns);
        }

        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource_main.Filter = advancedDataGridView_main.FilterString;
            textBox_filter.Text = bindingSource_main.Filter;
        }

        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource_main.Sort = advancedDataGridView_main.SortString;
            textBox_sort.Text = bindingSource_main.Sort;
        }

        private void bindingSource_main_ListChanged(object sender, ListChangedEventArgs e)
        {
            textBox_total.Text = bindingSource_main.List.Count.ToString();
        }

        private void button_unloadfilters_Click(object sender, EventArgs e)
        {
            advancedDataGridView_main.CleanFilterAndSort();
        }

        private void advancedDataGridViewSearchToolBar_main_Search(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = advancedDataGridView_main.CurrentCell.ColumnIndex + 1 >= advancedDataGridView_main.ColumnCount;
                bool endrow = advancedDataGridView_main.CurrentCell.RowIndex + 1 >= advancedDataGridView_main.RowCount;

                if (endcol && endrow)
                {
                    startColumn = advancedDataGridView_main.CurrentCell.ColumnIndex;
                    startRow = advancedDataGridView_main.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : advancedDataGridView_main.CurrentCell.ColumnIndex + 1;
                    startRow = advancedDataGridView_main.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }
            DataGridViewCell c = advancedDataGridView_main.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);

            if (c != null)
                advancedDataGridView_main.CurrentCell = c;
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            _dataTable.Rows.Clear();
        }

        private void btnStartThread_Click(object sender, System.EventArgs e)
        {
            btnStartThread.Enabled = false;
            btnStopThread.Enabled = true;

            m_EventStopThread.Reset();
            m_EventThreadStopped.Reset();

            m_WorkerThread = new Thread(new ThreadStart(this.WorkerThreadFunction));

            m_WorkerThread.Name = "Logger Thread";

            m_WorkerThread.Start();

        }

        private void btnStopThread_Click(object sender, System.EventArgs e)
        {
            StopThread();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void WorkerThreadFunction()
        {
            Process longProcess;

            longProcess = new Process(m_EventStopThread, m_EventThreadStopped, this);

            longProcess.Run();
        }

        private void PutMinusOne()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "tester";
            factory.Password = "tester";
            factory.VirtualHost = "/";
            factory.HostName = "airport-dko-1.cloudapp.net";
            factory.Port = 5672;

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare("LoggerQueue", false, false, false, null);

            string message = "-1";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", "LoggerQueue", null, body);

            channel.Close();
            connection.Close();
        }


        private void StopThread()
        {

            if (m_WorkerThread != null && m_WorkerThread.IsAlive)
            {
                PutMinusOne();
                m_EventStopThread.Set();

                while (m_WorkerThread.IsAlive)
                {
                    if (WaitHandle.WaitAll(
                        (new ManualResetEvent[] { m_EventThreadStopped }),
                        100,
                        true))
                    {
                        break;
                    }

                    Application.DoEvents();
                }
            }

            ThreadFinished();
        }

        private void AddString(String s)
        {
            if (s != "-1")
            {
                String[] words = s.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    _dataTable.Rows.Add(words[0], words[1], words[2], words[3], words[4]);
                    sw.WriteLine(words[0] + ";" + words[1] + ";" + words[2] + ";" + words[3] + ";" + words[4]);
                }
                catch
                {
                    _dataTable.Rows.Add("", "", "", "",  "Нераспознанная строка");
                }
            }
        }

        private void ThreadFinished()
        {
            btnStartThread.Enabled = true;
            btnStopThread.Enabled = false;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopThread();
            sw.Close();
        }

    }
}
