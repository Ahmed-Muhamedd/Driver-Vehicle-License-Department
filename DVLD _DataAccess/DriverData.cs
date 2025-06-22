using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class DriverData
    {

        public static bool FindDriver(ref int DriverID , int PersonID , ref int CreatedByUserID ,ref DateTime CreatedDate)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From Drivers Where PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);



            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    DriverID = (int)Reader["DriverID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];
                   

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

        public static bool FindDriver( int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From Drivers Where DriverID = @DriverID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@DriverID", DriverID);



            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];


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

        public static DataTable GetAllDrivers()
        {
            DataTable Table = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From Drivers_View";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                Table.Load(Reader);
                Reader.Close();

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

        public static int AddNewDriver(int PersonID , int CreatedByUserID)
        {
            int DriverID = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into Drivers(PersonID, CreatedByUserID, CreatedDate)
                            Values( @PersonID , @CreatedByUserID ,@CreatedDate);
                            Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);


            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    DriverID = InsertedID;

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return DriverID;
        }


    }
}
