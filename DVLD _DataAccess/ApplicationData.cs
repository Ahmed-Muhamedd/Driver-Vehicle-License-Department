using System;
using System.Data.SqlClient;

namespace DVLD__DataAccess
{
    public class ApplicationData
    {

        public static int AddNewApplication(int PersonID , DateTime ApplicationDate , int ApplicationTypeID , int ApplicationStatus ,
                                              DateTime LastStatusDate , decimal PaidFees ,int CreatedUser)
        {
            int AppID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into Applications (ApplicantPersonID , ApplicationDate , ApplicationTypeID , ApplicationStatus , LastStatusDate , PaidFees , CreatedByUserID)
                             Values(@PersonID , @AppDate , @AppTypeID , @AppStatus , @LastStatusDate , @PaidFees , @CreatedUser);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@AppDate", ApplicationDate);
            Command.Parameters.AddWithValue("@AppTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@AppStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedUser", CreatedUser);

            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    AppID = InsertedID;

            }catch(Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return AppID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
          int ApplicationStatus, DateTime LastStatusDate,
          decimal PaidFees, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(Connection.ConnectionDB);

            string query = @"Update  Applications  
                            set ApplicantPersonID = @ApplicantPersonID,
                                ApplicationDate = @ApplicationDate,
                                ApplicationTypeID = @ApplicationTypeID,
                                ApplicationStatus = @ApplicationStatus, 
                                LastStatusDate = @LastStatusDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID=@CreatedByUserID
                            where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("ApplicantPersonID", @ApplicantPersonID);
            command.Parameters.AddWithValue("ApplicationDate", @ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", @ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationStatus", @ApplicationStatus);
            command.Parameters.AddWithValue("LastStatusDate", @LastStatusDate);
            command.Parameters.AddWithValue("PaidFees", @PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", @CreatedByUserID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool FindApplicationWithLDlAppViewID( int LDLAppID, ref int ApplicationID ,  ref int PersonID, ref DateTime ApplicationDate, 
            ref int ApplicationTypeID, ref int ApplicationStatus , ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedUser)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select Applications.* From Applications 
                            Inner Join LocalDrivingLicenseApplications On LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLAppID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
  
     

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    PersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedUser = (int)Reader["CreatedByUserID"];
                    IsFound = true;
                }
                Reader.Close();

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

        public static bool FindApplicationByID (int ApplicationID, ref int PersonID, ref DateTime ApplicationDate,
        ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedUser)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From Applications Where ApplicationID = @AppID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@AppID", ApplicationID);



            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    PersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedUser = (int)Reader["CreatedByUserID"];
                    IsFound = true;
                }
                Reader.Close();

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

        public static bool DeleteApplication(int ApplicationID)
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Delete From Applications Where ApplicationID = @AppID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("AppID", ApplicationID);

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

        public static bool IsApplicationExists(int ApplicationID)
        {
            bool IsDeleted = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = @"Select 1 Where Exists (
                             Select ApplicationID From Application 
                             Where ApplicationID = @AppID)";
            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("AppID", ApplicationID);

            try
            {
                ConnectionDB.Open();
                IsDeleted = Command.ExecuteScalar() != null ? true : false;
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsDeleted;
        }

        public static int FindActiveApplicationID(int ApplicationID , int PersonID)
        {
            int AppID = -1;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            string Query = @"Select ApplicationID As ActiveApplicationID From Applications
                            Where ApplicationID = @AppID And 
                                  ApplicantPersonID = @PersonID And
                                  ApplicationStatus = 1;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@AppID", ApplicationID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    AppID = InsertedID;
            
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }



            return AppID;

        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {

            //incase the ActiveApplication ID !=-1 return true.
            return (FindActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(Connection.ConnectionDB);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static bool CanAddNewApplication(int PersonID , string ClassName )
        {
            bool Can = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists(
                            Select Applications.*
                             From LicenseClasses 
                            Inner Join LocalDrivingLicenseApplications On LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                            inner Join Applications On Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            Inner Join People On People.PersonID = Applications.ApplicantPersonID
                            Where People.PersonID = @PersonID And LicenseClasses.ClassName = @ClassName And 
                            Applications.ApplicationStatus in (1,3));";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@ClassName", ClassName);


            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null)
                    Can = true;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return Can;
        }

        public static bool CancelApplication(int LocalLicenseID)
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update Applications 
                            Set Applications.ApplicationStatus = 2
                            From Applications
                            Inner Join LocalDrivingLicenseApplications On LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalLicenseID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);


            try
            {
                ConnectionDB.Open();

                RowsEffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return RowsEffected > 0;
        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(Connection.ConnectionDB);

            string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool ApplicationStatusCompeleted(int ApplicationID )
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update Applications 
                            Set Applications.ApplicationStatus = 3
                            Where ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


            try
            {
                ConnectionDB.Open();

                RowsEffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
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
