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
        #region Class Properties
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        #endregion

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

        #region SaveData Method for Admin
        /// <summary>
        /// Save Collector's Data in the Collector's Database Table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveAdminData(Users user)
        {
            bool isSaved = false;

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "AddAdmin";

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
            else if (selectedUser == "Collector")
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
                        user = new Users();
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

        #region Update User's Data
        public bool Update(Users user, string selectedUser)
        {
            bool isUpdated = false;
            string userToUpdate = "UpdateCollector";
            string userId = "@CollectorId";

            //Update the userToUpdate variable to select the correct 
            //Stored Procedure for the updatec function
            if (selectedUser == "Admin")
            {
                userToUpdate = "UpdateAdmin";
                userId = "@AdminId";
            }
            else if (selectedUser == "Collector")
            {
                userToUpdate = "UpdateCollector";
                userId = "@CollectorId";
            }

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = userToUpdate;

                sqlCommand.Parameters.AddWithValue(userId, user.Id);
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

        #region Delete User's Data
        public bool Delete(int id, string selectedUser)
        {
            bool isDeleted = false;
            string userToDelete = "DeleteCollector";
            string userId = "@CollectorId";

            //Update the userToUpdate variable to select the correct 
            //Stored Procedure for the updatec function
            if (selectedUser == "Admin")
            {
                userToDelete = "DeleteAdmin";
                userId = "@AdminId";
            }
            else if (selectedUser == "Collector")
            {
                userToDelete = "DeleteCollector";
                userId = "@CollectorId";
            }

            try
            {
                sqlCommand.Parameters.Clear();      //Clear Parameters
                sqlCommand.CommandText = userToDelete;

                sqlCommand.Parameters.AddWithValue(userId, id);

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

        #region Insert and Update User Banking Details

        /// <summary>
        /// The method searches for the Collector's banking details
        /// Using the provided CollectorId
        /// </summary>
        /// <param name="CollectorId"></param>
        /// <returns>A List with the User's banking details</returns>
        public Banking SearchBanking(int CollectorId)
        {
            Banking banker = new Banking();

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "SearchBankingDetails";
                sqlCommand.Parameters.AddWithValue("@CollectorId", CollectorId);

                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {

                    while(sqlDataReader.Read())
                    {
                        banker.BankDetailsId = sqlDataReader.GetInt32(0);
                        banker.BankName = sqlDataReader.GetString(1);
                        banker.BranchName = sqlDataReader.GetString(2);
                        banker.BranchCode = sqlDataReader.GetString(3);
                        banker.AccountType = sqlDataReader.GetString(4);
                        banker.AccountNumber = sqlDataReader.GetString(5);
                    } 
                    sqlDataReader.Close();  
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            return banker;
        }

        /// <summary>
        /// To save the banking the details of the Collector 
        /// for the first time
        /// </summary>
        /// <param name="banker"></param>
        /// <param name="user"></param>
        /// <returns>Return True if successful, else False</returns>
        public bool NewBankingDetails(Banking banker, Users user)
        {
            bool isSaved = false;

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "NewBankingDetails";

                sqlCommand.Parameters.AddWithValue("@BankName", banker.BankName);
                sqlCommand.Parameters.AddWithValue("@BranchName", banker.BranchName);
                sqlCommand.Parameters.AddWithValue("@BranchCode", banker.BranchCode);
                sqlCommand.Parameters.AddWithValue("@AccType", banker.AccountType);
                sqlCommand.Parameters.AddWithValue("@AccNumber", banker.AccountNumber);
                sqlCommand.Parameters.AddWithValue("@CollectorId", user.Id);

                //Open Sql connection
                sqlConnection.Open();

                //If number of rows affected is > 0, data is saved successfully
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

        /// <summary>
        /// To update existing Collector's banking details
        /// </summary>
        /// <param name="banker"></param>
        /// <returns>Return true if successful, else false</returns>
        public bool UpdateBankingDetails(Banking banker)
        {
            bool isUpdated = false;

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "UpdateBankingDetails";

                sqlCommand.Parameters.AddWithValue("@BankDetailsId", banker.BankDetailsId);
                sqlCommand.Parameters.AddWithValue("@BankName", banker.BankName);
                sqlCommand.Parameters.AddWithValue("@BranchName", banker.BranchName);
                sqlCommand.Parameters.AddWithValue("@BranchCode", banker.BranchCode);
                sqlCommand.Parameters.AddWithValue("@AccType", banker.AccountType);
                sqlCommand.Parameters.AddWithValue("@AccNumber", banker.AccountNumber);

                //Open Sql connection
                sqlConnection.Open();

                //If the number of rows affected > 0, then the data is succesfully updated
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

        #region Get The List of Bottles
        public List<BottleDataSource> GetBottleList()
        {
            List<BottleDataSource> bottleList = new List<BottleDataSource>();

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "GetBottles";

                sqlConnection.Open();

                var sqlDataReader = sqlCommand.ExecuteReader(); 

                if(sqlDataReader.HasRows)
                {
                    BottleDataSource bottle;

                    while (sqlDataReader.Read())
                    {
                        bottle = new BottleDataSource();

                        bottle.BottleDataSourceId = sqlDataReader.GetInt32(0);
                        bottle.BottleName = sqlDataReader.GetString(1);
                        bottle.Size = sqlDataReader.GetString(2);

                        bottleList.Add(bottle);

                    }
                    sqlDataReader.Close();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally 
            { 
                sqlConnection.Close(); 
            }  


            return bottleList;
        }

        #endregion

        #region Save BuyBackCentre Details
        /// <summary>
        /// Save the Data for the BuyBackCentre with the Associated Admin details
        /// Admin ID is sufficient in this case
        /// </summary>
        /// <param name="buyBackCentre"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveBBCData(BuyBackCentre buyBackCentre, Users user)
        {
            bool isSaved = false;

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "NewBBCDetails";

                sqlCommand.Parameters.AddWithValue("@BBCName", buyBackCentre.BuyBackCentreName);    
                sqlCommand.Parameters.AddWithValue("@StreetAddress", buyBackCentre.StreetAddress);
                sqlCommand.Parameters.AddWithValue("@Suburb", buyBackCentre.Suburb);
                sqlCommand.Parameters.AddWithValue("@City", buyBackCentre.City);
                sqlCommand.Parameters.AddWithValue("@Province", buyBackCentre.Province);
                sqlCommand.Parameters.AddWithValue("@Country", buyBackCentre.Country);
                sqlCommand.Parameters.AddWithValue("@AdminId", user.Id);

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

        #region Search BuyBackCentre Details
        public BuyBackCentre SearchBBC(Users user)
        {
            BuyBackCentre buyBackCentre = new BuyBackCentre();

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "SearchBBC";
                sqlCommand.Parameters.AddWithValue("@AdminId", user.Id);

                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                if(sqlDataReader.HasRows)
                {
                    while(sqlDataReader.Read())
                    {
                        buyBackCentre.BBCId = sqlDataReader.GetInt32(0);
                        buyBackCentre.BuyBackCentreName = sqlDataReader.GetString(1);
                        buyBackCentre.StreetAddress = sqlDataReader.GetString(2);
                        buyBackCentre.Suburb = sqlDataReader.GetString(3);
                        buyBackCentre.City = sqlDataReader.GetString(4);
                        buyBackCentre.Province = sqlDataReader.GetString(5);
                        buyBackCentre.Country = sqlDataReader.GetString(6);
                    }
                    sqlDataReader.Close();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            return buyBackCentre;
        }

        #endregion

        #region Update BuyBackCentre Details
        public bool UpdateBBC(BuyBackCentre buyBackCentre)
        {
            bool isUpdated = false;

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "UpdateBBCDetails";

                sqlCommand.Parameters.AddWithValue("@BBCName", buyBackCentre.BuyBackCentreName);
                sqlCommand.Parameters.AddWithValue("@StreetAddress", buyBackCentre.StreetAddress);
                sqlCommand.Parameters.AddWithValue("@Suburb", buyBackCentre.Suburb);
                sqlCommand.Parameters.AddWithValue("@City", buyBackCentre.City);
                sqlCommand.Parameters.AddWithValue("@Province", buyBackCentre.Province);
                sqlCommand.Parameters.AddWithValue("@Country", buyBackCentre.Country);

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

    }
}
