using System;
using MovementFolder = Data.Characters.Movement;

namespace Data.Characters.Enemies
{
    public class Enemy : Character
    {
        public Enemy()
            : this(1, 20, 20, 2, 2, 50, 1)
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
            if (this.CanMove)
            {
                int nextDirection = maze.FindPath(this.Position.Row, this.Position.Column, hero.Position.Row, hero.Position.Column);
                MovementFolder.Movement.ChangeDirection(this, nextDirection);
                MovementFolder.Movement.Move(this);
                this.CanMove = false;
            }
            else
            {
                this.CanMove = true;
            }

            if (MovementFolder.Movement.CollisionDetect(this, hero))
            {
                // TO DO Battle
            }
        }
    }
}
