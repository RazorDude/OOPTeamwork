<<<<<<< HEAD
﻿using Data;
using Data.Player;
using Data.GridItem;
using Data.Characters.Movement;
using Data.Items;
using Data.Items.Potions;
=======
﻿using Data.Characters.Enemies;
using Data.Characters.Movement;
using Data.Items;
using Data.Items.Potions;
using Data.GridItem;
using Data.Player;
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public delegate void OnClick(object sender, EventArgs e);
    public delegate void ExecuteDelegate(string param);
    public delegate void LoadMenuEnteredDelegate();
    public delegate void LoadCharacterDelegate(int row, int column, int imageIndex);
    delegate void ChangeDelegate (int[] data);

    public class Window : Form
    {
        public static ExecuteDelegate Execute;
        public static LoadCharacterDelegate LoadCharacter;
        bool SaveMenuLoadedFlag, LoadMenuLoadedFlag;
        string currentState;
        ImageList imageList;
        MainMenuScreen MainMenu;
        PauseMenuScreen PauseMenu;
        SaveMenuScreen SaveMenu;
        LoadMenuScreen LoadMenu;
        CharacterSelectMenuScreen CharacterSelectMenu;
        Player player;
        Level level;
        ShotLogic Shot;
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
            imageList.Images.Add(Image.FromFile("Data\\Image\\ExitDoor.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\PotionRed.bmp"));
            imageList.Images.Add(Image.FromFile("Data\\Image\\Scroll.bmp"));
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
        void ExecuteCharacterSelectMenu()
        {
            this.currentState = "Character select";
            this.Clear();
            this.BackgroundImage = this.imageList.Images[0];
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.AddRange(this.CharacterSelectMenu.GetControlData());
        }
        void ExecuteCharacter(string param)
        {
            this.player = new Player(this.CharacterSelectMenu.PlayerName);
            this.player.CreateCharacter(this.CharacterSelectMenu.CharacterName, param);
            this.ExecuteNewGame();
        }
        void ExecuteNewGame()
        {
            this.Clear();
            this.BackColor = Color.Black;
            level = new Level();
            level.LoadLevel("Data\\Levels\\level1.dat", this.imageList, this.player.Character.CharacterClass);
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
                case 0: this.SaveMenu.SaveToSlot(1, this.level, this.player);
                    break;
                case 1: this.SaveMenu.SaveToSlot(2, this.level, this.player);
                    break;
                case 2: this.SaveMenu.SaveToSlot(3, this.level, this.player);
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
            this.level = new Level();
            this.player = new Player("");
            this.player.CreateCharacter("", "");
            this.level.LoadLevel(this.LoadMenu.GetSlot(slot), this.LoadMenu.GetPlayerSlot(slot), this.imageList);
            this.player.PlayerName = this.level.PlayerName;
            this.player.Character.CharacterName = this.level.CharacterName;
            this.player.Character.CharacterClass = this.level.CharacterClass;
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
                case "Character select": this.ExecuteCharacterSelectMenu();
                    break;
                case "Knight": this.ExecuteCharacter("Knight");
                    break;
                case "Marksman": this.ExecuteCharacter("Marksman");
                    break;
                case "Mage": this.ExecuteCharacter("Mage");
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
        void OnPlayerDirectionChange(int direction)
        {
            int row = this.player.Character.Position.Row;
            int column = this.player.Character.Position.Column;

            if (direction == (int)Direction.Left)
            {
                ChangeImage(row, column, 10);
            }
            else if (direction == (int)Direction.Right)
            {
                ChangeImage(row, column, 11);
            }
            else if (direction == (int)Direction.Up)
            {
                ChangeImage(row, column, 12);
            }
            else if (direction == (int)Direction.Down)
            {
                ChangeImage(row, column, 13);
            }
        }
<<<<<<< HEAD
        void OnGridItemChange(int row, int column, int imageIndex)
        {
            int[] a = new int[3];
            a[0] = row;
            a[1] = column;
            a[2] = imageIndex;
            if (InvokeRequired)
            {
                ChangeDelegate d = new ChangeDelegate(this.UpdateOnGridItemChange);
                Invoke(d,a);
                return;
            }
            this.UpdateOnGridItemChange(a);
=======

        private void ChangeImage(int row, int column, int imageIndex)
        {
            this.Controls.Remove(this.level.GetVisualData(column, row));
            this.level.SetSquareImageIndex(column, row, imageIndex, this.imageList.Images[imageIndex]);
            this.Controls.Add(this.level.GetVisualData(column, row));
        }

        protected void MoveEnemy()
        {
            int[,] map = this.level.SimplifeidField();
            MazeSolver playGround = new MazeSolver(map);
            this.enemy.FindDirectionAndMove(playGround, this.player.Character);
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
        }
        void UpdateOnGridItemChange(int[] data)
        {
<<<<<<< HEAD
            this.Controls.Remove(this.level.GetVisualData(data[1], data[0]));
            this.level.SetSquareImageIndex(data[1], data[0], data[2], this.imageList.Images[data[2]], true);
            this.Controls.Add(this.level.GetVisualData(data[1], data[0]));
=======
            this.Controls.Remove(this.level.GetVisualData(column, row));
            this.level.SetSquareImageIndex(column, row, imageIndex, this.imageList.Images[imageIndex], true);
            this.Controls.Add(this.level.GetVisualData(column, row));
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
        }
        void OnEncounter(string param, int direction)
        {
            switch (param)
            {
                case "PotionRed": this.player.Character.Inventory.Potions.StrengthPotions.AddItem(new StrengthPotion(0, 20));
                    break;
                case "Quiver": this.player.Character.Equipment.Arrows += 10;
                    break;
                case "Potion": this.player.Character.Inventory.Potions.ManaPotions.AddItem(new ManaPotion(0, 20));
                    break;
                case "Key": this.player.Character.Inventory.Items.AddItem(new Key());
                    this.level.KeysOnMap--;
                    break;
                case "Door": if (this.player.Character.Inventory.Items.Items.Count > 0)
                    {
                        this.player.Character.Inventory.Items.RemoveItemByIndex(0);

                        SwitchDirection(direction);
                    }
                    break;
                case "ExitDoor": if (this.level.KeysOnMap == 0)
                    {
                        SwitchDirection(direction);
                       
                        this.Clear();
                        this.BackColor = Color.Black;
                        level = new Level();
                        this.level.LoadLevel("Data\\Levels\\level2.dat", this.imageList, this.player.Character.CharacterClass);
                        this.currentState = "Ingame";
                        this.Controls.AddRange(level.GetControlData());
                    }
                    break;
            }
        }

        private void SwitchDirection(int direction)
        {
            switch (direction)
            {
                case (int)Direction.Left:
                    this.level.SetSquareImageIndex((this.player.Character.Position.Column - 1), this.player.Character.Position.Row, (int)Images.Empty, this.imageList.Images[(int)Images.Empty]);
                    break;
                case (int)Direction.Right:
                    this.level.SetSquareImageIndex((this.player.Character.Position.Column + 1), this.player.Character.Position.Row, (int)Images.Empty, this.imageList.Images[(int)Images.Empty]);
                    break;
                case (int)Direction.Up:
                    this.level.SetSquareImageIndex(this.player.Character.Position.Column, (this.player.Character.Position.Row - 1), (int)Images.Empty, this.imageList.Images[(int)Images.Empty]);
                    break;
                case (int)Direction.Down:
                    this.level.SetSquareImageIndex(this.player.Character.Position.Column, (this.player.Character.Position.Row + 1), (int)Images.Empty, this.imageList.Images[(int)Images.Empty]);
                    break;
            }
        }

        void CharacterLoad(int row, int column, int imageIndex)
        {
<<<<<<< HEAD
            this.player.Character.Position.Row = row;
            this.player.Character.Position.Column = column;
            switch (imageIndex)
            {
                case 10: this.player.Character.Direction = 1;
                    break;
                case 11: this.player.Character.Direction = 2;
                    break;
                case 12: this.player.Character.Direction = 3;
                    break;
                case 13: this.player.Character.Direction = 4;
                    break;
=======
            if (imageIndex == (int)Images.Demon)
            {
                this.enemy.Position.Row = row;
                this.enemy.Position.Column = column;
                this.enemy.Direction = (int)Direction.Left;
            }
            else
            {
                this.player.Character.Position.Row = row;
                this.player.Character.Position.Column = column;
                switch (imageIndex)
                {
                    case (int)Images.CharacterLeft: this.player.Character.Direction = (int)Direction.Left;
                        break;
                    case (int)Images.CharacterRight: this.player.Character.Direction = (int)Direction.Right;
                        break;
                    case (int)Images.CharacterUp: this.player.Character.Direction = (int)Direction.Up;
                        break;
                    case (int)Images.CharacterDown: this.player.Character.Direction = (int)Direction.Down;
                        break;
                }
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
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
                        if (this.player.Character.Direction == (int)Direction.Left && Movement.IsMoveAvailable(this.player.Character))
                            Movement.Move(this.player.Character);
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Left);
                        return true;
                    case Keys.Right:
                        if (this.player.Character.Direction == (int)Direction.Right && Movement.IsMoveAvailable(this.player.Character))
                            Movement.Move(this.player.Character);
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Right);
                        return true;
                    case Keys.Up:
                        if (this.player.Character.Direction == (int)Direction.Up && Movement.IsMoveAvailable(this.player.Character))
                            Movement.Move(this.player.Character);
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Up);
                        return true;
<<<<<<< HEAD
                    case Keys.Down: if (this.player.Character.Direction == 4) Movement.Move(this.player.Character);
                        else Movement.ChangeDirection(this.player.Character, 4);
                        return true;
                    case Keys.P:
                        return true;
                    case Keys.Space: 
                        if (this.player.Character.CharacterClass == "Knight") { }
                        else if ((this.player.Character.CharacterClass == "Marksman") && (this.player.Character.Equipment.Arrows > 0))
                        {
                            if (Movement.IsMoveAvailable(this.player.Character))
                            {
                                if (this.player.Character.CharacterClass == "Marksman") this.player.Character.Equipment.Arrows--;
                                switch (this.player.Character.Direction)
                                {
                                    case 1: this.Shot = new ShotLogic(this.player.Character.Position.Row, (this.player.Character.Position.Column - 1), this.player.Character.Direction, this.player.Character.CharacterClass);
                                        break;
                                    case 2: this.Shot = new ShotLogic(this.player.Character.Position.Row, (this.player.Character.Position.Column + 1), this.player.Character.Direction, this.player.Character.CharacterClass);
                                        break;
                                    case 3: this.Shot = new ShotLogic((this.player.Character.Position.Row - 1), this.player.Character.Position.Column, this.player.Character.Direction, this.player.Character.CharacterClass);
                                        break;
                                    case 4: this.Shot = new ShotLogic((this.player.Character.Position.Row + 1), this.player.Character.Position.Column, this.player.Character.Direction, this.player.Character.CharacterClass);
                                        break;
                                }
                            }
                            Thread ShotThread = new Thread(new ThreadStart(this.Shot.Shoot));
                            ShotThread.Start();
                        }
                        else if (this.player.Character.CharacterClass == "Mage") { }
=======
                    case Keys.Down:
                        if (this.player.Character.Direction == (int)Direction.Down && Movement.IsMoveAvailable(this.player.Character))
                            Movement.Move(this.player.Character);
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Down);
>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
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
            LoadCharacter += this.CharacterLoad;
            LevelGrid.PlayerDirectionChanged += this.OnPlayerDirectionChange;
            LevelGrid.OnGridItemChanged += this.OnGridItemChange;
            Movement.Encounter += this.OnEncounter;
            this.currentState = "";
            this.LoadImages();
            this.MainMenu = new MainMenuScreen();
            this.PauseMenu = new PauseMenuScreen();
            this.CharacterSelectMenu = new CharacterSelectMenuScreen();
<<<<<<< HEAD
=======

>>>>>>> 6b583b1c258696e11e40eb4d464f95c58c5919f1
            Execute("Main menu");
        }
    }
}
