using Data.Characters;
using System;

namespace Data.Items.Weapons
{
    public class Weapon : Item, IDamageDealable
    {
        public int Damage { get; protected set; }

        public int Range { get; protected set; }

        public Weapon(int weight, int damage, int range)
            : base(weight)
        {
            this.Damage = damage;
            this.Range = range;
        }

        public int DealDamage()
        {
            int damage = this.Damage;

            return damage;
        }
    }
}
