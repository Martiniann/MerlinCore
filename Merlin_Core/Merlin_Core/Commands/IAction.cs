namespace MerlinCore.Commands
{
    interface IAction<T>
    {
        void Execute(T t);
    }
}
