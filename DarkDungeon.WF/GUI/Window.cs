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
    public delegate int GetLevelDimensionsDelegate(string param);
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
        public static GetLevelDimensionsDelegate LevelDimensions;
        void LoadImages()
        {
            imageList = new ImageList();
            imageList.Images.Add(Image.FromFile("Data\\Image\\MainMenuBackground.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\HorizontalFrame.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\VerticalFrame.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Stone.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Brick.bmp"));
        }
        void Clear()
        {
            this.Controls.Clear();
            this.BackgroundImage = null;
            this.BackColor = DefaultBackColor;
        }
        void ExecuteItem(string param)
        {
            if (param == "Main menu")
            {
                this.Clear();
                this.BackgroundImage = this.imageList.Images[0];
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.currentState = "Main menu";
                this.Controls.AddRange(this.MainMenu.GetControlData());
            }
            else if (param == "Pause menu")
            {
                this.currentState = "Pause menu";
                this.Clear();
                this.BackgroundImage = this.imageList.Images[0];
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.AddRange(this.PauseMenu.GetControlData());
            }
            else if (param == "New game")
            {
                this.Clear();
                this.BackColor = Color.Black;
                level = new Level();
                level.LoadLevel("Data\\Levels\\level1.dat", this.imageList);
                this.currentState = "Ingame";
                this.Controls.AddRange(level.GetControlData());
            }
            else if (param == "Save game")
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
            else if (param == "Save to 1")
            {
                this.SaveMenu.SaveToSlot(1, this.level);
                this.Clear();
                this.BackColor = Color.Black;
                this.currentState = "Ingame";
                this.Controls.AddRange(level.GetControlData());
            }
            else if (param == "Save to 2")
            {
                this.SaveMenu.SaveToSlot(2, this.level);
                this.Clear();
                this.BackColor = Color.Black;
                this.currentState = "Ingame";
                this.Controls.AddRange(level.GetControlData());
            }
            else if (param == "Save to 3")
            {
                this.SaveMenu.SaveToSlot(3, this.level);
                this.Clear();
                this.BackColor = Color.Black;
                this.currentState = "Ingame";
                this.Controls.AddRange(level.GetControlData());
            }
            else if (param == "Load game")
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
            else if (param == "Load from 1")
            {
                this.Clear();
                this.BackColor = Color.Black;
                this.currentState = "Ingame";
                this.level.LoadLevel(this.LoadMenu.GetSlot(0), this.imageList);
                this.Controls.AddRange(this.level.GetControlData());
            }
            else if (param == "Load from 2")
            {
                this.Clear();
                this.BackColor = Color.Black;
                this.currentState = "Ingame";
                this.level.LoadLevel(this.LoadMenu.GetSlot(1), this.imageList);
                this.Controls.AddRange(this.level.GetControlData());
            }
            else if (param == "Load from 3")
            {
                this.Clear();
                this.BackColor = Color.Black;
                this.currentState = "Ingame";
                this.level.LoadLevel(this.LoadMenu.GetSlot(2), this.imageList);
                this.Controls.AddRange(this.level.GetControlData());
            }
            else if (param == "Resume game")
            {
                this.Clear();
                this.BackColor = Color.Black;
                this.currentState = "Ingame";
                this.Controls.AddRange(level.GetControlData());
            }
            else if (param == "High scores") { }
            else if (param == "Help") { }
            else if (param == "To desktop")
            {
                Application.Exit();
            }
        }
        bool IsIngame()
        {
            return (this.currentState == "Ingame");
        }
        int GetLevelDimensions(string param)
        {
            if (param == "width") return this.level.LevelWidth;
            return this.level.LevelHeight;
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
            LevelDimensions += this.GetLevelDimensions;
            this.currentState = "";
            this.LoadImages();
            this.MainMenu = new MainMenuScreen();
            this.PauseMenu = new PauseMenuScreen();
            Execute("Main menu");
        }
    }
}
