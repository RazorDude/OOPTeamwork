using System;

namespace Data.Items.DefenceItems
{
    public class DefenceItem : Item, IDefensible
    {
        public int Defence { get; protected set; }

        public DefenceItem(decimal weight, int defence)
            : base(weight)
        {
            this.Defence = defence;
        }

        public int AbsorbDamage(int damage)
        {
            int absorbedDamage = Math.Min(this.Defence, damage);

            int remainedDamage = damage - absorbedDamage;

            return remainedDamage;
        }
    }
}
