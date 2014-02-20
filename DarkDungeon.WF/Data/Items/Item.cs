using System;

namespace Data.Items
{
    public abstract class Item : IWearable
    {
        public decimal Weight { get; set; }

        public Item(decimal weight)
        {
            this.Weight = weight;
        }
    }
}
