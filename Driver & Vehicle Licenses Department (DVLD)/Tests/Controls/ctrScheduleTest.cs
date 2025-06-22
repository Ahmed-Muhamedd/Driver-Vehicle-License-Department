using Driver___Vehicle_Licenses_Department__DVLD_.Properties;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Tests.Controls
{
    public partial class ctrScheduleTest : UserControl
    {
        private enum _enMode { AddNew ,Update  };
        private _enMode _Mode = _enMode.Update;

        public enum _enCreationMode { FirstTime, RetakeTest}
        private _enCreationMode _CreationMode = _enCreationMode.FirstTime;

        private TestTypeB.enTestTypes _TestTypeID = TestTypeB.enTestTypes.VisionTest;

        private LocalDrivingLicenseB _LocalDrivingLicense;

        private int _LocalDrivingLicenseID = -1;
        private int _TestAppointmentID = -1;

        private TestAppointmentB _TestAppointment;

        public TestTypeB.enTestTypes TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case TestTypeB.enTestTypes.VisionTest:
                        gbTest.Text = "Vision Test";
                        pbMain.Image = Resources.Vision_512;
                        break;
                    case TestTypeB.enTestTypes.WrittenTest:
                        gbTest.Text = "Written Test";
                        pbMain.Image = Resources.Written_Test_512;
                        break;
                    case TestTypeB.enTestTypes.StreetTest:
                        gbTest.Text = "Street Test";
                        pbMain.Image = Resources.Street_Test_32;
                        break;
                }
            }
        }

        public void LoadInfo(int LocalDrivingLicenseID , int TestAppointmentID = -1)
        {
            if (TestAppointmentID == -1)
                _Mode = _enMode.AddNew;
            else
                _Mode = _enMode.Update;

            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicense = LocalDrivingLicenseB.FindLocalDrivingLicenseByID(LocalDrivingLicenseID);

            if(_LocalDrivingLicense == null)
            {
                MessageBox.Show("No Local Driving License Application With This ID = " + LocalDrivingLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicense.DoesAttendTestType(_TestTypeID))
                _CreationMode = _enCreationMode.RetakeTest;
            else
                _CreationMode = _enCreationMode.FirstTime;

            if(_CreationMode == _enCreationMode.RetakeTest)
            {
                lRAppFees.Text = ((int)ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.RetakeTest).Fees).ToString();
                gbRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeID.Text = "?";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeID.Text = "N/A";
                lRAppFees.Text = "0";
            }

            lblLocalID.Text = _LocalDrivingLicense.LocalDrivingLicenseID.ToString();
            lDClass.Text = _LocalDrivingLicense.LicenseClassInfo.ClassName;
            lName.Text = _LocalDrivingLicense.PersonFullName;
            lTrial.Text = _LocalDrivingLicense.TotalTrialsPerTest(_TestTypeID).ToString();

            if(_Mode == _enMode.AddNew)
            {
                dtpDate.MinDate = DateTime.Now;
                lFees.Text = ((int)TestTypeB.FindTestType(_TestTypeID).TestTypeFees).ToString();
                lblRetakeID.Text = "N/A";

                _TestAppointment = new TestAppointmentB();
            }
            else
            {
                if (!_LoadTestAppointment())
                    return;
            }

            lTotalFees.Text = ((int)(Convert.ToDecimal(lFees.Text) + Convert.ToDecimal(lRAppFees.Text))).ToString();

            if (!_HandleActiveAppointmentTest())
                return;

            if (!_HandleAppointmentLockedConstraints())
                return;

            if (!_HandlePerviousTestConstraint())
                return;

        }

        private bool _HandleActiveAppointmentTest()
        {
            if(_Mode == _enMode.AddNew && LocalDrivingLicenseB.IsThereAnActiveScheduledTest(_LocalDrivingLicenseID , TestTypeID))
            {
                MessageBox.Show("Person Already Have An Acive Appointment For This Test", "Not Allowed",MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraints()
        {
            if (_TestAppointment.IsLocked)
            {
                lUserMessage.Visible = true;
                lUserMessage.Text = "Person Already Sat For The Test, Appointment Locked";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }
            else
                lUserMessage.Visible = false;

            return true;
        }

        private bool _LoadTestAppointment()
        {
            _TestAppointment = TestAppointmentB.FindTestAppointment(_TestAppointmentID);
            if(_TestAppointment == null)
            {
                MessageBox.Show("Test Appointment Not Found ", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }
            lFees.Text = ((int)_TestAppointment.PaidFees).ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpDate.MinDate = DateTime.Now;
            else
                dtpDate.MinDate = _TestAppointment.AppointmentDate;

            dtpDate.Value = _TestAppointment.AppointmentDate;

            if(_TestAppointment.RetakeTestApplicationID == -1)
            {
                gbRetakeTest.Enabled = false;
                lblRetakeID.Text = "??";
                lRAppFees.Text = "0";
            }
            else
            {
                gbRetakeTest.Enabled = true;
                lblRetakeID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                lblTitle.Text = "Schedule Retake Test";
                lRAppFees.Text = ((int)_TestAppointment.PaidFees).ToString();

            }

            return true;

        }

        private bool _HandlePerviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case TestTypeB.enTestTypes.VisionTest:
                    return true;
                case TestTypeB.enTestTypes.WrittenTest:
                    if (!_LocalDrivingLicense.DoesPassTestType(TestTypeB.enTestTypes.VisionTest))
                    {
                        lUserMessage.Text = "Cannot Schedule , Vision Test Should Be Passed First";
                        lUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                        return true;
                    }
                case TestTypeB.enTestTypes.StreetTest:
                    if (!_LocalDrivingLicense.DoesPassTestType(TestTypeB.enTestTypes.WrittenTest))
                    {
                        lUserMessage.Text = "Cannot Schedule , Written Test Should Be Passed First";
                        lUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                        return true;
                    }
                default:
                    return false;
            }
        }
        public ctrScheduleTest()
        {
            InitializeComponent();
        }

        private bool _HandleRetakeApplication()
        {
            if(_Mode == _enMode.AddNew && _CreationMode == _enCreationMode.RetakeTest)
            {
                ApplicationB Application = new ApplicationB();

                Application.ApplicationDate = DateTime.Now;
                Application.LastStatusDate = DateTime.Now.AddDays(7);
                Application.ApplicationTypeID = (int)ApplicationB.enApplicationType.RetakeTest;
                Application.ApplicationStatus = ApplicationB.enApplicationStatus.New;
                Application.PaidFees = ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.RetakeTest).Fees;
                Application.PersonID = _LocalDrivingLicense.PersonID;
                Application.CreatedByUser = GlobalUser.User.UserID;
                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed To Create Application ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }
            return true;
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.AppointmentDate = dtpDate.Value;
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDID = _LocalDrivingLicense.LocalDrivingLicenseID;
            _TestAppointment.PaidFees = Convert.ToDecimal(lTotalFees.Text);
            _TestAppointment.CreatedByUserID = GlobalUser.User.UserID;
            _TestAppointment.IsLocked = false;

            if (_TestAppointment.Save())
            {
                _Mode = _enMode.Update;
                MessageBox.Show("Appointment Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }else
                MessageBox.Show("Appointment Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
