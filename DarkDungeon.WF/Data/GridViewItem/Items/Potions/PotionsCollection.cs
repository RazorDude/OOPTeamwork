using Data.Items.ItemsCollections;
using System;
using System.Collections.Generic;

namespace Data.Items.Potions
{
    public class PotionsCollection : Item
    {
        public ItemsCollection StrengthPotions { get; private set; }
        public ItemsCollection ManaPotions { get; private set; }

        public PotionsCollection()
            : base(0)
        {
            this.StrengthPotions = new ItemsCollection(16, 50.0M);
            this.ManaPotions = new ItemsCollection(16, 50.0M);
        }

        public new decimal GetWeight()
        {
            decimal weight = 0.0M;

            weight += this.StrengthPotions.GetWeight();
            weight += this.ManaPotions.GetWeight();

            return weight;
        }
    }
}
