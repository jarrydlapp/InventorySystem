namespace RIDS
{
    partial class AddCargo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.AddCargoGrid = new System.Windows.Forms.DataGridView();
            this.lbSerialNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxCargoType = new System.Windows.Forms.ComboBox();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.ckbSensitive = new System.Windows.Forms.CheckBox();
            this.ckcBoxDamaged = new System.Windows.Forms.CheckBox();
            this.cmbBoxDepo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbxDrivable = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.gpBoxRS = new System.Windows.Forms.GroupBox();
            this.gpbxContainerItem = new System.Windows.Forms.GroupBox();
            this.txtCDesc = new System.Windows.Forms.TextBox();
            this.txtContNum = new System.Windows.Forms.TextBox();
            this.lblContainerNum = new System.Windows.Forms.Label();
            this.lblCDesc = new System.Windows.Forms.Label();
            this.grpBoxLoose = new System.Windows.Forms.GroupBox();
            this.txtBoxDescLoose = new System.Windows.Forms.TextBox();
            this.lblDescpLoose = new System.Windows.Forms.Label();
            this.gb463L = new System.Windows.Forms.GroupBox();
            this.ckboxTrained = new System.Windows.Forms.CheckBox();
            this.txt463LDecs = new System.Windows.Forms.TextBox();
            this.lbl463LDesc = new System.Windows.Forms.Label();
            this.ckbHazmat = new System.Windows.Forms.CheckBox();
            this.ckbHighVis = new System.Windows.Forms.CheckBox();
            this.txtSTCN = new System.Windows.Forms.Label();
            this.txtBoxStcn = new System.Windows.Forms.TextBox();
            this.txtBoxDest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.richTextComment = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBoxUnitOwner = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDepoReset = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.AddCargoGrid)).BeginInit();
            this.gpBoxRS.SuspendLayout();
            this.gpbxContainerItem.SuspendLayout();
            this.grpBoxLoose.SuspendLayout();
            this.gb463L.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(48, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 47);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddCargoGrid
            // 
            this.AddCargoGrid.AllowUserToAddRows = false;
            this.AddCargoGrid.AllowUserToDeleteRows = false;
            this.AddCargoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddCargoGrid.Location = new System.Drawing.Point(12, 241);
            this.AddCargoGrid.Name = "AddCargoGrid";
            this.AddCargoGrid.RowTemplate.Height = 24;
            this.AddCargoGrid.Size = new System.Drawing.Size(1081, 243);
            this.AddCargoGrid.TabIndex = 1;
            // 
            // lbSerialNum
            // 
            this.lbSerialNum.AutoSize = true;
            this.lbSerialNum.Location = new System.Drawing.Point(24, 29);
            this.lbSerialNum.Name = "lbSerialNum";
            this.lbSerialNum.Size = new System.Drawing.Size(102, 17);
            this.lbSerialNum.TabIndex = 2;
            this.lbSerialNum.Text = "Serial Number:";
            this.lbSerialNum.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cargo Type:";
            // 
            // cmbxCargoType
            // 
            this.cmbxCargoType.FormattingEnabled = true;
            this.cmbxCargoType.Items.AddRange(new object[] {
            "",
            "Rolling Stock",
            "Container",
            "Loose",
            "463L Pallet"});
            this.cmbxCargoType.Location = new System.Drawing.Point(124, 39);
            this.cmbxCargoType.Name = "cmbxCargoType";
            this.cmbxCargoType.Size = new System.Drawing.Size(121, 24);
            this.cmbxCargoType.TabIndex = 1;
            this.cmbxCargoType.SelectedIndexChanged += new System.EventHandler(this.cmbxCargoType_SelectedIndexChanged);
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Location = new System.Drawing.Point(123, 27);
            this.txtSerialNum.MaxLength = 25;
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(121, 22);
            this.txtSerialNum.TabIndex = 5;
            this.txtSerialNum.Visible = false;
            // 
            // ckbSensitive
            // 
            this.ckbSensitive.AutoSize = true;
            this.ckbSensitive.Location = new System.Drawing.Point(334, 178);
            this.ckbSensitive.Name = "ckbSensitive";
            this.ckbSensitive.Size = new System.Drawing.Size(117, 21);
            this.ckbSensitive.TabIndex = 6;
            this.ckbSensitive.Text = "Sensitive Item";
            this.ckbSensitive.UseVisualStyleBackColor = true;
            this.ckbSensitive.CheckedChanged += new System.EventHandler(this.ckbSensitive_CheckedChanged);
            // 
            // ckcBoxDamaged
            // 
            this.ckcBoxDamaged.AutoSize = true;
            this.ckcBoxDamaged.Location = new System.Drawing.Point(334, 201);
            this.ckcBoxDamaged.Name = "ckcBoxDamaged";
            this.ckcBoxDamaged.Size = new System.Drawing.Size(91, 21);
            this.ckcBoxDamaged.TabIndex = 7;
            this.ckcBoxDamaged.Text = "Damaged";
            this.ckcBoxDamaged.UseVisualStyleBackColor = true;
            // 
            // cmbBoxDepo
            // 
            this.cmbBoxDepo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBoxDepo.FormattingEnabled = true;
            this.cmbBoxDepo.Items.AddRange(new object[] {
            "",
            "Recieved",
            "Outbound",
            "Departed"});
            this.cmbBoxDepo.Location = new System.Drawing.Point(124, 128);
            this.cmbBoxDepo.Name = "cmbBoxDepo";
            this.cmbBoxDepo.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxDepo.TabIndex = 4;
            this.cmbBoxDepo.SelectedIndexChanged += new System.EventHandler(this.cmbBoxDepo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(44, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Deposition:";
            // 
            // ckbxDrivable
            // 
            this.ckbxDrivable.AutoSize = true;
            this.ckbxDrivable.Location = new System.Drawing.Point(124, 60);
            this.ckbxDrivable.Name = "ckbxDrivable";
            this.ckbxDrivable.Size = new System.Drawing.Size(82, 21);
            this.ckbxDrivable.TabIndex = 10;
            this.ckbxDrivable.Text = "Drivable";
            this.ckbxDrivable.UseVisualStyleBackColor = true;
            this.ckbxDrivable.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Destination:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(123, 92);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(121, 22);
            this.txtDesc.TabIndex = 13;
            this.txtDesc.Visible = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(40, 94);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(83, 17);
            this.lblDesc.TabIndex = 14;
            this.lblDesc.Text = "Description:";
            this.lblDesc.Visible = false;
            // 
            // gpBoxRS
            // 
            this.gpBoxRS.Controls.Add(this.txtDesc);
            this.gpBoxRS.Controls.Add(this.txtSerialNum);
            this.gpBoxRS.Controls.Add(this.ckbxDrivable);
            this.gpBoxRS.Controls.Add(this.lbSerialNum);
            this.gpBoxRS.Controls.Add(this.lblDesc);
            this.gpBoxRS.Location = new System.Drawing.Point(307, 15);
            this.gpBoxRS.Name = "gpBoxRS";
            this.gpBoxRS.Size = new System.Drawing.Size(264, 132);
            this.gpBoxRS.TabIndex = 15;
            this.gpBoxRS.TabStop = false;
            this.gpBoxRS.Text = "Rolling Stock Item";
            this.gpBoxRS.Visible = false;
            // 
            // gpbxContainerItem
            // 
            this.gpbxContainerItem.Controls.Add(this.txtCDesc);
            this.gpbxContainerItem.Controls.Add(this.txtContNum);
            this.gpbxContainerItem.Controls.Add(this.lblContainerNum);
            this.gpbxContainerItem.Controls.Add(this.lblCDesc);
            this.gpbxContainerItem.Location = new System.Drawing.Point(273, 26);
            this.gpbxContainerItem.Name = "gpbxContainerItem";
            this.gpbxContainerItem.Size = new System.Drawing.Size(276, 87);
            this.gpbxContainerItem.TabIndex = 16;
            this.gpbxContainerItem.TabStop = false;
            this.gpbxContainerItem.Text = "Container Item";
            this.gpbxContainerItem.Visible = false;
            // 
            // txtCDesc
            // 
            this.txtCDesc.Location = new System.Drawing.Point(139, 53);
            this.txtCDesc.MaxLength = 15;
            this.txtCDesc.Name = "txtCDesc";
            this.txtCDesc.Size = new System.Drawing.Size(121, 22);
            this.txtCDesc.TabIndex = 13;
            this.txtCDesc.Visible = false;
            // 
            // txtContNum
            // 
            this.txtContNum.Location = new System.Drawing.Point(139, 20);
            this.txtContNum.MaxLength = 15;
            this.txtContNum.Name = "txtContNum";
            this.txtContNum.Size = new System.Drawing.Size(121, 22);
            this.txtContNum.TabIndex = 5;
            this.txtContNum.Visible = false;
            // 
            // lblContainerNum
            // 
            this.lblContainerNum.AutoSize = true;
            this.lblContainerNum.Location = new System.Drawing.Point(14, 22);
            this.lblContainerNum.Name = "lblContainerNum";
            this.lblContainerNum.Size = new System.Drawing.Size(127, 17);
            this.lblContainerNum.TabIndex = 2;
            this.lblContainerNum.Text = "Container Number:";
            this.lblContainerNum.Visible = false;
            // 
            // lblCDesc
            // 
            this.lblCDesc.AutoSize = true;
            this.lblCDesc.Location = new System.Drawing.Point(58, 55);
            this.lblCDesc.Name = "lblCDesc";
            this.lblCDesc.Size = new System.Drawing.Size(83, 17);
            this.lblCDesc.TabIndex = 14;
            this.lblCDesc.Text = "Description:";
            this.lblCDesc.Visible = false;
            // 
            // grpBoxLoose
            // 
            this.grpBoxLoose.Controls.Add(this.txtBoxDescLoose);
            this.grpBoxLoose.Controls.Add(this.lblDescpLoose);
            this.grpBoxLoose.Location = new System.Drawing.Point(270, 52);
            this.grpBoxLoose.Name = "grpBoxLoose";
            this.grpBoxLoose.Size = new System.Drawing.Size(274, 64);
            this.grpBoxLoose.TabIndex = 23;
            this.grpBoxLoose.TabStop = false;
            this.grpBoxLoose.Text = "Loose";
            this.grpBoxLoose.Visible = false;
            // 
            // txtBoxDescLoose
            // 
            this.txtBoxDescLoose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBoxDescLoose.Location = new System.Drawing.Point(107, 25);
            this.txtBoxDescLoose.MaxLength = 25;
            this.txtBoxDescLoose.Name = "txtBoxDescLoose";
            this.txtBoxDescLoose.Size = new System.Drawing.Size(121, 22);
            this.txtBoxDescLoose.TabIndex = 15;
            this.txtBoxDescLoose.Visible = false;
            // 
            // lblDescpLoose
            // 
            this.lblDescpLoose.AutoSize = true;
            this.lblDescpLoose.Location = new System.Drawing.Point(24, 27);
            this.lblDescpLoose.Name = "lblDescpLoose";
            this.lblDescpLoose.Size = new System.Drawing.Size(83, 17);
            this.lblDescpLoose.TabIndex = 16;
            this.lblDescpLoose.Text = "Description:";
            this.lblDescpLoose.Visible = false;
            // 
            // gb463L
            // 
            this.gb463L.Controls.Add(this.ckboxTrained);
            this.gb463L.Controls.Add(this.txt463LDecs);
            this.gb463L.Controls.Add(this.lbl463LDesc);
            this.gb463L.Location = new System.Drawing.Point(275, 25);
            this.gb463L.Name = "gb463L";
            this.gb463L.Size = new System.Drawing.Size(248, 88);
            this.gb463L.TabIndex = 24;
            this.gb463L.TabStop = false;
            this.gb463L.Text = "463L Pallet";
            this.gb463L.Visible = false;
            // 
            // ckboxTrained
            // 
            this.ckboxTrained.AutoSize = true;
            this.ckboxTrained.Location = new System.Drawing.Point(107, 57);
            this.ckboxTrained.Name = "ckboxTrained";
            this.ckboxTrained.Size = new System.Drawing.Size(118, 21);
            this.ckboxTrained.TabIndex = 17;
            this.ckboxTrained.Text = "Trained Pallet";
            this.ckboxTrained.UseVisualStyleBackColor = true;
            // 
            // txt463LDecs
            // 
            this.txt463LDecs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt463LDecs.Location = new System.Drawing.Point(107, 25);
            this.txt463LDecs.MaxLength = 25;
            this.txt463LDecs.Name = "txt463LDecs";
            this.txt463LDecs.Size = new System.Drawing.Size(121, 22);
            this.txt463LDecs.TabIndex = 15;
            this.txt463LDecs.Visible = false;
            // 
            // lbl463LDesc
            // 
            this.lbl463LDesc.AutoSize = true;
            this.lbl463LDesc.Location = new System.Drawing.Point(27, 27);
            this.lbl463LDesc.Name = "lbl463LDesc";
            this.lbl463LDesc.Size = new System.Drawing.Size(83, 17);
            this.lbl463LDesc.TabIndex = 16;
            this.lbl463LDesc.Text = "Description:";
            this.lbl463LDesc.Visible = false;
            // 
            // ckbHazmat
            // 
            this.ckbHazmat.AutoSize = true;
            this.ckbHazmat.Location = new System.Drawing.Point(334, 155);
            this.ckbHazmat.Name = "ckbHazmat";
            this.ckbHazmat.Size = new System.Drawing.Size(78, 21);
            this.ckbHazmat.TabIndex = 17;
            this.ckbHazmat.Text = "Hazmat";
            this.ckbHazmat.UseVisualStyleBackColor = true;
            this.ckbHazmat.CheckedChanged += new System.EventHandler(this.ckbHazmat_CheckedChanged);
            // 
            // ckbHighVis
            // 
            this.ckbHighVis.AutoSize = true;
            this.ckbHighVis.Location = new System.Drawing.Point(454, 178);
            this.ckbHighVis.Name = "ckbHighVis";
            this.ckbHighVis.Size = new System.Drawing.Size(115, 21);
            this.ckbHighVis.TabIndex = 18;
            this.ckbHighVis.Text = "High Visablity";
            this.ckbHighVis.UseVisualStyleBackColor = true;
            this.ckbHighVis.Visible = false;
            // 
            // txtSTCN
            // 
            this.txtSTCN.AutoSize = true;
            this.txtSTCN.Location = new System.Drawing.Point(83, 71);
            this.txtSTCN.Name = "txtSTCN";
            this.txtSTCN.Size = new System.Drawing.Size(40, 17);
            this.txtSTCN.TabIndex = 15;
            this.txtSTCN.Text = "TCN:";
            // 
            // txtBoxStcn
            // 
            this.txtBoxStcn.Location = new System.Drawing.Point(124, 69);
            this.txtBoxStcn.MaxLength = 17;
            this.txtBoxStcn.Name = "txtBoxStcn";
            this.txtBoxStcn.Size = new System.Drawing.Size(121, 22);
            this.txtBoxStcn.TabIndex = 2;
            // 
            // txtBoxDest
            // 
            this.txtBoxDest.Location = new System.Drawing.Point(124, 159);
            this.txtBoxDest.MaxLength = 25;
            this.txtBoxDest.Name = "txtBoxDest";
            this.txtBoxDest.Size = new System.Drawing.Size(121, 22);
            this.txtBoxDest.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Unit Owner:";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleDescription = "";
            this.btnAdd.AccessibleName = "";
            this.btnAdd.Location = new System.Drawing.Point(727, 181);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 49);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add Cargo";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(904, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 47);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // richTextComment
            // 
            this.richTextComment.Location = new System.Drawing.Point(677, 20);
            this.richTextComment.MaxLength = 125;
            this.richTextComment.Name = "richTextComment";
            this.richTextComment.Size = new System.Drawing.Size(280, 155);
            this.richTextComment.TabIndex = 28;
            this.richTextComment.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Comments:";
            // 
            // cmbBoxUnitOwner
            // 
            this.cmbBoxUnitOwner.FormattingEnabled = true;
            this.cmbBoxUnitOwner.Items.AddRange(new object[] {
            ""});
            this.cmbBoxUnitOwner.Location = new System.Drawing.Point(124, 97);
            this.cmbBoxUnitOwner.Name = "cmbBoxUnitOwner";
            this.cmbBoxUnitOwner.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxUnitOwner.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDepoReset);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 214);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Piece Information";
            // 
            // btnDepoReset
            // 
            this.btnDepoReset.AccessibleDescription = "Reset Deposition";
            this.btnDepoReset.AccessibleName = "Reset Deposition";
            this.btnDepoReset.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDepoReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDepoReset.Location = new System.Drawing.Point(234, 112);
            this.btnDepoReset.Name = "btnDepoReset";
            this.btnDepoReset.Size = new System.Drawing.Size(23, 23);
            this.btnDepoReset.TabIndex = 0;
            this.btnDepoReset.UseVisualStyleBackColor = true;
            this.btnDepoReset.Click += new System.EventHandler(this.btnDepoReset_Click);
            this.btnDepoReset.MouseHover += new System.EventHandler(this.btnDepoReset_MouseHover);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(51, 176);
            this.dateTimePicker1.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2017, 4, 12, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(293, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 83);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // AddCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 546);
            this.Controls.Add(this.ckbHighVis);
            this.Controls.Add(this.ckcBoxDamaged);
            this.Controls.Add(this.ckbSensitive);
            this.Controls.Add(this.ckbHazmat);
            this.Controls.Add(this.cmbBoxUnitOwner);
            this.Controls.Add(this.grpBoxLoose);
            this.Controls.Add(this.gpbxContainerItem);
            this.Controls.Add(this.gb463L);
            this.Controls.Add(this.richTextComment);
            this.Controls.Add(this.gpBoxRS);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxDest);
            this.Controls.Add(this.txtBoxStcn);
            this.Controls.Add(this.txtSTCN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBoxDepo);
            this.Controls.Add(this.cmbxCargoType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddCargoGrid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddCargo";
            this.Text = "Add Cargo";
            this.Load += new System.EventHandler(this.AddCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AddCargoGrid)).EndInit();
            this.gpBoxRS.ResumeLayout(false);
            this.gpBoxRS.PerformLayout();
            this.gpbxContainerItem.ResumeLayout(false);
            this.gpbxContainerItem.PerformLayout();
            this.grpBoxLoose.ResumeLayout(false);
            this.grpBoxLoose.PerformLayout();
            this.gb463L.ResumeLayout(false);
            this.gb463L.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView AddCargoGrid;
        private System.Windows.Forms.Label lbSerialNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxCargoType;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.CheckBox ckbSensitive;
        private System.Windows.Forms.CheckBox ckcBoxDamaged;
        private System.Windows.Forms.ComboBox cmbBoxDepo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbxDrivable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.GroupBox gpBoxRS;
        private System.Windows.Forms.GroupBox gpbxContainerItem;
        private System.Windows.Forms.TextBox txtCDesc;
        private System.Windows.Forms.Label lblCDesc;
        private System.Windows.Forms.Label lblContainerNum;
        private System.Windows.Forms.TextBox txtContNum;
        private System.Windows.Forms.CheckBox ckbHazmat;
        private System.Windows.Forms.CheckBox ckbHighVis;
        private System.Windows.Forms.Label txtSTCN;
        private System.Windows.Forms.TextBox txtBoxStcn;
        private System.Windows.Forms.TextBox txtBoxDest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoxLoose;
        private System.Windows.Forms.TextBox txtBoxDescLoose;
        private System.Windows.Forms.Label lblDescpLoose;
        private System.Windows.Forms.GroupBox gb463L;
        private System.Windows.Forms.CheckBox ckboxTrained;
        private System.Windows.Forms.Label lbl463LDesc;
        private System.Windows.Forms.TextBox txt463LDecs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox richTextComment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBoxUnitOwner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnDepoReset;
        private System.Windows.Forms.Label label6;
    }
}