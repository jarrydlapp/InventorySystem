using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RIDS
{
    public partial class CargoShipment : Form
    {
        private static DataTable _dt = new DataTable();
        private readonly List<RollingStock> _rollingstock = new List<RollingStock>();
        private readonly List<Container> _container = new List<Container>();
        private readonly RidsDriver _ridsDriver = new RidsDriver();

        public CargoShipment()
        {
            InitializeComponent();
            _dt.Clear();
        }
        public CargoShipment(List<RollingStock> rList, List<Container> cnList)
        {
            InitializeComponent();
            _rollingstock = rList;
            _container = cnList;
            LockDepo(_rollingstock, _container);
        }
        ////////////////////////////////////////////////////////////
        // Loads the DataTable with CargoShipment Headers
        // Loads Recieved By with a list of Distinct Units
        // Loads the DataTable with CargoPieces from Add Cargo page
        private void CargoShipment_Load(object sender, EventArgs e)
        {
            if (_dt.Columns.Count != 15)
            {
                _dt.Columns.Add("TCN", typeof(string));
                _dt.Columns.Add("Cargo Type", typeof(string));
                _dt.Columns.Add("Piece ID", typeof(string));
                _dt.Columns.Add("Description", typeof(string));
                _dt.Columns.Add("Unit Owner", typeof(string));
                _dt.Columns.Add("Deposition", typeof(string));
                _dt.Columns.Add("Destination", typeof(string));
                _dt.Columns.Add("Drivable", typeof(string));
                _dt.Columns.Add("Hazmat", typeof(string));
                _dt.Columns.Add("Sensitive Item", typeof(string));
                _dt.Columns.Add("High Visabilty", typeof(string));
                _dt.Columns.Add("Damaged", typeof(string));
                _dt.Columns.Add("Trained Pallet", typeof(string));
                _dt.Columns.Add("Comments", typeof(string));
                _dt.Columns.Add("Date", typeof(string));
            }
            _dt = ConvertListToDataTable(_rollingstock, _container);

            CargoShipmentGrid.DataSource = _dt;
            LoadRecievedBy();
        }
        ////////////////////////////////////////////////////////////
        // Converts List into an Array for easier reading and adding
        // of the data into the DataTable
        public DataTable ConvertListToDataTable(List<RollingStock> rs, List<Container> cont)
        {
            foreach (var rsArray in rs)
            {
                _dt.Rows.Add(rsArray.Tcn, rsArray.Cargotype, rsArray.IdNumber, rsArray.Description, rsArray.Unitowner,
                    rsArray.Deposition
                    , rsArray.Destination, rsArray.IsDrivable, rsArray.IsHazmat, rsArray.IsSensitive,
                    rsArray.IsHighVisability, rsArray.IsDamaged,
                    "", rsArray.Comments, rsArray.Datetime);
            }
            foreach (var cArray in cont)
            {
                _dt.Rows.Add(cArray.Tcn, cArray.Cargotype, cArray.IdNumber, cArray.Description, cArray.Unitowner,
                    cArray.Deposition
                    , cArray.Destination, "", cArray.IsHazmat, cArray.IsSensitive, cArray.IsHighVisability,
                    cArray.IsDamaged,
                    cArray.IsTrained, cArray.Comments, cArray.Datetime);
            }
            return _dt;
        }
        ////////////////////////////////////////////////////////////
        // Opens the Add Cargo Piece window for the user
        // so that they can add additional cargo pieces
        private void btnAddCargo_Click(object sender, EventArgs e)
        {
            if (_dt.Rows.Count >= 1)
            {
                DialogResult result =
                    MessageBox.Show(@"Would you like to add more cargo pieces to the manifest?"
                                    ,@"Add Additional Cargo",
                        MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _dt.Clear();
                    Form addCargo = new AddCargo(_rollingstock, _container);
                    addCargo.Show();
                    Close();
                }
             }
            else
            {
                Form addCargo = new AddCargo();
                addCargo.Show();
                Close();
            }
         }
        ////////////////////////////////////////////////////////////
        // Closed the Form Page, Main Screen opens for the user
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_dt.Rows.Count >= 1)
            {
                var result =
                    MessageBox.Show(
                        @"Closing window, All data will be lost. Do you want to continue?",
                        @"Manifest Not Created",
                        MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var m = new Main();
                    m.Show();
                    Close();
                }
            }
            else
            {
                var m = new Main();
                m.Show();
                Close();
            }
        }

        ////////////////////////////////////////////////////////////
        // Saves the Manifest and Cargo Pieces to external database
        // file. Closes out the form and opens Main 
        private void btnSave_Click(object sender, EventArgs e)
        {
            var valid = _fieldValidation(txtBoxTCN.Text, cmbBoxDepo.Text, txtBoxDest.Text, cmbBoxAsset.Text, cmbBoxRecv.Text);
            if (valid && (_dt.Rows.Count >= 1))
            {
                foreach (RollingStock t in _rollingstock)
                {
                    CShipment cs = new CShipment(txtBoxTCN.Text, cmbBoxDepo.Text, cmbBoxAsset.Text, txtBoxDest.Text,
                        t.Tcn, cmbBoxRecv.Text);
                    _ridsDriver.CreateCargoShipment(cs);
                }
                foreach (Container t in _container)
                {
                    CShipment cs = new CShipment(txtBoxTCN.Text, cmbBoxDepo.Text, cmbBoxAsset.Text, txtBoxDest.Text,
                        t.Tcn, cmbBoxRecv.Text);
                    _ridsDriver.CreateCargoShipment(cs);
                }

                _ridsDriver.CreateCargoShipment(_rollingstock, _container);
                _ridsDriver.WriteCargoShipment();

                _dt.Clear();

                MessageBox.Show(@"Cargo manifest has been saved!");

                Close();
                Main m = new Main();
                m.Show();
            }
            else
            {
                MessageBox.Show(@"Please fill out required fields");
            }
        }
        ////////////////////////////////////////////////////////////
        // Validates Form Entry of Required Fields
        private bool _fieldValidation(string tcn, string depo, string dest, string asset, string recievedby)
        {
            bool isvalid = true; 
            if (string.IsNullOrEmpty(tcn))
            {
                txtBoxTCN.BackColor = Color.Red;
                isvalid = false;
            }
            if (string.IsNullOrEmpty(depo))
            {
                cmbBoxDepo.BackColor = Color.Red;
                isvalid = false;
            }
            if (string.IsNullOrEmpty(dest))
            {
                txtBoxDest.BackColor = Color.Red;
                isvalid = false;
            }
            if (string.IsNullOrEmpty(asset))
            {
                cmbBoxAsset.BackColor = Color.Red;
                isvalid = false;
            }
            if (string.IsNullOrEmpty(recievedby))
            {
                cmbBoxRecv.BackColor = Color.Red;
                isvalid = false;
            }
            return isvalid;
        }

        private void LockDepo(IReadOnlyList<RollingStock> rList, IReadOnlyList<Container> cnList)
        {
            string value;

            cmbBoxDepo.Enabled = false;

            if (rList.Count > 0)
            {
                value = rList[0].Deposition;
                cmbBoxDepo.Text = value;
            }
            else if (cnList.Count > 0)
            {
                value = cnList[0].Deposition;
                cmbBoxDepo.Text = value;
            }
        }
        ////////////////////////////////////////////////////////////
        // Loads Received By with Unit Names from the Unit File
        private void LoadRecievedBy()
        {
            RidsDriver ridsDriver = new RidsDriver();
            List<string> uniqueUnit = ridsDriver.LoadRecievedBy();

            foreach (var u in uniqueUnit)
            {
                cmbBoxRecv.Items.Add(u);
            }
        }
    }
}
