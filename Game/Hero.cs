using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public abstract class Hero: ICreature, IMovable
    {
        private string name;
        private byte age;
        private string gender;

    }
}
