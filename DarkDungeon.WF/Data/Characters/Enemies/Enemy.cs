using System;

namespace Data.Characters.Enemies
{
    public class Enemy : Character
    {
        public Enemy()
            : this(1, 20, 20, 2, 2, 50)
        {

        }

        public Enemy(int health, int mana, int strength, int defence, int neededExperienceIncrementPerLevel)
            : this(1, health, mana, strength, defence, neededExperienceIncrementPerLevel)
        {

        }

        public Enemy(int level, int health, int mana, int strength, int defence, int neededExperienceIncrementPerLevel)
            : base(level, health, mana, strength, defence, neededExperienceIncrementPerLevel)
        {

        }
    }
}
