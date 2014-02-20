using System;

namespace Data
{
    public class Position
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Position()
            : this(0, 0)
        {

        }

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
