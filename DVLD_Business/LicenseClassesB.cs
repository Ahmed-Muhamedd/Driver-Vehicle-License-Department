using DVLD__DataAccess;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

namespace DVLD_Business
{
    public class LicenseClassesB
    {

        public int LicenseClassID { set; get; }
        public string ClassName{ set; get; }
        public string ClassDescription  { set; get; }
        public byte MinimumAge { set; get; }
        public byte ValidityLength { set; get; }
        public decimal ClassFees{ set; get; }


        private LicenseClassesB(int LicenseClassID, string ClassName, string ClassDescription , byte MinimumAge, byte ValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAge = MinimumAge;
            this.ValidityLength = ValidityLength;
            this.ClassFees = ClassFees;
        }

        public static LicenseClassesB FindLicenseClass(int LicenseClassID)
        {
            int LcID = LicenseClassID;
            string ClassName = "", ClassDesc = "";
            byte Min = 0;
            byte Length = 0;
            decimal Fees = -1;
            if (LicenseClassesData.FindLicenseClass(LcID, ref ClassName, ref ClassDesc, ref Min, ref Length, ref Fees))
                return new LicenseClassesB(LcID, ClassName, ClassDesc, Min, Length, Fees);
            else
                return null;
        }

        public static LicenseClassesB FindLicenseClass(string ClassName)
        {
            int LcID = -1;
            string  ClassDesc = "";
            byte Min = 0;
            byte Length = 0;
            decimal Fees = -1;
            if (LicenseClassesData.FindLicenseClass(ref LcID,  ClassName, ref ClassDesc, ref Min, ref Length, ref Fees))
                return new LicenseClassesB(LcID, ClassName, ClassDesc, Min, Length, Fees);
            else
                return null;
        }


        public static DataTable GetAllLicenseClass()
        {
            return LicenseClassesData.GetAllLicenseClasse();
        }

        public static int ReturnLicenseClassID(string ClassName)
        {
            return LicenseClassesData.ReturnLicenseClassID(ClassName);
        }

        public static bool IsPersonOwnedThisLicense(int PersonID ,string ClassName)
        {
            return LicenseClassesData.IsPersonOwnedThisLicense(PersonID, ClassName);
        }

    }
}
