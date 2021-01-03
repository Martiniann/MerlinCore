namespace Merlin.Actors
{
    public interface IObserver
    {
        void Notify(IObservable observable);
    }
}
