using GreenWayBottles.Models;
using System.Collections.ObjectModel;
/* Unmerged change from project 'GreenWayBottles (net6.0-ios)'
Before:
using GreenWayBottles.Models;
using GreenWayBottles.Services;
After:
using GreenWayBottles.Services;
using System.Collections.ObjectModel;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-maccatalyst)'
Before:
using GreenWayBottles.Models;
using GreenWayBottles.Services;
After:
using GreenWayBottles.Services;
using System.Collections.ObjectModel;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-windows10.0.19041.0)'
Before:
using GreenWayBottles.Models;
using GreenWayBottles.Services;
After:
using GreenWayBottles.Services;
using System.Collections.ObjectModel;
*/


namespace GreenWayBottles.Services
{
    public partial class SearchService 
    {
        public SearchService()
        {
            dataService = new DatabaseService();
            alerts = new AlertService();
        }

        DatabaseService dataService;
        AlertService alerts;

        public ObservableCollection<Users> FindUser(string name, string selectedUser)
        {
            ObservableCollection<Users> UsersList = new ObservableCollection<Users>();

            if (selectedUser != null)
            {
                //Get the list of users that match the given name
                UsersList = new ObservableCollection<Users>(dataService.Search(name, selectedUser));

                //If the user is not found, notify the user
                if (UsersList.Count == 0)
                    alerts.ShowAlert("Search Operation Failed", "User not found");
            }
            else
                alerts.ShowAlert("Search Operation Failed", "The User Category Must be Selected First");

            return UsersList;
        }
    }
}
