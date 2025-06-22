using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DVLD__DataAccess
{
    public  class People
    {

        public static bool FindPeoplePersonID(int PersonID, ref string NationalNum, ref string FirstName, ref string SecondName
            , ref string ThirdName, ref string LastName , ref DateTime DateOfBirth, ref byte Gender , ref string Address , ref string Phone 
            , ref string Email , ref int NationalityCountryID , ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From People Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query , ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    NationalNum = (string)Reader["NationalNum"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] != null)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gender = (byte)Reader["Gender"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["Email"] != null)
                        Email = Convert.ToString(Reader["Email"]);
                    else
                        Email = "";

                    if (Reader["ImagePath"] != null)
                        ImagePath = Convert.ToString(Reader["ImagePath"]);
                    else
                        ImagePath = "";

                }
                else
                    IsFound = false;

                Reader.Close();

            }
            catch (Exception Ex)
            {
                //Error Handling :)
                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }
           return IsFound ;

        }

        public static bool FindPeopleNationalNumber(ref int PersonID,  string NationalNum, ref string FirstName, ref string SecondName
       , ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone
       , ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From People Where NationalNum = @NationalNum";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@NationalNum", NationalNum);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] != null)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gender = (byte)Reader["Gender"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["Email"] != null)
                        Email = Convert.ToString(Reader["Email"]);
                    else
                        Email = "";

                    if (Reader["ImagePath"] != null)
                        ImagePath = Convert.ToString(Reader["ImagePath"]);
                    else
                        ImagePath = "";
                }
                else
                    IsFound = false;


                Reader.Close();

            }
            catch (Exception Ex)
            {
                //Error Handling :)
                IsFound = false;
            }
            finally
            {
                ConnectionDB.Close();
            }
            return IsFound;

        }


        public static int AddNewPerson( string NationalNum,  string FirstName,  string SecondName
          ,  string ThirdName,  string LastName,  DateTime DateOfBirth,  byte Gender,  string Address,  string Phone
          ,  string Email,  int NationalityCountryID,  string ImagePath)
        {
            int ID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into People (NationalNum , FirstName ,  SecondName ,ThirdName, LastName,DateOfBirth, Gender ,Address
                            ,Phone,Email ,NationalityCountryID , ImagePath )
                            Values ( @NationalNum , @FirstName , @SecondName , @ThirdName , @LastName , @DateOfBirth ,@Gender , @Address,
                                    @Phone , @Email , @NationalityCountryID , @ImagePath); 
                            Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@NationalNum", NationalNum);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if(Email != "")
                 Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            if( ImagePath != "" && ImagePath != null)
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    ID = InsertedID;

            }
            catch (Exception Ex)
            {
                //Error Handling :)
            }
            finally
            {
                ConnectionDB.Close();
            }
            return ID;
        }

        public static bool UpdatePerson(int PersonID , string NationalNum, string FirstName, string SecondName
          , string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone
          , string Email, int NationalityCountryID, string ImagePath)
        {
            int RowsEffected = 0;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update People Set FirstName = @FirstName , 
                                           SecondName = @SecondName,    
                                           ThirdName = @ThirdName,
                                           LastName = @LastName,    
                                           DateOfBirth = @DateOfBirth, 
                                           NationalNum = @NationalNum,
                                           Gender = @Gender, 
                                           Address = @Address,
                                           Phone = @Phone,
                                           Email = @Email ,
                                           NationalityCountryID = @NationalityCountryID,
                                           ImagePath = @ImagePath
                                           Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@NationalNum", NationalNum);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (Email != "" && Email != null)
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            if (ImagePath != "" && ImagePath != null)
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                ConnectionDB.Open();


                RowsEffected = Command.ExecuteNonQuery();
        

            }
            catch (Exception Ex)
            {
                //Error Handling :)
            }
            finally
            {
                ConnectionDB.Close();
            }

            return RowsEffected == 1 ;
        
        }

        public static bool DeletePerson(int PersonID)
        {
            int RowsEffected = 0;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Delete From People Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                ConnectionDB.Open();


                RowsEffected = Command.ExecuteNonQuery();


            }
            catch (Exception Ex)
            {
                //Error Handling :)
            }
            finally
            {
                ConnectionDB.Close();
            }

            return RowsEffected == 1;

        }

        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @" Select 1 Where Exists ( Select 1 From People Where PersonID = @PersonID)";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                ConnectionDB.Open();

                IsFound = Command.ExecuteScalar() != null;
            }
            catch (Exception Ex)
            {
                //Error Handling :)
                IsFound = false;

            }
            finally
            {
                ConnectionDB.Close();
            }




            return IsFound;
        }

        public static bool IsPersonExist(string NationalNumber)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @" Select 1 Where Exists ( Select 1 From People Where NationalNum = @NationalNum)";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@NationalNum", NationalNumber);

            try
            {
                ConnectionDB.Open();

                IsFound = Command.ExecuteScalar() != null;
            }
            catch (Exception Ex)
            {
                //Error Handling :)
                IsFound = false;

            }
            finally
            {
                ConnectionDB.Close();
            }




            return IsFound;
        }

        public static DataTable GetAllPeople()
        {
            DataTable Tb = new DataTable();


            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select People.PersonID , People.NationalNum , People.FirstName , People.SecondName , People.ThirdName 
                            , People.LastName , 
                            case 
                            When Gender = 0 Then 'Male'
                            When Gender = 1 Then 'Female'
                            Else 'Unkown'
                            End As Gender
                            , People.DateOfBirth , Countries.CountryName As Nationality ,
                            People.Phone ,
                            case
							when People.Email is not null then People.Email
                            when People.Email is null then 'NULL'
							End
							As Email 
                            From People 
                            inner join Countries on People.NationalityCountryID = Countries.CountryID
                            Order By People.FirstName;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
       

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    Tb.Load(Reader);

                Reader.Close();

            }
            catch (Exception Ex)
            {
                //Error Handling:
            }
            finally
            {
                ConnectionDB.Close();
            }


            return Tb;
        }


        public static int GetPersonID(string NaitonalNumber)
        {
            int PersonID = -1;


            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select PersonID From People Where NationalNum = @NationalNum";


            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@NationalNum", NaitonalNumber);

            try
            {
                ConnectionDB.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int PID))
                    PersonID = PID;

            }
            catch (Exception Ex)
            {
                //Error Handling:
            }
            finally
            {
                ConnectionDB.Close();
            }


            return PersonID;
        }

    }
}
