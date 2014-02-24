using Data.Items.ItemsCollections;
using Data.Items.Money;
using Data.Items.Potions;
using System;
using System.Collections.Generic;

namespace Data.Items.ItemsCollections.Inventars
{
    public abstract class Inventar : IWearable, IWeightable
    {
        public MoneyBag Money { get; protected set; }

        public ItemsCollection Items { get; protected set; }

        public PotionsCollection Potions { get; protected set; }
        
        public Inventar(int itemsCountCapacity, decimal itemsWeightCapacity)
        {
            this.Money = new MoneyBag();
            this.Items = new ItemsCollection(itemsCountCapacity, itemsWeightCapacity);
            this.Potions = new PotionsCollection();
        }

        public decimal GetWeight()
        {
            decimal weight = 0.0M;

            weight += this.Money.GetWeight();
            weight += this.Items.GetWeight();
            weight += this.Potions.GetWeight();

            return weight;
        }
    }
}
