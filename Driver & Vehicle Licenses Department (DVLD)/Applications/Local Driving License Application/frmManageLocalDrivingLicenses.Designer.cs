namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Local_Driving_License
{
    partial class frmManageLocalDrivingLicenses
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
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.lCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNewDriving = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowPersonLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(286, 200);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(150, 20);
            this.tbFilter.TabIndex = 19;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "LocalAppId",
            "National Number",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(88, 199);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(166, 21);
            this.cbFilter.TabIndex = 18;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(85, 479);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(35, 13);
            this.lCount.TabIndex = 17;
            this.lCount.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "# Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter By";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 227);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1018, 237);
            this.dataGridView1.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.cmsEdit,
            this.cmsDelete,
            this.cmsCancel,
            this.cmsScheduleTests,
            this.cmsNewDriving,
            this.cmsShowLicense,
            this.cmsShowPersonLicense,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(262, 224);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // cmsEdit
            // 
            this.cmsEdit.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.edit_32;
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new System.Drawing.Size(261, 22);
            this.cmsEdit.Text = "Edit Application";
            this.cmsEdit.Click += new System.EventHandler(this.cmsEdit_Click);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Delete_32;
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(261, 22);
            this.cmsDelete.Text = "Delete Application";
            this.cmsDelete.Click += new System.EventHandler(this.cmsDelete_Click);
            // 
            // cmsCancel
            // 
            this.cmsCancel.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.close;
            this.cmsCancel.Name = "cmsCancel";
            this.cmsCancel.Size = new System.Drawing.Size(243, 22);
            this.cmsCancel.Text = "Cancel Application";
            this.cmsCancel.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // cmsScheduleTests
            // 
            this.cmsScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsVisionTest,
            this.cmsWrittenTest,
            this.cmsStreetTest});
            this.cmsScheduleTests.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.test;
            this.cmsScheduleTests.Name = "cmsScheduleTests";
            this.cmsScheduleTests.Size = new System.Drawing.Size(243, 22);
            this.cmsScheduleTests.Text = "Sechdule Tests";
            this.cmsScheduleTests.Click += new System.EventHandler(this.seToolStripMenuItem_Click);
            // 
            // cmsVisionTest
            // 
            this.cmsVisionTest.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Vision_Test_Schdule;
            this.cmsVisionTest.Name = "cmsVisionTest";
            this.cmsVisionTest.Size = new System.Drawing.Size(187, 22);
            this.cmsVisionTest.Text = "Schedule Vision Test";
            this.cmsVisionTest.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // cmsWrittenTest
            // 
            this.cmsWrittenTest.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Written_Test_32;
            this.cmsWrittenTest.Name = "cmsWrittenTest";
            this.cmsWrittenTest.Size = new System.Drawing.Size(187, 22);
            this.cmsWrittenTest.Text = "Schedule Written Test";
            this.cmsWrittenTest.Click += new System.EventHandler(this.cmsWrittenTest_Click);
            // 
            // cmsStreetTest
            // 
            this.cmsStreetTest.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Street_Test_32;
            this.cmsStreetTest.Name = "cmsStreetTest";
            this.cmsStreetTest.Size = new System.Drawing.Size(187, 22);
            this.cmsStreetTest.Text = "Schedule Street Test";
            this.cmsStreetTest.Click += new System.EventHandler(this.cmsStreetTest_Click);
            // 
            // cmsNewDriving
            // 
            this.cmsNewDriving.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.LocalDriving_License;
            this.cmsNewDriving.Name = "cmsNewDriving";
            this.cmsNewDriving.Size = new System.Drawing.Size(243, 22);
            this.cmsNewDriving.Text = "New Driving License (First Time)";
            this.cmsNewDriving.Click += new System.EventHandler(this.cmsNewDriving_Click);
            // 
            // cmsShowLicense
            // 
            this.cmsShowLicense.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.License_View_32;
            this.cmsShowLicense.Name = "cmsShowLicense";
            this.cmsShowLicense.Size = new System.Drawing.Size(261, 22);
            this.cmsShowLicense.Text = "Show License";
            this.cmsShowLicense.Click += new System.EventHandler(this.cmsShowLicense_Click);
            // 
            // cmsShowPersonLicense
            // 
            this.cmsShowPersonLicense.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.List_32;
            this.cmsShowPersonLicense.Name = "cmsShowPersonLicense";
            this.cmsShowPersonLicense.Size = new System.Drawing.Size(261, 22);
            this.cmsShowPersonLicense.Text = "Show Person License History";
            this.cmsShowPersonLicense.Click += new System.EventHandler(this.cmsShowPersonLicense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(321, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "Local Driving License Applications ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(614, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.New_Application_64;
            this.button1.Location = new System.Drawing.Point(951, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 71);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Driver___Vehicle_Licenses_Department__DVLD_.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(511, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem2.Text = "  ";
            // 
            // frmManageLocalDrivingLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 510);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageLocalDrivingLicenses";
            this.Text = "frmManageLocalDrivingLicenses";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsCancel;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem cmsNewDriving;
        private System.Windows.Forms.ToolStripMenuItem cmsShowLicense;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonLicense;
        private System.Windows.Forms.ToolStripMenuItem cmsVisionTest;
        private System.Windows.Forms.ToolStripMenuItem cmsWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem cmsStreetTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}