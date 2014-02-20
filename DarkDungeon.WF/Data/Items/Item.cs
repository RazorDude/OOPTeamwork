using Data.GridItem;
using System;

namespace Data.Items
{
    public abstract class Item : GridViewItem, IWearable, IWeightable
    {
        protected decimal Weight { get; set; }

        public Item(decimal weight)
            : base()
        {
            this.Weight = weight;
        }

        public decimal GetWeight()
        {
            return this.Weight;
        }
    }
}
