using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RIDS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadRecievedBy();
        }
        ////////////////////////////////////////////////////////////
        // Opens Form to Add and Create Unit and Point of Contact
        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            UnitProfile unitProfiler = new UnitProfile();
            Hide();
            unitProfiler.Show();
        }
        ////////////////////////////////////////////////////////////
        // Opens Form that allows user to see Create Manifest Page
        private void btnAddShipment_Click(object sender, EventArgs e)
        {
           AddCargo ad = new AddCargo();
           Hide();
           ad.Show();
        }
        ////////////////////////////////////////////////////////////
        // Exits the Applicaion
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        ////////////////////////////////////////////////////////////
        // Button used to inititae search functions on QuickSearch
        // area
        private void btnSearchQS_Click(object sender, EventArgs e)
        {
            Search search = new Search(cmbBoxUnits.Text, txtBoxUIC.Text,cmbBoxCargoType.Text, txtBoxTCNS.Text);
            search.Show();
        }
        ////////////////////////////////////////////////////////////
        // Allows the user to generate a report, select file path
        private void btnReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog newfile = new SaveFileDialog
            {
                Filter = @"CSV (Comma delimited) | *.csv",
                DefaultExt = "csv"
            };
            var result = newfile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = newfile.FileName;
                RidsDriver ridsDriver = new RidsDriver();
                ridsDriver.Export(fileName);
            }
         
        }
        ////////////////////////////////////////////////////////////
        // Allows the user to Import database file and merge 
        // the file with the current database file.
        private void btnImport_Click(object sender, EventArgs e)
        {
            string importType;
            MessageBox.Show(@"Ensure importing file is an export from another RIDS system.");
            OpenFileDialog importfile = new OpenFileDialog();

            if (importfile.ShowDialog() == DialogResult.OK)
            {
                var sourcefile = importfile.FileName;

                string extenstion = Path.GetExtension(sourcefile);
                if (extenstion != ".csv")
                {
                    MessageBox.Show(@"Invalid file extension. Only .csv can be imported");
                }
                else
                {
                    RidsDriver ridsDriver = new RidsDriver();
                    importType = ridsDriver.ValidateInputFile(sourcefile);
                    if (importType == "Cargo")
                    {
                        ridsDriver.ImportData(sourcefile);
                        MessageBox.Show(@"Import Completed");
                    }
                    else
                    {
                        MessageBox.Show(@"Input file does not match the layout of a RIDS export." + "\n\nPlease verify " +
                                        @"that the file you are importing, was exported from another RIDS applicaion and has not been modified.",@"Invalid Input File Format");
                    }
                }
              
            }
        }
        ////////////////////////////////////////////////////////////
        // Loads Received By with Unit Names from the Unit File
        private void LoadRecievedBy()
        {
            RidsDriver ridsDriver = new RidsDriver();
            List<string> uniqueUnit = ridsDriver.LoadRecievedBy();

            cmbBoxUnits.Items.Add("");
            foreach (var u in uniqueUnit)
            {
                cmbBoxUnits.Items.Add(u);
            }
        }

    }
}
