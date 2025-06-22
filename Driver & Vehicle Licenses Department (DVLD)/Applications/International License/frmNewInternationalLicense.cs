using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Tests_Application.Vision_Test;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.International_License
{
    public partial class frmNewInternationalLicense : Form
    {
        public frmNewInternationalLicense()
        {
            InitializeComponent();
           
        }


   
        private int _SelectedLicenseID { set; get; }
        private int _InternationalLicenseID{ set; get; }
       
   

   

        private void _AddNewInternationalLicense()
        {

            InternationalLicenseB InterLicense = new InternationalLicenseB();

            InterLicense.PersonID = ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID;
            InterLicense.ApplicationDate = DateTime.Now;
            InterLicense.LastStatusDate = DateTime.Now.AddDays(12);
            InterLicense.ApplicationStatus = ApplicationB.enApplicationStatus.Completed;
            InterLicense.ApplicationTypeID = ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.NewInternationalLicense).ID;
            InterLicense.PaidFees = ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.NewInternationalLicense).Fees;
            InterLicense.CreatedByUser = GlobalUser.User.UserID;


            InterLicense.DriverID = ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverID;
            InterLicense.LocalLicenseID = _SelectedLicenseID;
            InterLicense.IssueDate = Convert.ToDateTime(lIssueDate.Text);
            InterLicense.ExpirationDate = Convert.ToDateTime(lExpirationDate.Text);
            InterLicense.IsActive = true;
            InterLicense.CreatedByUserID = GlobalUser.User.UserID;


            if (InterLicense.Save())
            {
                MessageBox.Show("International Saved", "Confirm", MessageBoxButtons.OK);
                liAppID.Text = InterLicense.ApplicationID.ToString();
                liLicenseID.Text = InterLicense.InternationalLicenseID.ToString();
                llShowLicense.Enabled = true;
                btnIssue.Enabled = false;
                ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
                _InternationalLicenseID = InterLicense.InternationalLicenseID;
            }
            else
                MessageBox.Show("International Failed", "Error", MessageBoxButtons.OK);


        }
        private void frmNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lAppDate.Text = DateTime.Now.ToShortDateString();
            lIssueDate.Text = DateTime.Now.ToShortDateString();
            lExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lCreatedBy.Text = GlobalUser.User.UserName;
            lFees.Text = ((int)(ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.NewInternationalLicense).Fees)).ToString();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _AddNewInternationalLicense();
        }


       
        private void llHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory Form = new frmLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
            Form.ShowDialog();
        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo Form = new frmInternationalLicenseInfo(_InternationalLicenseID);
            Form.ShowDialog();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            llShowLicense.Enabled = _SelectedLicenseID != -1;

            if(_SelectedLicenseID == -1)
            {
                btnIssue.Enabled = false;
                return;
            }

            lLocalLicenseID.Text = _SelectedLicenseID.ToString();

            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License Not Active , Pleaase Choose Another One", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;

            }

            if (ctrDriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Cannot Issue International License For " + ctrDriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.ClassName
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            if(InternationalLicenseB.GetActiveInternationalLicenseID(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverID) != -1)
            {
                MessageBox.Show("Selected License Already Have An International Lincese", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
