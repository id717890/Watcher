using System.ComponentModel;
using Watcher.Data;

namespace Watcher.Interface.Model
{
    public interface IWatcherViewModel
    {
        //IEnumerable<Server> VerificationList { get; set; }
        BindingList<GridData> GridDataList { get; set; }
        BindingList<GroupColorData> GroupColorDataList { get; }

        void FillGroupColorList();
    }
}
