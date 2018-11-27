using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using MediaViewer.Annotations;

namespace MediaViewer.Model
{
    public class Media:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected FileInfo _fileInfo;
        protected Uri _uri;

        public string Name => Path.GetFileNameWithoutExtension(_fileInfo.Name);

        public string Directory => _fileInfo.Directory?.Name;

        public Uri Uri => _uri;

        public void SetFile(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
            _uri=new Uri(_fileInfo.FullName);
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Directory));
            OnPropertyChanged(nameof(Uri));
        }
    }
}
