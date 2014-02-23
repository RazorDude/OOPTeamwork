using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.GridItem
{
    public delegate void PlayerDirectionChangedDelegate(int direction);
    public delegate void GridItemChangedDelegate(int row, int column, int imageIndex);
    public static class LevelGrid
    {
        public static PlayerDirectionChangedDelegate PlayerDirectionChanged;
        public static GridItemChangedDelegate OnGridItemChanged;
        static GridViewItem[,] grid = new GridViewItem[19, 31];
        public static void InitializeGridItem(int row, int column, int imageIndex)
        {
            grid[row, column] = new GridViewItem(row, column, imageIndex);
        }
        public static int GetGridItemImageIndex(int row, int column)
        {
            return grid[row, column].ImageIndex;
        }
        public static string GetGridItemValue(int row, int column)
        {
            return grid[row, column].Value;
        }
        public static void SetGridItemValue(int row, int column, int imageIndex)
        {
            grid[row, column].UpdateValue(imageIndex);
        }
    }
}
