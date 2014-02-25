using Data.Characters.PlayerCharacters;
using Data.GridItem;

namespace Data.Characters.Movement
{
    public delegate void EncounteredDelegate(string param, int direction);
    public class Movement
    {
        public static EncounteredDelegate Encounter;
        public static void ChangeDirection(Character entity, int direction)
        {
            entity.Direction = direction;
            if (entity is PlayerCharacter) LevelGrid.PlayerDirectionChanged(direction);
        }

        public static bool IsMoveAvailable(Character entity)
        {
            if (entity.Direction == (int)1)
            {
                if (entity.Position.Column == 0) return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Stone") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Brick") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Demon") return false;
                if (entity is PlayerCharacter)
                {
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "PotionRed")
                    {
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Quiver")
                    {
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Potion")
                    {
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Sword")
                    {
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Bow")
                    {
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Scroll")
                    {
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Armor")
                    {
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Key")
                    {
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Door")
                    {
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "ExitDoor")
                    {
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
                }
            }
            else if (entity.Direction == (int)2)
            {
                if (entity.Position.Column == 30) return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Stone") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Brick") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Demon") return false;
                if (entity is PlayerCharacter)
                {
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "PotionRed")
                    {
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Quiver")
                    {
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Potion")
                    {
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Sword")
                    {
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Bow")
                    {
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Scroll")
                    {
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Armor")
                    {
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Key")
                    {
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Door")
                    {
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "ExitDoor")
                    {
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
                }
            }
            else if (entity.Direction == (int)3)
            {
                if (entity.Position.Row == 0) return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Stone") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Brick") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Demon") return false;
                if (entity is PlayerCharacter)
                {
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "PotionRed")
                    {
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Quiver")
                    {
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Potion")
                    {
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Sword")
                    {
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Bow")
                    {
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Scroll")
                    {
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Armor")
                    {
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Key")
                    {
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Door")
                    {
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "ExitDoor")
                    {
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
                }
            }
            else if (entity.Direction == (int)4)
            {
                if (entity.Position.Row == 18) return false;
                if (entity.Position.Row == 0) return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Stone") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Brick") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Demon") return false;
                if (entity is PlayerCharacter)
                {
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "PotionRed")
                    {
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Quiver")
                    {
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Potion")
                    {
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Sword")
                    {
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Bow")
                    {
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Scroll")
                    {
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Armor")
                    {
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Key")
                    {
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Door")
                    {
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "ExitDoor")
                    {
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool CollisionDetect(Character entity, PlayerCharacter hero)
        {
            if (hero.Position.Column == entity.Position.Column && hero.Position.Row == entity.Position.Row)
            {
                return true;
            }
            return false;
        }

        public static void Move(Character entity)
        {
            int row = entity.Position.Row;
            int col = entity.Position.Column;
            int direction = entity.Direction;

            if (direction == (int)Direction.Up)
            {
                ChangePosition(entity, row - 1, col);
            }
            if (direction == (int)Direction.Down)
            {
                ChangePosition(entity, row + 1, col);
            }
            if (direction == (int)Direction.Left)
            {
                ChangePosition(entity, row, col - 1);
            }
            if (direction == (int)Direction.Right)
            {
                ChangePosition(entity, row, col + 1);
            }
        }

        private static void ChangePosition(Character entity, int newRow, int newCol)
        {
            int index = LevelGrid.GetGridItemImageIndex(entity.Position.Row, entity.Position.Column);
            LevelGrid.SetGridItemValue(entity.Position.Row, entity.Position.Column, 9); // set empty image
            LevelGrid.SetGridItemValue(newRow, newCol, index); // set the image on the new position
            entity.Position.Row = newRow; // set a new value or the old one
            entity.Position.Column = newCol; // set a new value or the old one
        }

    }
}
