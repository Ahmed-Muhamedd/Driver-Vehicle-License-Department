using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Replace_License
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
        }


        private int _NewLicenseID { set; get; }
     
        private void _LoadDefaultData()
        {
            lAppDate.Text = DateTime.Now.ToShortDateString();
            lCreatedBy.Text = GlobalUser.User.UserName;
            rbDamageLicense.Checked = true;

        }
        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            _LoadDefaultData();
        }

        private LicensesB.enIssueReason _GetIssueReason()
        {
            if (rbDamageLicense.Checked)
                return LicensesB.enIssueReason.DamagedReplacement;
            else
                return LicensesB.enIssueReason.LostReplacement;
        }
        private void _ReplaceLicense()
        {

            LicensesB NewLicense = ctrDriverLicenseInfoWithFilter1.SelectedLicense.Replace(_GetIssueReason(), GlobalUser.User.UserID);

            if(NewLicense == null)
            {
                MessageBox.Show("Failed To Issue A Replacement License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;
            lRAppID.Text = NewLicense.ApplicationID.ToString();
            lReplaceLicenseID.Text = NewLicense.LicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully With ID = " + _NewLicenseID, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

            btnIssue.Enabled = false;
            gpChoose.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicense.Enabled = true;

        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            _ReplaceLicense();
        }

 
        private int _GetApplicationTypeID()
        {
            if (rbDamageLicense.Checked)
                return (int)ApplicationB.enApplicationType.ReplaceDamageDrivingLicense;
            else
                return (int)ApplicationB.enApplicationType.ReplaceLostDrivingLicense;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ltitle.Text = "Replace For Damage License";
            this.Text = ltitle.Text;
            lApplicationFees.Text = ((int)ApplicationTypesB.FindApplicationType(_GetApplicationTypeID()).Fees).ToString();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ltitle.Text = "Replace For Lost License";
            this.Text = ltitle.Text;

            lApplicationFees.Text = ((int)ApplicationTypesB.FindApplicationType(_GetApplicationTypeID()).Fees).ToString();
        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo Frm = new frmLicenseInfo(_NewLicenseID);
            Frm.ShowDialog();
        }

        private void llHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmLicenseHistory Frm = new frmLicenseHistory();
           // Frm.ShowDialog();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicense.Enabled = SelectedLicenseID != -1;
            if (SelectedLicenseID == -1)
                return;

            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License Is Not Active" ," Choose An Active License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
        }
    }
}
