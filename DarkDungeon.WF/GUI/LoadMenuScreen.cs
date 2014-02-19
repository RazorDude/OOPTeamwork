using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    class LoadMenuScreen : MenuScreen
    {
        int[][] slots;
        public static LoadMenuEnteredDelegate MenuEntered;
        void ReadSlot(int slot)
        {
            string path = "Data\\Savedata\\Saves\\slot" + slot + ".dat";
            List<int> file = new List<int>();
            int line;
            StreamReader s;
            try
            {
                s = new StreamReader(path);
            }
            catch (FileNotFoundException)
            {
                this.MarkSlotButtonEmpty(slot, "Empty");
                return;
            }
            s = new StreamReader(path);
            while (!s.EndOfStream)
            {
                try
                {
                    line = int.Parse(s.ReadLine());
                    file.Add(line);
                }
                catch (InvalidDataException)
                {
                    this.MarkSlotButtonEmpty(slot, "Corrupt data");
                    return;
                }
            }
            if (file.Count != (Window.LevelDimensions("width") * Window.LevelDimensions("height")))
            {
                this.MarkSlotButtonEmpty(slot, "Corrupt data");
                return;
            }
            this.UnmarkSlotButton(slot);
            for (int i = 0; i < file.Count; i++) this.slots[slot][i] = file[i];
        }
        void OnMenuEntered()
        {
            this.ReadSlot(0);
            this.ReadSlot(1);
            this.ReadSlot(2);
        }
        void MarkSlotButtonEmpty(int index, string param)
        {
            this.buttons[index].Text = "Slot " + (index + 1) + "\nEmpty";
            this.buttons[index].Enabled = false;
        }
        void UnmarkSlotButton(int index)
        {
            if (this.buttons[index].Enabled == false)
            {
                this.buttons[index].Text = "Slot " + (index + 1);
                this.buttons[index].Enabled = true;
            }
        }
        public LoadMenuScreen()
        {
            this.buttons = new Button[5];
            OnClick c = new OnClick(ButtonClickEvents.LoadSlot1Click);
            this.InitializeButton(0, "Slot1", "Slot 1", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 270, c);
            c = new OnClick(ButtonClickEvents.LoadSlot2Click);
            this.InitializeButton(1, "Slot2", "Slot 2", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 350, c);
            c = new OnClick(ButtonClickEvents.LoadSlot3Click);
            this.InitializeButton(2, "Slot3", "Slot 3", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 430, c);
            c = new OnClick(ButtonClickEvents.LoadMenuBackClick);
            this.InitializeButton(3, "Back", "Back", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 510, c);
            c = new OnClick(ButtonClickEvents.ToMainMenuClick);
            this.InitializeButton(4, "ExitToMainMenu", "Exit to Main Menu", 130, 53,
                (Screen.PrimaryScreen.Bounds.Width / 2 - 65), 590, c);
            MenuEntered += this.OnMenuEntered;
            this.slots = new int[3][];
            int dimension = Window.LevelDimensions("width") * Window.LevelDimensions("height");
            for (int i = 0; i < 3; i++) slots[i] = new int[(Window.LevelDimensions("width") * Window.LevelDimensions("height"))];
            slots[0] = new int[(Window.LevelDimensions("width") * Window.LevelDimensions("height"))];
        }
        public int[] GetSlot(int slot)
        {
            return slots[slot];
        }
    }
}
