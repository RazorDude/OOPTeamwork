using Data.Items.DefenceItems;
using Data.Items.Weapons;
using System;

namespace Data.Items.Inventars
{
    public class CharacterInventar : Inventar
    {
        public decimal TotalWeight { get; private set; }

        public Weapon Weapon { get; private set; }

        public DefenceItem Armor { get; private set; }

        public DefenceItem Helmet { get; private set; }

        public DefenceItem Boots { get; private set; }

        public DefenceItem Gloves { get; private set; }

        public CharacterInventar()
            : this(16, 50.0M)
        {
            
        }

        public CharacterInventar(int itemsCountCapacity, decimal itemsWeightCapacity)
            : base(itemsCountCapacity, itemsWeightCapacity)
        {
            this.TotalWeight = this.ItemsWeight;
            this.Weapon = null;
            this.Armor = null;
            this.Helmet = null;
            this.Boots = null;
            this.Gloves = null;
        }

        public Weapon SetWeapon(Weapon weapon)
        {
            Weapon oldWeapon = this.Weapon;

            if (oldWeapon != null)
            {
                this.TotalWeight -= oldWeapon.Weight;
            }

            this.Weapon = weapon;
            
            if (weapon != null)
            {
                this.TotalWeight += weapon.Weight;
            }

            return oldWeapon;
        }

        public DefenceItem SetArmor(DefenceItem armor)
        {
            DefenceItem oldArmor = this.Armor;

            if (oldArmor != null)
            {
                this.TotalWeight -= oldArmor.Weight;
            }

            this.Armor = armor;

            if (Armor != null)
            {
                this.TotalWeight += armor.Weight;
            }

            return oldArmor;
        }

        public DefenceItem SetHelmet(DefenceItem helmet)
        {
            DefenceItem oldHelmet = this.Helmet;

            if (oldHelmet != null)
            {
                this.TotalWeight -= oldHelmet.Weight;
            }

            this.Helmet = helmet;

            if (Helmet != null)
            {
                this.TotalWeight += helmet.Weight;
            }

            return oldHelmet;
        }

        public DefenceItem SetBoots(DefenceItem boots)
        {
            DefenceItem oldBoots = this.Boots;

            if (oldBoots != null)
            {
                this.TotalWeight -= oldBoots.Weight;
            }

            this.Boots = boots;

            if (Boots != null)
            {
                this.TotalWeight += boots.Weight;
            }

            return oldBoots;
        }
    
        public DefenceItem SetGloves(DefenceItem gloves)
        {
            DefenceItem oldGloves = this.Gloves;

            if (oldGloves != null)
            {
                this.TotalWeight -= oldGloves.Weight;
            }

            this.Gloves = gloves;

            if (Gloves != null)
            {
                this.TotalWeight += gloves.Weight;
            }

            return oldGloves;
        }
    }
}
