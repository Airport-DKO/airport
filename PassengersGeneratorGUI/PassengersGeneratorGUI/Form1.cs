using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PassengersGeneratorGUI.PassengersWs;

namespace PassengersGeneratorGUI
{
    public partial class Form1 : Form
    {
        private readonly WebServicePassengersGenerator _passengersGenerator;

        public Form1()
        {
            InitializeComponent();
            _passengersGenerator = new WebServicePassengersGenerator();
            categingComboBox.Properties.Items.AddRange(Enum.GetNames(typeof (Food)));
            var task = new Task(AsyncMethod);
            task.Start();
        }

        private void createSinglePassengerButton_Click(object sender, EventArgs e)
        {
            if (categingComboBox.SelectedItem.ToString() == "Еда" || baggageTextEdit.Text == "")
            {
                return;
            }
            Food food;
            Enum.TryParse(categingComboBox.SelectedItem.ToString(), out food);
            _passengersGenerator.GeneratePassenger(food, Int32.Parse(baggageTextEdit.Text));
            RefreshGrid();
        }

        private void createMultiplePassengersButton_Click(object sender, EventArgs e)
        {
            if (countOfRandomTextEdit.Text == "")
            {
                return;
            }
            int count = Int32.Parse(countOfRandomTextEdit.Text);
            _passengersGenerator.GenerateRandomPassengers(count);
            RefreshGrid();
        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            _passengersGenerator.PassengerBehavior();
            passengersGrid.BeginInvoke((Action) (() => passengersGrid.RefreshDataSource()));
        }

        private void AsyncMethod()
        {
            RefreshGrid();
            while (true)
            {
                if (simulationToggle.IsOn)
                {_passengersGenerator.PassengerBehavior();
                    RefreshGrid();
                }
                Thread.Sleep(3000);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //TODO: reset'а нет
        }

        private void RefreshGrid()
        {
            Passenger[] list = _passengersGenerator.GetPassengersList();
            passengersGrid.BeginInvoke((Action) (() => passengersGrid.DataSource = list));
            passengersGrid.BeginInvoke((Action) (() => passengersGrid.RefreshDataSource()));
        }
    }
}