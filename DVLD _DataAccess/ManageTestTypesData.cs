using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class ManageTestTypesData
    {
        public static bool FindTest(int ID, ref string Title , ref string Description, ref decimal Fees)
        {
            bool IsFound = false;


            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From TestTypes Where TestTypeID = @ID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@ID", ID);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Title = (string)Reader["TestTypeTitle"];
                    Description = (string)Reader["TestTypeDescription"];
                    Fees = (decimal)Reader["TestTypeFees"];
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

        public static DataTable GetTestTypes()
        {
            DataTable Table = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From TestTypes";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            try
            {
                ConnectionDB.Open();

                SqlDataReader Reader = Command.ExecuteReader();
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

        public static bool UpdateTestTypes(int ID, string Title,string Description, decimal Fees)
        {
            int RowsEffected = 0;


            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Update TestTypes 
                             Set TestTypeTitle = @Title,
                                 TestTypeDescription = @Description,
                                 TestTypeFees = @Fees
                                 Where TestTypeID = @ID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@Title", Title);
            Command.Parameters.AddWithValue("@Description", Description);
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
            return RowsEffected > 0;

        }

    }
}
