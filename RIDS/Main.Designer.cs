namespace RIDS
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnCreateManifest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbQuickSearch = new System.Windows.Forms.GroupBox();
            this.cmbBoxUnits = new System.Windows.Forms.ComboBox();
            this.btnSearchQS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxUIC = new System.Windows.Forms.TextBox();
            this.txtBoxTCNS = new System.Windows.Forms.TextBox();
            this.cmbBoxCargoType = new System.Windows.Forms.ComboBox();
            this.lblCargoTypeS = new System.Windows.Forms.Label();
            this.lblTCNs = new System.Windows.Forms.Label();
            this.lblUnitS = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.grpBoxDataBaseOpt = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbQuickSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(24, 41);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(97, 57);
            this.btnAddContact.TabIndex = 0;
            this.btnAddContact.Text = "Create Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddUnit_Click);
            // 
            // btnCreateManifest
            // 
            this.btnCreateManifest.Location = new System.Drawing.Point(24, 132);
            this.btnCreateManifest.Name = "btnCreateManifest";
            this.btnCreateManifest.Size = new System.Drawing.Size(97, 61);
            this.btnCreateManifest.TabIndex = 1;
            this.btnCreateManifest.Text = "Create Manifest";
            this.btnCreateManifest.UseVisualStyleBackColor = true;
            this.btnCreateManifest.Click += new System.EventHandler(this.btnAddShipment_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(212, 310);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 59);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbQuickSearch
            // 
            this.gbQuickSearch.Controls.Add(this.cmbBoxUnits);
            this.gbQuickSearch.Controls.Add(this.btnSearchQS);
            this.gbQuickSearch.Controls.Add(this.txtBoxUIC);
            this.gbQuickSearch.Controls.Add(this.txtBoxTCNS);
            this.gbQuickSearch.Controls.Add(this.cmbBoxCargoType);
            this.gbQuickSearch.Controls.Add(this.lblCargoTypeS);
            this.gbQuickSearch.Controls.Add(this.lblTCNs);
            this.gbQuickSearch.Controls.Add(this.lblUnitS);
            this.gbQuickSearch.Controls.Add(this.label1);
            this.gbQuickSearch.Location = new System.Drawing.Point(153, 23);
            this.gbQuickSearch.Name = "gbQuickSearch";
            this.gbQuickSearch.Size = new System.Drawing.Size(223, 262);
            this.gbQuickSearch.TabIndex = 3;
            this.gbQuickSearch.TabStop = false;
            this.gbQuickSearch.Text = "Quick Search";
            // 
            // cmbBoxUnits
            // 
            this.cmbBoxUnits.FormattingEnabled = true;
            this.cmbBoxUnits.Location = new System.Drawing.Point(96, 35);
            this.cmbBoxUnits.Name = "cmbBoxUnits";
            this.cmbBoxUnits.Size = new System.Drawing.Size(122, 24);
            this.cmbBoxUnits.TabIndex = 9;
            // 
            // btnSearchQS
            // 
            this.btnSearchQS.Location = new System.Drawing.Point(77, 182);
            this.btnSearchQS.Name = "btnSearchQS";
            this.btnSearchQS.Size = new System.Drawing.Size(75, 58);
            this.btnSearchQS.TabIndex = 8;
            this.btnSearchQS.Text = "Search";
            this.btnSearchQS.UseVisualStyleBackColor = true;
            this.btnSearchQS.Click += new System.EventHandler(this.btnSearchQS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "UIC:";
            // 
            // txtBoxUIC
            // 
            this.txtBoxUIC.Location = new System.Drawing.Point(96, 69);
            this.txtBoxUIC.Name = "txtBoxUIC";
            this.txtBoxUIC.Size = new System.Drawing.Size(121, 22);
            this.txtBoxUIC.TabIndex = 6;
            // 
            // txtBoxTCNS
            // 
            this.txtBoxTCNS.Location = new System.Drawing.Point(96, 97);
            this.txtBoxTCNS.Name = "txtBoxTCNS";
            this.txtBoxTCNS.Size = new System.Drawing.Size(122, 22);
            this.txtBoxTCNS.TabIndex = 4;
            // 
            // cmbBoxCargoType
            // 
            this.cmbBoxCargoType.FormattingEnabled = true;
            this.cmbBoxCargoType.Items.AddRange(new object[] {
            "",
            "Rolling Stock",
            "Container",
            "Loose",
            "463L Pallet"});
            this.cmbBoxCargoType.Location = new System.Drawing.Point(96, 128);
            this.cmbBoxCargoType.Name = "cmbBoxCargoType";
            this.cmbBoxCargoType.Size = new System.Drawing.Size(122, 24);
            this.cmbBoxCargoType.TabIndex = 3;
            // 
            // lblCargoTypeS
            // 
            this.lblCargoTypeS.AutoSize = true;
            this.lblCargoTypeS.Location = new System.Drawing.Point(10, 131);
            this.lblCargoTypeS.Name = "lblCargoTypeS";
            this.lblCargoTypeS.Size = new System.Drawing.Size(86, 17);
            this.lblCargoTypeS.TabIndex = 2;
            this.lblCargoTypeS.Text = "Cargo Type:";
            // 
            // lblTCNs
            // 
            this.lblTCNs.AutoSize = true;
            this.lblTCNs.Location = new System.Drawing.Point(56, 100);
            this.lblTCNs.Name = "lblTCNs";
            this.lblTCNs.Size = new System.Drawing.Size(40, 17);
            this.lblTCNs.TabIndex = 1;
            this.lblTCNs.Text = "TCN:";
            // 
            // lblUnitS
            // 
            this.lblUnitS.AutoSize = true;
            this.lblUnitS.Location = new System.Drawing.Point(59, 38);
            this.lblUnitS.Name = "lblUnitS";
            this.lblUnitS.Size = new System.Drawing.Size(37, 17);
            this.lblUnitS.TabIndex = 0;
            this.lblUnitS.Text = "Unit:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(35, 323);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 33);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(35, 280);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 31);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Export";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // grpBoxDataBaseOpt
            // 
            this.grpBoxDataBaseOpt.Location = new System.Drawing.Point(12, 250);
            this.grpBoxDataBaseOpt.Name = "grpBoxDataBaseOpt";
            this.grpBoxDataBaseOpt.Size = new System.Drawing.Size(118, 119);
            this.grpBoxDataBaseOpt.TabIndex = 5;
            this.grpBoxDataBaseOpt.TabStop = false;
            this.grpBoxDataBaseOpt.Text = "File Options";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 381);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.gbQuickSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateManifest);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.grpBoxDataBaseOpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Main";
            this.gbQuickSearch.ResumeLayout(false);
            this.gbQuickSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnCreateManifest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbQuickSearch;
        private System.Windows.Forms.Label lblCargoTypeS;
        private System.Windows.Forms.Label lblTCNs;
        private System.Windows.Forms.Label lblUnitS;
        private System.Windows.Forms.ComboBox cmbBoxCargoType;
        private System.Windows.Forms.Button btnSearchQS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxUIC;
        private System.Windows.Forms.TextBox txtBoxTCNS;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox grpBoxDataBaseOpt;
        private System.Windows.Forms.ComboBox cmbBoxUnits;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}