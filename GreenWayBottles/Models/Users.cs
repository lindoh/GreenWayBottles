using System.ComponentModel;


namespace GreenWayBottles.Models
{
    public class Users : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion

        #region Class Properties
        //User's First Name
        private string firstName;
        public string FirstName
        {
            get => firstName;

            set
            {
                if (value != null)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        //User's Last name
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                if (value != null)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

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
        private string gender;
        public string Gender
        {
            get => gender;
            set
            {
                if (value != null)
                {
                    gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        //User's Highest Qualification
        private string highestQlfn;
        public string HighestQlfn
        {
            get => highestQlfn;
            set
            {
                if (value != null)
                {
                    highestQlfn = value;
                    OnPropertyChanged(nameof(highestQlfn));
                }
            }

        }

        //User's Income Range
        private string incomeRange;
        public string IncomeRange
        {
            get => incomeRange;
            set
            {
                if (value != null)
                {
                    incomeRange = value;
                    OnPropertyChanged(nameof(IncomeRange)); 
                }
            }
        }

        //User's Email Address
        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (value != null)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        //User's Cell Number
        private string cellNumber;
        public string CellNumber
        {
            get => cellNumber;
            set
            {
                if (value != null)
                {
                   cellNumber = value;
                    OnPropertyChanged(nameof(cellNumber));
                }
            }
        }

        //User's Street Address
        private string streetAddress;
        public string StreetAddress
        {
            get => streetAddress;
            set
            {
                if (value != null)
                {
                    streetAddress = value;
                    OnPropertyChanged(nameof(StreetAddress));
                }
            }
        }

        //User's Suburb Name
        private string suburb;
        public string Suburb
        {
            get => suburb;
            set
            {
                if (value != null)
                {
                    suburb = value;
                    OnPropertyChanged(nameof(Suburb));
                }
            }
        }

        //User's City Name
        private string city;
        public string City
        {
            get => city;
            set
            {
                if (value != null)
                {
                    city = value;
                    OnPropertyChanged(nameof (City));
                }
            }
        }

        //User's Province Name
        private string province;
        public string Province
        {
            get => province;
            set
            {
                if (value != null)
                {
                    province = value;
                    OnPropertyChanged(nameof(Province));
                }
            }
        }

        //User's Country Name
        private string country;
        public string Country
        {
            get => country;
            set
            {
                if (value != null)
                {
                    country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        #endregion

    }
}
