using System;

namespace Data.Characters.PlayerCharacters
{
    public class PlayerCharacter : Character
    {
        public string CharacterName { get; set; }

        public PlayerCharacter(string characterName)
            : base(100, 100, 100, 10, 10)
        {
            this.CharacterName = characterName;
        }
    }
}
