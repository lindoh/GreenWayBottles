using System.ComponentModel;
using GreenWayBottles.Models;


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
        Users user = new();

        #endregion

        #region Helper Methods


        #endregion
    }
}
