using Data.Items.ItemsCollections;
using Data.Items.Money;
using Data.Items.Potions;
using System;
using System.Collections.Generic;

namespace Data.Items.ItemsCollections.Inventories
{
    public class Inventory : IWearable, IWeightable
    {
        public MoneyBag Money { get; protected set; }

        public ItemsCollection Items { get; set; }

        public PotionsCollection Potions { get; set; }
        
        public Inventory(int itemsCountCapacity, decimal itemsWeightCapacity)
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
