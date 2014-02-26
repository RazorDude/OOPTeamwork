
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

            //switch (imageIndex)
            //{
            //    case 3: this.value = "Stone";
            //        break;
            //    case 4: this.value = "StoneWall";
            //        break;
            //    case 5: this.value = "Brick";
            //        break;
            //    case 6: this.value = "BrickWall";
            //        break;
            //    case 7: this.value = "Door";
            //        break;
            //    case 8: this.value = "Key";
            //        break;
            //    case 9: this.value = "Empty";
            //        break;
            //    case 10: this.value = "Character-Left";
            //        break;
            //    case 11: this.value = "Character-Right";
            //        break;
            //    case 12: this.value = "Character-Up";
            //        break;
            //    case 13: this.value = "Character-Down";
            //        break;
            //    case 14: this.value = "Demon";
            //        break;
            //    case 15: this.value = "Sword";
            //        break;
            //    case 16: this.value = "Bow";
            //        break;
            //    case 17: this.value = "Armor";
            //        break;
            //    case 18: this.value = "Quiver";
            //        break;
            //    case 19: this.value = "Potion";
            //        break;
            //    case 20: this.value = "Fireball";
            //        break;
            //    case 21: this.value = "Arrow-Left";
            //        break;
            //    case 22: this.value = "Arrow-Right";
            //        break;
            //    case 23: this.value = "Arrow-Up";
            //        break;
            //    case 24: this.value = "Arrow-Down";
            //        break;
            //    case 25: this.value = "ExitDoor";
            //        break;
            //    case 26: this.value = "PotionRed";
            //        break;
            //    case 27: this.value = "Scroll";
            //        break;
            //}
        }

        public GridViewItem(Position position)
        {
            this.Position = position;
        }
    }
}
