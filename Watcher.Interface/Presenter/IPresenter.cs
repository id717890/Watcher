namespace Watcher.Interface.Presenter
{
    public interface IPresenter
    {
        void Initialize();
        object Ui { get; }
    }
}
