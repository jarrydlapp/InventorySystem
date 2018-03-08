using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RIDS
{
    public partial class AddCargo : Form
    {
        public AddCargo()
        {
            InitializeComponent();
            _rollingstock.Clear();
            _container.Clear();
        }
        
        public bool Valid = true;
        private DataTable _dt = new DataTable();
        private static List<RollingStock> _rollingstock = new List<RollingStock>();
        private static List<Container> _container = new List<Container>();
        private readonly RidsDriver _rdsDriver = new RidsDriver();
        private readonly DateTime _dteTime = DateTime.Today;

        public AddCargo(List<RollingStock> rList, List<Container> cnList)
        {
            InitializeComponent();
            _rollingstock= rList;
            _container = cnList;
            LockDepo(_rollingstock,_container);
        }

        private void AddCargo_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = @"yyyy-MM-dd";

            _dt.Clear();

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

            LoadRecievedBy();

            _dt = ConvertListToDataTable(_rollingstock, _container);

            AddCargoGrid.DataSource = _dt;
            dateTimePicker1.Value = _dteTime;
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
        private void ClearRollingStock(bool value)
        {
            gpBoxRS.Visible = value;
            lbSerialNum.Visible = value;
            txtSerialNum.Visible = value;
            ckbxDrivable.Visible = value;
            lblDesc.Visible = value;
            txtDesc.Visible = value;
        }
        private void ClearContainer(bool value)
        {
            gpbxContainerItem.Visible = value;
            lblContainerNum.Visible = value;
            txtContNum.Visible = value;
            lblCDesc.Visible = value;
            txtCDesc.Visible = value;
        }
        protected void ClearLoose(bool value)
        {
            grpBoxLoose.Visible = value;
            lblDescpLoose.Visible = value;
            txtBoxDescLoose.Visible = value;
        }
        private void ClearPallet(bool value)
        {
            gb463L.Visible = value;
            lbl463LDesc.Visible = value;
            txt463LDecs.Visible = value;
            ckboxTrained.Visible = value;
        }
        private void ClearTextBoxes()
        {
            txtBoxStcn.Clear();
            cmbxCargoType.Text = "";
            txtSerialNum.Clear();
            txtDesc.Clear();
            cmbBoxUnitOwner.Text = "";
            txtBoxDest.Clear();
            ckbxDrivable.Checked = false;
            ckbHazmat.Checked = false;
            ckbSensitive.Checked = false;
            ckbHighVis.Checked = false;
            ckcBoxDamaged.Checked = false;
            richTextComment.Clear();
        }

        private void AddContainerCargo(Container container)
        {
            _rdsDriver.AddCargoPiece(container.Tcn, container.Cargotype, container.Unitowner, container.IdNumber,
                       container.Destination, container.Deposition, container.IsSensitive
                     , container.IsDamaged, container.IsHazmat, container.IsHighVisability, container.Comments,
                       dateTimePicker1.Value);
        }
        private void cmbxCargoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = cmbxCargoType.Text;

            if (selection == "Rolling Stock")
            {
                ClearRollingStock(true);
                ClearContainer(false);
                ClearLoose(false);
                ClearPallet(false);
            }
            if (selection == "Container")
            {
                ClearRollingStock(false);
                ClearContainer(true);
                ClearLoose(false);
                ClearPallet(false);

            }
            if (selection == "Loose")
            {
                ClearRollingStock(false);
                ClearContainer(false);
                ClearLoose(true);
                ClearPallet(false);
            }
            if (selection == "463L Pallet")
            {
                ClearRollingStock(false);
                ClearContainer(false);
                ClearLoose(false);
                ClearPallet(true);
            }
        }
        public void cmbBoxDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBoxDepo.Enabled = false;
        }
        private void ckbHazmat_CheckedChanged(object sender, EventArgs e)
        {
            ckbHighVis.Visible = true;
            if (ckbHazmat.Checked == false)
            {
                ckbHighVis.Visible = false;
            }
        }
        private void ckbSensitive_CheckedChanged(object sender, EventArgs e)
        {
            ckbHighVis.Visible = true;
            if (ckbSensitive.Checked == false)
            {
                ckbHighVis.Visible = false;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Valid = _fieldValidation(cmbxCargoType.Text, txtBoxStcn.Text, cmbBoxUnitOwner.Text, cmbBoxDepo.Text, txtBoxDest.Text);
            if (Valid)
            {
                if (cmbxCargoType.Text == @"Rolling Stock")
                {
                    _dt.Rows.Add(txtBoxStcn.Text, cmbxCargoType.Text, txtSerialNum.Text, txtDesc.Text, cmbBoxUnitOwner.Text,
                        cmbBoxDepo.Text, txtBoxDest.Text, ckbxDrivable.Checked, ckbHazmat.Checked, ckbSensitive.Checked,
                        ckbHighVis.Checked, ckcBoxDamaged.Checked, false, richTextComment.Text, dateTimePicker1.Text);

                    var rs = new RollingStock(txtBoxStcn.Text, cmbxCargoType.Text, cmbBoxUnitOwner.Text,
                        txtSerialNum.Text, txtDesc.Text, ckbxDrivable.Checked, txtBoxDest.Text, cmbBoxDepo.Text,
                        ckbSensitive.Checked, ckcBoxDamaged.Checked, ckbHazmat.Checked,
                        ckbHighVis.Checked, richTextComment.Text,dateTimePicker1.Value);
                    
                    _rdsDriver.AddCargoPiece(rs.Tcn, rs.Cargotype, rs.Unitowner, rs.IdNumber, rs.Destination, rs.Deposition, rs.IsSensitive
                        , rs.IsDamaged, rs.IsHazmat, rs.IsHighVisability, rs.Comments, dateTimePicker1.Value);

                    _rollingstock.Add(rs);
                    ClearTextBoxes();

                    txtSerialNum.Clear();
                    txtDesc.Clear();  
                    ckbxDrivable.Checked = false;
             
                }
                if (cmbxCargoType.Text == @"Container")
                {
                    _dt.Rows.Add(txtBoxStcn.Text, cmbxCargoType.Text, txtContNum.Text, txtCDesc.Text, cmbBoxUnitOwner.Text,
                        cmbBoxDepo.Text, txtBoxDest.Text, false, ckbHazmat.Checked, ckbSensitive.Checked,
                        ckbHighVis.Checked, ckcBoxDamaged.Checked, false, richTextComment.Text, dateTimePicker1.Text);

                    var container = new Container(txtBoxStcn.Text, cmbxCargoType.Text, txtContNum.Text, cmbBoxUnitOwner.Text,
                         txtBoxDest.Text, cmbBoxDepo.Text, txtCDesc.Text, false, ckbSensitive.Checked,
                        ckcBoxDamaged.Checked, ckbHazmat.Checked, ckbHighVis.Checked, richTextComment.Text,dateTimePicker1.Value);

                    AddContainerCargo(container);

                   _container.Add(container);
                    ClearTextBoxes();

                    txtContNum.Clear();
                    txtCDesc.Clear();
                    ckbxDrivable.Checked = false;

                }
                if (cmbxCargoType.Text == @"Loose")
                {
                    _dt.Rows.Add(txtBoxStcn.Text, cmbxCargoType.Text, false, txtBoxDescLoose.Text, cmbBoxUnitOwner.Text,
                        cmbBoxDepo.Text, txtBoxDest.Text, false, ckbHazmat.Checked, ckbSensitive.Checked,
                        ckbHighVis.Checked, ckcBoxDamaged.Checked, false, richTextComment.Text, dateTimePicker1.Text);

                    var container = new Container(txtBoxStcn.Text, cmbxCargoType.Text, "", cmbBoxUnitOwner.Text, txtBoxDest.Text,
                         cmbBoxDepo.Text, txtBoxDescLoose.Text, false, ckbSensitive.Checked,
                        ckcBoxDamaged.Checked, ckbHazmat.Checked, ckbHighVis.Checked, richTextComment.Text, dateTimePicker1.Value);

                    AddContainerCargo(container);
                    _container.Add(container);

                    ClearTextBoxes();
                    txtBoxDescLoose.Clear();

                }
                if (cmbxCargoType.Text == @"463L Pallet")
                {
                    _dt.Rows.Add(txtBoxStcn.Text, cmbxCargoType.Text, false, txt463LDecs.Text, cmbBoxUnitOwner.Text,
                        cmbBoxDepo.Text, txtBoxDest.Text, false, ckbHazmat.Checked, ckbSensitive.Checked,
                        ckbHighVis.Checked, ckcBoxDamaged.Checked, ckboxTrained.Checked, richTextComment.Text,
                        dateTimePicker1.Text);

                    var container = new Container(txtBoxStcn.Text, cmbxCargoType.Text, "", cmbBoxUnitOwner.Text,
                        txtBoxDest.Text, cmbBoxDepo.Text, txt463LDecs.Text, ckboxTrained.Checked, ckbSensitive.Checked,
                        ckcBoxDamaged.Checked, ckbHazmat.Checked, ckbHighVis.Checked, richTextComment.Text,
                        dateTimePicker1.Value);

                    AddContainerCargo(container);
                    _container.Add(container);

                    ClearTextBoxes();
                    txt463LDecs.Clear();
                    ckboxTrained.Checked = false;
                }
                AddCargoGrid.DataSource = _dt;
            }
            else
            {
                MessageBox.Show(@"Please enter required fields that are highlighted");
            }
        }

        private bool _fieldValidation(string cargotype, string tcn, string unitowner, string depo, string destination)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(cargotype))
            {
                cmbxCargoType.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                cmbxCargoType.BackColor = Color.White;
            }
            if (cmbxCargoType.Text == @"Rolling Stock")
            {
                if (string.IsNullOrEmpty(txtSerialNum.Text))
                {
                    txtSerialNum.BackColor = Color.Red;
                    valid = false;
                }
                else
                {
                    txtSerialNum.BackColor = Color.White;
                }
            }
            if (cmbxCargoType.Text == @"Container")
            {
                if (string.IsNullOrEmpty(txtContNum.Text))
                {
                    txtContNum.BackColor = Color.Red;
                    valid = false;
                }
                else
                {
                    txtContNum.BackColor = Color.White;
                }
            }
            if (string.IsNullOrEmpty(tcn))
            {
                txtBoxStcn.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                txtBoxStcn.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(unitowner))
            {
                cmbBoxUnitOwner.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                cmbBoxUnitOwner.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(depo))
            {
                cmbBoxDepo.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                cmbxCargoType.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(destination))
            {
                txtBoxDest.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                txtBoxDest.BackColor = Color.White;
            }
            return valid;
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (_rollingstock.Count > 0 || _container.Count > 0)
            {
                var cargoShipment = new CargoShipment(_rollingstock, _container);
                cargoShipment.Show();
                Close();
            }
            else
            {
                MessageBox.Show(@"You cannot save without a cargo piece added to the manifest");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        { 
            if (_dt.Rows.Count >= 1)
            {
                var result =
                    MessageBox.Show(
                        @"Closing window, all data will be lost. Do you want to continue?",
                        @"Manifest not created",
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
        private void LoadRecievedBy()
        {
            RidsDriver ridsDriver = new RidsDriver();
            List<string> uniqueUnit = ridsDriver.LoadRecievedBy();

            foreach (var u in uniqueUnit)
            {
                cmbBoxUnitOwner.Items.Add(u);
            }
        }

        private void btnDepoReset_Click(object sender, EventArgs e)
        {
            if(cmbBoxDepo.Enabled ==false)
            cmbBoxDepo.Enabled = true;
        }

        private void LockDepo(IReadOnlyList<RollingStock> rList, IReadOnlyList<Container> cnList)
        {
            string value;

            cmbBoxDepo.Enabled = false;
            btnDepoReset.Visible = false;

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

        private void btnDepoReset_MouseHover(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this.btnDepoReset,"Press to unlock field");
        }
    }
}

