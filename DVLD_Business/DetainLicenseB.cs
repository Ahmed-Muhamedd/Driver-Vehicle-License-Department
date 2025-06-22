using DVLD__DataAccess;
using System;
using System.Data;
using System.Diagnostics;


namespace DVLD_Business
{
    public class DetainLicenseB
    {
     
         public int DetainID { get; set; }
         public int LicenseID { get; set; }
         public DateTime DetainDate { get; set; }
         public decimal FineFees { get; set; }
         public int CreatedByUserID { get; set; }
         public UsersB CreatedByUserInfo { set; get; }
         public bool IsReleased { get; set; }
         public int ReleasedByUserID { get; set; }
         public UsersB ReleasedByUserInfo { set; get; }
         public int ReleaseApplicationID { get; set; }

        public DateTime ReleaseDate { get; set; }


         private enum _enMode { Update , AddNew};

         private _enMode _Mode = _enMode.Update;
         public DetainLicenseB()
         {
             this.DetainID = -1;
             this.LicenseID = -1;
             this.DetainDate = DateTime.Now;
             this.FineFees = 0.0m;
             this.CreatedByUserID = -1;
             this.IsReleased = false;
             this.ReleasedByUserID = -1;
             this.ReleaseApplicationID = -1;
             this.ReleaseDate = DateTime.Now;
            _Mode = _enMode.AddNew;
         }

         public DetainLicenseB(int DetainId, int LicenseId, DateTime DetainDate, decimal FineFees, int CreatedByUserId, bool IsReleased
             , int ReleasedByUserId, int ReleaseApplicationId, DateTime ReleaseDate)
         {
             this.DetainID = DetainId;
             this.LicenseID = LicenseId;
             this.DetainDate = DetainDate;
             this.FineFees = FineFees;
             this.CreatedByUserID = CreatedByUserId;
             this.CreatedByUserInfo = UsersB.FindUserByUserID(CreatedByUserId);
             this.IsReleased = IsReleased;
             this.ReleasedByUserID = ReleasedByUserId;
             this.ReleasedByUserInfo= UsersB.FindUserByUserID(CreatedByUserId);
             this.ReleaseApplicationID = ReleaseApplicationId;
             this.ReleaseDate = ReleaseDate;
            _Mode = _enMode.Update;
         }



         public static DetainLicenseB FindLicenseDetaByDetainID(int detainId)
            {
                int licenseId = -1, createdByUserId = -1, releasedByUserId = -1, releaseApplicationId = -1;
                DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
                decimal fineFees = 0;
                bool isReleased = false;

                if (DetainLicenseData.FindLicenseDeta(detainId, ref licenseId, ref detainDate, ref fineFees, 
                    ref createdByUserId, ref isReleased, ref releasedByUserId, ref releaseApplicationId, ref releaseDate))

                    return new DetainLicenseB(detainId, licenseId, detainDate, fineFees, createdByUserId, 
                        isReleased, releasedByUserId, releaseApplicationId, releaseDate);
                
                else
                
                    return null;
                
            }

         public static DetainLicenseB FindLicenseDetainByLicense(int LicenseID)
         {
            int detainId = -1, createdByUserId = -1, releasedByUserId = -1, releaseApplicationId = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
            decimal fineFees = 0;
            bool isReleased = false;

            if (DetainLicenseData.FindLicenseDeta(ref detainId, LicenseID, ref detainDate, ref fineFees,
                ref createdByUserId, ref isReleased, ref releasedByUserId, ref releaseApplicationId, ref releaseDate))

                return new DetainLicenseB(detainId, LicenseID, detainDate, fineFees, createdByUserId,
                    isReleased, releasedByUserId, releaseApplicationId, releaseDate);

            else

                return null;

         }

         private bool AddNewDetain()
         {
            this.DetainID = DetainLicenseData.AddNewDetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
            return this.DetainID != -1;
         }
         
         private bool UpdateDetainLicense()
         {
            return DetainLicenseData.UpdateDetainLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
         }
         public bool Save()
         {
            switch (_Mode)
            {
                case _enMode.Update:
                    if (UpdateDetainLicense())
                        return true;
                    break;

                case _enMode.AddNew:
                    AddNewDetain();
                    _Mode = _enMode.Update;
                    return true;
                   
                default:
                    return false;
                   
            }
            return false;
        }

         public static DataTable GetAllDetainLicense()
         {
            return DetainLicenseData.GetAllDetainLicense();
         }

         public static bool IsLicenseDetained(int LicenseID)
         {
            return DetainLicenseData.IsLicenseDetained(LicenseID);
         }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return DetainLicenseData.ReleasedDetainedLicense(this.DetainID,
                   ReleasedByUserID, ReleaseApplicationID);
        }

    }

    }

