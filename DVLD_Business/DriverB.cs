using DVLD__DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class DriverB
    {
        public int DriverID { set; get; }
        public int PersonID { set; get; }
        
        public PeopleBusiness PersonInfo { set; get; } 

        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate{ set; get; }


        public DriverB()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

        }

        private DriverB(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.PersonInfo = PeopleBusiness.FindPerson(PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        } 


        public static DriverB FindDriver(int PersonID)
        {
            int  DriverID = -1, CreatedByUserID = -1;
            DateTime CreateDate = DateTime.Now;
            if (DriverData.FindDriver(ref DriverID, PersonID, ref CreatedByUserID, ref CreateDate))
                return new DriverB(DriverID, PersonID, CreatedByUserID, CreateDate);
            else
                return null;
        }

        public static DriverB FindDriverByDriverID(int DriverID)
        {
            int P = -1,  CreatedByUserID = -1;
            DateTime CreateDate = DateTime.Now;
            if (DriverData.FindDriver( DriverID, ref P, ref CreatedByUserID, ref CreateDate))
                return new DriverB(DriverID, P, CreatedByUserID, CreateDate);
            else
                return null;
        }
        private bool _AddNewDriver()
        {
            this.DriverID = DriverData.AddNewDriver(this.PersonID, this.CreatedByUserID);

            return this.DriverID != -1;
        }

        public static DataTable GetAllDrivers()
        {
            return DriverData.GetAllDrivers();
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return LicensesB.GetDriverLicenses(DriverID);
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return InternationalLicenseB.GetDriverInternationalLicenses(DriverID);
        }

        public bool Save()
        {
            if (_AddNewDriver())
                return true;
            else
                return false;
        }


    }
}
