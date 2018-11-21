using System;

namespace ContactManager.Model
{
    [Serializable]
    public class Contact:Notifier
    {
        private Address _address=new Address();
        private string _cellPhone;
        private string _homePhone;
        private string _officePhone;
        private string _firstName;
        private string _lastName;
        private string _imagePath;
        private string _jobTitle;
        private string _organization;
        private string _primaryEmail;
        private string _secondaryEmail;
        private Guid _id=Guid.Empty;

        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public string CellPhone
        {
            get { return _cellPhone; }
            set
            {
                _cellPhone = value;
                OnPropertyChanged();
            }
        }

        public string HomePhone
        {
            get { return _homePhone; }
            set
            {
                _homePhone = value;
                OnPropertyChanged();
            }
        }

        public string OfficePhone
        {
            get { return _officePhone; }
            set
            {
                _officePhone = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        public string Organization
        {
            get { return _organization; }
            set
            {
                _organization = value;
                OnPropertyChanged();
            }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                OnPropertyChanged();
            }
        }

        public string PrimaryEmail
        {
            get { return _primaryEmail; }
            set
            {
                _primaryEmail = value;
                OnPropertyChanged();
            }
        }

        public string SecondaryEmail
        {
            get { return _secondaryEmail; }
            set
            {
                _secondaryEmail = value;
                OnPropertyChanged();
            }
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string LookupName
        {
            get { return $"{_lastName}, {_firstName}"; }
        }

        public override string ToString()
        {
            return LookupName;
        }

        public override bool Equals(object obj)
        {
            Contact other=obj as Contact;
            return other != null && other.Id == Id;
        }
    }
}
