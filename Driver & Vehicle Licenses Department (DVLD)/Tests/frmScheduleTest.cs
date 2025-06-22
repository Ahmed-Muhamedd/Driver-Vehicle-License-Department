using DVLD_Business;
using System;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Tests_Application.Vision_Test
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalLicenseID = -1;
        private int _AppotinmentID = -1;
        private TestTypeB.enTestTypes _TestTypeID;
        public frmScheduleTest(int LocalLicenseID, TestTypeB.enTestTypes TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();
            this._LocalLicenseID = LocalLicenseID;
            this._AppotinmentID = AppointmentID;
            this._TestTypeID = TestTypeID;
        }

   


        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrScheduleTest1.TestTypeID = _TestTypeID;
            ctrScheduleTest1.LoadInfo(_LocalLicenseID, _AppotinmentID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
