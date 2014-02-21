using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.GridItem
{
    public abstract class GridViewItem
    {
        public Position Position { get; set; }

        public GridViewItem()
            : this(0, 0)
        {

        }

        public GridViewItem(int row, int column)
            :  this(new Position(row, column))
        {

        }

        public GridViewItem(Position position)
        {
            this.Position = position;
        }
    }
}
