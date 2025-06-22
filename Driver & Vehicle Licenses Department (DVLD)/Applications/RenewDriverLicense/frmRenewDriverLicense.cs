using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup.Localizer;
using System.Xml.Serialization;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.RenewDriverLicense
{
    public partial class frmRenewDriverLicense : Form
    {
        public frmRenewDriverLicense()
        {
            InitializeComponent();
            
        }

       
        private int _NewLicenseID { set; get; }
    

        private void _RenewLicense()
        {

            LicensesB NewLicense = ctrdriverLicenseInfoWithFilter1.SelectedLicense.RenewLicense(tbNotes.Text.Trim(), GlobalUser.User.UserID);
            if(NewLicense == null)
            {
                MessageBox.Show("Failed To Renew The License", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lRenewLicenseID.Text = NewLicense.LicenseID.ToString();
            liAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            MessageBox.Show("License Renwed Successfully With This ID = " + _NewLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ctrdriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicense.Enabled = true;


        }

  

        private void _SetTheDefaultData()
        {

            ctrdriverLicenseInfoWithFilter1.InputFocus();

            lIssueDate.Text = DateTime.Now.ToShortDateString();
            lAppDate.Text = DateTime.Now.ToShortDateString();
            lApplicationFees.Text = ((int)ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.RenewDrivingLicense).Fees).ToString();
            lCreatedBy.Text = GlobalUser.User.UserName;
            lExpirationDate.Text = "???";
        }
        private void frmRenewDriverLicense_Load(object sender, EventArgs e)
        {
            _SetTheDefaultData();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _RenewLicense();
        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo Frm = new frmLicenseInfo(_NewLicenseID);
            Frm.ShowDialog();
        }

        private void ctrdriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicense = obj;

            llHistory.Enabled = SelectedLicense != -1;

            if (SelectedLicense == -1)
                return;

            int DefualtValidityLength = ctrdriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.ValidityLength;
            lExpirationDate.Text = DateTime.Now.AddYears(DefualtValidityLength).ToShortDateString();
            lFees.Text = ((int)ctrdriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.ClassFees).ToString();
            lTotalFees.Text = ((int)(Convert.ToDecimal(lFees.Text.Trim()) + Convert.ToDecimal(lApplicationFees.Text.Trim()))).ToString();
            tbNotes.Text = ctrdriverLicenseInfoWithFilter1.SelectedLicense.Notes;

            if (!ctrdriverLicenseInfoWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show($"Selected License Not Expired Yet , It Will Expired On {ctrdriverLicenseInfoWithFilter1.SelectedLicense.ExpirataionDate.ToShortDateString()}"
                    , "Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            if (!ctrdriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License Not Active ,Choose An Active License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
;