using System.ComponentModel;
using GreenWayBottles.Models;
using GreenWayBottles.Services;


namespace GreenWayBottles.ViewModels
{ 
    public class CreateUserAccViewModel : INotifyPropertyChanged
    {
        #region Default Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CreateUserAccViewModel()
        {
            User = new Users();
            dataService = new DatabaseService();
        }
        #endregion

        #region INotifyPropertyChanged Implementation Method
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Class Members
        DatabaseService dataService;

        private Users user;
        public Users User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(user));
            }
        }
        #endregion

        

        #region Helper Methods


        #endregion
    }
}
