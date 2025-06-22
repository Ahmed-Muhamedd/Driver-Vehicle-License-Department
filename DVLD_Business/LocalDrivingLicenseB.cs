using DVLD__DataAccess;
using System;
using System.Data;


namespace DVLD_Business
{
    public class LocalDrivingLicenseB : ApplicationB
    {
        private new enum _enMode { AddNew, Update  };
        private new _enMode Mode = _enMode.AddNew;

        public int LocalDrivingLicenseID{ get; set; }

        public int LicenseClassID { get; set; }
        public LicenseClassesB LicenseClassInfo { set; get; }

        public string PersonFullName
        {
            get { return PeopleBusiness.FindPerson(this.PersonID).FullName(); }
        }

        public LocalDrivingLicenseB()
        {
            this.LocalDrivingLicenseID = -1;
            this.LicenseClassID = -1;
            Mode = _enMode.AddNew;
        }

        public LocalDrivingLicenseB(int LocalDrivingLicenseID , int ApplicationID , int LicenseClassID , int ApplicantPersonID, DateTime ApplicationDate, 
                int ApplicationTypeID, enApplicationStatus ApplicationStatus , DateTime LastStatusDate , decimal PaidFees , int CreatedByUserID )
        {
            this.LocalDrivingLicenseID = LocalDrivingLicenseID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.PersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = (enApplicationStatus)ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUser = CreatedByUserID;
            LicenseClassInfo = LicenseClassesB.FindLicenseClass(LicenseClassID);

            Mode = _enMode.Update;
        }


        public static LocalDrivingLicenseB FindLocalDrivingLicenseByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseID = -1, LicenseClassID = -1;

            if (LocalDrivingLicenseData.FindLocalDrivingLicenseByApplicationID(ref LocalDrivingLicenseID,  ApplicationID, ref LicenseClassID))
            {
                ApplicationB Application = ApplicationB.FindApplication(ApplicationID);

                if (Application == null)
                    return null;

                return new LocalDrivingLicenseB(LocalDrivingLicenseID, ApplicationID, LicenseClassID , Application.PersonID , Application.ApplicationDate , 
                    Application.ApplicationTypeID , Application.ApplicationStatus , Application.LastStatusDate , Application.PaidFees , Application.CreatedByUser);
            }
            else
                return null;

        }

        public static LocalDrivingLicenseB FindLocalDrivingLicenseByID(int LocalDrivingID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (LocalDrivingLicenseData.FindLocalDrivingLicenseByID(LocalDrivingID, ref ApplicationID, ref LicenseClassID))
            {
                ApplicationB Application = ApplicationB.FindApplication(ApplicationID);

                if (Application == null)
                    return null;


                return new LocalDrivingLicenseB(LocalDrivingID, ApplicationID, LicenseClassID, Application.PersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUser);
            }
            else
                return null;

        }

        private bool _AddNewLocalLicense()
        {
            this.LocalDrivingLicenseID = LocalDrivingLicenseData.AddNewLocalLicense(this.ApplicationID , this.LicenseClassID);
            return this.LocalDrivingLicenseID != -1;
        }

        private bool _UpdateLocalLicense()
        {
            return LocalDrivingLicenseData.UpdateLocalDrivingLicense(this.LocalDrivingLicenseID, this.ApplicationID, this.LicenseClassID);
        }

        public override bool Save()
        {
            base.Mode = (ApplicationB._enMode) this.Mode;

            if (!base.Save())
                return false;

            switch (Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewLocalLicense())
                    {
                        Mode = _enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case _enMode.Update:
                    if (_UpdateLocalLicense())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return LocalDrivingLicenseData.GetAllLocalDrivingLicense();
        }

        public override bool Delete()
        {
            bool IsLocalDrivingLicenseDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsLocalDrivingLicenseDeleted = LocalDrivingLicenseData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseID);

            if (!IsLocalDrivingLicenseDeleted)
                return false;

            IsBaseApplicationDeleted = base.Delete();

            return IsBaseApplicationDeleted;

        }

        public bool DoesPassTestType(TestTypeB.enTestTypes TestTypeID)
        {
            return LocalDrivingLicenseData.DoesPassTestType(this.LocalDrivingLicenseID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(TestTypeB.enTestTypes CurrentTestType)
        {
            switch (CurrentTestType)
            {
                case TestTypeB.enTestTypes.VisionTest:
                    return true;

                case TestTypeB.enTestTypes.WrittenTest:
                    return this.DoesPassTestType(TestTypeB.enTestTypes.VisionTest);

                case TestTypeB.enTestTypes.StreetTest:
                    return this.DoesPassTestType(TestTypeB.enTestTypes.WrittenTest);

                default:
                    return false;

            }
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseID,TestTypeB.enTestTypes TestTypeID)
        {
            return LocalDrivingLicenseData.DoesPassTestType(LocalDrivingLicenseID, (int)TestTypeID);
        }


        public bool DoesAttendTestType(TestTypeB.enTestTypes TestTypeID)

        {
            return LocalDrivingLicenseData.DoesAttendTestType(this.LocalDrivingLicenseID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(TestTypeB.enTestTypes TestTypeID)
        {
            return LocalDrivingLicenseData.TotalTrialsPerTest(this.LocalDrivingLicenseID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, TestTypeB.enTestTypes TestTypeID)

        {
            return LocalDrivingLicenseData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, TestTypeB.enTestTypes TestTypeID)

        {
            return LocalDrivingLicenseData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public bool AttendedTest(TestTypeB.enTestTypes TestTypeID)

        {
            return LocalDrivingLicenseData.TotalTrialsPerTest(this.LocalDrivingLicenseID, (int)TestTypeID) > 0;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, TestTypeB.enTestTypes TestTypeID)

        {

            return LocalDrivingLicenseData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(TestTypeB.enTestTypes TestTypeID)

        {

            return LocalDrivingLicenseData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseID, (int)TestTypeID);
        }

        public TestB GetLastTestPerTestType(TestTypeB.enTestTypes TestTypeID)
        {
            return TestB.FindLastTestPerPersonAndLicenseClass(this.PersonID, this.LicenseClassID, TestTypeID);
        }

        public byte GetPassedTestCount()
        {
            return TestB.GetPassedTestCount(this.LocalDrivingLicenseID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return TestB.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return TestB.PassedAllTests(this.LocalDrivingLicenseID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return TestB.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            DriverB Driver = DriverB.FindDriver(this.PersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new DriverB();

                Driver.PersonID = this.PersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            LicensesB License = new LicensesB();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirataionDate = DateTime.Now.AddYears(this.LicenseClassInfo.ValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = LicensesB.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetCompleted();

                return License.LicenseID;
            }

            else
                return -1;
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return LicensesB.GetActiveLicenseIDByPersonID(this.PersonID, this.LicenseClassID);
        }

    }
}
