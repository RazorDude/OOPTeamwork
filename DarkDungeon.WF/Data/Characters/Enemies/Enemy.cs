using Data.Exceptions;
using Data.GridItem;
using System;
using MovementFolder = Data.Characters.Movement;

namespace Data.Characters.Enemies
{
    public delegate void HpLossDelegate(string param, int value, bool flag);
    public class Enemy : Character
    {
        public static HpLossDelegate HpLoss;
        public Enemy()
            : this(1, 20, 20, 2, 0, 50, 1)
        {
        }

        public Enemy(int health, int mana, int strength, int defence, int neededExperienceIncrementPerLevel)
            : this(1, health, mana, strength, defence, neededExperienceIncrementPerLevel, 1)
        {
        }

        public Enemy(int level, int health, int mana, int strength, int defence, int neededExperienceIncrementPerLevel, int direction)
            : base(level, health, mana, strength, defence, neededExperienceIncrementPerLevel, direction)
        {
        }

        protected bool CanMove { get; set; }

        public void FindDirectionAndMove(MovementFolder.MazeSolver maze, Data.Characters.PlayerCharacters.PlayerCharacter hero)
        {
            int nextDirection = default(int);

            if (this.CanMove)
            {
                try
                {
                    nextDirection = maze.FindPath(this.Position.Row, this.Position.Column, hero.Position.Row, hero.Position.Column);
                    MovementFolder.Movement.ChangeDirection(this, nextDirection);
                    MovementFolder.Movement.Move(this);
                    this.CanMove = false;
                }
                catch (NullReferenceException) // when there is no path between the demon and the hero
                {
                    nextDirection = hero.Direction;
                }                
            }
            else
            {
                this.CanMove = true;
            }

            if (MovementFolder.Movement.CollisionDetect(this, hero))
            {
                int takenDamageDemon = this.TakeDamage(this.DealDamage());  // decrease enemy health
                int takenDamageHero = hero.TakeDamage(hero.DealDamage());  // decrease hero health
                HpLoss("HP", takenDamageHero, true);
                if (hero.IsDead()) // game end
                {
                    throw new GameEndException("End Game!"); // catch the exception and call MainMenu
                }
            }
        }        
    }
}
