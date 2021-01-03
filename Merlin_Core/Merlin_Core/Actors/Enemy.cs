using MerlinCore.Commands;
using MerlinCore.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using Merlin2d.Game.Enums;

namespace MerlinCore.Actors
{
    public class Enemy : AbstractCharacter, IMovable
    {
        Random random = new Random();

        private int counter = 0;

        private int[] range = { 200, 50 };

        private Player player1;

        private Animation animationOn;

        private Command moveRight;
        private Command moveLeft;


        public Enemy()
        {
            animationOn = new Animation("Resources/sprites/enemy.png", 64, 58);
            SetAnimation(animationOn);
            animationOn.Start();
            SetPhysics(true);

            //int randomStep = random.Next(1, 2);
            int randomSpeed = random.Next(1, 2);
            if (randomSpeed == 0)
            {
                randomSpeed = 1;
            }

            moveRight = new Move(this, randomSpeed, 0);
            moveLeft = new Move(this, -randomSpeed, 0);

        }

        public void HuntingPlayer()
        {
            player1 = (Player)GetWorld().GetActors().Find(a => a is Player);
            int diffenceX = player1.GetX() - GetX();
            int differenceY = player1.GetY() - GetY();
            int beforeStepX = GetX();

            if (diffenceX < 0)
            {
                diffenceX = -diffenceX;
            }

            if (differenceY < 0)
            {
                differenceY = -differenceY;
            }

            if (diffenceX <= range[0] && differenceY <= range[1])
            {
                animationOn.Start();
                if (player1.GetX() - GetX() < 0)
                {
                    moveLeft.Execute();
                    if (counter % 2 == 0)
                    {
                        animationOn.FlipAnimation();
                        counter++;
                    }
                }
                else if (player1.GetX() - GetX() > 0)
                {
                    moveRight.Execute();
                    if (counter % 2 == 1)
                    {
                        animationOn.FlipAnimation();
                        counter++;
                    }
                }
                else
                {
                    player1.ChangeHealth(-1);
                    animationOn.Stop();
                }
            }
            else
            {
                animationOn.Start();
                if (GetWorld().IntersectWithWall(this) is false)
                {
                    if (counter % 2 == 0)
                    {
                        moveRight.Execute();
                        if (beforeStepX == GetX())
                        {
                            counter++;
                            animationOn.FlipAnimation();
                        }
                    }
                    else if (counter % 2 == 1)
                    {
                        moveLeft.Execute();
                        if (beforeStepX == GetX())
                        {
                            counter++;
                            animationOn.FlipAnimation();
                        }
                    }
                }
            }
        }

        public override void Update()
        {
            int inthp = GetHealth();
            string strhp = inthp.ToString();
            Message msg = new Message(strhp , GetX()+25, GetY()-5, 11, Color.Red, (MessageDuration)2);
            GetWorld().AddMessage(msg);

            if (GetHealth() == 0)
            {
                Die();
            }
            if (Input.GetInstance().IsKeyPressed(Input.Key.B))
            {
                this.ChangeHealth(-90);
            }
            if (myState == false)
            {
                animationOn.Stop();
                RemoveFromWorld();              
            }
            else
            {                
                if (IntersectsWithActor(GetWorld().GetActors().Find(a => a.GetName() == "player")))
                {
                    ChangeHealth(-1);
                }
                HuntingPlayer();
            }  
        }
    }
}
