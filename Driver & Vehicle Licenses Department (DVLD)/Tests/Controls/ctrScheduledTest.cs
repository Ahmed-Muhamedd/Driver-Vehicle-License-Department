using Driver___Vehicle_Licenses_Department__DVLD_.Properties;
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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Tests.Controls
{
    public partial class ctrScheduledTest : UserControl
    {
        private int _TestAppointmentID;

        private TestTypeB.enTestTypes _TestTypeID = TestTypeB.enTestTypes.VisionTest;

        private int _TestID = -1;

        public TestTypeB.enTestTypes TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case TestTypeB.enTestTypes.VisionTest:
                        gbTestTitle.Text = "Vision Test";
                        pbMain.Image = Resources.Vision_512;
                        break;
                    case TestTypeB.enTestTypes.WrittenTest:
                        gbTestTitle.Text = "Written Test";
                        pbMain.Image = Resources.Written_Test_512;
                        break;
                    case TestTypeB.enTestTypes.StreetTest:
                        gbTestTitle.Text = "Street Test";
                        pbMain.Image = Resources.Street_Test_32;
                        break;
                    
                }
            }
        }


        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        {
            get { return _TestID; }
        }

        public ctrScheduledTest()
        {
            InitializeComponent();
        }

        public void LoadTestAppointmentInfo(int TestAppointmentID)
        {
            TestAppointmentB TestAppointment = TestAppointmentB.FindTestAppointment(TestAppointmentID);
            if(TestAppointment == null)
            {
                _TestAppointmentID = -1;
                MessageBox.Show("There Is No Test Appoitnemnt With This ID = " + TestAppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestID = TestAppointment.TestID;

            LocalDrivingLicenseB LocalLicense = LocalDrivingLicenseB.FindLocalDrivingLicenseByID(TestAppointment.LocalDID);

            if(LocalLicense == null)
            {
                MessageBox.Show("There Is No Local Application With This ID = " + TestAppointment.LocalDID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            lLocalID.Text = TestAppointment.LocalDID.ToString();
            lDate.Text = TestAppointment.AppointmentDate.ToShortDateString();
            lFees.Text = ((int)TestAppointment.PaidFees).ToString();


            lDClass.Text = LocalLicense.LicenseClassInfo.ClassName;
            lName.Text = LocalLicense.PersonFullName;
            lTrial.Text = LocalLicense.TotalTrialsPerTest(_TestTypeID).ToString();

            lTestID.Text = TestAppointment.TestID == -1 ? "Not Taken Yet" : TestAppointment.TestID.ToString();

        }

        //private void _HandleTypeOfTest()
        //{
        //    switch (_TestTypes)
        //    {
        //        case TestTypeB.enTestTypes.VisionTest:
        //            break;
        //        case TestTypeB.enTestTypes.WrittenTest:
        //            break;
        //        case TestTypeB.enTestTypes.StreetTest:
        //            break;
        //        default:
        //            break;
        //    }
        //}

    }
}
