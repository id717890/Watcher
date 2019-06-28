namespace Watcher.Interface.View
{
    public interface IView<TCallbacks>
    {
        void Attach(TCallbacks callback);
    }
}
