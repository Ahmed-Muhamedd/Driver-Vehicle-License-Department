using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public static class CountriesData
    {
        public static bool FindCountryByName(string CountryName , ref int CountryID)
        {
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = "Select CountryID From Countries Where CountryName = @CountryName";
            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                    CountryID = ID;

                return true;

            }catch(Exception Ex)
            {
                // Error Handling 
                return false;
            }
            finally
            {
                ConnectionDB.Close();
            }

        }

        public static bool FindCountryByID(ref string CountryName,  int CountryID)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = "Select CountryName From Countries Where CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    CountryName = (string)Result;
                    IsFound = true;

                }


            }
            catch (Exception Ex)
            {
                // Error Handling 
                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable TB = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select CountryName From Countries";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                    TB.Load(Reader);

            }catch(Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return TB;
        }


    }
}
