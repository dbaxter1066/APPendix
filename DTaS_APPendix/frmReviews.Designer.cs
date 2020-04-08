namespace DTaS_APPendix
{
    partial class frmReviews
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBDAppNo = new System.Windows.Forms.TextBox();
            this.lblBDAppNo = new System.Windows.Forms.Label();
            this.grpReviews = new System.Windows.Forms.GroupBox();
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.txtBDAppID = new System.Windows.Forms.TextBox();
            this.reviewIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDAppIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDAppNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rRagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rNotesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rActionedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEviewsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEviewsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(723, 71);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(723, 133);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(723, 194);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(357, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBDAppNo
            // 
            this.txtBDAppNo.Enabled = false;
            this.txtBDAppNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDAppNo.Location = new System.Drawing.Point(141, 15);
            this.txtBDAppNo.Multiline = true;
            this.txtBDAppNo.Name = "txtBDAppNo";
            this.txtBDAppNo.Size = new System.Drawing.Size(162, 31);
            this.txtBDAppNo.TabIndex = 25;
            this.txtBDAppNo.TabStop = false;
            // 
            // lblBDAppNo
            // 
            this.lblBDAppNo.AutoSize = true;
            this.lblBDAppNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBDAppNo.Location = new System.Drawing.Point(15, 15);
            this.lblBDAppNo.Name = "lblBDAppNo";
            this.lblBDAppNo.Size = new System.Drawing.Size(120, 21);
            this.lblBDAppNo.TabIndex = 24;
            this.lblBDAppNo.Text = "BDApp Number";
            // 
            // grpReviews
            // 
            this.grpReviews.Controls.Add(this.dgvReviews);
            this.grpReviews.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReviews.Location = new System.Drawing.Point(9, 46);
            this.grpReviews.Name = "grpReviews";
            this.grpReviews.Size = new System.Drawing.Size(707, 191);
            this.grpReviews.TabIndex = 0;
            this.grpReviews.TabStop = false;
            // 
            // dgvReviews
            // 
            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            this.dgvReviews.AutoGenerateColumns = false;
            this.dgvReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReviews.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reviewIDDataGridViewTextBoxColumn,
            this.bDAppIDDataGridViewTextBoxColumn,
            this.bDAppNumberDataGridViewTextBoxColumn,
            this.rDateDataGridViewTextBoxColumn,
            this.rRagDataGridViewTextBoxColumn,
            this.rDescriptionDataGridViewTextBoxColumn,
            this.rNotesDataGridViewTextBoxColumn,
            this.rActionedDataGridViewTextBoxColumn});
            this.dgvReviews.DataSource = this.rEviewsBindingSource;
            this.dgvReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReviews.Location = new System.Drawing.Point(3, 25);
            this.dgvReviews.MultiSelect = false;
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.ReadOnly = true;
            this.dgvReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReviews.Size = new System.Drawing.Size(701, 163);
            this.dgvReviews.TabIndex = 0;
            this.dgvReviews.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvReviews_DataBindingComplete);
            this.dgvReviews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvReviews_MouseDoubleClick);
            // 
            // txtBDAppID
            // 
            this.txtBDAppID.Enabled = false;
            this.txtBDAppID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDAppID.Location = new System.Drawing.Point(318, 15);
            this.txtBDAppID.Multiline = true;
            this.txtBDAppID.Name = "txtBDAppID";
            this.txtBDAppID.Size = new System.Drawing.Size(162, 31);
            this.txtBDAppID.TabIndex = 26;
            this.txtBDAppID.TabStop = false;
            this.txtBDAppID.Visible = false;
            this.txtBDAppID.TextChanged += new System.EventHandler(this.txtBDAppID_TextChanged);
            // 
            // reviewIDDataGridViewTextBoxColumn
            // 
            this.reviewIDDataGridViewTextBoxColumn.DataPropertyName = "Review_ID";
            this.reviewIDDataGridViewTextBoxColumn.HeaderText = "Review_ID";
            this.reviewIDDataGridViewTextBoxColumn.Name = "reviewIDDataGridViewTextBoxColumn";
            this.reviewIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bDAppIDDataGridViewTextBoxColumn
            // 
            this.bDAppIDDataGridViewTextBoxColumn.DataPropertyName = "BDApp_ID";
            this.bDAppIDDataGridViewTextBoxColumn.HeaderText = "BDApp_ID";
            this.bDAppIDDataGridViewTextBoxColumn.Name = "bDAppIDDataGridViewTextBoxColumn";
            this.bDAppIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bDAppNumberDataGridViewTextBoxColumn
            // 
            this.bDAppNumberDataGridViewTextBoxColumn.DataPropertyName = "BDApp_Number";
            this.bDAppNumberDataGridViewTextBoxColumn.HeaderText = "BDApp_Number";
            this.bDAppNumberDataGridViewTextBoxColumn.Name = "bDAppNumberDataGridViewTextBoxColumn";
            this.bDAppNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rDateDataGridViewTextBoxColumn
            // 
            this.rDateDataGridViewTextBoxColumn.DataPropertyName = "RDate";
            this.rDateDataGridViewTextBoxColumn.HeaderText = "Review Date";
            this.rDateDataGridViewTextBoxColumn.Name = "rDateDataGridViewTextBoxColumn";
            this.rDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rRagDataGridViewTextBoxColumn
            // 
            this.rRagDataGridViewTextBoxColumn.DataPropertyName = "RRag";
            this.rRagDataGridViewTextBoxColumn.HeaderText = "RAG";
            this.rRagDataGridViewTextBoxColumn.Name = "rRagDataGridViewTextBoxColumn";
            this.rRagDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rDescriptionDataGridViewTextBoxColumn
            // 
            this.rDescriptionDataGridViewTextBoxColumn.DataPropertyName = "RDescription";
            this.rDescriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.rDescriptionDataGridViewTextBoxColumn.Name = "rDescriptionDataGridViewTextBoxColumn";
            this.rDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rNotesDataGridViewTextBoxColumn
            // 
            this.rNotesDataGridViewTextBoxColumn.DataPropertyName = "RNotes";
            this.rNotesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.rNotesDataGridViewTextBoxColumn.Name = "rNotesDataGridViewTextBoxColumn";
            this.rNotesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rActionedDataGridViewTextBoxColumn
            // 
            this.rActionedDataGridViewTextBoxColumn.DataPropertyName = "RActioned";
            this.rActionedDataGridViewTextBoxColumn.HeaderText = "Actioned";
            this.rActionedDataGridViewTextBoxColumn.Name = "rActionedDataGridViewTextBoxColumn";
            this.rActionedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rEviewsBindingSource
            // 
            this.rEviewsBindingSource.DataSource = typeof(DTaS_APPendix.VPRew);
            // 
            // frmReviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 285);
            this.Controls.Add(this.txtBDAppID);
            this.Controls.Add(this.grpReviews);
            this.Controls.Add(this.txtBDAppNo);
            this.Controls.Add(this.lblBDAppNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.Name = "frmReviews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DTaS APPendix - Reviews";
            this.Load += new System.EventHandler(this.frmReviews_Load);
            this.grpReviews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEviewsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource rEviewsBindingSource;
        protected internal System.Windows.Forms.Button btnAdd;
        protected internal System.Windows.Forms.Button btnUpdate;
        protected internal System.Windows.Forms.Button btnDelete;
        protected internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblBDAppNo;
        protected internal System.Windows.Forms.TextBox txtBDAppNo;
        private System.Windows.Forms.GroupBox grpReviews;
        protected internal System.Windows.Forms.TextBox txtBDAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDAppIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDAppNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rRagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rNotesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rActionedDataGridViewTextBoxColumn;
        protected internal System.Windows.Forms.DataGridView dgvReviews;
    }
}