using DVLD__DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class ApplicationTypesB
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        private ApplicationTypesB(int ID , string Title , decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;

        }

        public static ApplicationTypesB FindApplicationType(int ID)
        {
            string Title = "";
            decimal Fees = 0;

            if (ApplicationTypesData.FindApplicationType(ID, ref Title, ref  Fees))
                return new ApplicationTypesB(ID, Title, Fees);
            else
                return null;
        }

        public static DataTable GetApplicationTypes()
        {
            return ApplicationTypesData.GetApplicationTypes();
        }

        private bool _Update()
        {
            return ApplicationTypesData.UpdateApplicationTypes(this.ID, this.Title, this.Fees);
        }

        public bool Save()
        {
            if (_Update())
                return true;
            else
                return false;
        }
    }
}
