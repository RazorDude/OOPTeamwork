using Data.GridItem;
using System;

namespace Data.Items
{
    public abstract class Item : GridViewItem, IWearable, IWeightable
    {
        public bool IsObtacle { get; private set; }
        protected decimal Weight { get; set; }

        public Item()
        { 
        }
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
