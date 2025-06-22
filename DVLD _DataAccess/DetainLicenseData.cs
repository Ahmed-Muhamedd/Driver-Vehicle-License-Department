using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD__DataAccess
{
    public class DetainLicenseData
    {

        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID )
        {
            int DetainLicense = -1;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Insert Into DetainedLicenses(LicenseID,DetainDate,FineFees ,CreatedByUserID,IsReleased)
                            Values( @LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased);
                            Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", 0);
        



            try
            {
                ConnectionDB.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    DetainLicense = InsertedID;

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return DetainLicense;
        }

        public static bool FindLicenseDeta(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID
                , ref bool IsReleased, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref DateTime ReleaseDate)
            {
                bool IsFound = false;

                SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

                string Query = @"SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

                SqlCommand Command = new SqlCommand(Query, ConnectionDB);
                Command.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    ConnectionDB.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {
                        LicenseID = (int)Reader["LicenseId"];
                        DetainDate = (DateTime)Reader["DetainDate"];
                        FineFees = (decimal)Reader["FineFees"];
                        CreatedByUserID = (int)Reader["CreatedByUserId"];
                        IsReleased = (bool)Reader["IsReleased"];
                        ReleasedByUserID = (int)Reader["ReleasedByUserId"];
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationId"];
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                        IsFound = true;
                    }
                }
                catch (Exception ex)
                {
                    // Optional: Log the exception
                }
                finally
                {
                    ConnectionDB.Close();
                }

                return IsFound;
            }

        public static bool FindLicenseDeta(ref int DetainID,  int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID
            , ref bool IsReleased, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref DateTime ReleaseDate)
        {
            bool IsFound = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"SELECT * FROM DetainedLicenses WHERE LicenseID= @LicenseID";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                ConnectionDB.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (decimal)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];
                    if (Reader["ReleasedByUserId"] == System.DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                         ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == System.DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

                    if (Reader["ReleaseDate"] == System.DBNull.Value)
                        ReleaseDate = DateTime.MinValue;
                    else
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                // Optional: Log the exception
            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsFound;
        }


        public static bool UpdateDetainLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees
            , int CreatedByUserID)
        {
            int RowsEffected = 0;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);
            
            string Query = @"UPDATE DetainedLicenses
                             SET LicenseID = @LicenseId,
                             DetainDate = @DetainDate,
                             FineFees = @FineFees,
                             CreatedByUserID = @CreatedByUserId";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@DetainId", DetainID);
            Command.Parameters.AddWithValue("@LicenseId", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserID);
       

            try
            {
                ConnectionDB.Open();
                RowsEffected = Command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                // Log the error or handle it
            }
            finally
            {
                ConnectionDB.Close();

            }

            return RowsEffected > 0;
        }

        public static bool  ReleasedDetainedLicense(int DetainID , int ReleasedByUserID , int ReleaseApplicationID)
        {

            int RowsAffected = 0;
            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleasedByUserID = @ReleasedByUserID,
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID = @DetainID;";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            Command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
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

        public static DataTable GetAllDetainLicense()
        {
            DataTable Table = new DataTable();

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select * From DetainedLicenses_View;";

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

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection ConnectionDB = new SqlConnection(Connection.ConnectionDB);

            string Query = @"Select 1 Where Exists ( Select * From DetainedLicenses 
                            Where LicenseID = @LicenseID And IsReleased = 0);";

            SqlCommand Command = new SqlCommand(Query, ConnectionDB);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                ConnectionDB.Open();

                IsDetained = Command.ExecuteScalar() != null ? true : false;
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                ConnectionDB.Close();
            }

            return IsDetained;
        }

    }
}
