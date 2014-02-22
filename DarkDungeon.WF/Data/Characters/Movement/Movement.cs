using Data.Characters.PlayerCharacters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Characters.Movement
{
    public class Movement
    {
        public static void ChangeDirection(Character entity, int direction)
        {
            entity.Direction = direction;
        }

        public static bool IsMoveAvailable(Character entity)
        {
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
            int direction = entity.Direction;

            // TO DO Remove old position from the screen

            if (direction == (int)Direction.Up)
            {
                entity.Position.Row--;
            }
            if (direction == (int)Direction.Down)
            {
                entity.Position.Row++;
            }
            if (direction == (int)Direction.Left)
            {
                entity.Position.Column--;
            }
            if (direction == (int)Direction.Right)
            {
                entity.Position.Column++;
            }

            // TO DO Draw new position
        }
    }
}
