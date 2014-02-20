using System;
using System.Collections.Generic;

namespace Data.Items.ItemsCollections
{
    public class ItemsCollection : Item
    {
        public List<Item> Items { get; protected set; }

        public int ItemsCountCapacity { get; protected set; }

        public decimal ItemsWeightCapacity { get; protected set; }

        public decimal ItemsWeight { get; protected set; }

        public ItemsCollection(int itemsCountCapacity, decimal itemsWeightCapacity)
            : base(0.0M)
        {
            this.Items = new List<Item>();
            this.ItemsCountCapacity = itemsCountCapacity;
            this.ItemsWeightCapacity = itemsWeightCapacity;
            this.ItemsWeight = 0.0M;
        }

        public bool AddItem(Item item)
        {
            if (this.Items.Count < this.ItemsCountCapacity && this.ItemsWeight + item.GetWeight() <= this.ItemsWeightCapacity)
            {
                this.Items.Add(item);
                this.ItemsWeight += item.GetWeight();

                return true;
            }

            return false;
        }

        public Item RemoveItem(Item item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i] == item)
                {
                    Item removedItem = this.Items[i];

                    this.ItemsWeight -= removedItem.GetWeight();
                    this.Items.RemoveAt(i);

                    return removedItem;
                }
            }

            return null;
        }

        public Item RemoveItemByIndex(int index)
        {
            if (index >= 0 && index < this.Items.Count)
            {
                Item removedItem = this.Items[index];

                this.ItemsWeight -= removedItem.GetWeight();
                this.Items.RemoveAt(index);

                return removedItem;
            }

            return null;
        }

        public new decimal GetWeight()
        {
            return this.ItemsWeight;
        }
    }
}
