using Merlin_Core.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System.Collections.Generic;
using System.Linq;

namespace Merlin_Core.Commands
{
    class Gravity : AbstractActor, IPhysics
    {

        private IWorld world;
        private IAction<AbstractActor> fall = new Fall<AbstractActor>();

        public void Execute()
        {
            List<IActor> actors = world.GetActors().Where(a => a.IsAffectedByPhysics()).ToList();

            foreach (AbstractActor actor in actors)
            {
                fall.Execute(actor);
            }
        }

        public void SetWorld(IWorld world)
        {
            this.world = world;
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
