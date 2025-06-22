using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD__DataAccess
{
    public class ApplicationTypesData
    {
        public static bool FindApplicationType(int ID, ref string Title, ref decimal Fees)
        {
            bool IsFound = false;


            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From ApplicationTypes Where ApplicationTypeID = @ID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ID", ID);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    Title = (string)Reader["ApplicationTypeTitle"];
                    Fees = (decimal)Reader["ApplicationFees"];
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

        public static DataTable GetApplicationTypes()
        {
            DataTable Table = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From ApplicationTypes";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.HasRows)
                    Table.Load(Reader);

                Reader.Close(); 
            }
            catch
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return Table;
        }

        public static bool  UpdateApplicationTypes(int ID , string Title , decimal Fees)
        {
            int RowsEffected = 0;


            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update ApplicationTypes 
                             Set ApplicationTypeTitle = @Title,
                                 ApplicationFees = @Fees
                                 Where ApplicationTypeID = @ID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@Title", Title);
            Command.Parameters.AddWithValue("@Fees", Fees);
            Command.Parameters.AddWithValue("@ID", ID);
            try
            {
                ConnectionDB.Open();

                RowsEffected = Command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                ConnectionDB.Close();
            }
            return RowsEffected > 0 ;

        }

    }
}
