using DVLD__DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class LicensesB
    {

        public enum enIssueReason { FirstTime = 1, Renew = 2 , DamagedReplacement = 3 , LostReplacement = 4}

        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public DriverB DriverInfo { set; get;  }
        public int LicenseClassID { set; get; }
        public LicenseClassesB LicenseClassInfo { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirataionDate { set; get; }
        public string Notes{ set; get; }
        public decimal PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }

        public DetainLicenseB DetainLicenseInfo { set; get; }

        public bool IsDetained { get { return DetainLicenseB.IsLicenseDetained(this.LicenseID); } }

        public string IssueReasonText
        {
            get { return GetIssueReasonText(this.IssueReason); }

        }

        public int CreatedByUserID { set; get; }


        public LicensesB()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirataionDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
        }


        public LicensesB(int ApplicationID, int LicensesClassID, int LicenseID, int CreatedByUserID, int DriverID, decimal PaidFees, DateTime IssueDate,
              enIssueReason IssueReason, string Notes, DateTime ExpireDate, bool IsActive)
        {
            this.ApplicationID = ApplicationID;
            this.LicenseID = LicenseID;
            this.IssueDate = IssueDate;
            this.IssueReason = IssueReason;
            this.Notes = Notes;
            this.ExpirataionDate = ExpireDate;
            this.IsActive = IsActive;
            this.DriverID = DriverID;
            this.LicenseClassID = LicensesClassID;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.DetainLicenseInfo = DetainLicenseB.FindLicenseDetainByLicense(LicenseID);
            this.DriverInfo = DriverB.FindDriverByDriverID(DriverID);
            this.LicenseClassInfo = LicenseClassesB.FindLicenseClass(LicensesClassID);

        }


        public static LicensesB FindLicenseByLicenseID(int LicenseID)
        {
            int AppID = -1, LID = LicenseID, DriverID = -1 , LicenseClassID = -1 , CreatedByUserID = -1;
            decimal PaidFees = -1;
            DateTime IssueDate = DateTime.Now, ExpireDate = DateTime.Now;
            byte IssueReason = 0;
            bool IsActive = false;
            string Notes = "";

            if (LicensesDate.FindLicense(ref AppID, LID, ref IssueDate, ref IssueReason, ref DriverID, ref Notes, ref ExpireDate, ref IsActive , ref LicenseClassID
                   , ref PaidFees , ref CreatedByUserID))
                return new LicensesB(AppID, LicenseClassID ,LID,CreatedByUserID,DriverID,PaidFees,IssueDate,(enIssueReason) IssueReason, Notes, ExpireDate, IsActive);
            else
                return null;
        }

        public static LicensesB FindLicenseByLocalLicenseID(int LocalLicenseID)
        {
            int AppID = -1, LID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            decimal PaidFees = -1;
            DateTime IssueDate = DateTime.Now, ExpireDate = DateTime.Now;
            byte IssueReason = 0;
            bool IsActive = false;
            string Notes = "";

            if (LicensesDate.FindLicense(LocalLicenseID,ref AppID,ref LID, ref IssueDate, ref IssueReason, ref DriverID, ref Notes, ref ExpireDate, ref IsActive, ref LicenseClassID
                   , ref PaidFees, ref CreatedByUserID))
                return new LicensesB(AppID, LicenseClassID, LID, CreatedByUserID, DriverID, PaidFees, IssueDate,(enIssueReason) IssueReason, Notes, ExpireDate, IsActive);
            else
                return null;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = LicensesDate.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirataionDate, this.Notes,
                                                        this.PaidFees, this.IsActive,(byte) this.IssueReason, this.CreatedByUserID);
            return this.LicenseID != -1;
        }

        public bool IsLicenseExpired()
        {
            return this.ExpirataionDate < DateTime.Now;
        }

        public  bool IsLicenseNotExpired()
        {
            return this.ExpirataionDate > DateTime.Now;
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            return LicensesDate.IsLicenseActive(LicenseID);
        }
       
        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement For Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement For Lost";
                default:
                    return "Unkown";
            }
        }

        public bool Save()
        {
            if (_AddNewLicense())
                return true;
            else
                return false;
        }

        public static bool DisabledLicense(int LID)
        {
            return LicensesDate.DisableLicense(LID);
        }

        public  bool DisabledLicense()
        {
            return LicensesDate.DisableLicense(this.LicenseID);
        }

        public static bool IsLicenseHaveInterLicense(int LicenseID)
        {
            return LicensesDate.IsLicenseHaveInternationalLicense(LicenseID);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return LicensesDate.FindActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return LicensesDate.GetDriverLicenses(DriverID);
        }


        public int Detain(decimal PaidFees , int CreatedByUserID)
        {
            DetainLicenseB Detain = new DetainLicenseB();
            Detain.LicenseID = this.LicenseID;
            Detain.DetainDate = DateTime.Now;
            Detain.FineFees = PaidFees;
            Detain.CreatedByUserID = CreatedByUserID;

            if (!Detain.Save())
                return -1;

            return Detain.DetainID;

        }


        // Repair
        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {
            ApplicationB Application = new ApplicationB();
            Application.PersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)ApplicationB.enApplicationType.ReleaseDetainenDrivingLicense;
            Application.ApplicationStatus = ApplicationB.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now.AddDays(3);
            Application.PaidFees = ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.ReleaseDetainenDrivingLicense).Fees;
            Application.CreatedByUser = ReleasedByUserID;
            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }


            ApplicationID = Application.ApplicationID;

            return this.DetainLicenseInfo.ReleaseDetainedLicense(ReleasedByUserID , Application.ApplicationID);
        }


        public LicensesB RenewLicense(string Notes, int CreatedByUserID)
        {
            ApplicationB Application = new ApplicationB();

            Application.PersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)ApplicationB.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = ApplicationB.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUser = CreatedByUserID;

            if (!Application.Save())
                return null;
           

            LicensesB NewLicense = new LicensesB();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.Notes = Notes;
            NewLicense.CreatedByUserID = CreatedByUserID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirataionDate = DateTime.Now.AddYears(this.LicenseClassInfo.ValidityLength);
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IsActive = true;
            NewLicense.PaidFees = this.PaidFees;

            if (!NewLicense.Save())
                return null;

            DisabledLicense();
            
            return NewLicense;
        }

        public LicensesB Replace(enIssueReason IssueReason , int CreatedByUserID)
        {
            ApplicationB Application = new ApplicationB();

            Application.PersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)ApplicationB.enApplicationType.ReplaceDamageDrivingLicense : (int)ApplicationB.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = ApplicationB.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = ApplicationTypesB.FindApplicationType(Application.ApplicationTypeID).Fees;
            Application.CreatedByUser = CreatedByUserID;

            if (!Application.Save())
                return null;

            LicensesB NewLicense = new LicensesB();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.CreatedByUserID = CreatedByUserID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.PaidFees = 0;
            NewLicense.Notes = this.Notes;
            NewLicense.ExpirataionDate = this.ExpirataionDate;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.LicenseClassID = this.LicenseClassID;

            if (!NewLicense.Save())
                return null;

            DisabledLicense();

            return NewLicense;

        }
    }
}
