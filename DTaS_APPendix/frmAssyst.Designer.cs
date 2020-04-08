namespace DTaS_APPendix
{
    partial class frmAssyst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssyst));
            this.lblAssRef = new System.Windows.Forms.Label();
            this.cboAssRef = new System.Windows.Forms.ComboBox();
            this.txtAssRef = new System.Windows.Forms.TextBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.lblBDAppNo = new System.Windows.Forms.Label();
            this.cboBDAppNo = new System.Windows.Forms.ComboBox();
            this.lblBDAppName = new System.Windows.Forms.Label();
            this.txtBDAppName = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtDateOpened = new System.Windows.Forms.TextBox();
            this.lblAssignDev = new System.Windows.Forms.Label();
            this.cboAssignDev = new System.Windows.Forms.ComboBox();
            this.lblSLATarget = new System.Windows.Forms.Label();
            this.txtSLATarget = new System.Windows.Forms.TextBox();
            this.lblEmailSent = new System.Windows.Forms.Label();
            this.lblChased = new System.Windows.Forms.Label();
            this.txtEmailSent = new System.Windows.Forms.TextBox();
            this.txtEmailChased = new System.Windows.Forms.TextBox();
            this.lblDateClosed = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblNAD = new System.Windows.Forms.Label();
            this.lblNA = new System.Windows.Forms.Label();
            this.txtDateResolved = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtNAD = new System.Windows.Forms.TextBox();
            this.txtNA = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboFix = new System.Windows.Forms.ComboBox();
            this.lblAppliedFix = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblKPIs = new System.Windows.Forms.Label();
            this.dgvKPIs = new System.Windows.Forms.DataGridView();
            this.kPIDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kPILinkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KPIbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSaveClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KPIbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAssRef
            // 
            this.lblAssRef.AutoSize = true;
            this.lblAssRef.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssRef.Location = new System.Drawing.Point(10, 15);
            this.lblAssRef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAssRef.Name = "lblAssRef";
            this.lblAssRef.Size = new System.Drawing.Size(155, 28);
            this.lblAssRef.TabIndex = 0;
            this.lblAssRef.Text = "Assyst Reference";
            // 
            // cboAssRef
            // 
            this.cboAssRef.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssRef.FormattingEnabled = true;
            this.cboAssRef.Location = new System.Drawing.Point(300, 15);
            this.cboAssRef.Name = "cboAssRef";
            this.cboAssRef.Size = new System.Drawing.Size(180, 36);
            this.cboAssRef.TabIndex = 1;
            this.cboAssRef.SelectedIndexChanged += new System.EventHandler(this.cboAssRef_SelectedIndexChanged);
            // 
            // txtAssRef
            // 
            this.txtAssRef.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssRef.Location = new System.Drawing.Point(300, 17);
            this.txtAssRef.Name = "txtAssRef";
            this.txtAssRef.Size = new System.Drawing.Size(180, 34);
            this.txtAssRef.TabIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(10, 105);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(95, 28);
            this.lblSummary.TabIndex = 3;
            this.lblSummary.Text = "Summary";
            // 
            // txtSummary
            // 
            this.txtSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSummary.Location = new System.Drawing.Point(130, 105);
            this.txtSummary.MaxLength = 100;
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(350, 100);
            this.txtSummary.TabIndex = 6;
            // 
            // lblBDAppNo
            // 
            this.lblBDAppNo.AutoSize = true;
            this.lblBDAppNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBDAppNo.Location = new System.Drawing.Point(10, 45);
            this.lblBDAppNo.Name = "lblBDAppNo";
            this.lblBDAppNo.Size = new System.Drawing.Size(106, 28);
            this.lblBDAppNo.TabIndex = 5;
            this.lblBDAppNo.Text = "BDApp No";
            // 
            // cboBDAppNo
            // 
            this.cboBDAppNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBDAppNo.FormattingEnabled = true;
            this.cboBDAppNo.Location = new System.Drawing.Point(300, 45);
            this.cboBDAppNo.Name = "cboBDAppNo";
            this.cboBDAppNo.Size = new System.Drawing.Size(180, 36);
            this.cboBDAppNo.TabIndex = 2;
            this.cboBDAppNo.SelectedIndexChanged += new System.EventHandler(this.cboBDAppNo_SelectedIndexChanged);
            // 
            // lblBDAppName
            // 
            this.lblBDAppName.AutoSize = true;
            this.lblBDAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBDAppName.Location = new System.Drawing.Point(500, 45);
            this.lblBDAppName.Name = "lblBDAppName";
            this.lblBDAppName.Size = new System.Drawing.Size(131, 28);
            this.lblBDAppName.TabIndex = 7;
            this.lblBDAppName.Text = "BDApp Name";
            // 
            // txtBDAppName
            // 
            this.txtBDAppName.BackColor = System.Drawing.SystemColors.Window;
            this.txtBDAppName.Enabled = false;
            this.txtBDAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDAppName.Location = new System.Drawing.Point(620, 45);
            this.txtBDAppName.Name = "txtBDAppName";
            this.txtBDAppName.ReadOnly = true;
            this.txtBDAppName.Size = new System.Drawing.Size(180, 34);
            this.txtBDAppName.TabIndex = 3;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(10, 75);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(128, 28);
            this.lblStart.TabIndex = 9;
            this.lblStart.Text = "Date Opened";
            // 
            // txtDateOpened
            // 
            this.txtDateOpened.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateOpened.Location = new System.Drawing.Point(300, 75);
            this.txtDateOpened.Name = "txtDateOpened";
            this.txtDateOpened.Size = new System.Drawing.Size(180, 34);
            this.txtDateOpened.TabIndex = 4;
            this.txtDateOpened.LostFocus += new System.EventHandler(this.txtDateOpened_LostFocus);
            // 
            // lblAssignDev
            // 
            this.lblAssignDev.AutoSize = true;
            this.lblAssignDev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignDev.Location = new System.Drawing.Point(10, 210);
            this.lblAssignDev.Name = "lblAssignDev";
            this.lblAssignDev.Size = new System.Drawing.Size(210, 28);
            this.lblAssignDev.TabIndex = 11;
            this.lblAssignDev.Text = "Assigned to Developer";
            // 
            // cboAssignDev
            // 
            this.cboAssignDev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssignDev.FormattingEnabled = true;
            this.cboAssignDev.Location = new System.Drawing.Point(300, 210);
            this.cboAssignDev.Name = "cboAssignDev";
            this.cboAssignDev.Size = new System.Drawing.Size(180, 36);
            this.cboAssignDev.TabIndex = 8;
            // 
            // lblSLATarget
            // 
            this.lblSLATarget.AutoSize = true;
            this.lblSLATarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLATarget.Location = new System.Drawing.Point(500, 75);
            this.lblSLATarget.Name = "lblSLATarget";
            this.lblSLATarget.Size = new System.Drawing.Size(105, 28);
            this.lblSLATarget.TabIndex = 13;
            this.lblSLATarget.Text = "SLA Target";
            // 
            // txtSLATarget
            // 
            this.txtSLATarget.Enabled = false;
            this.txtSLATarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLATarget.Location = new System.Drawing.Point(620, 75);
            this.txtSLATarget.Name = "txtSLATarget";
            this.txtSLATarget.Size = new System.Drawing.Size(180, 34);
            this.txtSLATarget.TabIndex = 5;
            // 
            // lblEmailSent
            // 
            this.lblEmailSent.AutoSize = true;
            this.lblEmailSent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailSent.Location = new System.Drawing.Point(10, 240);
            this.lblEmailSent.Name = "lblEmailSent";
            this.lblEmailSent.Size = new System.Drawing.Size(271, 28);
            this.lblEmailSent.TabIndex = 15;
            this.lblEmailSent.Text = "Acknowledgement Email Sent";
            // 
            // lblChased
            // 
            this.lblChased.AutoSize = true;
            this.lblChased.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChased.Location = new System.Drawing.Point(500, 240);
            this.lblChased.Name = "lblChased";
            this.lblChased.Size = new System.Drawing.Size(127, 28);
            this.lblChased.TabIndex = 16;
            this.lblChased.Text = "Email Chased";
            // 
            // txtEmailSent
            // 
            this.txtEmailSent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailSent.Location = new System.Drawing.Point(300, 240);
            this.txtEmailSent.Name = "txtEmailSent";
            this.txtEmailSent.Size = new System.Drawing.Size(180, 34);
            this.txtEmailSent.TabIndex = 9;
            // 
            // txtEmailChased
            // 
            this.txtEmailChased.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailChased.Location = new System.Drawing.Point(620, 240);
            this.txtEmailChased.Name = "txtEmailChased";
            this.txtEmailChased.Size = new System.Drawing.Size(180, 34);
            this.txtEmailChased.TabIndex = 10;
            // 
            // lblDateClosed
            // 
            this.lblDateClosed.AutoSize = true;
            this.lblDateClosed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateClosed.Location = new System.Drawing.Point(10, 435);
            this.lblDateClosed.Name = "lblDateClosed";
            this.lblDateClosed.Size = new System.Drawing.Size(136, 28);
            this.lblDateClosed.TabIndex = 19;
            this.lblDateClosed.Text = "Date Resolved";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(10, 270);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(64, 28);
            this.lblNotes.TabIndex = 20;
            this.lblNotes.Text = "Notes";
            // 
            // lblNAD
            // 
            this.lblNAD.AutoSize = true;
            this.lblNAD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAD.Location = new System.Drawing.Point(10, 375);
            this.lblNAD.Name = "lblNAD";
            this.lblNAD.Size = new System.Drawing.Size(155, 28);
            this.lblNAD.TabIndex = 21;
            this.lblNAD.Text = "Next Action Due";
            // 
            // lblNA
            // 
            this.lblNA.AutoSize = true;
            this.lblNA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNA.Location = new System.Drawing.Point(10, 405);
            this.lblNA.Name = "lblNA";
            this.lblNA.Size = new System.Drawing.Size(115, 28);
            this.lblNA.TabIndex = 22;
            this.lblNA.Text = "Next Action";
            // 
            // txtDateResolved
            // 
            this.txtDateResolved.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateResolved.Location = new System.Drawing.Point(300, 435);
            this.txtDateResolved.Name = "txtDateResolved";
            this.txtDateResolved.Size = new System.Drawing.Size(180, 34);
            this.txtDateResolved.TabIndex = 14;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(130, 270);
            this.txtNotes.MaxLength = 100;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(350, 100);
            this.txtNotes.TabIndex = 11;
            // 
            // txtNAD
            // 
            this.txtNAD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNAD.Location = new System.Drawing.Point(300, 375);
            this.txtNAD.Name = "txtNAD";
            this.txtNAD.Size = new System.Drawing.Size(180, 34);
            this.txtNAD.TabIndex = 12;
            // 
            // txtNA
            // 
            this.txtNA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNA.Location = new System.Drawing.Point(130, 405);
            this.txtNA.MaxLength = 100;
            this.txtNA.Name = "txtNA";
            this.txtNA.Size = new System.Drawing.Size(350, 34);
            this.txtNA.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(341, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 51);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(481, 474);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 51);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboFix
            // 
            this.cboFix.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFix.FormattingEnabled = true;
            this.cboFix.Location = new System.Drawing.Point(620, 435);
            this.cboFix.Name = "cboFix";
            this.cboFix.Size = new System.Drawing.Size(180, 36);
            this.cboFix.TabIndex = 15;
            // 
            // lblAppliedFix
            // 
            this.lblAppliedFix.AutoSize = true;
            this.lblAppliedFix.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppliedFix.Location = new System.Drawing.Point(500, 438);
            this.lblAppliedFix.Name = "lblAppliedFix";
            this.lblAppliedFix.Size = new System.Drawing.Size(110, 28);
            this.lblAppliedFix.TabIndex = 29;
            this.lblAppliedFix.Text = "Fix Applied";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(19, 474);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 55);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Word Doc";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblKPIs
            // 
            this.lblKPIs.AutoSize = true;
            this.lblKPIs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKPIs.Location = new System.Drawing.Point(500, 105);
            this.lblKPIs.Name = "lblKPIs";
            this.lblKPIs.Size = new System.Drawing.Size(48, 28);
            this.lblKPIs.TabIndex = 31;
            this.lblKPIs.Text = "KPIs";
            // 
            // dgvKPIs
            // 
            this.dgvKPIs.AllowUserToAddRows = false;
            this.dgvKPIs.AllowUserToDeleteRows = false;
            this.dgvKPIs.AutoGenerateColumns = false;
            this.dgvKPIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKPIs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kPIDescriptionDataGridViewTextBoxColumn,
            this.kPILinkDataGridViewTextBoxColumn});
            this.dgvKPIs.DataSource = this.KPIbindingSource;
            this.dgvKPIs.Location = new System.Drawing.Point(545, 107);
            this.dgvKPIs.MultiSelect = false;
            this.dgvKPIs.Name = "dgvKPIs";
            this.dgvKPIs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKPIs.Size = new System.Drawing.Size(255, 127);
            this.dgvKPIs.TabIndex = 7;
            this.dgvKPIs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKPIs_MouseDoubleClick);
            // 
            // kPIDescriptionDataGridViewTextBoxColumn
            // 
            this.kPIDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kPIDescriptionDataGridViewTextBoxColumn.DataPropertyName = "KPI_Description";
            this.kPIDescriptionDataGridViewTextBoxColumn.HeaderText = "KPI Description";
            this.kPIDescriptionDataGridViewTextBoxColumn.Name = "kPIDescriptionDataGridViewTextBoxColumn";
            // 
            // kPILinkDataGridViewTextBoxColumn
            // 
            this.kPILinkDataGridViewTextBoxColumn.DataPropertyName = "KPI_Link";
            this.kPILinkDataGridViewTextBoxColumn.HeaderText = "KPI_Link";
            this.kPILinkDataGridViewTextBoxColumn.Name = "kPILinkDataGridViewTextBoxColumn";
            this.kPILinkDataGridViewTextBoxColumn.Visible = false;
            // 
            // KPIbindingSource
            // 
            this.KPIbindingSource.DataSource = typeof(DTaS_APPendix.VPKPI);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveClose.Location = new System.Drawing.Point(191, 474);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(100, 51);
            this.btnSaveClose.TabIndex = 32;
            this.btnSaveClose.Text = "Save && Close";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // frmAssyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 541);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.dgvKPIs);
            this.Controls.Add(this.lblKPIs);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblAppliedFix);
            this.Controls.Add(this.cboFix);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNA);
            this.Controls.Add(this.txtNAD);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtDateResolved);
            this.Controls.Add(this.lblNA);
            this.Controls.Add(this.lblNAD);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblDateClosed);
            this.Controls.Add(this.txtEmailChased);
            this.Controls.Add(this.txtEmailSent);
            this.Controls.Add(this.lblChased);
            this.Controls.Add(this.lblEmailSent);
            this.Controls.Add(this.txtSLATarget);
            this.Controls.Add(this.lblSLATarget);
            this.Controls.Add(this.cboAssignDev);
            this.Controls.Add(this.lblAssignDev);
            this.Controls.Add(this.txtDateOpened);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtBDAppName);
            this.Controls.Add(this.lblBDAppName);
            this.Controls.Add(this.cboBDAppNo);
            this.Controls.Add(this.lblBDAppNo);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.txtAssRef);
            this.Controls.Add(this.cboAssRef);
            this.Controls.Add(this.lblAssRef);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAssyst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assyst Cases";
            this.Load += new System.EventHandler(this.frmAssyst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KPIbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAssRef;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblBDAppNo;
        private System.Windows.Forms.Label lblBDAppName;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblAssignDev;
        private System.Windows.Forms.Label lblSLATarget;
        private System.Windows.Forms.Label lblEmailSent;
        private System.Windows.Forms.Label lblChased;
        private System.Windows.Forms.Label lblDateClosed;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblNAD;
        private System.Windows.Forms.Label lblNA;
        private System.Windows.Forms.Button btnCancel;
        protected internal System.Windows.Forms.ComboBox cboAssRef;
        protected internal System.Windows.Forms.TextBox txtAssRef;
        protected internal System.Windows.Forms.TextBox txtSummary;
        protected internal System.Windows.Forms.ComboBox cboBDAppNo;
        protected internal System.Windows.Forms.TextBox txtBDAppName;
        protected internal System.Windows.Forms.TextBox txtDateOpened;
        protected internal System.Windows.Forms.ComboBox cboAssignDev;
        protected internal System.Windows.Forms.TextBox txtSLATarget;
        protected internal System.Windows.Forms.TextBox txtEmailSent;
        protected internal System.Windows.Forms.TextBox txtEmailChased;
        protected internal System.Windows.Forms.TextBox txtDateResolved;
        protected internal System.Windows.Forms.TextBox txtNotes;
        protected internal System.Windows.Forms.TextBox txtNAD;
        protected internal System.Windows.Forms.TextBox txtNA;
        private System.Windows.Forms.ComboBox cboFix;
        private System.Windows.Forms.Label lblAppliedFix;
        protected internal System.Windows.Forms.Button btnSave;
        protected internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblKPIs;
        private System.Windows.Forms.DataGridView dgvKPIs;
        private System.Windows.Forms.BindingSource KPIbindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn kPIDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kPILinkDataGridViewTextBoxColumn;
        protected internal System.Windows.Forms.Button btnSaveClose;
    }
}