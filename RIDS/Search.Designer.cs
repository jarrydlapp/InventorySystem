namespace RIDS
{
    partial class Search
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
            this.SearchDataGrid = new System.Windows.Forms.DataGridView();
            this.btnCloseSearch = new System.Windows.Forms.Button();
            this.pointOfContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SearchDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointOfContactBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchDataGrid
            // 
            this.SearchDataGrid.AllowUserToAddRows = false;
            this.SearchDataGrid.AllowUserToDeleteRows = false;
            this.SearchDataGrid.AllowUserToResizeRows = false;
            this.SearchDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.SearchDataGrid.Location = new System.Drawing.Point(12, 12);
            this.SearchDataGrid.Name = "SearchDataGrid";
            this.SearchDataGrid.ReadOnly = true;
            this.SearchDataGrid.RowTemplate.Height = 24;
            this.SearchDataGrid.Size = new System.Drawing.Size(1042, 366);
            this.SearchDataGrid.TabIndex = 1;
            // 
            // btnCloseSearch
            // 
            this.btnCloseSearch.Location = new System.Drawing.Point(455, 384);
            this.btnCloseSearch.Name = "btnCloseSearch";
            this.btnCloseSearch.Size = new System.Drawing.Size(106, 52);
            this.btnCloseSearch.TabIndex = 4;
            this.btnCloseSearch.Text = "Close";
            this.btnCloseSearch.UseVisualStyleBackColor = true;
            this.btnCloseSearch.Click += new System.EventHandler(this.btnCloseSearch_Click_1);
            // 
            // pointOfContactBindingSource
            // 
            this.pointOfContactBindingSource.DataSource = typeof(RIDS.PointOfContact);
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(RIDS.Person);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 448);
            this.Controls.Add(this.btnCloseSearch);
            this.Controls.Add(this.SearchDataGrid);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.SearchDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointOfContactBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView SearchDataGrid;
        private System.Windows.Forms.BindingSource pointOfContactBindingSource;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.Button btnCloseSearch;
        private System.IO.Ports.SerialPort serialPort1;
    }
}