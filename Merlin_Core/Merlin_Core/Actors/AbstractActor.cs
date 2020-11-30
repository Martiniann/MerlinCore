using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace MerlinCore.Actors
{
    public abstract class AbstractActor : IActor
    {
        private Animation animation;
        private int x, y;
        private IWorld world;
        private bool isRemoved = false;
        private string name;
        private bool isSetPhysics;


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
            return name;
        }

        public bool IntersectsWithActor(IActor other)
        {
            int diffenceX = other.GetX() - GetX();
            int differenceY = other.GetY() - GetY();
            int[] otherRange = { other.GetWidth(), other.GetHeight() };
            int[] myRange = { GetWidth(), GetHeight() };

            if (diffenceX < 0)
            {
                diffenceX = -diffenceX;
            }

            if (differenceY < 0)
            {
                differenceY = -differenceY;
            }

            if (diffenceX <= (myRange[0] + otherRange[0]) && differenceY <= (myRange[1] + otherRange[1]))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsAffectedByPhysics()
        {
            if (isSetPhysics == true)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            this.name = name;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            if (isPhysicsEnabled == true)
            {
                isSetPhysics = true;
            }
            else
            {
                isSetPhysics = false;
            }
        }

        public void SetPosition(int posX, int posY)
        {
            this.x = posX;
            this.y = posY;
        }

        public abstract void Update();
    }
}