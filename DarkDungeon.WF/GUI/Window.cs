using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public delegate void OnClick(object sender, EventArgs e);
    public delegate void ExecuteDelegate(string param);
    public delegate void LoadMenuEnteredDelegate();
    public class Window : Form
    {
        bool SaveMenuLoadedFlag, LoadMenuLoadedFlag;
        string currentState;
        ImageList imageList;
        MainMenuScreen MainMenu;
        PauseMenuScreen PauseMenu;
        SaveMenuScreen SaveMenu;
        LoadMenuScreen LoadMenu;
        Level level;
        public static ExecuteDelegate Execute;
        void LoadImages()
        {
            imageList = new ImageList();
            imageList.Images.Add(Image.FromFile("Data\\Image\\MenuBackground.jpg"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\HorizontalFrame.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\VerticalFrame.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Stone.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\StoneWall.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Brick.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\BrickWall.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Door.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Key.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Empty.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Character-Left.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Character-Right.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Character-Up.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Character-Down.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Demon.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Sword.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Bow.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Armor.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Quiver.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Potion.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Fireball.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Arrow-Left.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Arrow-Right.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Arrow-Up.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Arrow-Down.bmp"));
        }
        void Clear()
        {
            this.Controls.Clear();
            this.BackgroundImage = null;
            this.BackColor = DefaultBackColor;
        }
        void ExecuteMainMenu()
        {
            this.Clear();
            this.BackgroundImage = this.imageList.Images[0];
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.currentState = "Main menu";
            this.Controls.AddRange(this.MainMenu.GetControlData());
        }
        void ExecutePauseMenu()
        {
            this.currentState = "Pause menu";
            this.Clear();
            this.BackgroundImage = this.imageList.Images[0];
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.AddRange(this.PauseMenu.GetControlData());
        }
        void ExecuteNewGame()
        {
            this.Clear();
            this.BackColor = Color.Black;
            level = new Level();
            level.LoadLevel("Data\\Levels\\level1.dat", this.imageList);
            this.currentState = "Ingame";
            this.Controls.AddRange(level.GetControlData());
        }
        void ExecuteSaveGameMenu()
        {
            this.Clear();
            this.BackgroundImage = this.imageList.Images[0];
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (!this.SaveMenuLoadedFlag)
            {
                this.SaveMenuLoadedFlag = true;
                this.SaveMenu = new SaveMenuScreen();
            }
            this.currentState = "Save game";
            this.Controls.AddRange(this.SaveMenu.GetControlData());
        }
        void SaveTo(int slot)
        {
            switch (slot)
            {
                case 0: this.SaveMenu.SaveToSlot(1, this.level);
                    break;
                case 1: this.SaveMenu.SaveToSlot(2, this.level);
                    break;
                case 2: this.SaveMenu.SaveToSlot(3, this.level);
                    break;
            }
            this.Clear();
            this.BackColor = Color.Black;
            this.currentState = "Ingame";
            this.Controls.AddRange(level.GetControlData());
        }
        void ExecuteLoadGameMenu()
        {
            this.Clear();
            this.BackgroundImage = this.imageList.Images[0];
            if (!this.LoadMenuLoadedFlag)
            {
                this.LoadMenuLoadedFlag = true;
                this.LoadMenu = new LoadMenuScreen();
                LoadMenuScreen.MenuEntered();
            }
            else LoadMenuScreen.MenuEntered();
            this.currentState = "Load game";
            this.Controls.AddRange(this.LoadMenu.GetControlData());
        }
        void LoadFrom(int slot)
        {
            this.Clear();
            this.BackColor = Color.Black;
            this.currentState = "Ingame";
            this.level.LoadLevel(this.LoadMenu.GetSlot(slot), this.imageList);
            this.Controls.AddRange(this.level.GetControlData());
        }
        void ExecuteResumeGame()
        {
            this.Clear();
            this.BackColor = Color.Black;
            this.currentState = "Ingame";
            this.Controls.AddRange(level.GetControlData());
        }
        void ExecuteHighscoreScreen() { }
        void ExecuteHelpScreen() { }
        void ExecuteItem(string param)
        {
            switch (param)
            {
                case "Main menu": this.ExecuteMainMenu();
                    break;
                case "Pause menu": this.ExecutePauseMenu();
                    break;
                case "New game": this.ExecuteNewGame();
                    break;
                case "Save game": this.ExecuteSaveGameMenu();
                    break;
                case "Save to 1": this.SaveTo(0);
                    break;
                case "Save to 2": this.SaveTo(1);
                    break;
                case "Save to 3": this.SaveTo(2);
                    break;
                case "Load game": this.ExecuteLoadGameMenu();
                    break;
                case "Load from 1": this.LoadFrom(0);
                    break;
                case "Load from 2": this.LoadFrom(1);
                    break;
                case "Load from 3": this.LoadFrom(2);
                    break;
                case "Resume game": this.ExecuteResumeGame();
                    break;
                case "High scores": this.ExecuteHighscoreScreen();
                    break;
                case "Help": this.ExecuteHelpScreen();
                    break;
                case "To desktop": Application.Exit();
                    break;
            }
        }
        bool IsIngame()
        {
            return (this.currentState == "Ingame");
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.IsIngame())
            {
                switch (keyData)
                {
                    case Keys.Escape: Execute("Pause menu");
                        return true;
                    case Keys.Left:
                        return true;
                    case Keys.Right:
                        return true;
                    case Keys.Up:
                        return true;
                    case Keys.Down:
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public Window()
        {
            this.Text = "Dark Dungeon";
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SaveMenuLoadedFlag = false;
            this.LoadMenuLoadedFlag = false;
            Execute += this.ExecuteItem;
            this.currentState = "";
            this.LoadImages();
            this.MainMenu = new MainMenuScreen();
            this.PauseMenu = new PauseMenuScreen();
            Execute("Main menu");
        }
    }
}
