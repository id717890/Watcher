using Ninject.Modules;
using Watcher.Interface.Model;
using Watcher.Interface.Presenter;
using Watcher.Interface.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher;

namespace Watcher
{
    public class CompositeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWatcherPresenter>().To<WatcherPresenter>();
            Bind<IWatcherView>().To<WatcherView>();
            Bind<IWatcherViewModel>().To<WatcherViewModel>();
        }
    }
}
