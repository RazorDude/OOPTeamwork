using Data.Items.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Items.Inventars
{
    public abstract class Inventar
    {
        public MoneyBag Money { get; protected set; }

        public List<Item> Items { get; protected set; }

        public int ItemsCountCapacity { get; protected set; }

        public decimal ItemsWeightCapacity { get; protected set; }

        public decimal ItemsWeight { get; protected set; }
        
        public Inventar(int itemsCountCapacity, decimal itemsWeightCapacity)
        {
            this.Money = new MoneyBag();
            this.Items = new List<Item>();
            this.ItemsCountCapacity = itemsCountCapacity;
            this.ItemsWeightCapacity = itemsWeightCapacity;
            this.ItemsWeight = 0.0M;
        }

        public bool AddItem(Item item)
        {
            if (this.Items.Count < this.ItemsCountCapacity && this.ItemsWeight + item.Weight <= this.ItemsWeightCapacity)
            {
                this.Items.Add(item);
                this.ItemsWeight += item.Weight;

                return true;
            }

            return false;
        }

        public Item RemoveItem(Item item)
        {
            for (int i = 0 ; i < this.Items.Count; i++)
            {
                if (this.Items[i] == item)
                {
                    Item removedItem = this.Items[i];

                    this.ItemsWeight -= removedItem.Weight;
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

                this.ItemsWeight -= removedItem.Weight;
                this.Items.RemoveAt(index);

                return removedItem;
            }

            return null;
        }
    }
}
