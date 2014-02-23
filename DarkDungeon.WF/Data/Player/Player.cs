using System;
using Data.Characters;
using Data.Characters.PlayerCharacters;

namespace Data.Player
{
    public class Player
    {
        public string PlayerName { get; set; }

        public PlayerCharacter Character { get; private set; }   

        public Player(string playerName)
        {
            this.PlayerName = playerName;
            this.Character = null;
        }

        public void CreateCharacter(string characterName, string characterClass)
        {
            this.Character = new PlayerCharacter(characterName);
            this.Character.CharacterClass = characterClass;
        }
    }
}
