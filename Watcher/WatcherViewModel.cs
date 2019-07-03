using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Watcher.Data;
using Watcher.Interface.Model;

namespace Watcher
{
    public class WatcherViewModel : IWatcherViewModel
    {
        public BindingList<GridData> GridDataList { get ; set; }
        public BindingList<GroupColorData> GroupColorDataList { get; set; }
        //    get {
        //        var result = new List<GroupColorData>();
        //        foreach (var group in GridDataList.Select(x => x.GroupCaption).Distinct())
        //            result.Add(new GroupColorData(group, GridDataList.Any(x => x.GroupCaption == group && !x.IsVerified)));
        //        return new BindingList<GroupColorData>(result);
        //    }
        //}

        public void FillGroupColorList()
        {
            var result = new List<GroupColorData>();
            foreach (var group in GridDataList.Select(x => x.GroupCaption).Distinct())
                result.Add(new GroupColorData(group, null));
            GroupColorDataList = new BindingList<GroupColorData>(result);
        }
    }
}
