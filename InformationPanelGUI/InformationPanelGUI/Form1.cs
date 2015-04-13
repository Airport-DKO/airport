using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Implementation;
using DevExpress.XtraEditors.Mask;
using InformationPanelGUI.InformationPanelWs;

namespace InformationPanelGUI
{
    public partial class Form1 : Form
    {
        private readonly WebServiceInformationPanel _informationPanel;
        public Form1()
        {
            InitializeComponent();
            _informationPanel=new WebServiceInformationPanel();
            cityComboBox.Properties.Items.AddRange(Enum.GetNames(typeof(Cities)));
            var flightsList=_informationPanel.GetFlightsList();
            flightsGridControl.DataSource = flightsList;
            flightsGridControl.RefreshDataSource();
            arrivalDateEdit.Properties.VistaDisplayMode=DefaultBoolean.True;
            arrivalDateEdit.Properties.VistaEditTime = DefaultBoolean.True;
            arrivalDateEdit.Properties.DisplayFormat.FormatString = "hh:mm";
            departureDateEdit.Properties.VistaDisplayMode = DefaultBoolean.True;
            departureDateEdit.Properties.VistaEditTime = DefaultBoolean.True;
            departureDateEdit.Properties.DisplayFormat.FormatString = "hh:mm";
            var t = new Task(TaskMethod);
            t.Start();
        }

        private void TaskMethod()
        {
            while (true)
            {
                RefreshGrid();
                Thread.Sleep(5000);
            }
        }

        private void RefreshGrid()
        {
            SetControlPropertyThreadSafe(flightsGridControl,"DataSource",new object());
        }

        private delegate void SetControlPropertyThreadSafeDelegate(
    Control control,
    string propertyName,
    object propertyValue);

        public void SetControlPropertyThreadSafe(
            Control control,
            string propertyName,
            object propertyValue)
        {
            var actualFlights = _informationPanel.GetFlightsList();
            if (flightsGridControl.InvokeRequired)
            {
                flightsGridControl.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe),
                    new object[]
                    {
                        flightsGridControl,
                        "DataSource", actualFlights
                    });
            }
            else
            {
                flightsGridControl.GetType()
                    .InvokeMember("DataSource", BindingFlags.SetProperty, null, flightsGridControl,
                        new object[] {actualFlights});
            }
        }


        private void createFlightButton_Click(object sender, EventArgs e)
        {
            if (cityComboBox.SelectedItem.ToString() == "Город" || economTextEdit.Text=="" || vipTextEdit.Text=="")
                return;
            if (arrivalDateEdit.DateTime == DateTime.MinValue)
            {
                arrivalDateEdit.DateTime = DateTime.Now;
            }
            if (departureDateEdit.DateTime == DateTime.MinValue)
            {
                departureDateEdit.DateTime = arrivalDateEdit.DateTime.AddHours(4);
            }
            string cityString = cityComboBox.SelectedItem.ToString();
            Cities city;
            Cities.TryParse(cityString, out city);
            _informationPanel.CreateFlight(arrivalDateEdit.DateTime, departureDateEdit.DateTime, city, Int32.Parse(economTextEdit.Text), Int32.Parse(vipTextEdit.Text));
            RefreshGrid();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _informationPanel.Reset();
            RefreshGrid();
        }
    }
}
