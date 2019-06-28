using System;
using System.ComponentModel;

namespace Watcher.Data
{
    public class GridData
    {
        public Guid Id { get; set; }
        public string GroupCaption { get; set; }
        public string StatementCaption { get; set; }
        public object VerifyIf { get; set; }
        public string Tag { get; set; }

        bool isVerified = false;
        public bool IsVerified { get { return isVerified; } set { isVerified = value; NotifyChanged("IsVerified"); } }

        /// <summary>
        /// Значение которое будет считываться с сервера или хоста (при инициализации = null)
        /// </summary>
        string value;
        public string Value { get { return value; } set { this.value = value; NotifyChanged("Value"); } }

        string quality = string.Empty;
        public string Quality { get { return quality; } set { quality = value; NotifyChanged("Quality"); } }

        bool isIgnore = false;
        public bool IsIgnore { get { return isIgnore; } set { isIgnore = value; NotifyChanged("IsIgnore"); } }

        public string ParamType { get; set; }
        public bool AllowBadQuality { get; set; }

        void NotifyChanged(string prop)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
