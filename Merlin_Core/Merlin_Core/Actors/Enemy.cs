﻿using Merlin_Core.Commands;
using Merlin_Core.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;

namespace Merlin_Core.Actors
{
    public class Enemy : AbstractActor, IMovable
    {
        Random random = new Random();

        private int counter = 0;

        private int[] range = { 200, 50 };

        private Player player1;

        private Animation animationOn;

        private Command moveRight;
        private Command moveLeft;


        public Enemy(IActor player)
        {
            animationOn = new Animation("Resources/enemy.png", 64, 58);
            SetAnimation(animationOn);
            animationOn.Start();
            SetPhysics(true);
            player1 = (Player)player;

            int randomStep = random.Next(1, 2);
            int randomSpeed = random.Next(1, 3);
            if (randomSpeed == 0)
            {
                randomSpeed = 1;
            }

            moveRight = new Move(this, randomStep, randomSpeed, 0);
            moveLeft = new Move(this, randomStep, -randomSpeed, 0);
        }

        public void AddEffect(Command effect)
        {
            throw new NotImplementedException();
        }

        public void ChangeHealth(int delta)
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public int GetHealth()
        {
            throw new NotImplementedException();
        }

        public double GetSpeed()
        {
            throw new NotImplementedException();
        }

        public void RemoveEffect(Command effect)
        {
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy speedStrategy)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
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
                    Console.WriteLine("GAME OVER!");
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
    }
}