using Driver___Vehicle_Licenses_Department__DVLD_.Applications;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Detained_Licenses;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.International_License;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Local_Driving_License;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.RenewDriverLicense;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Replace_License;
using Driver___Vehicle_Licenses_Department__DVLD_.Local_Driving_License;
using Driver___Vehicle_Licenses_Department__DVLD_.People;
using Driver___Vehicle_Licenses_Department__DVLD_.Test_Types;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using System;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_
{
    public partial class Main : Form
    {
        private frmUserLogin _Login;
        public Main(frmUserLogin Form)
        {
            InitializeComponent();
            _Login = Form;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form PeopleForum = new frmPeopleForum();
            PeopleForum.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers ManageUsers = new frmManageUsers();
            ManageUsers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(GlobalUser.User.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(GlobalUser.User.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalUser.User = null;
            _Login.Show();
            this.Close();
           
           
        }

        private void drvingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageTestApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManageTestTypes = new frmManageTestTypes();
            frmManageTestTypes.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManageApplicationTypes = new frmManageApplicationTypes();
            frmManageApplicationTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmLocalDrivingLicense = new frmAddUpdateLocalDrivingLicense();
            frmLocalDrivingLicense.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenses Frm = new frmManageLocalDrivingLicenses();
            Frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers Frm = new frmManageDrivers();
            Frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense Frm = new frmNewInternationalLicense();
            Frm.ShowDialog();
        }

        private void internationalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication Frm = new frmInternationalLicenseApplication();
            Frm.ShowDialog();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDriverLicense Frm = new frmRenewDriverLicense();
            Frm.ShowDialog();
        }

        private void replacmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicense Frm = new frmReplaceLostOrDamagedLicense();
            Frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses Frm = new frmManageDetainedLicenses();
            Frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicense Frm = new frmDetainedLicense();
            Frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense Frm = new frmReleaseDetainedLicense();
            Frm.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
