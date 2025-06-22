using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class TestData
    {
        public static bool FindTestByID(int TestID,ref int TestAppointmentID, ref bool TestResult,ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "SELECT * FROM Tests WHERE TestID = @TestID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    IsFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    IsFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsFound;
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID, int LicenseClassID, int TestTypeID, ref int TestID,
            ref int TestAppointmentID, ref bool TestResult,ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON
                                         LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                                         INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    IsFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    IsFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "SELECT * FROM Tests order by TestID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                ConnectionDB.Close();
            }

            return dt;

        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,string Notes, int CreatedByUserID)
        {

            int RowsAffected = 0;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update  Tests  
                            set TestAppointmentID = @TestAppointmentID,
                                TestResult=@TestResult,
                                Notes = @Notes,
                                CreatedByUserID=@CreatedByUserID
                                where TestID = @TestID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                ConnectionDB.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                ConnectionDB.Close();
            }

            return (RowsAffected > 0);
        }

        public static int AddNewTest(int TestAppointmentID , bool TestResult , string Notes ,int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into Tests(TestAppointmentID , TestResult ,Notes ,CreatedByUserID)
                            Values(@TestAppID , @TestResult , @Notes , @UserID);
                            
                            Select Scope_Identity();

                            Update TestAppointments Set 
                            TestAppointments.IsLocked = 1 
                            Where TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@TestAppID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@UserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    TestID = InsertedID;

            }catch(Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return TestID;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"SELECT PassedTestCount = count(TestTypeID)
                             FROM Tests INNER JOIN
                             TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						     where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult = 1";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                ConnectionDB.Open();

                object result = Command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
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

            return PassedTestCount;



        }

        // More Functions (Not Used)
        public static bool IsTestExists(int TestAppointmentID)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @" Select 1 Where Exists(
                            Select Tests.* From Tests 
                            Inner join TestAppointments On TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            Where TestAppointments.TestAppointmentID = @TestAppID);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@TestAppID", TestAppointmentID);


            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null )
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

        public static bool IsPassedTest(int LocalDid , int PersonID, int TestType)
        {
            bool Passed = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists(
                         Select Tests.* From Tests 
                         Inner join TestAppointments 
                         On TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                         Inner Join TestTypes On TestTypes.TestTypeID = TestAppointments.TestTypeID
                         inner join LocalDrivingLicenseApplications 
                         On LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                         Inner Join Applications 
                         On Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                         Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalID And Tests.TestResult = 1 
                         And Applications.ApplicantPersonID = @PersonID And TestTypes.TestTypeID = @TestType);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LocalID", LocalDid);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@TestType", TestType);


            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null)
                    Passed = true;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return Passed;
        }

    }
}
