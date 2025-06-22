using Driver___Vehicle_Licenses_Department__DVLD_.People;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications
{
    public partial class ctrDrivingLicenseApplicationInfo : UserControl
    {
        public ctrDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private int _LocalDrivingLicenseID = -1;

        public int LocalDrivingLicenseID
        {
            get
            {
                return _LocalDrivingLicenseID;
            }
        }

        private int LicenseID ;

        private LocalDrivingLicenseB _LocalDrivingLicense;


        public void LoadLocalLicenseInfo(int LocalLicenseID)
        {
            _LocalDrivingLicense = LocalDrivingLicenseB.FindLocalDrivingLicenseByID(LocalLicenseID);
            if (_LocalDrivingLicense == null)
            {
                MessageBox.Show("There No Local License With This ID = " + LocalLicenseID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicenseInfo();
        }

        public void LoadLocalLicenseInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicense = LocalDrivingLicenseB.FindLocalDrivingLicenseByApplicationID(ApplicationID);
            if (_LocalDrivingLicense == null)
            {
                MessageBox.Show("There No Local License With This ID = " + ApplicationID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicenseInfo();
        }

        // Not Finished Yet
        private void _LoadLocalLicenseInfo()
        {

            _LocalDrivingLicenseID = _LocalDrivingLicense.LocalDrivingLicenseID;

            lLocalID.Text = _LocalDrivingLicense.LocalDrivingLicenseID.ToString();
            lAppliedL.Text = LicenseClassesB.FindLicenseClass(_LocalDrivingLicense.LicenseClassID).ClassName;
            lPassedTest.Text = "Null";

            ctrApplicationInfo1.LoadApplicationInfo(_LocalDrivingLicense.ApplicationID);
      

        }

        private void label8_Click(object sender, EventArgs e)
        {
            //frmLicenseInfo Frm = new frmLicenseInfo(_LocalDrivingLicense.get)
        }
    }
}
