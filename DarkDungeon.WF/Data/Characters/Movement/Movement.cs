﻿using Data.Characters.PlayerCharacters;
using Data.GridItem;

namespace Data.Characters.Movement
{
    public class Movement
    {
        public static void ChangeDirection(Character entity, int direction)
        {
            entity.Direction = direction;
            if (entity is PlayerCharacter) LevelGrid.PlayerDirectionChanged(direction);
        }

        public static bool IsMoveAvailable(Character entity)
        {
<<<<<<< HEAD
            if (entity.Direction == (int)1)
            {
                if (entity.Position.Column == 0) return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Stone") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Brick") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column - 1)) == "Demon") return false;
            }
            else if (entity.Direction == (int)2)
            {
                if (entity.Position.Column == 30) return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Stone") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Brick") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue(entity.Position.Row, (entity.Position.Column + 1)) == "Demon") return false;
            }
            else if (entity.Direction == (int)3)
            {
                if (entity.Position.Row == 0) return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Stone") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "StoneWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Brick") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "BrickWall") return false;
                if (LevelGrid.GetGridItemValue((entity.Position.Row - 1), entity.Position.Column) == "Demon") return false;
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
            }
            return true; 
=======
            int moveX = 0;
            int moveY = 0;
            
            if (entity.Direction == Direction.Right)
            {
                moveX = 1;
            }
            
            if (entity.Direction == Direction.Left)
            {
                moveX = -1;
            }
            
            if (entity.Direction == Direction.Up)
            {
                moveY = -1;
            }

            if (entity.Direction == Direction.Down)
            {
                moveY = 1;
            }

           // TO DO - code like this : if item in cooridnates(x+moveX,y+moveY).IsObtacle ==true return false 

            // TO DO - add check it there is a wall, item,...
            return false; // temp value
>>>>>>> 7867dd1429f112bfb10aaa8cca95367677c33283
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
