﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Character
    {
        public int Level { get; protected set; }

        public int Experience { get; protected set; }

        public int Healt { get; protected set; }

        public int Mana { get; protected set; }

        public int Strength { get; protected set; }

        public int Defence { get; protected set; }

        protected int NeededExperienceForLevelUp { get; set; }

        protected readonly int neededExperienceIncrementPerLevel;
        protected int NeededExperienceIncrementPerLevel
        {
            get { return this.neededExperienceIncrementPerLevel; }
        }

        public Character(int healt, int mana, int strength, int defence, int neededExperienceIncrementPerLevel)
            : this(1, healt, mana, strength, defence, neededExperienceIncrementPerLevel)
        {
        }

        public Character(int level, int healt, int mana, int strength, int defence, int neededExperienceIncrementPerLevel)
        {
            this.Level = level;
            this.Experience = 0;
            this.Healt = healt;
            this.Mana = mana;
            this.Strength = strength;
            this.Defence = defence;

            this.neededExperienceIncrementPerLevel = neededExperienceIncrementPerLevel;
            this.NeededExperienceForLevelUp = this.Level * this.NeededExperienceIncrementPerLevel;
        }

        private void LevelUp()
        {
            while (this.Experience - this.NeededExperienceForLevelUp > this.NeededExperienceForLevelUp)
            {
                this.Level++;
                
                this.Healt += this.Level * 10;
                this.Mana += this.Level * 10;
                this.Strength += 2;
                this.Defence += 2;

                this.Experience -= this.NeededExperienceForLevelUp;
                this.NeededExperienceForLevelUp = this.Level * this.NeededExperienceIncrementPerLevel;
            }
        }

        public bool IsDead()
        {
            return this.Healt <= 0;
        }
    }
}
