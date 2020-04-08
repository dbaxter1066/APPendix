namespace DTaS_APPendix
{
    partial class frmOtherDevs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtherDevs));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvOtherDevs = new System.Windows.Forms.DataGridView();
            this.txtBDAppID = new System.Windows.Forms.TextBox();
            this.devCheckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dEVPIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherDevs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(238, 385);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 44);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(55, 385);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 44);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvOtherDevs
            // 
            this.dgvOtherDevs.AllowUserToDeleteRows = false;
            this.dgvOtherDevs.AutoGenerateColumns = false;
            this.dgvOtherDevs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvOtherDevs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherDevs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.devCheckDataGridViewCheckBoxColumn,
            this.dEVPIDDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn});
            this.dgvOtherDevs.DataSource = this.DevsBindingSource;
            this.dgvOtherDevs.Location = new System.Drawing.Point(18, 18);
            this.dgvOtherDevs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOtherDevs.Name = "dgvOtherDevs";
            this.dgvOtherDevs.Size = new System.Drawing.Size(386, 357);
            this.dgvOtherDevs.TabIndex = 7;
            // 
            // txtBDAppID
            // 
            this.txtBDAppID.Enabled = false;
            this.txtBDAppID.Location = new System.Drawing.Point(357, 391);
            this.txtBDAppID.Name = "txtBDAppID";
            this.txtBDAppID.Size = new System.Drawing.Size(46, 26);
            this.txtBDAppID.TabIndex = 8;
            this.txtBDAppID.TabStop = false;
            this.txtBDAppID.Visible = false;
            this.txtBDAppID.TextChanged += new System.EventHandler(this.txtBDAppID_TextChanged);
            // 
            // devCheckDataGridViewCheckBoxColumn
            // 
            this.devCheckDataGridViewCheckBoxColumn.DataPropertyName = "DevCheck";
            this.devCheckDataGridViewCheckBoxColumn.FalseValue = "0";
            this.devCheckDataGridViewCheckBoxColumn.HeaderText = "Select";
            this.devCheckDataGridViewCheckBoxColumn.Name = "devCheckDataGridViewCheckBoxColumn";
            this.devCheckDataGridViewCheckBoxColumn.TrueValue = "1";
            this.devCheckDataGridViewCheckBoxColumn.Width = 60;
            // 
            // dEVPIDDataGridViewTextBoxColumn
            // 
            this.dEVPIDDataGridViewTextBoxColumn.DataPropertyName = "DEVPID";
            this.dEVPIDDataGridViewTextBoxColumn.HeaderText = "DEVPID";
            this.dEVPIDDataGridViewTextBoxColumn.Name = "dEVPIDDataGridViewTextBoxColumn";
            this.dEVPIDDataGridViewTextBoxColumn.Width = 95;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "Full_Name";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Full_Name";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.Width = 110;
            // 
            // DevsBindingSource
            // 
            this.DevsBindingSource.DataSource = typeof(DTaS_APPendix.VPOthDev);
            // 
            // frmOtherDevs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 443);
            this.Controls.Add(this.txtBDAppID);
            this.Controls.Add(this.dgvOtherDevs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOtherDevs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "DTaS APPendix - Other Devs";
            this.Text = "DTaS APPendix - Other Devs";
            this.Load += new System.EventHandler(this.frmOtherDevs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherDevs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        protected internal System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvOtherDevs;
        private System.Windows.Forms.BindingSource DevsBindingSource;
        protected internal System.Windows.Forms.TextBox txtBDAppID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn devCheckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEVPIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
    }
}