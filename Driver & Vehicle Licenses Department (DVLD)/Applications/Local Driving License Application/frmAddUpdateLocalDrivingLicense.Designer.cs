namespace Driver___Vehicle_Licenses_Department__DVLD_.Local_Driving_License
{
    partial class frmAddUpdateLocalDrivingLicense
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
            this.lMain = new System.Windows.Forms.Label();
            this.tbPersonalInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrPersonCardWithFilter1 = new Driver___Vehicle_Licenses_Department__DVLD_.People.User_Controller.ctrPersonCardWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbApplicationInfo = new System.Windows.Forms.TabPage();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbClassName = new System.Windows.Forms.ComboBox();
            this.lCreatedBy = new System.Windows.Forms.Label();
            this.lAppFees = new System.Windows.Forms.Label();
            this.lAppData = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lAppID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPersonalInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lMain
            // 
            this.lMain.AutoSize = true;
            this.lMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lMain.Location = new System.Drawing.Point(278, -40);
            this.lMain.Name = "lMain";
            this.lMain.Size = new System.Drawing.Size(236, 37);
            this.lMain.TabIndex = 11;
            this.lMain.Text = "Add New User";
            // 
            // tbPersonalInfo
            // 
            this.tbPersonalInfo.Controls.Add(this.tabPage1);
            this.tbPersonalInfo.Controls.Add(this.tbApplicationInfo);
            this.tbPersonalInfo.Location = new System.Drawing.Point(5, 66);
            this.tbPersonalInfo.Name = "tbPersonalInfo";
            this.tbPersonalInfo.SelectedIndex = 0;
            this.tbPersonalInfo.Size = new System.Drawing.Size(728, 474);
            this.tbPersonalInfo.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrPersonCardWithFilter1);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(720, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrPersonCardWithFilter1
            // 
            this.ctrPersonCardWithFilter1.FilteredEnabled = true;
            this.ctrPersonCardWithFilter1.Location = new System.Drawing.Point(6, 6);
            this.ctrPersonCardWithFilter1.Name = "ctrPersonCardWithFilter1";
            this.ctrPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrPersonCardWithFilter1.Size = new System.Drawing.Size(709, 397);
            this.ctrPersonCardWithFilter1.TabIndex = 2;
            this.ctrPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrPersonCardWithFilter1_OnPersonSelected);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(610, 409);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 33);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next    ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbApplicationInfo
            // 
            this.tbApplicationInfo.Controls.Add(this.pictureBox5);
            this.tbApplicationInfo.Controls.Add(this.pictureBox4);
            this.tbApplicationInfo.Controls.Add(this.pictureBox3);
            this.tbApplicationInfo.Controls.Add(this.pictureBox2);
            this.tbApplicationInfo.Controls.Add(this.pictureBox1);
            this.tbApplicationInfo.Controls.Add(this.cbClassName);
            this.tbApplicationInfo.Controls.Add(this.lCreatedBy);
            this.tbApplicationInfo.Controls.Add(this.lAppFees);
            this.tbApplicationInfo.Controls.Add(this.lAppData);
            this.tbApplicationInfo.Controls.Add(this.label7);
            this.tbApplicationInfo.Controls.Add(this.lAppID);
            this.tbApplicationInfo.Controls.Add(this.label6);
            this.tbApplicationInfo.Controls.Add(this.label5);
            this.tbApplicationInfo.Controls.Add(this.label4);
            this.tbApplicationInfo.Controls.Add(this.label3);
            this.tbApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tbApplicationInfo.Name = "tbApplicationInfo";
            this.tbApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbApplicationInfo.Size = new System.Drawing.Size(720, 448);
            this.tbApplicationInfo.TabIndex = 1;
            this.tbApplicationInfo.Text = "Application Info";
            this.tbApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Person_32;
            this.pictureBox5.Location = new System.Drawing.Point(214, 212);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(23, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.money_32;
            this.pictureBox4.Location = new System.Drawing.Point(214, 169);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.License_View_32;
            this.pictureBox3.Location = new System.Drawing.Point(214, 127);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Calendar_321;
            this.pictureBox2.Location = new System.Drawing.Point(214, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.field_numeric;
            this.pictureBox1.Location = new System.Drawing.Point(214, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // cbClassName
            // 
            this.cbClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClassName.FormattingEnabled = true;
            this.cbClassName.Location = new System.Drawing.Point(268, 129);
            this.cbClassName.Name = "cbClassName";
            this.cbClassName.Size = new System.Drawing.Size(221, 21);
            this.cbClassName.TabIndex = 17;
            // 
            // lCreatedBy
            // 
            this.lCreatedBy.AutoSize = true;
            this.lCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCreatedBy.Location = new System.Drawing.Point(265, 216);
            this.lCreatedBy.Name = "lCreatedBy";
            this.lCreatedBy.Size = new System.Drawing.Size(31, 15);
            this.lCreatedBy.TabIndex = 16;
            this.lCreatedBy.Text = "???";
            // 
            // lAppFees
            // 
            this.lAppFees.AutoSize = true;
            this.lAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAppFees.Location = new System.Drawing.Point(265, 171);
            this.lAppFees.Name = "lAppFees";
            this.lAppFees.Size = new System.Drawing.Size(31, 15);
            this.lAppFees.TabIndex = 15;
            this.lAppFees.Text = "???";
            // 
            // lAppData
            // 
            this.lAppData.AutoSize = true;
            this.lAppData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAppData.Location = new System.Drawing.Point(265, 87);
            this.lAppData.Name = "lAppData";
            this.lAppData.Size = new System.Drawing.Size(31, 15);
            this.lAppData.TabIndex = 14;
            this.lAppData.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(74, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Created By ";
            // 
            // lAppID
            // 
            this.lAppID.AutoSize = true;
            this.lAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAppID.Location = new System.Drawing.Point(265, 45);
            this.lAppID.Name = "lAppID";
            this.lAppID.Size = new System.Drawing.Size(31, 15);
            this.lAppID.TabIndex = 4;
            this.lAppID.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Application Fees";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "License Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Application Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "ApplicationID";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lTitle.Location = new System.Drawing.Point(62, 9);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(597, 37);
            this.lTitle.TabIndex = 14;
            this.lTitle.Text = "New Local Driving License Application";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(538, 546);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 40);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(632, 546);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "     Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddUpdateLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 599);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lMain);
            this.Controls.Add(this.tbPersonalInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License";
            this.Load += new System.EventHandler(this.frmNewLocalDrivingLicense_Load);
            this.tbPersonalInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tbApplicationInfo.ResumeLayout(false);
            this.tbApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lMain;
        private System.Windows.Forms.TabControl tbPersonalInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tbApplicationInfo;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.ComboBox cbClassName;
        private System.Windows.Forms.Label lCreatedBy;
        private System.Windows.Forms.Label lAppFees;
        private System.Windows.Forms.Label lAppData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lAppID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private People.User_Controller.ctrPersonCardWithFilter ctrPersonCardWithFilter1;
    }
}