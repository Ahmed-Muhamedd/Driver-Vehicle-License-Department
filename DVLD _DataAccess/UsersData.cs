using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class UsersData
    {
        public static bool FindUserByPersonID(int PersonID , ref int UserID , ref string UserName , ref string Password , ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From Users Where PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    UserName = (string)Reader["UserName"];
                    UserID = (int)Reader["UserID"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                    IsFound = true;
                }
                Reader.Close();

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);

                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;
        }

        public static bool FindUserByUserID(ref int PersonID, int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From Users Where UserID = @UserID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    UserName = (string)Reader["UserName"];
                    PersonID = (int)Reader["PersonID"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                    IsFound = true;
                }
                Reader.Close();

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);

                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;
        }

        public static bool FindUserByUserNameAndPassword(ref int PersonID, ref int UserID,  string UserName,  string Password, ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From Users Where UserName = @UserName And Password = @Password;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    UserID = (int)Reader["UserID"];
                    IsActive = (bool)Reader["IsActive"];

                    IsFound = true;
                }
                Reader.Close();

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);

                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;
        }

        public static bool IsPersonIsUser(int PersonID)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"  Select 1 Where Exists 
                               (Select Users.PersonID From Users 
                                where Users.PersonID = @PersonID);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                ConnectionDB.Open();
                IsFound = Command.ExecuteScalar() != null ? true : false;

            }
            catch (Exception Ex)
            {
                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound ;
        }

        public static int AddNewUser(int PersonID , string UserName ,  string Password , bool IsActive)
        {
            int ID = -1;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into Users (PersonID , UserName , Password , IsActive)
                             Values (@PersonID , @UserName , @Password ,@IsActive);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    ID = InsertedID;

            }
            catch (Exception Ex)
            {
               
            }
            finally
            {
                ConnectionDB.Close();
            }

            return ID;
        }

        public static bool UpdateUser(int UserID , string UserName , string Password , bool IsActive)
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update Users Set UserName = @UserName,
                                              Password = @Password,
                                              IsActive = @IsActive
                                                Where UserID = @UserID ;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@UserID", UserID);

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

        public static DataTable GetAllUsers()
        {
            DataTable UsersTable = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select	Users.UserID , Users.PersonID ,  People.FirstName + ' ' + People.SecondName + ' ' 
                            + People.ThirdName + ' ' + People.LastName As FullName  , Users.UserName , Users.IsActive From Users
                            inner join People On People.PersonID = Users.PersonID ;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
              
                UsersTable.Load(Reader);

                Reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return UsersTable;

        }

        public static bool IsUserExists(int UserID)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists 
                            (Select UserName From Users 
                             Where UserID = @UserID)";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                ConnectionDB.Open();
                IsFound = Command.ExecuteScalar() != null ? true : false;
            }catch(Exception Ex)
            {
                IsFound = false;

            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsFound;
        }

        public static bool IsUserExists(string UserName)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists 
                            (Select UserName From Users 
                             Where UserName = @UserName)";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                ConnectionDB.Open();
                IsFound = Command.ExecuteScalar() != null ? true : false;
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

        public static bool DeleteUser(int UserID)
        {
            int RowEffected = 0;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Delete From Users Where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                ConnectionDB.Open();
                RowEffected = Command.ExecuteNonQuery();

            }catch(Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return RowEffected  > 0 ;
        }

        public static bool ChangePassword(int UserID , string NewPassword)
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Update  Users Set Password = @NewPassword  Where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@NewPassword", NewPassword);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                ConnectionDB.Open();

                RowsEffected = Command.ExecuteNonQuery();

            }catch(Exception ex)
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
