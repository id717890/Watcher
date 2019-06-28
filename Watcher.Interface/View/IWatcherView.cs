using Watcher.Interface.Model;
using Watcher.Interface.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher.Data;
using System.ComponentModel;

namespace Watcher.Interface.View
{
    public interface IWatcherView : IView<IWatcherPresenterCallback>
    {
        //bool IsShow { get; set; }
        //bool IsShutdowActive { set; }
        //void Exit();
        //Int32 ColumnCaption { get; set; }
        //Int32 ColumnTag { get; set; }
        //Int32 MnaNumber { get; set; }
        //Boolean IsMnaNumber { get; set; }
        //string[] Enginers { set; }
        //string Enginer { get; set; }
        string SelectedGroup { get; set; }

        void SetModel(IWatcherViewModel model);
        void RenderGrid(BindingList<GridData> model);
    }
}
