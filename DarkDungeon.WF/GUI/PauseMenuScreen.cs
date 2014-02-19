using System.Windows.Forms;

namespace GUI
{
    class PauseMenuScreen : MenuScreen
    {
        public PauseMenuScreen()
        {
            this.buttons = new Button[5];
            OnClick c = new OnClick(ButtonClickEvents.ResumeGameClick);
            this.InitializeButton(0, "ResumeGame", "Resume Game", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 270, c);
            c = new OnClick(ButtonClickEvents.SaveGameClick);
            this.InitializeButton(1, "SaveGame", "Save Game", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 350, c);
            c = new OnClick(ButtonClickEvents.HelpClick);
            this.InitializeButton(2, "Help", "Help", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 430, c);
            c = new OnClick(ButtonClickEvents.ToMainMenuClick);
            this.InitializeButton(3, "ExitToMainMenu", "Exit to Main Menu", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 510, c);
            c = new OnClick(ButtonClickEvents.ExitClick);
            this.InitializeButton(4, "Quit", "Quit to Desktop", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 590, c);
        }
    }
}
