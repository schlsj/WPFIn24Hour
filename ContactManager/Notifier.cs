using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactManager.Annotations;

namespace ContactManager
{
    [Serializable]
    public abstract class Notifier:INotifyPropertyChanged
    {
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
