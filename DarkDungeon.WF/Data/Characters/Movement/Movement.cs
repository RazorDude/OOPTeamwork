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
<<<<<<< HEAD
            return true;
=======
            return true; 
>>>>>>> fe6b2f879d76d17ff22b514607ace8d21e1876ee
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
            int direction = entity.Direction, tempImageIndex = 0;
            if (direction == (int)Direction.Up)
            {
                if (IsMoveAvailable(entity))
                {
                    tempImageIndex = LevelGrid.GetGridItemImageIndex(entity.Position.Row, entity.Position.Column);
                    LevelGrid.SetGridItemValue(entity.Position.Row, entity.Position.Column, 9);
                    LevelGrid.SetGridItemValue((entity.Position.Row - 1), entity.Position.Column, tempImageIndex);
                    entity.Position.Row--;
                }
            }
            if (direction == (int)Direction.Down)
            {
                if (IsMoveAvailable(entity))
                {
                    tempImageIndex = LevelGrid.GetGridItemImageIndex(entity.Position.Row, entity.Position.Column);
                    LevelGrid.SetGridItemValue(entity.Position.Row, entity.Position.Column, 9);
                    LevelGrid.SetGridItemValue((entity.Position.Row + 1), entity.Position.Column, tempImageIndex);
                    entity.Position.Row++;
                }
            }
            if (direction == (int)Direction.Left)
            {
                if (IsMoveAvailable(entity))
                {
                    tempImageIndex = LevelGrid.GetGridItemImageIndex(entity.Position.Row, entity.Position.Column);
                    LevelGrid.SetGridItemValue(entity.Position.Row, entity.Position.Column, 9);
                    LevelGrid.SetGridItemValue(entity.Position.Row, (entity.Position.Column - 1), tempImageIndex);
                    entity.Position.Column--;
                }
            }
            if (direction == (int)Direction.Right)
            {
                if (IsMoveAvailable(entity))
                {
                    tempImageIndex = LevelGrid.GetGridItemImageIndex(entity.Position.Row, entity.Position.Column);
                    LevelGrid.SetGridItemValue(entity.Position.Row, entity.Position.Column, 9);
                    LevelGrid.SetGridItemValue(entity.Position.Row, (entity.Position.Column + 1), tempImageIndex);
                    entity.Position.Column++;
                }
            }
        }
    }
}
