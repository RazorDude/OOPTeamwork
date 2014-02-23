using System;

namespace GUI
{
    class ButtonClickEvents
    {
        public static void NewGameClick(object sender, EventArgs e)
        {
            Window.Execute("Character select");
        }
        public static void KnightKlick(object sender, EventArgs e)
        {
            Window.Execute("Knight");
        }
        public static void MarksmanKlick(object sender, EventArgs e)
        {
            Window.Execute("Marksman");
        }
        public static void MageKlick(object sender, EventArgs e)
        {
            Window.Execute("Mage");
        }
        public static void SaveGameClick(object sender, EventArgs e)
        {
            Window.Execute("Save game");
        }
        public static void SaveToSlot1Click(object sender, EventArgs e)
        {
            Window.Execute("Save to 1");
        }
        public static void SaveToSlot2Click(object sender, EventArgs e)
        {
            Window.Execute("Save to 2");
        }
        public static void SaveToSlot3Click(object sender, EventArgs e)
        {
            Window.Execute("Save to 3");
        }
        public static void SaveMenuBackClick(object sender, EventArgs e)
        {
            Window.Execute("Pause menu");
        }
        public static void LoadGameClick(object sender, EventArgs e)
        {
            Window.Execute("Load game");
        }
        public static void LoadSlot1Click(object sender, EventArgs e)
        {
            Window.Execute("Load from 1");
        }
        public static void LoadSlot2Click(object sender, EventArgs e)
        {
            Window.Execute("Load from 2");
        }
        public static void LoadSlot3Click(object sender, EventArgs e)
        {
            Window.Execute("Load from 3");
        }
        public static void LoadMenuBackClick(object sender, EventArgs e)
        {
            Window.Execute("Main menu");
        }
        public static void ResumeGameClick(object sender, EventArgs e)
        {
            Window.Execute("Resume game");
        }
        public static void HighScoresClick(object sender, EventArgs e)
        {
            Window.Execute("High scores");
        }
        public static void HelpClick(object sender, EventArgs e)
        {
            Window.Execute("Help");
        }
        public static void ToMainMenuClick(object sender, EventArgs e)
        {
            Window.Execute("Main menu");
        }
        public static void ExitClick(object sender, EventArgs e)
        {
            Window.Execute("To desktop");
        }
    }
}
