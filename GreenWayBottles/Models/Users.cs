using System.ComponentModel;


namespace GreenWayBottles.Models
{
    public class Users : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

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
       
    }
}
