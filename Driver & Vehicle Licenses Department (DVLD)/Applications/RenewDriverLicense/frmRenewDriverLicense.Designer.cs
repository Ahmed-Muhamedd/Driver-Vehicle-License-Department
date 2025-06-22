namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.RenewDriverLicense
{
    partial class frmRenewDriverLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.llShowLicense = new System.Windows.Forms.LinkLabel();
            this.llHistory = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lTotalFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.Notes = new System.Windows.Forms.Label();
            this.lApplicationFees = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lFees = new System.Windows.Forms.Label();
            this.lIssueDate = new System.Windows.Forms.Label();
            this.lAppDate = new System.Windows.Forms.Label();
            this.liAppID = new System.Windows.Forms.Label();
            this.lCreatedBy = new System.Windows.Forms.Label();
            this.lExpirationDate = new System.Windows.Forms.Label();
            this.lOldLicenseID = new System.Windows.Forms.Label();
            this.lRenewLicenseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrdriverLicenseInfoWithFilter1 = new Driver___Vehicle_Licenses_Department__DVLD_.Licenses.Local_Licenses.Controls.ctrDriverLicenseInfoWithFilter();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(225, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Renew License Application";
            // 
            // llShowLicense
            // 
            this.llShowLicense.AutoSize = true;
            this.llShowLicense.Enabled = false;
            this.llShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicense.Location = new System.Drawing.Point(182, 630);
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
            this.llHistory.Location = new System.Drawing.Point(34, 630);
            this.llHistory.Name = "llHistory";
            this.llHistory.Size = new System.Drawing.Size(130, 15);
            this.llHistory.TabIndex = 18;
            this.llHistory.TabStop = true;
            this.llHistory.Text = "Show Licenses History";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(591, 625);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 31);
            this.button2.TabIndex = 17;
            this.button2.Text = "       Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRenew.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.IssueDrivingLicense_32;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.Location = new System.Drawing.Point(711, 626);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(102, 31);
            this.btnRenew.TabIndex = 16;
            this.btnRenew.Text = "        Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lTotalFees);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbNotes);
            this.groupBox2.Controls.Add(this.Notes);
            this.groupBox2.Controls.Add(this.lApplicationFees);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lFees);
            this.groupBox2.Controls.Add(this.lIssueDate);
            this.groupBox2.Controls.Add(this.lAppDate);
            this.groupBox2.Controls.Add(this.liAppID);
            this.groupBox2.Controls.Add(this.lCreatedBy);
            this.groupBox2.Controls.Add(this.lExpirationDate);
            this.groupBox2.Controls.Add(this.lOldLicenseID);
            this.groupBox2.Controls.Add(this.lRenewLicenseID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(824, 216);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info";
            // 
            // lTotalFees
            // 
            this.lTotalFees.AutoSize = true;
            this.lTotalFees.Location = new System.Drawing.Point(516, 151);
            this.lTotalFees.Name = "lTotalFees";
            this.lTotalFees.Size = new System.Drawing.Size(31, 15);
            this.lTotalFees.TabIndex = 21;
            this.lTotalFees.Text = "???";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(402, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "Total Fees:";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(176, 176);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(264, 35);
            this.tbNotes.TabIndex = 19;
            // 
            // Notes
            // 
            this.Notes.AutoSize = true;
            this.Notes.Location = new System.Drawing.Point(93, 181);
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(48, 15);
            this.Notes.TabIndex = 18;
            this.Notes.Text = "Notes:";
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
            // lFees
            // 
            this.lFees.AutoSize = true;
            this.lFees.Location = new System.Drawing.Point(173, 151);
            this.lFees.Name = "lFees";
            this.lFees.Size = new System.Drawing.Size(31, 15);
            this.lFees.TabIndex = 15;
            this.lFees.Text = "???";
            // 
            // lIssueDate
            // 
            this.lIssueDate.AutoSize = true;
            this.lIssueDate.Location = new System.Drawing.Point(173, 121);
            this.lIssueDate.Name = "lIssueDate";
            this.lIssueDate.Size = new System.Drawing.Size(31, 15);
            this.lIssueDate.TabIndex = 14;
            this.lIssueDate.Text = "???";
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
            // liAppID
            // 
            this.liAppID.AutoSize = true;
            this.liAppID.Location = new System.Drawing.Point(173, 31);
            this.liAppID.Name = "liAppID";
            this.liAppID.Size = new System.Drawing.Size(31, 15);
            this.liAppID.TabIndex = 12;
            this.liAppID.Text = "???";
            // 
            // lCreatedBy
            // 
            this.lCreatedBy.AutoSize = true;
            this.lCreatedBy.Location = new System.Drawing.Point(516, 121);
            this.lCreatedBy.Name = "lCreatedBy";
            this.lCreatedBy.Size = new System.Drawing.Size(31, 15);
            this.lCreatedBy.TabIndex = 11;
            this.lCreatedBy.Text = "???";
            // 
            // lExpirationDate
            // 
            this.lExpirationDate.AutoSize = true;
            this.lExpirationDate.Location = new System.Drawing.Point(516, 91);
            this.lExpirationDate.Name = "lExpirationDate";
            this.lExpirationDate.Size = new System.Drawing.Size(31, 15);
            this.lExpirationDate.TabIndex = 10;
            this.lExpirationDate.Text = "???";
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
            // lRenewLicenseID
            // 
            this.lRenewLicenseID.AutoSize = true;
            this.lRenewLicenseID.Location = new System.Drawing.Point(516, 31);
            this.lRenewLicenseID.Name = "lRenewLicenseID";
            this.lRenewLicenseID.Size = new System.Drawing.Size(31, 15);
            this.lRenewLicenseID.TabIndex = 8;
            this.lRenewLicenseID.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Created By:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(370, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Expiration Date:";
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
            this.label10.Size = new System.Drawing.Size(123, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Renew LicenseID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "License Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Issue Date:";
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
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "I.l.Application ID:";
            // 
            // ctrdriverLicenseInfoWithFilter1
            // 
            this.ctrdriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrdriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(0, 55);
            this.ctrdriverLicenseInfoWithFilter1.Name = "ctrdriverLicenseInfoWithFilter1";
            this.ctrdriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(824, 324);
            this.ctrdriverLicenseInfoWithFilter1.TabIndex = 20;
            this.ctrdriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrdriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // frmRenewDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 680);
            this.Controls.Add(this.ctrdriverLicenseInfoWithFilter1);
            this.Controls.Add(this.llShowLicense);
            this.Controls.Add(this.llHistory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRenewDriverLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Local Driving License";
            this.Load += new System.EventHandler(this.frmRenewDriverLicense_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llShowLicense;
        private System.Windows.Forms.LinkLabel llHistory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Notes;
        private System.Windows.Forms.Label lApplicationFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lFees;
        private System.Windows.Forms.Label lIssueDate;
        private System.Windows.Forms.Label lAppDate;
        private System.Windows.Forms.Label liAppID;
        private System.Windows.Forms.Label lCreatedBy;
        private System.Windows.Forms.Label lExpirationDate;
        private System.Windows.Forms.Label lOldLicenseID;
        private System.Windows.Forms.Label lRenewLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label lTotalFees;
        private System.Windows.Forms.Label label13;
        private Driver___Vehicle_Licenses_Department__DVLD_.Licenses.Local_Licenses.Controls.ctrDriverLicenseInfoWithFilter ctrdriverLicenseInfoWithFilter1;
    }
}