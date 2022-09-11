using System.Data;
using Microsoft.Data.SqlClient;
using GreenWayBottles.Models;

//    TO DO:
// Formalize SqlExceptions to match what caused the error
// Add Comments

namespace GreenWayBottles.Services
{
    public class DatabaseService
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        #region Default Constructor
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

        #endregion

        #region SaveData Method for Collector
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

        #endregion

        #region GetAll User's Data 
        /// <summary>
        /// Get all data that matches a given name, i.e., Firstname
        /// </summary>
        /// <returns>List of users that matches Firstname</returns>
        public List<Users> Search(string name, string selectedUser)
        {
            List<Users> usersList = new();
            string userToSearch = "SearchCollector";

            //Update the userToSearch variable to select the correct 
            //Stored Procedure for the search
            if (selectedUser == "Admin")
                userToSearch = "SearchAdmin";
            else if (selectedUser == "Admin")
                userToSearch = "SearchCollector";

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = userToSearch;
                sqlCommand.Parameters.AddWithValue("@FirstName", name);

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
                        user.IdNumber = sqlDataReader.GetString(3);
                        user.Gender = sqlDataReader.GetString(4);
                        user.HighestQlfn = sqlDataReader.GetString(5);
                        user.IncomeRange = sqlDataReader.GetString(6);
                        user.Email = sqlDataReader.GetString(7);
                        user.CellNumber = sqlDataReader.GetString(8);
                        user.StreetAddress = sqlDataReader.GetString(9);
                        user.Suburb = sqlDataReader.GetString(10);
                        user.City = sqlDataReader.GetString(11);
                        user.Province = sqlDataReader.GetString(12);
                        user.Country = sqlDataReader.GetString(13);

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
        #endregion
        public List<Users> SearchAdmin(string name)
        {
            List<Users> usersList = new List<Users>();


            return usersList;
        }
        #region GetAll Admin's Data

        #endregion

        #region Update User's Data
        public bool Update(Users user, string selectedUser)
        {
            bool isUpdated = false;
            string userToUpdate = string.Empty;

            //Update the userToUpdate variable to select the correct 
            //Stored Procedure for the updatec function
            if (selectedUser == "Admin")
                userToUpdate = "UpdateAdmin";
            else if (selectedUser == "Admin")
                userToUpdate = "UpdateCollector";

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = userToUpdate;

                sqlCommand.Parameters.AddWithValue("@CollectorId", user.Id);
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

                //If affected number of rows is > 0, then data is updated successfully
                int NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
                isUpdated = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            return isUpdated;
        }

        #endregion

        #region Delete Collector's Data
        public bool Delete(int id)
        {
            bool isDeleted = false;

            try
            {
                sqlCommand.Parameters.Clear();      //Clear Parameters
                sqlCommand.CommandText = "DeleteCollector";

                sqlCommand.Parameters.AddWithValue("@CollectorId", id);

                //Open Sql database connection
                sqlConnection.Open();

                //If number of rows affected > 0 then the data is deleted succesfully
                int noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                isDeleted = noOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            return isDeleted;
        }

        #endregion

    }
}
