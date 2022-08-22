using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;


namespace GreenWayBottles.Models
{
    public partial class Users : ObservableObject
    {
        public Users()
        {           
            
        }

        #region Class Properties
        //User's First Name
        [ObservableProperty]
        private string firstName;

        //User's Last name
        [ObservableProperty]
        private string lastName;

        //User's Id Number
        private string idNumber;
        public string IdNumber
        {
            get => idNumber;
            set
            {
                if (value != null && value.Length == 13)
                {
                    idNumber = value;
                    OnPropertyChanged(nameof(IdNumber));    
                }
            }
        }

        //User's Gender
        [ObservableProperty]
        private string gender;

        //User's Highest Qualification
        [ObservableProperty]
        private string highestQlfn;

        //User's Income Range
        [ObservableProperty]
        private string incomeRange;

        //User's Email Address
        [ObservableProperty]
        private string email;

        //User's Cell Number
        [ObservableProperty]
        private string cellNumber;

        //User's Street Address
        [ObservableProperty]
        private string streetAddress;

        //User's Suburb Name
        [ObservableProperty]
        private string suburb;

        //User's City Name
        [ObservableProperty]
        private string city;

        //User's Province Name
        [ObservableProperty]
        private string province;

        //User's Country Name
        [ObservableProperty]
        private string country;

        #endregion

    }
}
