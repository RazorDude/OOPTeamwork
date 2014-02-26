
namespace Data.GridItem
{
    public class GridViewItem
    {
        int imageIndex;
        string value;
        public int ImageIndex { get { return this.imageIndex; } }
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public Position Position { get; set; }

        public GridViewItem()
        {
        }

        public GridViewItem(int row, int column, int imageIndex)
            : this(new Position(row, column))
        {
            this.value = "";
            SetValue(imageIndex);
        }

        public void UpdateValue(int imageIndex)
        {
            SetValue(imageIndex);

            LevelGrid.OnGridItemChanged(this.Position.Row, this.Position.Column, this.imageIndex);
        }

        private void SetValue(int imageIndex)
        {
            this.imageIndex = imageIndex;
            this.value = ((Images)imageIndex).ToString();  // do this instead of the switch below
        }

        public GridViewItem(Position position)
        {
            this.Position = position;
        }
    }
}
