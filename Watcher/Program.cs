using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watcher.Interface.Presenter;

namespace Watcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var kernel = new StandardKernel();
            CompositionRoot.Init(kernel);
            CompositionRoot.Wire(new CompositeModule());
            var presenter = CompositionRoot.Resolve<IWatcherPresenter>();
            presenter.Initialize();
            Application.Run((Form)presenter.Ui);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new View());
        }
    }
}
