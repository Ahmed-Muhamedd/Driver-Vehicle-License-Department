using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class InternationalLicense
    {
        public static bool FindInternationalLicense(int InterID,ref int ApplicationID, ref int LocalLicenseID, ref int DriverID, ref DateTime IssueDate 
            , ref DateTime ExpirationDate , ref bool IsActive , ref int CreatedByUserID)
        {
            bool IsFound = false;


            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From InternationalLicenses Where InternationalLicenseID = @ID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ID", InterID);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    LocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsFound = true;

                }
                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;

        }
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int LocalLicenseID , DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int InterID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @" Update InternationalLicenses Set IsActive = 0 Where DriverID = @DriverID;

                 Insert Into InternationalLicenses(ApplicationID, DriverID, IssuedUsingLocalLicenseID ,IssueDate, ExpirationDate ,IsActive,CreatedByUserID )
                 Values( @ApplicationID , @DriverID ,@LocalLicenseID , @IssueDate,@ExpirationDate , @IsActive ,@CreatedByUserID );

                 Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    InterID = InsertedID;

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return InterID;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable TB = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @" SELECT InternationalLicenseID, ApplicationID,DriverID, IssuedUsingLocalLicenseID , IssueDate, ExpirationDate, IsActive
		                      from InternationalLicenses 
                              order by IsActive, ExpirationDate desc";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                TB.Load(Reader);

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return TB;
        }

        public static DataTable GetDriverInternationaLicenses(int DriverID)
        {
            DataTable Tb = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = @"SELECT    InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID , IssueDate, ExpirationDate, IsActive
		                    from InternationalLicenses where DriverID = @DriverID
                            order by ExpirationDate desc";
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

        public static int GetActiveInternationalLicenseID(int DriverID)
        {
            int InternationalLicenseID = -1;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @" SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID = @DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                ConnectionDB.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                ConnectionDB.Close();
            }


            return InternationalLicenseID;
        }
    }
}
