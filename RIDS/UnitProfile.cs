using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RIDS
{
    public partial class UnitProfile : Form
    {
        private bool _validField = true;
        private bool _invalid;
        private bool _edit;
        private readonly RidsDriver _rdsDriver = new RidsDriver();
        private static List<Unit> _unit = new List<Unit>();
        private PointOfContact[] _contacts = new PointOfContact[_unit.Count];
        private int _index;

        public UnitProfile()
        {
          InitializeComponent();
          btnNext.Visible = false;
        }
        ////////////////////////////////////////////////////////////
        // On Form Loads, RIDSDriver Loads the Unit Information
        // From Unit File into Unit List for accessability
        private void UnitProfile_Load(object sender, EventArgs e)
        {
            _rdsDriver.LoadUnits();
        }
        ////////////////////////////////////////////////////////////
        // Saves a Unit & Point Of Contact to the Unit Information
        // file. Also used for editing a unit which follows
        // the same save/write methods
        private void btnSavePointOfContact_Click(object sender, EventArgs e)
        {
            _validField = _fieldValidation(txtFName.Text, txtLName.Text, txtEmail.Text, txtPhone.Text);
            if (_validField)
            {
                if (_edit)
                {
                    PointOfContact tempContact = new PointOfContact(_contacts[_index].Uic, _contacts[_index].Firstname,
                        _contacts[_index].Lastname,
                        _contacts[_index].Email, _contacts[_index].Phone, _contacts[_index].Station);

                    PointOfContact poc = new PointOfContact(txtUIC.Text, txtFName.Text, txtLName.Text, txtEmail.Text,
                        txtPhone.Text, txtStation.Text);

                    _rdsDriver.EditUnit(poc, tempContact);
                    _rdsDriver.WriteUnits();

                    //Used to catch Index Out of Range Exception
                    try
                    {
                        if (_unit.Count > _index || _index != 0)
                        {
                            txtUnit.Text = _unit[_index].Unitname;
                            txtUIC.Text = _unit[_index].Uic;
                            SetTextFields();
                            _edit = false;
                            MakeFieldsReadOnly();
                        }
                    }
                    catch (Exception indException)
                    {
                        MessageBox.Show(indException.ToString());
                    }
                }
                else
                {
                  bool isdupe =  _rdsDriver.CreateUnitProfile(txtUIC.Text, txtUnit.Text, txtFName.Text, txtLName.Text, txtEmail.Text,
                      txtPhone.Text, txtStation.Text);
                    if(isdupe)
                    {
                        MessageBox.Show(@"Contact already exist");
                    }
                    else
                    {
                        MessageBox.Show(@"Contact Saved Successfully");
                    }
                }
                ClearTxtFeilds();

                btnNext.Enabled = false;
                btnDelete.Visible = false;
            }
            else
            {
                MessageBox.Show(@"Please enter values in required fields");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _index = 0;

            _unit = _rdsDriver.SearchUnit(txtSearchUIC.Text.ToUpper());
            if (_unit.Count > 0)
            {
                _contacts = _rdsDriver.SearchContact(_unit);
                txtSearchUIC.Clear();
                MakeFieldsReadOnly();
                btnClearFields.Visible = true;

                txtUnit.Text = _unit[_index].Unitname;
                txtUIC.Text = _unit[_index].Uic;
                if (_contacts != null)
                {
                   SetTextFields();
                }
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                
                if (_unit.Count > 1)
                {
                    btnNext.Visible = true;
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(@"Unit Not Found");
            }
        }
        public void btnNext_Click(object sender, EventArgs e)
        {
            _index++;
            if (_index < _unit.Count)
            {
                txtUnit.Text = _unit[_index].Unitname;
                txtUIC.Text = _unit[_index].Uic;
                SetTextFields();
            }
            else
            {
                _index = 0;
                txtUnit.Text = _unit[_index].Unitname;
                txtUIC.Text = _unit[_index].Uic;
                SetTextFields();
            }
        }
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearTxtFeilds();
            _edit = false;
            btnDelete.Visible = false;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            _edit = true;
            btnNext.Enabled = false;
            btnDelete.Enabled = false;

            txtFName.ReadOnly = false;
            txtLName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtStation.ReadOnly = false;

            txtFName.Cursor = Cursors.IBeam;
            txtLName.Cursor = Cursors.IBeam;
            txtEmail.Cursor = Cursors.IBeam;
            txtPhone.Cursor = Cursors.IBeam;
            txtStation.Cursor = Cursors.IBeam;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    @"Do you want to delete this contact?",
                    @"Delete Contact",
                    MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _rdsDriver.DeleteContact(_contacts[_index]);
                _rdsDriver.WriteUnits();

                ClearTxtFeilds();
                btnDelete.Visible = false;

                MessageBox.Show(@"Contact Deleted Successfully");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            _rdsDriver.WriteUnits();
            Main main = new Main();
            main.Show();
            Close();
        }
        private bool _fieldValidation(string fname, string lname, string email, string phone)
        {

            bool valid = true;
            if (string.IsNullOrEmpty(fname))
            {
                txtFName.BackColor = System.Drawing.Color.Red;
                valid = false;
            }
            else
            {
                txtFName.BackColor = System.Drawing.Color.White;
            }
            if (string.IsNullOrEmpty(lname))
            {
                txtLName.BackColor = System.Drawing.Color.Red;
                valid = false;
            }
            else
            {
                txtLName.BackColor = System.Drawing.Color.White;
            }
            if (!IsValidEmail(email))
            {
                txtEmail.BackColor = System.Drawing.Color.Red;
                valid = false;
            }
            else
            {
                txtEmail.BackColor = System.Drawing.Color.White;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //This regular expression for phone numbers conforms to NANP A-digit and D-digit requirments (ANN-DNN-NNNN). 
            //Area Codes 001-199 are not permitted; Central Office Codes 001-199 are not permitted. 
            //Format validation accepts 10-digits without delimiters
            if (phone != null && Regex.Match(phone, @"^(?:\([2-9]\d{2}\)\ ?|[2-9]\d{2}(?:\-?|\ ?))[2-9]\d{2}[- ]?\d{4}$").Success)
            {
                txtPhone.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtPhone.BackColor = System.Drawing.Color.Red;
                valid = false;
            }
            return valid;
        }
        public bool IsValidEmail(string strIn)
        {
            _invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (_invalid)
                return false;
            // Return true if strIn is in valid e-mail format.
            if (Regex.IsMatch(strIn,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                return true;
            }
            MessageBox.Show(@"Email Address is Invalid");
            return false;
        }
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                _invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        private void MakeFieldsReadOnly()
        {
            txtUnit.ReadOnly = true;
            txtUIC.ReadOnly = true;
            txtFName.ReadOnly = true;
            txtLName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtStation.ReadOnly = true;

            txtUnit.Cursor = Cursors.No;
            txtUIC.Cursor = Cursors.No;
            txtFName.Cursor = Cursors.No;
            txtLName.Cursor = Cursors.No;
            txtEmail.Cursor = Cursors.No;
            txtPhone.Cursor = Cursors.No;
            txtStation.Cursor = Cursors.No;
        }
        public void ClearTxtFeilds()
        {
            txtFName.Clear();
            txtLName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtStation.Clear();
            txtUnit.Clear();
            txtUIC.Clear();

            txtUnit.ReadOnly = false;
            txtUIC.ReadOnly = false;
            txtFName.ReadOnly = false;
            txtLName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtStation.ReadOnly = false;

            if (txtUIC.Cursor == Cursors.No && txtUnit.Cursor == Cursors.No)
            {
                txtUIC.Cursor = Cursors.IBeam;
                txtUnit.Cursor = Cursors.IBeam;
                txtFName.Cursor = Cursors.IBeam;
                txtLName.Cursor = Cursors.IBeam;
                txtEmail.Cursor = Cursors.IBeam;
                txtPhone.Cursor = Cursors.IBeam;
                txtStation.Cursor = Cursors.IBeam;
            }
            btnNext.Enabled = false;
            btnNext.Visible = false;
            btnDelete.Enabled = true;
            btnClearFields.Visible = false;
            btnEdit.Visible = false;
         }
        public void SetTextFields()
        {
            txtFName.Text = _contacts[_index].Firstname;
            txtLName.Text = _contacts[_index].Lastname;
            txtEmail.Text = _contacts[_index].Email;
            txtPhone.Text = _contacts[_index].Phone;
            txtStation.Text = _contacts[_index].Station;
        }

        private void txtPhone_MouseHover(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this.txtPhone, "10 digits with no delimiters");
        }
    }
}
        