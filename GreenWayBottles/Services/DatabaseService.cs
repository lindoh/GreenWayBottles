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
            string DataConnection = "Server = LAPTOP-J3M5FNUA; Database = GreenWayData; " +
                                    "Integrated Security=True; Encrypt=True; TrustServerCertificate=True;" +
                                    "User Instance=False";
            sqlConnection = new SqlConnection(DataConnection);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// Save Collector's Data in the Collector's Database Table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        public List<Users> GetAll()
        {
            List<Users> usersList = new();

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "GetAllCollectors";

                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                if(sqlDataReader.HasRows)
                {
                    Users user;

                    while(sqlDataReader.Read())
                    {
                        user = new();
                        user.Id = sqlDataReader.GetInt32(0);
                        user.FirstName = sqlDataReader.GetString(1);
                        user.LastName = sqlDataReader.GetString(2);

                        usersList.Add(user);
                    }
                    sqlDataReader.Close();

                }

                return usersList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }
}
