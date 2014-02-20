using Data.Items.DefenceItems;
using Data.Items.Weapons;
using System;

namespace Data.Items.ItemsCollections.Inventars
{
    public class CharacterInventar : Inventar
    {
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
            this.Weapon = null;
            this.Armor = null;
            this.Helmet = null;
            this.Boots = null;
            this.Gloves = null;
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

        public decimal GetWeight()
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
    }
}
