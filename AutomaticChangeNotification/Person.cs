using System;

namespace AutomaticChangeNotification
{
    class Person
    {
        public event EventHandler FirstNameChanged;

        private void OnFirstNameChanged()
        {
            if (FirstNameChanged != null)
            {
                FirstNameChanged(this, EventArgs.Empty);
            }
        }

        private string mFirstName;

        public string FirstName
        {
            get { return mFirstName; }
            set
            {
                mFirstName = value;
                OnFirstNameChanged();                
            }
        }
    }
}
