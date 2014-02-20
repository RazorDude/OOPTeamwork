using System;

namespace Data.Characters
{
    public interface IFightable
    {
        int DealDamage();

        int AbsorbDamage(int damage);

        int TakeDamage(int damage);
    }
}
