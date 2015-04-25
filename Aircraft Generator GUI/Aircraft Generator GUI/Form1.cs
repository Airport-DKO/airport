using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aircraft_Generator_GUI.AircraftGeneratorWs;
using Aircraft_Generator_GUI.GmcVs;
using Aircraft_Generator_GUI.GscVs;

namespace Aircraft_Generator_GUI
{
    public partial class Form1 : Form
    {
        private readonly AircraftGenerator _aircraftGeneratorWebService;

        public Form1()
        {
            InitializeComponent();
            typeListBox.Items.AddRange(Enum.GetNames(typeof (PlaneType)));
            _aircraftGeneratorWebService = new AircraftGenerator();
            new Task(Refresher).Start();
        }
        private void GetPlanesList()
        {
            while (planesGridControl.IsHandleCreated == false)
            {
            }

            Plane[] planesList = _aircraftGeneratorWebService.GetAllPlanes();
            int oldSelectedIndex = 0;
            if (gridView1.DataRowCount > 0)
            {
                oldSelectedIndex = gridView1.GetSelectedRows().First();
            }
            planesGridControl.BeginInvoke((Action) (() => planesGridControl.DataSource = planesList));
            planesGridControl.BeginInvoke((Action) (() => planesGridControl.RefreshDataSource()));
            if(gridView1.DataRowCount>0)
            planesGridControl.BeginInvoke((Action)(() => gridView1.FocusedRowHandle=oldSelectedIndex));

        }

        private void CreateNewPlane(string name, PlaneType type, int fuelNeed, int currentStandartPassangers,
            int currentVipPassangers, bool hasArrivalPassengers, int currentBaggage)
        {
            _aircraftGeneratorWebService.CreateNewPlane(name, type, fuelNeed, currentStandartPassangers,
                currentVipPassangers, currentBaggage, hasArrivalPassengers);
        }

        private void createPlaneButton_Click(object sender, EventArgs e)
        {
            if (typeListBox.SelectedItem == null || fuelNeedTextEdit.Text == "" || maxStdPsnTextEdit.Text == "" ||
                maxVipPsnTextEdit.Text == "" || baggageTextEdit.Text == "" || nameTextEdit.Text == "")
            {
                return;
            }

            int currentStandartPassengers = Int32.Parse(maxStdPsnTextEdit.Text);
            int currentVipPassengers = Int32.Parse(maxVipPsnTextEdit.Text);
            bool hasArrivalPassengers = (currentStandartPassengers != 0 || currentVipPassengers != 0);

            PlaneType type;
            Enum.TryParse(typeListBox.SelectedItem.ToString(), out type);
            CreateNewPlane(nameTextEdit.Text, type, Int32.Parse(fuelNeedTextEdit.Text),
                currentStandartPassengers, currentVipPassengers,
                hasArrivalPassengers, Int32.Parse(baggageTextEdit.Text));
            GetPlanesList();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetPlanesList();
        }

        private void bindPlaneToFlightButton_Click(object sender, EventArgs e)
        {
            if (gridView1.GetSelectedRows() == null)
            {
                return;
            }
            int selectedRowNumber = gridView1.GetSelectedRows().First();
            object row = gridView1.GetRow(selectedRowNumber);
            var plane = row as Plane;
            if (plane.Flight != null)
            {
                return;}
            var bp = new BindPlane(plane);
            bp.ShowDialog();
            if (bp.DialogResult == DialogResult.OK)
            {
                _aircraftGeneratorWebService.BindPlaneToFlight(plane.Id, bp.SelectedFlightGuid);
                GetPlanesList();
            }
        }

        private void Refresher()
        {
            while (true)
            {
                GetPlanesList();
                Thread.Sleep(5000);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _aircraftGeneratorWebService.Reset();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var g = new GMC();
            g.Reset();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var g = new GSC();
            g.Reset();
        }
    }
}