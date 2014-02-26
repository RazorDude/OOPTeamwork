using System;

namespace Data.Items.Potions
{
    public abstract class Potion : Item, IConsumable
    {
        public int Bonus { get; set; }

        public Potion(decimal weight, int bonus)
            : base(weight)
        {
            this.Bonus = bonus;
        }
        public int Consume()
        {
            return this.Bonus;
        }

        void IConsumable.Consume()
        {
            throw new NotImplementedException();
        }
    }
}
