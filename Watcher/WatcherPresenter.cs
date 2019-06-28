using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher.Interface.Model;
using Watcher.Interface.Presenter;
using Watcher.Interface.View;

namespace Watcher
{
    public class WatcherPresenter : IWatcherPresenter, IWatcherPresenterCallback
    {
        private readonly IWatcherView _view;
        private readonly IWatcherViewModel _model;

        public WatcherPresenter(IWatcherView view, IWatcherViewModel model) 
        {
            _view = view;
            _model = model;
        }


        public object Ui => _view;

        public void Initialize()
        {
            _view.Attach(this);
        }
    }
}
