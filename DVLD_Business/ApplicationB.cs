using DVLD__DataAccess;
using System;
namespace DVLD_Business
{
    public class ApplicationB
    {
        public enum enApplicationType { NewDrivingLicense = 1 , RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3 , ReplaceDamageDrivingLicense = 4 , 
        ReleaseDetainenDrivingLicense = 5 , NewInternationalLicense = 6 , RetakeTest = 7}

        public enum enApplicationStatus  {New = 1 , Cancelled = 2 , Completed  = 3 }

        public  enum _enMode { AddNew, Update };


        public int ApplicationID { get; set; }
        public int PersonID { get; set; }
        public PeopleBusiness PersonInfo { set; get; }
        public string ApplicantFullName
        {
            get
            {
                return PeopleBusiness.FindPerson(PersonID).FullName();
            }
        }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public ApplicationTypesB ApplicationTypeInfo { set; get; }
        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees{ get; set; }
        public int CreatedByUser { get; set; }
        public UsersB CreatedByUserInfo { set; get; }

        public  _enMode Mode = _enMode.Update;

        public ApplicationB()
        {
            this.ApplicationID = -1;
            this.ApplicationTypeID = -1;
            this.PersonID = -1;
            this.PaidFees = -1;
            this.CreatedByUser = -1;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationStatus = enApplicationStatus.New;
            Mode = _enMode.AddNew;
        }


        private ApplicationB(int ApplicationID , int PersonID, DateTime ApplicationDate, int ApplicationTypeID , enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
                            decimal PaidFees, int CreatedByUser)
        {
            this.ApplicationID = ApplicationID;
            this.PersonID = PersonID;
            this.PersonInfo = PeopleBusiness.FindPerson(PersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = ApplicationTypesB.FindApplicationType(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUser = CreatedByUser;
            this.CreatedByUserInfo = UsersB.FindUserByUserID(CreatedByUser);

            Mode = _enMode.Update;
        }

      
        public static ApplicationB FindApplicationWithLDLAppID(int LDLAppID)
        {
            int AppID = -1, AppTypeID = -1,   CreatedUser = -1 , PersonID = -1;
            int AppStatus = 0; 
            decimal PaidFees = -1;
            DateTime AppDate = DateTime.Now, LastStatusDate = DateTime.Now;

            if (ApplicationData.FindApplicationWithLDlAppViewID( LDLAppID,ref AppID ,ref PersonID, ref AppDate,
                ref AppTypeID, ref AppStatus, ref LastStatusDate, ref PaidFees, ref CreatedUser))
                return new ApplicationB(AppID, PersonID, AppDate, AppTypeID, (enApplicationStatus)AppStatus, LastStatusDate, PaidFees, CreatedUser);
            else
                return null;
        }

        public static ApplicationB FindApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1 , ApplicationTypeID = -1 , CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.Now , LastStatusDate = DateTime.Now;
            int ApplicationStatus = 1;  decimal PaidFees = 0;

            if (ApplicationData.FindApplicationByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
                                                   ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))

                return new ApplicationB(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus) ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID
                    );
            else
                return null;
        }

        private  bool _AddNewApplication()
        {
            this.ApplicationID = ApplicationData.AddNewApplication(this.PersonID, this.ApplicationDate, this.ApplicationTypeID, (int) this.ApplicationStatus,
                                                                   this.LastStatusDate, this.PaidFees, this.CreatedByUser);

            return this.ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return ApplicationData.UpdateApplication(this.ApplicationID, this.PersonID, this.ApplicationDate, this.ApplicationTypeID,(int)this.ApplicationStatus
                                                     , this.LastStatusDate, this.PaidFees, this.CreatedByUser);
        }

        public static bool CancelApplication(int LocalID)
        {
            return ApplicationData.CancelApplication(LocalID);
        }

        public static bool CanAddNewAppliction(int PersonID , string ClasName)
        {
            return ApplicationData.CanAddNewApplication(PersonID, ClasName);
        }

        public virtual bool Save()
        {
            switch (Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = _enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case _enMode.Update:
                    _UpdateApplication();
                    return true;

                default:
                    return false;
            }

           
        }

        public bool Cancel()
        {
            return ApplicationData.UpdateStatus(this.ApplicationID, 2);
        }

        public virtual bool Delete()
        {
            return ApplicationData.DeleteApplication(this.ApplicationID);
        }

        public bool SetCompleted()
        {
            return ApplicationData.UpdateStatus(this.ApplicationID, 3);
        }

        public static bool ChangeApplicationStatusCompleted(int ApplicationID)
        {
            return ApplicationData.ApplicationStatusCompeleted(ApplicationID);
        }

        public static bool IsApplicationExists(int ApplicationID)
        {
            return ApplicationData.IsApplicationExists(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID , int ApplicationID)
        {
            return ApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationID);

        }

        public  bool DoesPersonHaveActiveApplication(int ApplicationID)
        {
            return ApplicationData.DoesPersonHaveActiveApplication(this.PersonID, ApplicationID);

        }

        public static int GetActiveApplicationID(int PersonID , ApplicationB.enApplicationType ApplicationTypeID )
        {
            return ApplicationData.FindActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public  int GetActiveApplicationID( ApplicationB.enApplicationType ApplicationTypeID)
        {
            return ApplicationData.FindActiveApplicationID(this.PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, ApplicationB.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return ApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

    }
}
