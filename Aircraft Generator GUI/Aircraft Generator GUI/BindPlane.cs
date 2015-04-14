using System;
using System.Linq;
using System.Windows.Forms;
using Aircraft_Generator_GUI.AircraftGeneratorWs;
using Aircraft_Generator_GUI.InformationPanelWs;
using Flight = Aircraft_Generator_GUI.InformationPanelWs.Flight;

namespace Aircraft_Generator_GUI
{
    public partial class BindPlane : Form
    {
        public BindPlane(Plane plane)
        {
            InitializeComponent();
            guidTextBox.Text = plane.Id.ToString();
            nameTextBox.Text = plane.Name;
            fuelTextBox.Text = plane.FuelNeed.ToString();
            baggageTextBox.Text = plane.CurrentBaggage.ToString();
            standartTextBox.Text = plane.CurrentStandartPassengers.ToString();
            vipTextBox.Text = plane.CurrentVipPassengers.ToString();
            var panel = new WebServiceInformationPanel();
            flightsGrid.DataSource = panel.GetAvailableFlights();
            flightsGrid.RefreshDataSource();
        }

        public Guid SelectedFlightGuid { get; set; }

        private void bindButton_Click(object sender, EventArgs e)
        {
            if (gridView1.GetSelectedRows() == null)
            {
                return;
            }
            Int32 rowNumber = gridView1.GetSelectedRows().First();
            object row = gridView1.GetRow(rowNumber);
            var flight = row as Flight;
            SelectedFlightGuid = flight.number;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}