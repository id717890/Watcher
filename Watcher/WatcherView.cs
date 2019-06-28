using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watcher.Interface.Presenter;
using Watcher.Interface.View;

namespace Watcher
{
    public partial class WatcherView : Form, IWatcherView
    {
        public WatcherView()
        {
            InitializeComponent();
        }

        public void Attach(IWatcherPresenterCallback callback)
        {
        }
    }
}
