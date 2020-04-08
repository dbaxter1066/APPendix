namespace DTaS_APPendix
{
    partial class frmReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReview));
            this.lblBDAppNo = new System.Windows.Forms.Label();
            this.lblReviewDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cboDescription = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtReviewDate = new System.Windows.Forms.TextBox();
            this.txtBDAppNo = new System.Windows.Forms.TextBox();
            this.cboReviewDate = new System.Windows.Forms.ComboBox();
            this.txtReviewID = new System.Windows.Forms.TextBox();
            this.lblUpdateTo = new System.Windows.Forms.Label();
            this.txtActionedDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBDAppID = new System.Windows.Forms.TextBox();
            this.btnSOP = new System.Windows.Forms.Button();
            this.toolTipSOP = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblBDAppNo
            // 
            this.lblBDAppNo.AutoSize = true;
            this.lblBDAppNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBDAppNo.Location = new System.Drawing.Point(10, 15);
            this.lblBDAppNo.Name = "lblBDAppNo";
            this.lblBDAppNo.Size = new System.Drawing.Size(120, 21);
            this.lblBDAppNo.TabIndex = 0;
            this.lblBDAppNo.Text = "BDApp Number";
            // 
            // lblReviewDate
            // 
            this.lblReviewDate.AutoSize = true;
            this.lblReviewDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewDate.Location = new System.Drawing.Point(10, 45);
            this.lblReviewDate.Name = "lblReviewDate";
            this.lblReviewDate.Size = new System.Drawing.Size(96, 21);
            this.lblReviewDate.TabIndex = 1;
            this.lblReviewDate.Text = "Review Date";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(10, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(89, 21);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(10, 105);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(51, 21);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Notes";
            // 
            // cboDescription
            // 
            this.cboDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDescription.FormattingEnabled = true;
            this.cboDescription.Location = new System.Drawing.Point(135, 76);
            this.cboDescription.Name = "cboDescription";
            this.cboDescription.Size = new System.Drawing.Size(297, 29);
            this.cboDescription.TabIndex = 3;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(135, 105);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(339, 134);
            this.txtNotes.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(374, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(135, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReviewDate
            // 
            this.txtReviewDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReviewDate.Location = new System.Drawing.Point(354, 45);
            this.txtReviewDate.Multiline = true;
            this.txtReviewDate.Name = "txtReviewDate";
            this.txtReviewDate.Size = new System.Drawing.Size(120, 31);
            this.txtReviewDate.TabIndex = 2;
            // 
            // txtBDAppNo
            // 
            this.txtBDAppNo.Enabled = false;
            this.txtBDAppNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDAppNo.Location = new System.Drawing.Point(135, 15);
            this.txtBDAppNo.Multiline = true;
            this.txtBDAppNo.Name = "txtBDAppNo";
            this.txtBDAppNo.Size = new System.Drawing.Size(162, 31);
            this.txtBDAppNo.TabIndex = 0;
            // 
            // cboReviewDate
            // 
            this.cboReviewDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReviewDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReviewDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReviewDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReviewDate.FormattingEnabled = true;
            this.cboReviewDate.Location = new System.Drawing.Point(135, 45);
            this.cboReviewDate.Name = "cboReviewDate";
            this.cboReviewDate.Size = new System.Drawing.Size(120, 29);
            this.cboReviewDate.TabIndex = 1;
            this.cboReviewDate.SelectedIndexChanged += new System.EventHandler(this.cboReviewDate_SelectedIndexChanged);
            // 
            // txtReviewID
            // 
            this.txtReviewID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReviewID.Location = new System.Drawing.Point(312, 15);
            this.txtReviewID.Multiline = true;
            this.txtReviewID.Name = "txtReviewID";
            this.txtReviewID.Size = new System.Drawing.Size(162, 31);
            this.txtReviewID.TabIndex = 7;
            this.txtReviewID.TabStop = false;
            this.txtReviewID.Visible = false;
            this.txtReviewID.TextChanged += new System.EventHandler(this.txtReviewID_TextChanged);
            // 
            // lblUpdateTo
            // 
            this.lblUpdateTo.AutoSize = true;
            this.lblUpdateTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateTo.Location = new System.Drawing.Point(272, 49);
            this.lblUpdateTo.Name = "lblUpdateTo";
            this.lblUpdateTo.Size = new System.Drawing.Size(78, 21);
            this.lblUpdateTo.TabIndex = 8;
            this.lblUpdateTo.Text = "Update to";
            // 
            // txtActionedDate
            // 
            this.txtActionedDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActionedDate.Location = new System.Drawing.Point(135, 240);
            this.txtActionedDate.Multiline = true;
            this.txtActionedDate.Name = "txtActionedDate";
            this.txtActionedDate.Size = new System.Drawing.Size(120, 31);
            this.txtActionedDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Actioned Date";
            // 
            // txtBDAppID
            // 
            this.txtBDAppID.Enabled = false;
            this.txtBDAppID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDAppID.Location = new System.Drawing.Point(135, 15);
            this.txtBDAppID.Multiline = true;
            this.txtBDAppID.Name = "txtBDAppID";
            this.txtBDAppID.Size = new System.Drawing.Size(162, 31);
            this.txtBDAppID.TabIndex = 12;
            this.txtBDAppID.TabStop = false;
            this.txtBDAppID.Visible = false;
            // 
            // btnSOP
            // 
            this.btnSOP.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSOP.Location = new System.Drawing.Point(438, 76);
            this.btnSOP.Name = "btnSOP";
            this.btnSOP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSOP.Size = new System.Drawing.Size(36, 29);
            this.btnSOP.TabIndex = 4;
            this.btnSOP.Text = ">>";
            this.toolTipSOP.SetToolTip(this.btnSOP, "Goto SOP Document\r\n");
            this.btnSOP.UseVisualStyleBackColor = true;
            this.btnSOP.Click += new System.EventHandler(this.btnSOP_Click);
            // 
            // toolTipSOP
            // 
            this.toolTipSOP.ToolTipTitle = "SOP";
            // 
            // frmReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 322);
            this.Controls.Add(this.btnSOP);
            this.Controls.Add(this.txtActionedDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUpdateTo);
            this.Controls.Add(this.txtReviewID);
            this.Controls.Add(this.cboReviewDate);
            this.Controls.Add(this.txtBDAppNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReviewDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cboDescription);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblReviewDate);
            this.Controls.Add(this.lblBDAppNo);
            this.Controls.Add(this.txtBDAppID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DTaS APPendix - Review";
            this.Load += new System.EventHandler(this.frmReview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblReviewDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ComboBox cboDescription;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnCancel;
        protected internal System.Windows.Forms.Button btnSave;
        protected internal System.Windows.Forms.TextBox txtBDAppNo;
        protected internal System.Windows.Forms.Label lblBDAppNo;
        protected internal System.Windows.Forms.TextBox txtReviewID;
        protected internal System.Windows.Forms.Label lblUpdateTo;
        protected internal System.Windows.Forms.TextBox txtReviewDate;
        protected internal System.Windows.Forms.ComboBox cboReviewDate;
        protected internal System.Windows.Forms.TextBox txtActionedDate;
        private System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.TextBox txtBDAppID;
        private System.Windows.Forms.Button btnSOP;
        private System.Windows.Forms.ToolTip toolTipSOP;
    }
}