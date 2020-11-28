using Merlin2d.Game.Actors;

namespace Merlin_Core.Commands
{
    public class Fall<T> : IAction<T> where T : IActor
    {
        private int speed = 6;
        public void Execute(T t)
        {

            if (t.GetWorld().IntersectWithWall(t) is false)
            {
                t.SetPosition(t.GetX(), t.GetY() + speed);
                if (t.GetWorld().IntersectWithWall(t) is true)
                {
                    t.SetPosition(t.GetX(), t.GetY() - speed);
                }
            }
        }
    }
}
