using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    class LoadMenuScreen : MenuScreen
    {
        string[][] playerSlots;
        int[][] slots;
        public static LoadMenuEnteredDelegate MenuEntered;
        void ReadSlot(int slot)
        {
            string path = "Data\\Savedata\\Saves\\slot" + (slot + 1) + ".dat";
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
            playerSlots[slot][0] = s.ReadLine();
            playerSlots[slot][1] = s.ReadLine();
            playerSlots[slot][2] = s.ReadLine();
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
            if (file.Count < (31 * 19))
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
            this.playerSlots = new string[3][];
            this.slots = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                this.playerSlots[i] = new string[3];
                this.slots[i] = new int[31 * 19];
            }
        }
        public string[] GetPlayerSlot(int slot)
        {
            return this.playerSlots[slot];
        }
        public int[] GetSlot(int slot)
        {
            return slots[slot];
        }
    }
}
