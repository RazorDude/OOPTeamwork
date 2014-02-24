using System;

namespace Data.Items.Money
{
    public class MoneyBag : Item, ITransactable
    {
        public decimal Money { get; private set; }

        public MoneyBag()
            : this(0.0M)
        {

        }

        public MoneyBag(decimal money)
            : base(1.0M)
        {
            this.Money = Math.Max(0, money);
        }

        public decimal Deposit(decimal money)
        {
            this.Money += money;

            return this.Money;
        }

        public decimal Draw(decimal money)
        {
            if (this.Money >= money)
            {
                this.Money -= money;
            }

            return this.Money;
        }
    }
}
