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
            int row = entity.Position.Row;
            int col = entity.Position.Column;

            if (entity.Direction == (int)Direction.Left)
            {
                if (entity.Position.Column == 0) return false;
<<<<<<< HEAD
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Stone") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Brick") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Demon") return false;
                if (entity is PlayerCharacter)
                {
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "PotionRed")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Quiver")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Potion")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Sword")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Bow")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Scroll")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Armor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Key")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Door")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "ExitDoor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
                }
=======
                return CheckNeighbour(entity, row, col - 1);
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
            }
            else if (entity.Direction == (int)Direction.Right)
            {
                if (entity.Position.Column == 30) return false;
<<<<<<< HEAD
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Stone") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Brick") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Demon") return false;
                if (entity is PlayerCharacter)
                {
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "PotionRed")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Quiver")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Potion")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Sword")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Bow")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Scroll")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Armor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Key")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Door")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "ExitDoor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
                }
=======
                return CheckNeighbour(entity, row, col + 1);
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
            }
            else if (entity.Direction == (int)Direction.Up)
            {
                if (entity.Position.Row == 0) return false;
<<<<<<< HEAD
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Stone") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Brick") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Demon") return false;
                if (entity is PlayerCharacter)
                {
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "PotionRed")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Quiver")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Potion")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Sword")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Bow")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Scroll")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Armor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Key")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Door")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "ExitDoor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
                }
=======
                return CheckNeighbour(entity, row - 1, col);
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
            }
            else if (entity.Direction == (int)Direction.Down)
            {
                if (entity.Position.Row == 18) return false;
                if (entity.Position.Row == 0) return false;
                return CheckNeighbour(entity, row + 1, col);
            }
            return true;
        }

        public static bool CheckNeighbour(Character entity, int row, int col)
        {
            if (LevelGrid.GetGridItemValue(row, col) == "Stone") return false;
            if (LevelGrid.GetGridItemValue(row, col) == "StoneWall") return false;
            if (LevelGrid.GetGridItemValue(row, col) == "Brick") return false;
            if (LevelGrid.GetGridItemValue(row, col) == "BrickWall") return false;
            if (LevelGrid.GetGridItemValue(row, col) == "Demon") return false;
            if (entity is PlayerCharacter)
            {
                if (LevelGrid.GetGridItemValue(row, col) == "PotionRed")
                {
                    Encounter("PotionRed", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Quiver")
                {
                    Encounter("Quiver", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Potion")
                {
                    Encounter("Potion", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Sword")
                {
                    Encounter("Sword", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Bow")
                {
                    Encounter("Bow", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Scroll")
                {
<<<<<<< HEAD
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "PotionRed")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("PotionRed", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Quiver")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Quiver", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Potion")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Potion", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Sword")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Sword", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Bow")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Bow", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Scroll")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Scroll", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Armor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Armor", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Key")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Key", entity.Direction);
                        return true;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "Door")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("Door", entity.Direction);
                        return false;
                    }
                    if (LevelGrid.GetGridItemValue((entity.Position.Row + 1), entity.Position.Column) == "ExitDoor")
                    {
                        if (entity.IsProjectile) return false;
                        Encounter("ExitDoor", entity.Direction);
                        return false;
                    }
=======
                    Encounter("Scroll", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Armor")
                {
                    Encounter("Armor", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Key")
                {
                    Encounter("Key", entity.Direction);
                    return true;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "Door")
                {
                    Encounter("Door", entity.Direction);
                    return false;
                }
                if (LevelGrid.GetGridItemValue(row, col) == "ExitDoor")
                {
                    Encounter("ExitDoor", entity.Direction);
                    return false;
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
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
