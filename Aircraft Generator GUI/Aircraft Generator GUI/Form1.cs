using System;
using System.Windows.Forms;
using Aircraft_Generator_GUI.WSAircraftGenerator;

namespace Aircraft_Generator_GUI
{
    public partial class Form1 : Form
    {
        private readonly AircraftGeneratorSoap _aircraftGeneratorWebService;

        public Form1()
        {
            InitializeComponent();
            typeListBox.Items.AddRange(Enum.GetNames(typeof (PlaneType)));
            _aircraftGeneratorWebService = new AircraftGeneratorSoapClient();
            GetPlanesList();
        }

        private void GetPlanesList()
        {
            GetAllPlanesResponse planesList = _aircraftGeneratorWebService.GetAllPlanes(new GetAllPlanesRequest());
            planesGridControl.DataSource = planesList.Body.GetAllPlanesResult;
            planesGridControl.RefreshDataSource();
        }

        private void CreateNewPlane(string name, PlaneType type, int fuelNeed, int maxStandartPassangers,
            int maxVipPassangers, bool hasArrivalPassengers)
        {
            var request = new CreateNewPlaneRequest
            {
                Body = new CreateNewPlaneRequestBody()
                {
                    name = name,
                    type = type,
                    fuelNeed = fuelNeed,
                    maxStandartPassengers = maxStandartPassangers,
                    maxVipPassengers = maxVipPassangers,
                    hasArrivalPassengers = hasArrivalPassengers
                }
            };
            CreateNewPlaneResponse response = _aircraftGeneratorWebService.CreateNewPlane(request);
        }

        private void createPlaneButton_Click(object sender, EventArgs e)
        {
            PlaneType type;
            Enum.TryParse(typeListBox.SelectedItem.ToString(), out type);
            CreateNewPlane(nameTextEdit.Text, type, Convert.ToInt32(fuelNeedTextEdit.Text),
                Convert.ToInt32(maxStdPsnTextEdit.Text), Convert.ToInt32(maxVipPsnTextEdit.Text),
                hasArrivalPassengersCheckBox.Checked);
            GetPlanesList();}

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetPlanesList();
        }
    }
}