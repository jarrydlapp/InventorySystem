namespace RIDS
{
    partial class CargoShipment
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
            this.components = new System.ComponentModel.Container();
            this.cmbBoxDepo = new System.Windows.Forms.ComboBox();
            this.btnAddCargo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTCN = new System.Windows.Forms.Label();
            this.txtDepo = new System.Windows.Forms.Label();
            this.txtBoxTCN = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.CargoShipmentGrid = new System.Windows.Forms.DataGridView();
            this.txtDest = new System.Windows.Forms.Label();
            this.txtBoxDest = new System.Windows.Forms.TextBox();
            this.txtAsset = new System.Windows.Forms.Label();
            this.cmbBoxAsset = new System.Windows.Forms.ComboBox();
            this.cmbBoxRecv = new System.Windows.Forms.ComboBox();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.CargoShipmentGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBoxDepo
            // 
            this.cmbBoxDepo.FormattingEnabled = true;
            this.cmbBoxDepo.Items.AddRange(new object[] {
            "Received",
            "Outbound",
            "Departed"});
            this.cmbBoxDepo.Location = new System.Drawing.Point(127, 41);
            this.cmbBoxDepo.Name = "cmbBoxDepo";
            this.cmbBoxDepo.Size = new System.Drawing.Size(132, 24);
            this.cmbBoxDepo.TabIndex = 2;
            // 
            // btnAddCargo
            // 
            this.btnAddCargo.Location = new System.Drawing.Point(285, 55);
            this.btnAddCargo.Name = "btnAddCargo";
            this.btnAddCargo.Size = new System.Drawing.Size(134, 46);
            this.btnAddCargo.TabIndex = 0;
            this.btnAddCargo.Text = "Add Piece";
            this.btnAddCargo.UseVisualStyleBackColor = true;
            this.btnAddCargo.Click += new System.EventHandler(this.btnAddCargo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(127, 419);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 50);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTCN
            // 
            this.txtTCN.AutoSize = true;
            this.txtTCN.Location = new System.Drawing.Point(86, 19);
            this.txtTCN.Name = "txtTCN";
            this.txtTCN.Size = new System.Drawing.Size(40, 17);
            this.txtTCN.TabIndex = 3;
            this.txtTCN.Text = "TCN:";
            // 
            // txtDepo
            // 
            this.txtDepo.AutoSize = true;
            this.txtDepo.Location = new System.Drawing.Point(47, 44);
            this.txtDepo.Name = "txtDepo";
            this.txtDepo.Size = new System.Drawing.Size(79, 17);
            this.txtDepo.TabIndex = 4;
            this.txtDepo.Text = "Deposition:";
            // 
            // txtBoxTCN
            // 
            this.txtBoxTCN.Location = new System.Drawing.Point(127, 16);
            this.txtBoxTCN.Name = "txtBoxTCN";
            this.txtBoxTCN.Size = new System.Drawing.Size(132, 22);
            this.txtBoxTCN.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(685, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 50);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CargoShipmentGrid
            // 
            this.CargoShipmentGrid.AllowUserToAddRows = false;
            this.CargoShipmentGrid.AllowUserToDeleteRows = false;
            this.CargoShipmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CargoShipmentGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CargoShipmentGrid.Location = new System.Drawing.Point(34, 162);
            this.CargoShipmentGrid.Name = "CargoShipmentGrid";
            this.CargoShipmentGrid.RowTemplate.Height = 24;
            this.CargoShipmentGrid.Size = new System.Drawing.Size(861, 248);
            this.CargoShipmentGrid.TabIndex = 0;
            // 
            // txtDest
            // 
            this.txtDest.AutoSize = true;
            this.txtDest.Location = new System.Drawing.Point(43, 71);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(83, 17);
            this.txtDest.TabIndex = 5;
            this.txtDest.Text = "Destination:";
            // 
            // txtBoxDest
            // 
            this.txtBoxDest.Location = new System.Drawing.Point(127, 68);
            this.txtBoxDest.Name = "txtBoxDest";
            this.txtBoxDest.Size = new System.Drawing.Size(132, 22);
            this.txtBoxDest.TabIndex = 3;
            // 
            // txtAsset
            // 
            this.txtAsset.AutoSize = true;
            this.txtAsset.Location = new System.Drawing.Point(79, 96);
            this.txtAsset.Name = "txtAsset";
            this.txtAsset.Size = new System.Drawing.Size(47, 17);
            this.txtAsset.TabIndex = 12;
            this.txtAsset.Text = "Asset:";
            // 
            // cmbBoxAsset
            // 
            this.cmbBoxAsset.FormattingEnabled = true;
            this.cmbBoxAsset.Items.AddRange(new object[] {
            "Military",
            "Civilian"});
            this.cmbBoxAsset.Location = new System.Drawing.Point(127, 93);
            this.cmbBoxAsset.Name = "cmbBoxAsset";
            this.cmbBoxAsset.Size = new System.Drawing.Size(132, 24);
            this.cmbBoxAsset.TabIndex = 4;
            // 
            // cmbBoxRecv
            // 
            this.cmbBoxRecv.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unitBindingSource, "Unitname", true));
            this.cmbBoxRecv.FormattingEnabled = true;
            this.cmbBoxRecv.Location = new System.Drawing.Point(127, 120);
            this.cmbBoxRecv.Name = "cmbBoxRecv";
            this.cmbBoxRecv.Size = new System.Drawing.Size(132, 24);
            this.cmbBoxRecv.TabIndex = 5;
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataSource = typeof(RIDS.Unit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Click to Add Additional Cargo Pieces";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(425, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 89);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(33, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 154);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Received By:";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(278, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 89);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // CargoShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 478);
            this.Controls.Add(this.cmbBoxRecv);
            this.Controls.Add(this.cmbBoxAsset);
            this.Controls.Add(this.txtAsset);
            this.Controls.Add(this.CargoShipmentGrid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBoxDest);
            this.Controls.Add(this.txtBoxTCN);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.txtTCN);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddCargo);
            this.Controls.Add(this.cmbBoxDepo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDepo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CargoShipment";
            this.Text = "Manifest";
            this.Load += new System.EventHandler(this.CargoShipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CargoShipmentGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxDepo;
        private System.Windows.Forms.Button btnAddCargo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label txtDepo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBoxTCN;
        private System.Windows.Forms.Label txtTCN;
        private System.Windows.Forms.DataGridView CargoShipmentGrid;
        private System.Windows.Forms.TextBox txtBoxDest;
        private System.Windows.Forms.Label txtDest;
        private System.Windows.Forms.Label txtAsset;
        private System.Windows.Forms.ComboBox cmbBoxAsset;
        private System.Windows.Forms.ComboBox cmbBoxRecv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
    }
}