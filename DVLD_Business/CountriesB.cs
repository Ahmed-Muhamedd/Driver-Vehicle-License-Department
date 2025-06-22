using DVLD__DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_Business
{
    public class CountriesB
    {
        public int CountryID { get; set; }
        public string CountryName{ get; set; }

        private CountriesB(int CountryID , string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            
        }

        public static CountriesB FindCountryByID(int CountryID)
        {
            int ID= CountryID;
            string CountryName = "";
            if (CountriesData.FindCountryByID(ref CountryName, ID))
                return new CountriesB(ID, CountryName);
            else
                return null; 

        }
        public static CountriesB FindCountry(string CountryName)
        {
            int CountryID = 0;
            if (CountriesData.FindCountryByName(CountryName, ref CountryID))
                return new CountriesB(CountryID, CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return CountriesData.GetAllCountries();
        }

    }
}
