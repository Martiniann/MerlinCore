using MerlinCore.Actors;
using MerlinCore.Commands;
using MerlinCore.Spells;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;

namespace MerlinCore.Actors
{
    public class Player : AbstractCharacter, IMovable, IWizard
    {

        private Animation animationOn;
        private bool side = false;
        private int counter = 0;
        private int bunnyHop = 20;

        private Command moveRight;
        private Command moveLeft;

        private Command jump;

        private List<Command> jumpLeft;
        private List<Command> jumpRight;

        private int mana;
        private ISpell spell;

        public Player()
        {
            animationOn = new Animation("Resources/sprites/player.png", 64, 58);
            SetAnimation(animationOn);
            animationOn.Start();

            SetPhysics(true);

            moveLeft = new Move(this, -3, 0);
            moveRight = new Move(this, 3, 0);

            jump = new Jump(this, 3);

            jumpLeft = new List<Command> { };
            jumpLeft.Add(jump);
            jumpLeft.Add(moveLeft);

            jumpRight = new List<Command> { };
            jumpRight.Add(jump);
            jumpRight.Add(moveRight);
        }

        public void Cast(ISpell spell)
        {
            this.spell = spell;
        }

        public void ChangeMana(int delta)
        {
            mana -= delta;
        }

        public int GetMana()
        {
            return mana;
        }

        public override void Update()
        {
            base.Update();
            counter++;
            animationOn.Start();
            
            if (Input.GetInstance().IsKeyPressed(Input.Key.LEFT))
            {
                if (side == false)
                {
                    animationOn.FlipAnimation();
                    side = true;
                }
     
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.RIGHT))
            {
                if (side == true)
                {
                    animationOn.FlipAnimation();
                    side = false;
                }

            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.SPACE) && Input.GetInstance().IsKeyDown(Input.Key.LEFT) && bunnyHop > 0)
            {

                SetPhysics(false);
                foreach (Command command in jumpLeft)
                {
                    command.Execute();
                }
                bunnyHop--;
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.SPACE) && Input.GetInstance().IsKeyDown(Input.Key.RIGHT) && bunnyHop > 0)
            {

                SetPhysics(false);
                foreach (Command command in jumpRight)
                {
                    command.Execute();
                }
                bunnyHop--;
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                SetPhysics(true);
                moveLeft.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                SetPhysics(true);
                moveRight.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.UP) && bunnyHop > 0)
            {
                SetPhysics(false);
                jump.Execute();
                bunnyHop--;
            }
            else
            {
                SetPhysics(true);
                animationOn.Stop();
            }

            if (bunnyHop < 20)
            {
                if (counter % 120 == 0)
                {
                    bunnyHop = 20;
                }

            }
        }
    }
}
