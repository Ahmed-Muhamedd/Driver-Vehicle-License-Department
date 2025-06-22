    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class TestTypesData
    {

        public static bool FindTestType(ref string TestTitle , int TestTypeID , ref string TestDescription , ref decimal TestFees)
        {
            bool IsFound = false;

            SqlConnection ConnnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select * From TestTypes Where TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, ConnnectionDB);
            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);

            try
            {
                ConnnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    TestTitle = (string)Reader["TestTypeTitle"];
                    TestDescription = (string)Reader["TestTypeDescription"];
                    TestFees = (decimal)Reader["TestTypeFees"];
                    IsFound = true;
                }

                Reader.Close();
            }catch(Exception Ex)
            {

            }
            finally
            {
                ConnnectionDB.Close();
            }

            return IsFound;

        }

        public static byte ReturnTestTypeID(string TestTitle)
        {
            byte TestTypeID = 5;

            SqlConnection ConnnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = "Select TestTypeID From TestTypes Where TestTypeTitle = @TestTitle";

            SqlCommand Command = new SqlCommand(Query, ConnnectionDB);
            Command.Parameters.AddWithValue("@TestTitle", TestTitle);
            try
            {
                ConnnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && byte.TryParse(Result.ToString(), out byte InsertedID))
                    TestTypeID = InsertedID;

               
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnnectionDB.Close();
            }

            return TestTypeID;
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

        public static bool UpdateTestTypes(int ID, string Title, string Description, decimal Fees)
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
