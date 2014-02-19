using System.Windows.Forms;

namespace GUI
{
    class MainMenuScreen : MenuScreen
    {
        public MainMenuScreen()
        {
            this.buttons = new Button[5];
            OnClick c = new OnClick(ButtonClickEvents.NewGameClick);
            this.InitializeButton(0, "NewGame", "New Game", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 0, c);
            c = new OnClick(ButtonClickEvents.LoadGameClick);
            this.InitializeButton(1, "LoadGame", "Load Game", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 80, c);
            c = new OnClick(ButtonClickEvents.HighScoresClick);
            this.InitializeButton(2, "HighScores", "High Scores", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 160, c);
            c = new OnClick(ButtonClickEvents.HelpClick);
            this.InitializeButton(3, "Help", "Help", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 240, c);
            c = new OnClick(ButtonClickEvents.ExitClick);
            this.InitializeButton(4, "Exit", "Exit", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 320, c);
        }
    }
}
