using System.IO;
using System.Windows.Forms;

namespace GUI
{
    class SaveMenuScreen : MenuScreen
    {
        public SaveMenuScreen()
        {
            this.buttons = new Button[5];
            OnClick c = new OnClick(ButtonClickEvents.SaveToSlot1Click);
            this.InitializeButton(0, "Slot1", "Slot 1", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 270, c);
            c = new OnClick(ButtonClickEvents.SaveToSlot2Click);
            this.InitializeButton(1, "Slot2", "Slot 2", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 350, c);
            c = new OnClick(ButtonClickEvents.SaveToSlot3Click);
            this.InitializeButton(2, "Slot3", "Slot 3", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 430, c);
            c = new OnClick(ButtonClickEvents.SaveMenuBackClick);
            this.InitializeButton(3, "Back", "Back", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 510, c);
            c = new OnClick(ButtonClickEvents.ToMainMenuClick);
            this.InitializeButton(4, "ExitToMainMenu", "Exit to Main Menu", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 590, c);
        }
        public void SaveToSlot(int slot, Level level)
        {
            string path = "Data\\Savedata\\Saves\\slot" + slot + ".dat";
            StreamWriter toSave = new StreamWriter(path);
            for (int i = 0; i < level.LevelHeight; i++)
            {
                for (int j = 0; j < level.LevelWidth; j++)
                {
                    toSave.WriteLine(level.GetSquareImageIndex(j, i));
                }
            }
            //Save entity data
            toSave.Close();
        }
    }
}
