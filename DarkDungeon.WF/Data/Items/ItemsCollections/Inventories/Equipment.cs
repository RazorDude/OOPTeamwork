using Data.Items.DefenceItems;
using Data.Items.Weapons;
using System;

namespace Data.Items.ItemsCollections.Inventories
{
    public class Equipment : Inventory, IDamageDealable, IDefensible
    {
        public Weapon Weapon { get; private set; }

        public DefenceItem Armor { get; private set; }

        public DefenceItem Helmet { get; private set; }

        public DefenceItem Boots { get; private set; }

        public DefenceItem Gloves { get; private set; }
        public int Arrows { get; set; }

        public Equipment()
            : this(16, 50.0M)
        {
            
        }

        public Equipment(int itemsCountCapacity, decimal itemsWeightCapacity)
            : base(itemsCountCapacity, itemsWeightCapacity)
        {
            this.Weapon = null;
            this.Armor = null;
            this.Helmet = null;
            this.Boots = null;
            this.Gloves = null;
            this.Arrows = 0;
        }

        public Weapon SetWeapon(Weapon weapon)
        {
            Weapon oldWeapon = this.Weapon;

            this.Weapon = weapon;
            
            return oldWeapon;
        }

        public DefenceItem SetArmor(DefenceItem armor)
        {
            DefenceItem oldArmor = this.Armor;

            this.Armor = armor;

            return oldArmor;
        }

        public DefenceItem SetHelmet(DefenceItem helmet)
        {
            DefenceItem oldHelmet = this.Helmet;
            
            this.Helmet = helmet;

            return oldHelmet;
        }

        public DefenceItem SetBoots(DefenceItem boots)
        {
            DefenceItem oldBoots = this.Boots;
            
            this.Boots = boots;

            return oldBoots;
        }
    
        public DefenceItem SetGloves(DefenceItem gloves)
        {
            DefenceItem oldGloves = this.Gloves;

            this.Gloves = gloves;
            
            return oldGloves;
        }

        public new decimal GetWeight()
        {
            decimal weight = 0.0M;

            weight += this.Items.GetWeight();

            if (this.Weapon != null)
            {
                weight += this.Weapon.GetWeight();
            }

            if (this.Armor != null)
            {
                weight += this.Armor.GetWeight();
            }

            if (this.Helmet != null)
            {
                weight += this.Helmet.GetWeight();
            }

            if (this.Boots != null)
            {
                weight += this.Boots.GetWeight();
            }

            if (this.Gloves != null)
            {
                weight += this.Gloves.GetWeight();
            }

            return weight;
        }

        public int DealDamage()
        {
            int damage = 0;

            if (this.Weapon != null)
            {
                damage += this.Weapon.DealDamage();
            }

            return damage;
        }

        public int AbsorbDamage(int damage)
        {
            int absorbedDamage = 0;

            if (this.Armor != null)
            {
                absorbedDamage += this.Armor.AbsorbDamage(damage);
            }

            if (this.Helmet != null)
            {
                absorbedDamage += this.Helmet.AbsorbDamage(damage);
            }

            if (this.Boots != null)
            {
                absorbedDamage += this.Boots.AbsorbDamage(damage);
            }

            if (this.Gloves != null)
            {
                absorbedDamage += this.Gloves.AbsorbDamage(damage);
            }

            int remainedDamage = Math.Max(damage - absorbedDamage, 0);

            return remainedDamage;
        }
    }
}
