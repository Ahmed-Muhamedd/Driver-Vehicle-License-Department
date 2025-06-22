using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD__DataAccess
{
    public class LicenseClassesData
    {
        public static bool FindLicenseClass(int LicenseClassID , ref string ClassName , ref string ClassDescription ,
            ref byte MinimumAge ,ref byte ValidityLength,ref decimal ClassFess)
        {
            bool IsFound = false;
            
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From   LicenseClasses Where  LicenseClassID= @LicenseClassID ";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ClassName = (string)Reader["ClassName"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAge = (byte)Reader["MinimumAllowedAge"];
                    ValidityLength = (byte)Reader["DefaultValidityLength"];
                    ClassFess = (decimal)Reader["ClassFees"];
                    IsFound = true;
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }


            return IsFound; ;

        }


        public static bool FindLicenseClass(ref int LicenseClassID,  string ClassName, ref string ClassDescription, ref byte MinimumAge, 
            ref byte ValidityLength,ref decimal ClassFess)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From   LicenseClasses Where  ClassName = @ClassName ";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAge = (byte)Reader["MinimumAllowedAge"];
                    ValidityLength = (byte)Reader["DefaultValidityLength"];
                    ClassFess = (decimal)Reader["ClassFees"];
                    IsFound = true;
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }


            return IsFound; ;

        }

      

        public static DataTable GetAllLicenseClasse()
        {
            DataTable Tb = new DataTable();
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From LicenseClasses";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                Tb.Load(Reader);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return Tb;
        }
        
        public static int ReturnLicenseClassID(string ClassName)
        {
            int AppID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select LicenseClassID From LicenseClasses Where ClassName = @ClassName";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ClassName", ClassName);
    

            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    AppID = InsertedID;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }


            return AppID;

        }

        public static bool IsPersonOwnedThisLicense(int PersonID , string ClassName)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists(
                            Select LicenseClasses.ClassName , LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID 
                            ,Applications.ApplicationID , People.PersonID
                             From LicenseClasses 
                            Inner Join LocalDrivingLicenseApplications On LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                            inner Join Applications On Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            Inner Join People On People.PersonID = Applications.ApplicantPersonID
                            Where People.PersonID = @PersonID And LicenseClasses.ClassName = @ClassName)";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@ClassName", ClassName);


            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null)
                    IsFound = true;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }


            return IsFound;
        }

    }
}
