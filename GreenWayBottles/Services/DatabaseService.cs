using System.Data;
using Microsoft.Data.SqlClient;
using GreenWayBottles.Models;

namespace GreenWayBottles.Services
{
    public class DatabaseService
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public DatabaseService()
        {
            string DataConnection = "data source = localhost; integrated security = true; initial catalog=GreenWayData";
            sqlConnection = new SqlConnection(DataConnection);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public bool SaveData(Users user)
        {
            bool isSaved = false;

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "AddCollector";

                sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                sqlCommand.Parameters.AddWithValue("@IdNumber", user.IdNumber);
                sqlCommand.Parameters.AddWithValue("@Gender", user.Gender);
                sqlCommand.Parameters.AddWithValue("@HighestQlfn", user.HighestQlfn); ;
                sqlCommand.Parameters.AddWithValue("@IncomeRange", user.IncomeRange);
                sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                sqlCommand.Parameters.AddWithValue("@CellNumber", user.CellNumber);
                sqlCommand.Parameters.AddWithValue("@StreetAddress", user.StreetAddress);
                sqlCommand.Parameters.AddWithValue("@Suburb", user.Suburb);
                sqlCommand.Parameters.AddWithValue("@City", user.City);
                sqlCommand.Parameters.AddWithValue("@Province", user.Province);
                sqlCommand.Parameters.AddWithValue("@Country", user.Country);

                //Open Sql database connection
                sqlConnection.Open();

                //If affected number of rows is > 0, then data is saved successfully
                int NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
                isSaved = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            

            return isSaved;
        }

    }
}
