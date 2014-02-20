using Data.Items.ItemsCollections;
using System;
using System.Collections.Generic;

namespace Data.Items.Potions
{
    public class PotionsCollection
    {
        public ItemsCollection HealthPotions { get; private set; }

        public ItemsCollection ManaPotions { get; private set; }

        public PotionsCollection()
        {
            this.HealthPotions = new ItemsCollection(16, 50.0M);
            this.ManaPotions = new ItemsCollection(16, 50.0M);
        }

        public decimal GetWeight()
        {
            decimal weight = 0.0M;

            weight += this.HealthPotions.GetWeight();
            weight += this.ManaPotions.GetWeight();

            return weight;
        }
    }
}
