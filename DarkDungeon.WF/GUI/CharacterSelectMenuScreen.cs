using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    class CharacterSelectMenuScreen : MenuScreen
    {
        TextBox playerName, characterName;
        public string PlayerName
        {
            get { return this.playerName.Text; }
        }
        public string CharacterName
        {
            get { return this.characterName.Text; }
        }
        public CharacterSelectMenuScreen()
        {
            this.playerName = new TextBox();
            this.characterName = new TextBox();
            this.buttons = new Button[4];
            OnClick c = new OnClick(ButtonClickEvents.KnightKlick);
            this.InitializeButton(0, "Knight", "Knight", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 270, c);
            c = new OnClick(ButtonClickEvents.MarksmanKlick);
            this.InitializeButton(1, "Marksman", "Marksman", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 350, c);
            c = new OnClick(ButtonClickEvents.MageKlick);
            this.InitializeButton(2, "Mage", "Mage", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 430, c);
            c = new OnClick(ButtonClickEvents.ToMainMenuClick);
            this.InitializeButton(3, "Back", "Back", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 510, c);
            this.playerName.Name = "Player";
            this.playerName.Text = "PlayerName";
            this.playerName.BackColor = Color.DarkGray;
            this.playerName.Width = 130;
            this.playerName.Height = 53;
            this.playerName.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2 + 125), 270);
            this.characterName.Name = "Character";
            this.characterName.Text = "CharacterName";
            this.characterName.BackColor = Color.DarkGray;
            this.characterName.Width = 130;
            this.characterName.Height = 53;
            this.characterName.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2 + 125), 330);
        }
        public override Control[] GetControlData()
        {
            Control[] controls = new Control[6];
            for (int i = 0; i < 4; i++) controls[i] = this.buttons[i];
            controls[4] = this.playerName;
            controls[5] = this.characterName;
            return controls;
        }
    }
}
