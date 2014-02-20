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
    }
}
