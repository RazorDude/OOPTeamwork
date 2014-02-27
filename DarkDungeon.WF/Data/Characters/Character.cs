using Data.Items.ItemsCollections.Inventories;
using Data.GridItem;
using System;

namespace Data.Characters
{
    public abstract class Character : GridViewItem, IImprovable, IFightable
    {
        public bool IsProjectile { get; set; }
       
        public Equipment Equipment { get; protected set; }

        public int Level { get; protected set; }

        public int Experience { get; protected set; }

        public int Health { get; set; }

        public int Mana { get; set; }

        public int Strength { get; set; }

        public int Defence { get; protected set; }
        
        public int Direction { get; set; }

        protected int NeededExperienceForLevelUp { get; set; }

        protected readonly int neededExperienceIncrementPerLevel;
        protected int NeededExperienceIncrementPerLevel
        {
            get { return this.neededExperienceIncrementPerLevel; }
        }

        public Character(int Health, int mana, int strength, int defence, int neededExperienceIncrementPerLevel)
            : this(1, Health, mana, strength, defence, neededExperienceIncrementPerLevel, 1)
        {
        }

        public Character(int level, int Health, int mana, int strength, int defence, int neededExperienceIncrementPerLevel, int direction)
            : base()
        {
            this.Position = new Position(0, 0);
            this.Equipment = new Equipment(16, 50M);

            this.Level = level;
            this.Experience = 0;
            this.Health = Health;
            this.Mana = mana;
            this.Strength = strength;
            this.Defence = defence;
            this.Direction = direction;

            this.neededExperienceIncrementPerLevel = neededExperienceIncrementPerLevel;
            this.NeededExperienceForLevelUp = this.Level * this.NeededExperienceIncrementPerLevel;
        }

        public void LevelUp()
        {
            while (this.Experience - this.NeededExperienceForLevelUp > this.NeededExperienceForLevelUp)
            {
                this.Level++;
                
                this.Health += this.Level * 10;
                this.Mana += this.Level * 10;
                this.Strength += 2;
                this.Defence += 2;

                this.Experience -= this.NeededExperienceForLevelUp;
                this.NeededExperienceForLevelUp = this.Level * this.NeededExperienceIncrementPerLevel;
            }
        }

        public void GainExperience(int experience)
        {
            this.Experience += experience;

            if (this.Experience >= this.NeededExperienceForLevelUp)
            {
                this.LevelUp();
            }
        }

        public bool IsDead()
        {
            return this.Health <= 0;
        }

        public int DealDamage()
        {
            int damage = 0;

            damage += this.Equipment.DealDamage();

            return damage;
        }

        public int AbsorbDamage(int damage)
        {
            int absorbedDamage = 0;

            absorbedDamage += this.Defence;
            // absorbedDamage += this.AbsorbDamage(damage);
            //absorbedDamage += this.Equipment.AbsorbDamage(damage);

            int remainedDamage = Math.Max(damage - absorbedDamage, 0);

            return remainedDamage;
        }

        public int TakeDamage(int damage)
        {
            int takenDamage = this.AbsorbDamage(damage);

            this.Health -= takenDamage;

            if(this.IsDead())
            {
                LevelGrid.SetGridItemValue(this.Position.Row, this.Position.Column, (int)Images.Empty);
                this.Position.Row = 10;
                this.Position.Column = LevelGrid.AlmostOutOfGrid;
            }

            return takenDamage;
        }
    }
}
