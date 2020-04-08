namespace DTaS_APPendix
{
    partial class frmAbout
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
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.lblResolver = new System.Windows.Forms.Label();
            this.lblBDAppName = new System.Windows.Forms.Label();
            this.lblBDAppNumber = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.picDTaS = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDTaS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.BackColor = System.Drawing.Color.DarkGray;
            this.lblApplicationName.Font = new System.Drawing.Font("Century Gothic", 24F);
            this.lblApplicationName.ForeColor = System.Drawing.Color.White;
            this.lblApplicationName.Location = new System.Drawing.Point(156, 27);
            this.lblApplicationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(512, 98);
            this.lblApplicationName.TabIndex = 1;
            this.lblApplicationName.Text = "DTAS APPendix";
            this.lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(311, 126);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(212, 25);
            this.labelVersion.TabIndex = 11;
            this.labelVersion.Text = "Version 0.0.0.0";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResolver
            // 
            this.lblResolver.AutoSize = true;
            this.lblResolver.BackColor = System.Drawing.Color.Transparent;
            this.lblResolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolver.ForeColor = System.Drawing.Color.White;
            this.lblResolver.Location = new System.Drawing.Point(16, 260);
            this.lblResolver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResolver.Name = "lblResolver";
            this.lblResolver.Size = new System.Drawing.Size(107, 25);
            this.lblResolver.TabIndex = 15;
            this.lblResolver.Text = "lblResolver";
            this.lblResolver.Visible = false;
            this.lblResolver.MouseEnter += new System.EventHandler(this.frmAbout_MouseEnter);
            this.lblResolver.MouseLeave += new System.EventHandler(this.frmAbout_MouseLeave);
            // 
            // lblBDAppName
            // 
            this.lblBDAppName.AutoSize = true;
            this.lblBDAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblBDAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBDAppName.ForeColor = System.Drawing.Color.White;
            this.lblBDAppName.Location = new System.Drawing.Point(16, 235);
            this.lblBDAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBDAppName.Name = "lblBDAppName";
            this.lblBDAppName.Size = new System.Drawing.Size(146, 25);
            this.lblBDAppName.TabIndex = 14;
            this.lblBDAppName.Text = "lblBDAppName";
            this.lblBDAppName.Visible = false;
            // 
            // lblBDAppNumber
            // 
            this.lblBDAppNumber.AutoSize = true;
            this.lblBDAppNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblBDAppNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBDAppNumber.ForeColor = System.Drawing.Color.White;
            this.lblBDAppNumber.Location = new System.Drawing.Point(16, 210);
            this.lblBDAppNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBDAppNumber.Name = "lblBDAppNumber";
            this.lblBDAppNumber.Size = new System.Drawing.Size(163, 25);
            this.lblBDAppNumber.TabIndex = 13;
            this.lblBDAppNumber.Text = "lblBDAppNumber";
            this.lblBDAppNumber.Visible = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Location = new System.Drawing.Point(16, 186);
            this.lblHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(71, 25);
            this.lblHelp.TabIndex = 12;
            this.lblHelp.Text = "lblHelp";
            this.lblHelp.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(16, 284);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(635, 25);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status ...";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(845, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 31);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picDTaS
            // 
            this.picDTaS.Enabled = false;
            this.picDTaS.Image = global::DTaS_APPendix.Properties.Resources.DTaS_2;
            this.picDTaS.Location = new System.Drawing.Point(21, 36);
            this.picDTaS.Margin = new System.Windows.Forms.Padding(4);
            this.picDTaS.Name = "picDTaS";
            this.picDTaS.Size = new System.Drawing.Size(127, 78);
            this.picDTaS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDTaS.TabIndex = 10;
            this.picDTaS.TabStop = false;
            this.picDTaS.Click += new System.EventHandler(this.picDTaS_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(773, 320);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblResolver);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblBDAppName);
            this.Controls.Add(this.lblBDAppNumber);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.picDTaS);
            this.Controls.Add(this.lblApplicationName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAbout";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mcgoan";
            this.Activated += new System.EventHandler(this.frmAbout_Activated);
            this.Deactivate += new System.EventHandler(this.frmAbout_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAbout_FormClosed);
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.Click += new System.EventHandler(this.frmAbout_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picDTaS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        public System.Windows.Forms.PictureBox picDTaS;
        private System.Windows.Forms.Label labelVersion;
        protected internal System.Windows.Forms.Label lblResolver;
        protected internal System.Windows.Forms.Label lblBDAppName;
        protected internal System.Windows.Forms.Label lblBDAppNumber;
        protected internal System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Timer UpdateTimer;
        public System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
    }
}