
using DVLD__DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class InternationalLicenseB : ApplicationB
    {
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public DriverB DriveInfo { set; get; }
        public int LocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public InternationalLicenseB()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now; 
            this.IsActive = false;
            this.CreatedByUserID = -1;
        }
        public InternationalLicenseB(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,decimal PaidFees,  int InternationalLicenseID,  int DriverID, int LocalLicenseID,
                                 DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID) 
        {

            base.ApplicationID = ApplicationID; 
            base.PersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)ApplicationB.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUser = CreatedByUserID;



            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LocalLicenseID = LocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.DriveInfo = DriverB.FindDriverByDriverID(DriverID);
        }


        public static InternationalLicenseB FindInternationalLicense(int InterID)
        {

            int internationalLicenseID = InterID, ApplicationID = -1 ;
            int driverID = -1;
            int localLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            
            if (InternationalLicense.FindInternationalLicense( internationalLicenseID,ref ApplicationID, ref localLicenseID, ref driverID, ref issueDate,
                ref expirationDate,ref isActive,ref createdByUserID))
            {
                ApplicationB Application = ApplicationB.FindApplication(ApplicationID);

                if (Application == null)
                    return null;

                return new InternationalLicenseB( ApplicationID, Application.PersonID , Application.ApplicationDate , Application.ApplicationStatus 
                    , Application.LastStatusDate , Application.PaidFees , internationalLicenseID, driverID,
                     localLicenseID,issueDate,expirationDate,isActive,createdByUserID);
            }
            else
                return null;
            
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return InternationalLicense.GetDriverInternationaLicenses(DriverID);
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = InternationalLicense.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.LocalLicenseID, this.IssueDate,
                                                                                           this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return this.InternationalLicenseID != -1;
        }

        public override bool Save()
        {
            base.Mode = ApplicationB._enMode.AddNew;
            if (!base.Save())
                return false;

            if (_AddNewInternationalLicense())
                return true;
            else
                return false;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return InternationalLicense.GetAllInternationalLicenses();
        }

        public static int GetActiveInternationalLicenseID(int DriverID)
        {
            return InternationalLicense.GetActiveInternationalLicenseID(DriverID);
        }
    }
}
