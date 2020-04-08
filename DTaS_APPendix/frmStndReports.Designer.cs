namespace DTaS_APPendix
{
    partial class frmStndReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStndReports));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpReviews = new System.Windows.Forms.GroupBox();
            this.dgvStndReports = new System.Windows.Forms.DataGridView();
            this.RepChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.repIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rTempDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rSPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rADDSPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFROMDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rTODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStndReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(447, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(208, 398);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 40);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // grpReviews
            // 
            this.grpReviews.Controls.Add(this.dgvStndReports);
            this.grpReviews.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReviews.Location = new System.Drawing.Point(12, 12);
            this.grpReviews.Name = "grpReviews";
            this.grpReviews.Size = new System.Drawing.Size(776, 380);
            this.grpReviews.TabIndex = 9;
            this.grpReviews.TabStop = false;
            // 
            // dgvStndReports
            // 
            this.dgvStndReports.AllowUserToAddRows = false;
            this.dgvStndReports.AllowUserToDeleteRows = false;
            this.dgvStndReports.AutoGenerateColumns = false;
            this.dgvStndReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStndReports.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvStndReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStndReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RepChk,
            this.repIDDataGridViewTextBoxColumn,
            this.rNameDataGridViewTextBoxColumn,
            this.rTempDataGridViewTextBoxColumn,
            this.rSPDataGridViewTextBoxColumn,
            this.rADDSPDataGridViewTextBoxColumn,
            this.rFROMDataGridViewCheckBoxColumn,
            this.DateFrom,
            this.rTODataGridViewCheckBoxColumn,
            this.DateTo});
            this.dgvStndReports.DataSource = this.ReportsBindingSource;
            this.dgvStndReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStndReports.Location = new System.Drawing.Point(3, 25);
            this.dgvStndReports.Name = "dgvStndReports";
            this.dgvStndReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvStndReports.Size = new System.Drawing.Size(770, 352);
            this.dgvStndReports.TabIndex = 0;
            this.dgvStndReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStndReports_CellContentClick);
            this.dgvStndReports.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStndReports_DataBindingComplete);
            // 
            // RepChk
            // 
            this.RepChk.HeaderText = "Select";
            this.RepChk.Name = "RepChk";
            // 
            // repIDDataGridViewTextBoxColumn
            // 
            this.repIDDataGridViewTextBoxColumn.DataPropertyName = "Rep_ID";
            this.repIDDataGridViewTextBoxColumn.HeaderText = "Rep_ID";
            this.repIDDataGridViewTextBoxColumn.Name = "repIDDataGridViewTextBoxColumn";
            // 
            // rNameDataGridViewTextBoxColumn
            // 
            this.rNameDataGridViewTextBoxColumn.DataPropertyName = "RName";
            this.rNameDataGridViewTextBoxColumn.HeaderText = "Report Name";
            this.rNameDataGridViewTextBoxColumn.Name = "rNameDataGridViewTextBoxColumn";
            // 
            // rTempDataGridViewTextBoxColumn
            // 
            this.rTempDataGridViewTextBoxColumn.DataPropertyName = "RTemp";
            this.rTempDataGridViewTextBoxColumn.HeaderText = "RTemp";
            this.rTempDataGridViewTextBoxColumn.Name = "rTempDataGridViewTextBoxColumn";
            // 
            // rSPDataGridViewTextBoxColumn
            // 
            this.rSPDataGridViewTextBoxColumn.DataPropertyName = "RSP";
            this.rSPDataGridViewTextBoxColumn.HeaderText = "RSP";
            this.rSPDataGridViewTextBoxColumn.Name = "rSPDataGridViewTextBoxColumn";
            // 
            // rADDSPDataGridViewTextBoxColumn
            // 
            this.rADDSPDataGridViewTextBoxColumn.DataPropertyName = "RADDSP";
            this.rADDSPDataGridViewTextBoxColumn.HeaderText = "RADDSP";
            this.rADDSPDataGridViewTextBoxColumn.Name = "rADDSPDataGridViewTextBoxColumn";
            // 
            // rFROMDataGridViewCheckBoxColumn
            // 
            this.rFROMDataGridViewCheckBoxColumn.DataPropertyName = "RFROM";
            this.rFROMDataGridViewCheckBoxColumn.HeaderText = "RFROM";
            this.rFROMDataGridViewCheckBoxColumn.Name = "rFROMDataGridViewCheckBoxColumn";
            // 
            // DateFrom
            // 
            this.DateFrom.HeaderText = "Date From";
            this.DateFrom.MaxInputLength = 10;
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.ToolTipText = "dd/mm/yyyy";
            // 
            // rTODataGridViewCheckBoxColumn
            // 
            this.rTODataGridViewCheckBoxColumn.DataPropertyName = "RTO";
            this.rTODataGridViewCheckBoxColumn.HeaderText = "RTO";
            this.rTODataGridViewCheckBoxColumn.Name = "rTODataGridViewCheckBoxColumn";
            // 
            // DateTo
            // 
            this.DateTo.HeaderText = "Date To";
            this.DateTo.MaxInputLength = 10;
            this.DateTo.Name = "DateTo";
            this.DateTo.ToolTipText = "dd/mm/yyyy";
            // 
            // ReportsBindingSource
            // 
            this.ReportsBindingSource.DataSource = typeof(DTaS_APPendix.VPReports);
            // 
            // frmStndReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpReviews);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStndReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DTaS APPendix - Standard Reports";
            this.Load += new System.EventHandler(this.frmStndReports_Load);
            this.grpReviews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStndReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        protected internal System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.BindingSource ReportsBindingSource;
        private System.Windows.Forms.GroupBox grpReviews;
        protected internal System.Windows.Forms.DataGridView dgvStndReports;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RepChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn repIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rTempDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rADDSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rFROMDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rTODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
    }
}