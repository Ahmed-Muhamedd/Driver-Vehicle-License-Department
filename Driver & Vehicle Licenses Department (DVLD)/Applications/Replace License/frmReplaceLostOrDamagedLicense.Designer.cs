namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Replace_License
{
    partial class frmReplaceLostOrDamagedLicense
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
            this.ltitle = new System.Windows.Forms.Label();
            this.llShowLicense = new System.Windows.Forms.LinkLabel();
            this.llHistory = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lApplicationFees = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lAppDate = new System.Windows.Forms.Label();
            this.lRAppID = new System.Windows.Forms.Label();
            this.lCreatedBy = new System.Windows.Forms.Label();
            this.lOldLicenseID = new System.Windows.Forms.Label();
            this.lReplaceLicenseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpChoose = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamageLicense = new System.Windows.Forms.RadioButton();
            this.ctrDriverLicenseInfoWithFilter1 = new Driver___Vehicle_Licenses_Department__DVLD_.Licenses.Local_Licenses.Controls.ctrDriverLicenseInfoWithFilter();
            this.groupBox2.SuspendLayout();
            this.gpChoose.SuspendLayout();
            this.SuspendLayout();
            // 
            // ltitle
            // 
            this.ltitle.AutoSize = true;
            this.ltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ltitle.Location = new System.Drawing.Point(134, 19);
            this.ltitle.Name = "ltitle";
            this.ltitle.Size = new System.Drawing.Size(513, 33);
            this.ltitle.TabIndex = 0;
            this.ltitle.Text = "Replacement For Damaged License";
            // 
            // llShowLicense
            // 
            this.llShowLicense.AutoSize = true;
            this.llShowLicense.Enabled = false;
            this.llShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicense.Location = new System.Drawing.Point(181, 576);
            this.llShowLicense.Name = "llShowLicense";
            this.llShowLicense.Size = new System.Drawing.Size(107, 15);
            this.llShowLicense.TabIndex = 19;
            this.llShowLicense.TabStop = true;
            this.llShowLicense.Text = "Show License Info";
            this.llShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicense_LinkClicked);
            // 
            // llHistory
            // 
            this.llHistory.AutoSize = true;
            this.llHistory.Enabled = false;
            this.llHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llHistory.Location = new System.Drawing.Point(20, 576);
            this.llHistory.Name = "llHistory";
            this.llHistory.Size = new System.Drawing.Size(130, 15);
            this.llHistory.TabIndex = 18;
            this.llHistory.TabStop = true;
            this.llHistory.Text = "Show Licenses History";
            this.llHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llHistory_LinkClicked);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(531, 571);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 31);
            this.button2.TabIndex = 17;
            this.button2.Text = "       Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnIssue
            // 
            this.btnIssue.Enabled = false;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIssue.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.IssueDrivingLicense_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(654, 571);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(164, 31);
            this.btnIssue.TabIndex = 16;
            this.btnIssue.Text = "        Issue Replacement";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lApplicationFees);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lAppDate);
            this.groupBox2.Controls.Add(this.lRAppID);
            this.groupBox2.Controls.Add(this.lCreatedBy);
            this.groupBox2.Controls.Add(this.lOldLicenseID);
            this.groupBox2.Controls.Add(this.lReplaceLicenseID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 415);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(822, 140);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info";
            // 
            // lApplicationFees
            // 
            this.lApplicationFees.AutoSize = true;
            this.lApplicationFees.Location = new System.Drawing.Point(173, 91);
            this.lApplicationFees.Name = "lApplicationFees";
            this.lApplicationFees.Size = new System.Drawing.Size(31, 15);
            this.lApplicationFees.TabIndex = 17;
            this.lApplicationFees.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "Application Fees";
            // 
            // lAppDate
            // 
            this.lAppDate.AutoSize = true;
            this.lAppDate.Location = new System.Drawing.Point(173, 63);
            this.lAppDate.Name = "lAppDate";
            this.lAppDate.Size = new System.Drawing.Size(31, 15);
            this.lAppDate.TabIndex = 13;
            this.lAppDate.Text = "???";
            // 
            // lRAppID
            // 
            this.lRAppID.AutoSize = true;
            this.lRAppID.Location = new System.Drawing.Point(173, 31);
            this.lRAppID.Name = "lRAppID";
            this.lRAppID.Size = new System.Drawing.Size(31, 15);
            this.lRAppID.TabIndex = 12;
            this.lRAppID.Text = "???";
            // 
            // lCreatedBy
            // 
            this.lCreatedBy.AutoSize = true;
            this.lCreatedBy.Location = new System.Drawing.Point(516, 91);
            this.lCreatedBy.Name = "lCreatedBy";
            this.lCreatedBy.Size = new System.Drawing.Size(31, 15);
            this.lCreatedBy.TabIndex = 11;
            this.lCreatedBy.Text = "???";
            // 
            // lOldLicenseID
            // 
            this.lOldLicenseID.AutoSize = true;
            this.lOldLicenseID.Location = new System.Drawing.Point(516, 61);
            this.lOldLicenseID.Name = "lOldLicenseID";
            this.lOldLicenseID.Size = new System.Drawing.Size(31, 15);
            this.lOldLicenseID.TabIndex = 9;
            this.lOldLicenseID.Text = "???";
            // 
            // lReplaceLicenseID
            // 
            this.lReplaceLicenseID.AutoSize = true;
            this.lReplaceLicenseID.Location = new System.Drawing.Point(516, 31);
            this.lReplaceLicenseID.Name = "lReplaceLicenseID";
            this.lReplaceLicenseID.Size = new System.Drawing.Size(31, 15);
            this.lReplaceLicenseID.TabIndex = 8;
            this.lReplaceLicenseID.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Created By:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Old LicenseID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(357, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Replace LicenseID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Application Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "I.R.Application ID:";
            // 
            // gpChoose
            // 
            this.gpChoose.Controls.Add(this.rbLostLicense);
            this.gpChoose.Controls.Add(this.rbDamageLicense);
            this.gpChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpChoose.Location = new System.Drawing.Point(628, 85);
            this.gpChoose.Name = "gpChoose";
            this.gpChoose.Size = new System.Drawing.Size(169, 71);
            this.gpChoose.TabIndex = 21;
            this.gpChoose.TabStop = false;
            this.gpChoose.Text = "Replacement For:";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(16, 41);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(100, 20);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbDamageLicense
            // 
            this.rbDamageLicense.AutoSize = true;
            this.rbDamageLicense.Location = new System.Drawing.Point(16, 18);
            this.rbDamageLicense.Name = "rbDamageLicense";
            this.rbDamageLicense.Size = new System.Drawing.Size(136, 20);
            this.rbDamageLicense.TabIndex = 0;
            this.rbDamageLicense.TabStop = true;
            this.rbDamageLicense.Text = "Damaged License";
            this.rbDamageLicense.UseVisualStyleBackColor = true;
            this.rbDamageLicense.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ctrDriverLicenseInfoWithFilter1
            // 
            this.ctrDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(5, 85);
            this.ctrDriverLicenseInfoWithFilter1.Name = "ctrDriverLicenseInfoWithFilter1";
            this.ctrDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(822, 324);
            this.ctrDriverLicenseInfoWithFilter1.TabIndex = 22;
            this.ctrDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // frmReplaceLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 612);
            this.Controls.Add(this.gpChoose);
            this.Controls.Add(this.ctrDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.llShowLicense);
            this.Controls.Add(this.llHistory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ltitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReplaceLostOrDamagedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace Lost Or Damaged License";
            this.Load += new System.EventHandler(this.frmReplaceLostOrDamagedLicense_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpChoose.ResumeLayout(false);
            this.gpChoose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ltitle;
        private System.Windows.Forms.LinkLabel llShowLicense;
        private System.Windows.Forms.LinkLabel llHistory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lApplicationFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lAppDate;
        private System.Windows.Forms.Label lRAppID;
        private System.Windows.Forms.Label lCreatedBy;
        private System.Windows.Forms.Label lOldLicenseID;
        private System.Windows.Forms.Label lReplaceLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpChoose;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamageLicense;
        private Driver___Vehicle_Licenses_Department__DVLD_.Licenses.Local_Licenses.Controls.ctrDriverLicenseInfoWithFilter ctrDriverLicenseInfoWithFilter1;
    }
}