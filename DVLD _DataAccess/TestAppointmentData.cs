using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLD__DataAccess
{
    public class TestAppointmentData
    {
        public static bool FindTestAppointmentByID(int TestAppointmentID , ref int TestTypeID , ref int LocalLicenseDrivingID , ref DateTime AppointmentDate,
            ref decimal PaidFees , ref int CreatedByUserID , ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = "Select * From TestAppointments Where TestAppointmentID = @TestAppoinID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@TestAppoinID", TestAppointmentID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestTypeID = (int)Reader["TestTypeID"];
                    LocalLicenseDrivingID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    IsLocked = (bool)Reader["IsLocked"];

                    if (Reader["RetakeTestApplicationID"] == System.DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)Reader["RetakeTestApplicationID"];

                }
                else
                {
                    IsFound = false;

                }

            }
            catch(Exception Ex)
            {
                IsFound = false;

            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsFound;
        }

        public static bool FindLastTestAppointment(ref int TestAppointmentID,  int TestTypeID, int LocalLicenseDrivingID, ref DateTime AppointmentDate,
            ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = @"Select top 1 * From TestAppointments Where 
                            TestTypeID = @TestTypeID And 
                            LocalDrivingLicenseApplicationID = @LocalID 
                            Order By TestAppointmentID Desc";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LocalID", LocalLicenseDrivingID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    IsLocked = (bool)Reader["IsLocked"];

                    if (Reader["RetakeTestApplicationID"] == System.DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)Reader["RetakeTestApplicationID"];

                }
                else
                {
                    IsFound = false;

                }

            }
            catch (Exception Ex)
            {
                IsFound = false;

            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllTestAppointments()
        {
            DataTable Tb = new DataTable();
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Selecet * From TestAppointments_View
                               Order By AppointmentDate Desc ";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Tb.Load(Reader);
                }
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

        public static int AddNewAppointment(int TestTypeID ,  int LocalDID , DateTime AppointmentDate , decimal PaidFees , int CreatedByUserID , bool IsLocked , int RetakeTestApplicationID)
        {
            int AppointmentID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into TestAppointments(TestTypeID , LocalDrivingLicenseApplicationID , AppointmentDate, PaidFees , CreatedByUserID , IsLocked , RetakeTestApplicationID)
                            Values(@TestTypeID , @LocalDID , @AppointmentDate ,@PaidFees , @CreatedByUserID ,@IsLocked,@RetakeTestApplicationID );
                            Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDID", LocalDID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if(RetakeTestApplicationID == -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);


            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    AppointmentID = InsertedID;

            }catch(Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return AppointmentID;

        }

        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees,
            int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {

            int RowsEffected = 0;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update  TestAppointments  
                            set TestTypeID = @TestTypeID,
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                AppointmentDate = @AppointmentDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsLocked=@IsLocked,
                                RetakeTestApplicationID=@RetakeTestApplicationID
                                where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);





            try
            {
                ConnectionDB.Open();
                RowsEffected = Command.ExecuteNonQuery();

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

            return (RowsEffected > 0);
        }

        public static DataTable FindPersonAppointments(int PersonID , int TestTypeID)
        {
            DataTable Table = new DataTable();
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select TestAppointments.TestAppointmentID , TestAppointments.AppointmentDate , TestAppointments.PaidFees
                            ,TestAppointments.IsLocked From TestAppointments 
                            Inner Join LocalDrivingLicenseApplications 
                            On LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            inner Join Applications 
                            On Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            Where Applications.ApplicantPersonID = @PersonID And TestTypes.TestTypeID = @TestTypeID";


            //string Query = @"Select TestAppointments.TestAppointmentID , TestAppointments.AppointmentDate , TestAppointments.PaidFees
            //                ,TestAppointments.IsLocked From TestAppointments 
            //                inner Join TestTypes On TestTypes.TestTypeID = TestAppointments.TestTypeID
            //                Inner Join LocalDrivingLicenseApplications 
            //                On LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
            //                inner Join Applications 
            //                On Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
            //                Where Applications.ApplicantPersonID = @PersonID And TestTypes.TestTypeID = @TestTypeID";


            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                Table.Load(Reader);

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return Table;
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Connection.ConnectionDB);

            string query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE  
                        (TestTypeID = @TestTypeID) 
                        AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

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
                connection.Close();
            }

            return dt;

        }

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string query = @"select TestID from Tests where TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, ConnectionDB);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                ConnectionDB.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;

        }


        // More Functions (Not Used)
        public static bool IsPersonHaveAppointment(int PersonID , int TestTypeID)
        {
            bool Exists = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"select 1 Where Exists(
                             Select TestAppointments.* From TestAppointments
                             Inner Join TestTypes On TestTypes.TestTypeID = TestAppointments.TestTypeID
                             Inner Join LocalDrivingLicenseApplications 
                             On LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             inner Join Applications 
                             On Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                             Where Applications.ApplicantPersonID = @PersonID And TestTypes.TestTypeID = @TestTypeID);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    Exists = true;

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return Exists;
        }

        public static bool IsPersonAppointmentLocked(int PersonID)
        {
            bool Locked = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @" Select 1 Where Exists(
                            Select TestAppointments.TestAppointmentID , TestAppointments.AppointmentDate , TestAppointments.PaidFees
                            ,TestAppointments.IsLocked From TestAppointments 
                            Inner Join LocalDrivingLicenseApplications 
                            On LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            inner Join Applications 
                            On Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            Where Applications.ApplicantPersonID = @PersonID and TestAppointments.IsLocked = 1);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    Locked = true;

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return Locked;
        }

        public static bool Update(int TestAppoitnmentID,DateTime Date)
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Update  TestAppointments Set AppointmentDate = @Date  Where TestAppointmentID = @TestAppID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@Date", Date);
            Command.Parameters.AddWithValue("@TestAppID", TestAppoitnmentID);

            try
            {
                ConnectionDB.Open();
                RowsEffected = Command.ExecuteNonQuery();

            }catch(Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return RowsEffected > 0;
        }

        public static bool Update(int TestAppoitnmentID)
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Update  TestAppointments Set IsLocked = 1  Where TestAppointmentID = @TestAppID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@TestAppID", TestAppoitnmentID);

            try
            {
                ConnectionDB.Open();
                RowsEffected = Command.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return RowsEffected > 0;
        }

    }
}
