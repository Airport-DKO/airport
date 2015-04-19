using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using InformationPanelGUI.InformationPanelWs;
using InformationPanelGUI.TimeService;

namespace InformationPanelGUI
{
    public partial class Form1 : Form
    {
        private WebServiceInformationPanel _informationPanel;
        private MetrologService _timeService;

        public Form1()
        {
            InitializeComponent();
            _informationPanel = new WebServiceInformationPanel();
            _timeService = new MetrologService();
            cityComboBox.Properties.Items.AddRange(Enum.GetNames(typeof (Cities)));
            arrivalDateEdit.Properties.VistaDisplayMode = DefaultBoolean.True;
            arrivalDateEdit.Properties.VistaEditTime = DefaultBoolean.True;
            arrivalDateEdit.Properties.DisplayFormat.FormatString = "dd MMM HH:mm";
            departureDateEdit.Properties.VistaDisplayMode = DefaultBoolean.True;
            departureDateEdit.Properties.VistaEditTime = DefaultBoolean.True;
            departureDateEdit.Properties.DisplayFormat.FormatString = "dd MMM HH:mm";
            var t = new Task(RefreshGridAsync);
            t.Start();
        }

        private void RefreshGridAsync()
        {
            while (true)
            {
                if (flightsGridControl.IsHandleCreated)
                {RefreshGrid();
                    Thread.Sleep(3000);
                }
            }
        }

        private void RefreshGrid()

        {
            try
            {
                Flight[] flights = _informationPanel.GetFlightsList();
                var flightList = new List<FlightGuiClass>();
                foreach (Flight flight in flights)
                {
                    var newFlight = new FlightGuiClass
                    {
                        FlightNumber = flight.FligthName,
                        ArriavalTime = flight.arrivalTime,
                        DepartureTime = flight.takeoffTime,
                        City = flight.city,
                        StartRegistration = flight.StartRegistrationTime,
                        EndRegistration = flight.EndRegistrationTime,
                        PassengersStandart = flight.EconomPassengersCount,
                        PassengersVip = flight.VipPassengersCount,
                        Status = _informationPanel.GetStatus(flight.number)
                    };
                    flightList.Add(newFlight);
                }
                flightsGridControl.BeginInvoke((Action) (() => flightsGridControl.DataSource = flightList));
                flightsGridControl.BeginInvoke((Action) (() => flightsGridControl.RefreshDataSource()));

                timeLabel.BeginInvoke(
                    (Action)
                        (() =>
                            timeLabel.Text = "Текущее время: " + _timeService.GetCurrentTime().ToString("dd MMM HH:mm")));
            }
            catch
            {
                _informationPanel = new WebServiceInformationPanel();
                _timeService = new MetrologService();
            }
        }

        private void createFlightButton_Click(object sender, EventArgs e)
        {
            if (cityComboBox.SelectedItem.ToString() == "Город" || economTextEdit.Text == "" || vipTextEdit.Text == "" ||
                flightNameTextEdit.Text == "")
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
            Enum.TryParse(cityString, out city);
            _informationPanel.CreateFlight(flightNameTextEdit.Text,
                arrivalDateEdit.DateTime.ToString("yyyy-MM-dd HH:mm"),
                departureDateEdit.DateTime.ToString("yyyy-MM-dd HH:mm"), city, Int32.Parse(economTextEdit.Text),
                Int32.Parse(vipTextEdit.Text));
            RefreshGrid();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _informationPanel.Reset();
            RefreshGrid();
        }
    }
}