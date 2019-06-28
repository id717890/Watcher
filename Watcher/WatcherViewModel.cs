using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher.Data;
using Watcher.Interface.Model;

namespace Watcher
{
    public class WatcherViewModel : IWatcherViewModel
    {
        public BindingList<GridData> GridDataList { get ; set; }
    }
}
