using Data.Characters.Movement;
using Data.Characters.PlayerCharacters;
using Data.GridItem;
using System.Threading;

namespace Data
{
    public class ShotLogic
    {
        string charClass;
        PlayerCharacter shot;
        public ShotLogic(int row, int column, int direction, string charClass)
        {
            this.shot = new PlayerCharacter("shot");
            this.charClass = charClass;
            this.shot.IsProjectile = true;
            this.shot.Position.Row = row;
            this.shot.Position.Column = column;
            this.shot.Direction = direction;
        }
        public void Shoot()
        {
            if (this.charClass == "Marksman")
            {
                switch (this.shot.Direction)
                {
                    case (int)Direction.Left: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, (int)Images.ArrowLeft);
                        break;
                    case (int)Direction.Right: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, (int)Images.ArrowRight);
                        break;
                    case (int)Direction.Up: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, (int)Images.ArrowUp);
                        break;
                    case (int)Direction.Down: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, (int)Images.ArrowDown);
                        break;
                }
            }
            else LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, (int)Images.Fireball);

            while (Movement.IsMoveAvailable(shot))
            {
                Thread.Sleep(250);
                Movement.Move(shot);
            }

            Thread.Sleep(250);
            LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, (int)Images.Empty);

            switch (this.shot.Direction)
            {
                case (int)Direction.Left:
                    if (LevelGrid.GetGridItemValue(shot.Position.Row, (shot.Position.Column - 1)) == "Demon")
                        Movement.Encounter("Demon", this.shot.Direction);
                    return;
                case (int)Direction.Right:
                    if (LevelGrid.GetGridItemValue(shot.Position.Row, (shot.Position.Column + 1)) == "Demon")
                        Movement.Encounter("Demon", this.shot.Direction);
                    return;
                case (int)Direction.Up:
                    if (LevelGrid.GetGridItemValue((shot.Position.Row - 1), shot.Position.Column) == "Demon")
                        Movement.Encounter("Demon", this.shot.Direction);
                    return;
                case (int)Direction.Down:
                    if (LevelGrid.GetGridItemValue((shot.Position.Row + 1), shot.Position.Column) == "Demon")
                        Movement.Encounter("Demon", this.shot.Direction);
                    return;
            }
        }
    }
}
