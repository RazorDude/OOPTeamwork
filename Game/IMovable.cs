using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    interface IMovable
    {
        void Move(int[,] direction, double speed);

        double Speed { get; set; }
        int[,] Direction { get; set; }
    }
}
