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
                    case 1: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 21);
                        break;
                    case 2: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 22);
                        break;
                    case 3: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 23);
                        break;
                    case 4: LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 24);
                        break;
                }
            }
            else LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 20);
            while (Movement.IsMoveAvailable(shot))
            {
                Thread.Sleep(500);
                Movement.Move(shot);
            }
            switch (this.shot.Direction)
            {
                case 1:
                    if (LevelGrid.GetGridItemValue(shot.Position.Row, (shot.Position.Column - 1)) == "Demon") return;
                    else
                    {
                        LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 9);
                        return;
                    }
                case 2:
                    if (LevelGrid.GetGridItemValue(shot.Position.Row, (shot.Position.Column + 1)) == "Demon") return;
                    else
                    {
                        LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 9);
                        return;
                    }
                case 3:
                    if (LevelGrid.GetGridItemValue((shot.Position.Row - 1), shot.Position.Column) == "Demon") return;
                    else
                    {
                        LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 9);
                        return;
                    }
                case 4:
                    if (LevelGrid.GetGridItemValue((shot.Position.Row + 1), shot.Position.Column) == "Demon") return;
                    else
                    {
                        LevelGrid.SetGridItemValue(this.shot.Position.Row, this.shot.Position.Column, 9);
                        return;
                    }
            }
        }
    }
}
