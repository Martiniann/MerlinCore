using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin_Core.Actors
{
    public abstract class AbstractActor : IActor
    {
        private Animation animation;
        private int x, y;
        private IWorld world;
        private bool isRemoved = false;

        public Animation GetAnimation()
        {
            return animation;
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public int GetHeight()
        {
            return animation.GetHeight();
        }

        public int GetWidth()
        {
            return animation.GetWidth();
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public string GetName()
        {
            throw new System.NotImplementedException();
        }

        public bool IntersectsWithActor(IActor other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsAffectedByPhysics()
        {
            throw new System.NotImplementedException();
        }

        public IWorld GetWorld()
        {
            return world;
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
        }

        public bool RemovedFromWorld()
        {
            return isRemoved;
        }

        public void RemoveFromWorld()
        {
            isRemoved = true;
        }

        public void SetName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            throw new System.NotImplementedException();
        }

        public void SetPosition(int posX, int posY)
        {
            this.x = posX;
            this.y = posY;
        }

        public abstract void Update();
    }
}