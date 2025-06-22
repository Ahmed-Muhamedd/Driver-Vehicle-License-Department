using DVLD__DataAccess;
using System;
using System.Data;
using System.Diagnostics;

namespace DVLD_Business
{
    public class TestAppointmentB
    {
        private enum _enMode { AddNew , Update}
        private _enMode _Mode = _enMode.Update;

        public int AppointmentID { set; get; }
        public TestTypeB.enTestTypes TestTypeID { set; get; }
       
        public int LocalDID{ set; get; }
        public DateTime AppointmentDate{ set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public ApplicationB RetakeTestInfo { set; get; }

        public int TestID
        {
            get { return _GetTestID(); }

        }
        public TestAppointmentB()
        {
            this.AppointmentID = -1;
            this.TestTypeID = TestTypeB.enTestTypes.StreetTest;
            this.LocalDID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.IsLocked = false;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            _Mode = _enMode.AddNew;
        }

        public TestAppointmentB(int TestAppointmentID, TestTypeB.enTestTypes TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees,
           int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.AppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.CreatedByUserID = CreatedByUserID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestInfo = ApplicationB.FindApplication(RetakeTestApplicationID);
            _Mode = _enMode.Update;

        }


        public static TestAppointmentB FindTestAppointment(int TestAppointmentID)
        {
            int TestTypeID = -1; int LocalID = -1; DateTime AppDate = DateTime.Now;
            decimal PaidFees = -1; int CreatedByUserID = -1; bool IsLocked = false; int RetakeID = -1;

            if (TestAppointmentData.FindTestAppointmentByID(TestAppointmentID, ref  TestTypeID, ref LocalID, ref AppDate,
                ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeID))
                return new TestAppointmentB(TestAppointmentID,(TestTypeB.enTestTypes) TestTypeID, LocalID, AppDate, PaidFees, CreatedByUserID, IsLocked, RetakeID);
            else
                return null;

        }

        public static TestAppointmentB FindLastTestAppointment(int LocalDrivingLicenseID , TestTypeB.enTestTypes TestTypeID)
        {

            int AppointmentID = -1;  DateTime AppDate = DateTime.Now;
            decimal PaidFees = -1; int CreatedByUserID = -1; bool IsLocked = false; int RetakeID = -1;

            if (TestAppointmentData.FindLastTestAppointment(ref AppointmentID, (int)TestTypeID, LocalDrivingLicenseID, ref AppDate, ref PaidFees, ref CreatedByUserID,
                ref IsLocked, ref RetakeID))
                return new TestAppointmentB(AppointmentID, (TestTypeB.enTestTypes)TestTypeID, LocalDrivingLicenseID, AppDate, PaidFees, CreatedByUserID, IsLocked, RetakeID);
            else
                return null;

        }

        private bool _AddNewTestAppointment()
        {
            this.AppointmentID = TestAppointmentData.AddNewAppointment((int)this.TestTypeID, this.LocalDID, this.AppointmentDate, this.PaidFees,this.CreatedByUserID
                 , this.IsLocked , this.RetakeTestApplicationID);

            return this.AppointmentID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return TestAppointmentData.UpdateTestAppointment(this.AppointmentID, (int)this.TestTypeID, this.LocalDID, this.AppointmentDate, this.PaidFees
                , this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case _enMode.Update:
                    if (_UpdateTestAppointment())
                        return true;
                    else
                        return false;
                default:
                    return false;
            }

          
        }

        public static DataTable GetAllTestAppointments()
        {
            return TestAppointmentData.GetAllTestAppointments();
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(TestTypeB.enTestTypes TestTypeID)
        {
            return TestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDID, (int)TestTypeID);
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalID , TestTypeB.enTestTypes TestTypeID)
        {
            return TestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalID, (int)TestTypeID);
        }

        private int _GetTestID()
        {
            return TestAppointmentData.GetTestID(this.AppointmentID);
        }

        public static DataTable GetPersonAppointments(int PersonID , int TestTypeID)
        {
            return TestAppointmentData.FindPersonAppointments(PersonID , TestTypeID);
        }

        public static bool IsPersonHaveAppointment(int PersonID , int TestTypeID)
        {
            return TestAppointmentData.IsPersonHaveAppointment(PersonID , TestTypeID);
        }

        public static bool IsPersonAppointmentLocked(int PersonID)
        {
            return TestAppointmentData.IsPersonAppointmentLocked(PersonID);
        }

        public static bool Update(int AppointmentID , DateTime NewDate)
         {
                return TestAppointmentData.Update(AppointmentID, NewDate);
         }

        public static bool Update(int AppointmentID)
        {
            return TestAppointmentData.Update(AppointmentID);
        }


    }
}
