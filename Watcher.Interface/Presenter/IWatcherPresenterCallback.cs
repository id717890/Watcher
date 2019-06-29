namespace Watcher.Interface.Presenter
{
    public interface IWatcherPresenterCallback
    {
        void OnStarWatch();
        void OnStopWatch();
        //void OnRunCmdCommand();
        //void OnCheckServices();
        void OnCheckOpc();
        void OnRefreshView();
        //void OnShowMinimizeForm();
        //void OnShowNormalForm();
        //void OnSetIgnore(Guid id, bool isIgnore);
        //void OnSetIgnoreAllModules(bool isIgnore);
    }
}
