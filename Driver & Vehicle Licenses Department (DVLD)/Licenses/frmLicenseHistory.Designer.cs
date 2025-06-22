namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses
{
    partial class frmLicenseHistory
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
            this.ctrPersonCardWithFilter1 = new Driver___Vehicle_Licenses_Department__DVLD_.People.User_Controller.ctrPersonCardWithFilter();
            this.ctrLicenseHistory1 = new Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses.ctrLicenseHistory();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(354, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "License History";
            // 
            // ctrPersonCardWithFilter1
            // 
            this.ctrPersonCardWithFilter1.FilteredEnabled = true;
            this.ctrPersonCardWithFilter1.Location = new System.Drawing.Point(236, 43);
            this.ctrPersonCardWithFilter1.Name = "ctrPersonCardWithFilter1";
            this.ctrPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrPersonCardWithFilter1.Size = new System.Drawing.Size(709, 397);
            this.ctrPersonCardWithFilter1.TabIndex = 5;
            // 
            // ctrLicenseHistory1
            // 
            this.ctrLicenseHistory1.Location = new System.Drawing.Point(12, 426);
            this.ctrLicenseHistory1.Name = "ctrLicenseHistory1";
         
            this.ctrLicenseHistory1.Size = new System.Drawing.Size(933, 311);
            this.ctrLicenseHistory1.TabIndex = 4;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 749);
            this.Controls.Add(this.ctrPersonCardWithFilter1);
            this.Controls.Add(this.ctrLicenseHistory1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ctrLicenseHistory ctrLicenseHistory1;
        private People.User_Controller.ctrPersonCardWithFilter ctrPersonCardWithFilter1;
    }
}