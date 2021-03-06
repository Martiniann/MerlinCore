﻿using MerlinCore.Commands;
using MerlinCore.Spells;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System.Collections.Generic;
using Merlin2d.Game.Items;
using Merlin_Core.Actors.Items;
using Merlin_Core.Spells;
using MerlinCore.Strategies;
using Merlin2d.Game.Enums;

namespace MerlinCore.Actors
{

    public class Player : AbstractCharacter, IMovable, IWizard
    {

        private Animation animationOn;
        private bool side = false;
        private int counter = 0;
        private int bunnyHop = 20;
        private int jumpCounter = 0;
        private int speedCounter = 0;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();

        private Command moveRight;
        private Command moveLeft;

        //ActorOrientation myOrientationLeft = ActorOrientation.facingLeft;
        //ActorOrientation myOrientationRight = ActorOrientation.facingRight;

        private Command jump;

        private List<Command> jumpLeft;
        private List<Command> jumpRight;

        private int mana = 200;
        private int maxMana = 200;
        private ISpell spell;

        IInventory backpack;
        private HealingPotion healingPotion;
        private ManaPotion manaPotion;
        private SpeedPotion speedPotion;
        private JumpPotion jumpPotion;
        private IItem potion;
        private int position = 1;
        private IWorld world;

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

            backpack = new Backpack(6);
            
            backpack.AddItem(new HealingPotion());
            backpack.AddItem(new HealingPotion());
            backpack.AddItem(new ManaPotion());
            backpack.AddItem(new ManaPotion());
            backpack.AddItem(new SpeedPotion());
            backpack.AddItem(new JumpPotion());
        }

        public void SetJump(int dy)
        {
            jump = new Jump(this, dy);

            jumpLeft = new List<Command> { };
            jumpLeft.Add(jump);
            jumpLeft.Add(moveLeft);

            jumpRight = new List<Command> { };
            jumpRight.Add(jump);
            jumpRight.Add(moveRight);
        }

        public void Cast(ISpell spell)
        {
            ISpellDirector director = new SpellDirector(SpellDataProvider.GetInstance());
        }

        public void ChangeMana(int delta)
        {
            mana += delta;
            if (mana > maxMana)
            {
                mana = maxMana;
            }
            if (mana < 0)
            {
                mana = 0;
            }
        }

        public int GetMana()
        {
            return mana;
        }

        public void ShowPlayerInformation()
        {
            int inthp = GetHealth();
            string strhp = inthp.ToString();
            int intmana = GetMana();
            string strmana = intmana.ToString();
            
            Message msg2 = new Message(strmana, 700, 618, 25, Color.Blue, (MessageDuration)2);
            Message msg = new Message(strhp, 750, 618, 25, Color.Red, (MessageDuration)2);
            GetWorld().AddMessage(msg);
            GetWorld().AddMessage(msg2);
            GetWorld().ShowInventory(backpack);
        }

        public override void Update()
        {
            base.Update();

            ShowPlayerInformation();
            counter++;
            animationOn.Start();        

            if(GetWorld().GetActors().Find(a => a.GetName() == "enemy") == null)
            {
                world = GetWorld();
                world.SetEndCondition(world => MapStatus.Finished);
            }

            if (GetHealth() == 0)
            {
                Die();
            }

            if (myState == false)
            {
                animationOn.Stop();
                world = GetWorld();
                world.SetEndCondition(world => MapStatus.Failed);               
            }
            else
            {

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
                else if (Input.GetInstance().IsKeyPressed(Input.Key.E))
                {
                    backpack.ShiftRight();
                }
                else if (Input.GetInstance().IsKeyPressed(Input.Key.Q))
                {
                    backpack.ShiftLeft();
                }
                else if (Input.GetInstance().IsKeyDown(Input.Key.F))
                {
                    potion = backpack.GetItem();
                    if (potion is HealingPotion)
                    {
                        healingPotion = (HealingPotion)potion;
                        healingPotion.Use(this);
                    }
                    else if (potion is ManaPotion)
                    {
                        manaPotion = (ManaPotion)potion;
                        manaPotion.Use(this);
                    }
                    else if (potion is SpeedPotion)
                    {
                        speedPotion = (SpeedPotion)potion;
                        speedPotion.Use(this);
                        speedCounter = 1;
                    }
                    else if (potion is JumpPotion)
                    {
                        jumpPotion = (JumpPotion)potion;
                        jumpPotion.Use(this);
                        jumpCounter = 1;
                    }
                }
                else if (Input.GetInstance().IsKeyPressed(Input.Key.R))
                {
                    backpack.RemoveItem(backpack.GetCapacity() - position);
                    position++;
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
                
                if (jumpCounter > 0)
                {
                    jumpCounter++;
                    if (jumpCounter == jumpPotion.GetDuration())
                    {
                        SetJump(3);
                        jumpCounter = 0;
                    }
                }
               

                if (speedCounter > 0)
                {
                    speedCounter++;
                    if (speedCounter == speedPotion.GetDuration())
                    {
                        this.SetSpeedStrategy(speedStrategy);
                        speedCounter = 0;
                    }
                }
            }
        }
    }
}
