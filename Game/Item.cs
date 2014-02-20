using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
   public abstract class Item: IItem
    {
       private byte durability;
       private int attack;
       private int defence;
       private byte chanceToCriticalHit;
       private byte restoreHealth;
       private byte regeneration;
       
    }
}
