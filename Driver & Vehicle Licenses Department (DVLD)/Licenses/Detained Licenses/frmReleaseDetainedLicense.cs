using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses;
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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Detained_Licenses
{
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrDriverLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private int _SelectedLicenseID { set; get; }
        


        private void _ReleaseLicense()
        {
            int ApplicationID = -1;

            if (ctrDriverLicenseInfoWithFilter1.SelectedLicense.ReleaseDetainedLicense(GlobalUser.User.UserID, ref ApplicationID))
                MessageBox.Show("License Released Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed To Release License", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


            lDetainApp.Text = ApplicationID.ToString();
            btnRelease.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;


         

        }


        private void btnRelease_Click(object sender, EventArgs e)
        {
            _ReleaseLicense();
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            lCreatedBy.Text = GlobalUser.User.UserName;
        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo Frm = new frmLicenseInfo(_SelectedLicenseID);
            Frm.ShowDialog();
        }

       
        private void llHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory Frm = new frmLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
            Frm.ShowDialog();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            lLicenseID.Text = _SelectedLicenseID.ToString();
            llShowLicense.Enabled = _SelectedLicenseID != -1;
            llHistory.Enabled = _SelectedLicenseID != -1;
            if(_SelectedLicenseID == -1)
            {
                                 
                btnRelease.Enabled = false;
                return;
            }

            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("This License Not Detained", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnRelease.Enabled = true;

            lDetainDate.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicense.DetainLicenseInfo.DetainDate.ToShortDateString();
            lDetainID.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicense.DetainLicenseInfo.DetainID.ToString();
            lFineFees.Text = ((int)ctrDriverLicenseInfoWithFilter1.SelectedLicense.DetainLicenseInfo.FineFees).ToString();
            lApplicationFees.Text = ((int)ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.ReleaseDetainenDrivingLicense).Fees).ToString();
            lTotalFees.Text = ((int)(Convert.ToDecimal(lFineFees.Text.Trim()) + Convert.ToDecimal(lApplicationFees.Text.Trim()))).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
