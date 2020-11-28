namespace Merlin_Core.Commands
{
    interface IAction<T>
    {
        void Execute(T t);
    }
}
