using System;

namespace Data.Items.Money
{
    public interface ITransactable
    {
        decimal Deposit(decimal value);

        decimal Draw(decimal value);
    }
}
