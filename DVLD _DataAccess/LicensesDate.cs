using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class LicensesDate
    {


        public static bool FindLicense(ref int ApplicationID,  int LicenseID, ref DateTime IssueDate, ref byte IssueReason, ref int DriverID, ref string Notes, ref DateTime ExpireDate,
                                      ref bool IsActive , ref int LicenseClassID , ref decimal PaidFees , ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From Licenses Where LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClass"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    IssueReason = (byte)Reader["IssueReason"];
                    Notes = (string)Reader["Notes"];
                    ExpireDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    DriverID = (int)Reader["DriverID"];
                    IsFound = true;
                }

                Reader.Close();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;
        }

        public static bool FindLicense(int LocalLicenseID,ref int ApplicationID, ref int LicenseID, ref DateTime IssueDate, ref byte IssueReason, ref int DriverID, ref string Notes, ref DateTime ExpireDate,
                                     ref bool IsActive, ref int LicenseClassID, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select Licenses.* From Licenses 
                            Inner Join LocalDrivingLicenseApplications On LocalDrivingLicenseApplications.ApplicationID = Licenses.ApplicationID
                            Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LLID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LLID", LocalLicenseID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseID = (int)Reader["LicenseID"];
                    LicenseClassID = (int)Reader["LicenseClass"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    IssueReason = (byte)Reader["IssueReason"];
                    Notes = (string)Reader["Notes"];
                    ExpireDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    DriverID = (int)Reader["DriverID"];
                    IsFound = true;
                }

                Reader.Close();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;
        }
        public static int AddNewLicense(int ApplicationID, int DriverID, int LiceneseClassID , DateTime IssueDate , DateTime ExpirationDate 
                                       ,string Notes , decimal PaidFees , bool IsActive , byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into Licenses(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
                            Values( @ApplicationID,@DriverID,@LiceneseClassID,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);
                            Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LiceneseClassID", LiceneseClassID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    LicenseID = InsertedID;

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return LicenseID;
        }


        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable Tb = new DataTable();
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = @"Select Licenses.LicenseID , Licenses.ApplicationID , LicenseClasses.ClassName , Licenses.IssueDate , Licenses.ExpirationDate,
                            Licenses.IsActive From Licenses Inner Join LicenseClasses On LicenseClasses.LicenseClassID = Licenses.LicenseClass
                            Where Licenses.DriverID = @DriverID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    Tb.Load(Reader);

                Reader.Close();
            }catch(Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return Tb;
        }


        public static int FindActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select Licenses.LicenseID From Licenses 
                             Inner Join Drivers On Drivers.DriverID = Licenses.DriverID
                             Where Drivers.PersonID = @PersonID
                                   And Licenses.LicenseClass = @LicenseClassID
                                   And IsActive = 1";


            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    LicenseID = InsertedID;
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return LicenseID;

        }

        public static bool IsLicenseHaveInternationalLicense(int InternationalLicense)
        {
            bool IsExist = false;

            DataTable Table = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists(
                            Select InternationalLicenses.InternationalLicenseID From InternationalLicenses
                            Inner Join Licenses On Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
                            Where Licenses.LicenseID = @InternationalLicense);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@InternationalLicense", InternationalLicense);

            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    IsExist = true;
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsExist;
        }

        public static bool DisableLicense(int LicenseID)
        {
            bool Disabled = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update Licenses Set IsActive = 0 Where LicenseID = @LID ;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LID", LicenseID);

            try
            {
                ConnectionDB.Open();


                Disabled = Command.ExecuteNonQuery() > 0;
                
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return Disabled;
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            bool IsActive = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists (Select * From  Licenses  Where LicenseID = @LID And IsActive = 1);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LID", LicenseID);

            try
            {
                ConnectionDB.Open();


                object Result = Command.ExecuteScalar();
                if (Result != null)
                    IsActive = true;

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsActive;
        }


    }


}
