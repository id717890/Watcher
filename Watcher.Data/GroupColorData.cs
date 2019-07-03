using System.ComponentModel;

namespace Watcher.Data
{
    public class GroupColorData : INotifyPropertyChanged
    {
        public string GroupCaption { get; set; }

        bool? isVerified = false;
        public bool? IsVerified { get { return isVerified; } set { isVerified = value; NotifyChanged("IsVerified"); } }

        void NotifyChanged(string prop)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public GroupColorData() {}

        public GroupColorData(string _caption, bool? _isVerified)
        {
            GroupCaption = _caption;
            IsVerified = _isVerified;
        }
    }
}
