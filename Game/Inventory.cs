using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
   public class Inventory
    {
       private double money;
       private int size; //size of the inventory
       private List<Weapon> weapons = new List<Weapon>();
       private List<Shield> shields = new List<Shield>();
       private List<Potion> potions = new List<Potion>();
       private List<Armor> armors = new List<Armor>();

    }
}
