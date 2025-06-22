using DVLD__DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class TestB
    {
        private enum _enMode { AddNew , Update}
        private _enMode _Mode = _enMode.Update;
        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public TestAppointmentB TestAppointmentInfo { set; get; }
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int UserID { set; get; }

        public TestB()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.UserID = -1;
            this._Mode = _enMode.AddNew;

        }

        
        public TestB(int TestID , int TestAppointmentID , bool TestResult , string Notes , int CreatedUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = TestAppointmentB.FindTestAppointment(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.UserID = CreatedUserID;
            this._Mode = _enMode.Update;

        }

        public static TestB FindTest(int TestID)
        {
            int TestAppointmentID = -1, CreatedUserID = -1; string Notes = ""; bool TestResult = false;

            if (TestData.FindTestByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedUserID))
                return new TestB(TestID, TestAppointmentID, TestResult, Notes, CreatedUserID);
            else
                return null;

        }

        public static TestB FindLastTestPerPersonAndLicenseClass(int PersonID , int LicenseClassID , TestTypeB.enTestTypes TestTypeID )
        {
            int TestAppointmentID = -1, CreatedUserID = -1 , TestID = -1;
            string Notes = ""; bool TestResult = false;



            if (TestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID , LicenseClassID, (int)TestTypeID , ref TestID, ref TestAppointmentID,
                ref TestResult, ref Notes, ref CreatedUserID))
                return new TestB(TestID, TestAppointmentID, TestResult, Notes, CreatedUserID);
            else
                return null;

        }

        private bool _AddNewUser()
        {
            this.TestID = TestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.UserID);

            return this.TestID != -1;
        }


        private bool _Update()
        {
            return TestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.UserID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case _enMode.Update:

                    if (_Update())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }
        }

        public static bool IsTestRecordExists(int AppointmentID)
        {
            return TestData.IsTestExists(AppointmentID);
        }

        public static byte GetPassedTestCount(int LocalLicenseID)
        {
            return TestData.GetPassedTestCount(LocalLicenseID);
        }

        public static bool PassedAllTests(int LocalLicenseID)
        {
            return GetPassedTestCount(LocalLicenseID) == 3;
        }

        public static bool IsPassedTest(int LocalDID , int PersonID , int TestTypeID)
        {
            return TestData.IsPassedTest(LocalDID , PersonID , TestTypeID);
        }

    }
}
