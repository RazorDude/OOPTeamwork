using Data;
using Data.Characters.Enemies;
using Data.Characters.Movement;
using Data.Exceptions;
using Data.GridItem;
using Data.Items;
using Data.Items.Potions;
using Data.Player;
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
    delegate void ChangeDelegate(int[] data);

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
        Enemy enemy;
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
            this.player.Character.CharacterClass = param;
            this.player.Character.Equipment.SetWeapon(20, 0);
            this.ExecuteNewGame();
        }
        void ExecuteNewGame()
        {
            this.Clear();
            this.BackColor = Color.Black;
            this.enemy = new Enemy();
            level = new Level();
            level.LoadLevel("Data\\Levels\\level1.dat", this.imageList, this.player.Character.CharacterClass);
            this.level.SetHP(this.player.Character.Health);
            this.currentState = "Ingame";
            this.Controls.AddRange(level.GetControlData());
            switch (this.player.Character.CharacterClass)
            {
                case "Knight": this.UpdateStatusBox("Ammo", this.player.Character.Strength);
                    break;
                case "Marksman": this.UpdateStatusBox("Ammo", this.player.Character.Equipment.Arrows);
                    break;
                case "Mage": this.UpdateStatusBox("Ammo", this.player.Character.Mana);
                    break;
            }
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
        void OnGridItemChange(int row, int column, int imageIndex)
        {
            int[] a = new int[3];
            a[0] = row;
            a[1] = column;
            a[2] = imageIndex;
            if (InvokeRequired)
            {
                ChangeDelegate d = new ChangeDelegate(this.UpdateOnGridItemChange);
                Invoke(d, a);
                return;
            }
            this.UpdateOnGridItemChange(a);
        }
        void UpdateOnGridItemChange(int[] data)
        {
            this.ChangeImage(data[0], data[1], data[2], true);
        }
        void UpdateStatusBox(string param, int value)
        {
            switch (param)
            {
                case "HP": this.Controls.Remove(this.level.GetHP());
                    this.Controls.Add(this.level.SetHP(value));
                    break;
                case "Ammo": this.Controls.Remove(this.level.GetAmmo());
                    this.Controls.Add(this.level.SetAmmo(value));
                    break;
                case "Potions": this.Controls.Remove(this.level.GetPotions());
                    this.Controls.Add(this.level.SetPotions(value));
                    break;
                case "Keys": this.Controls.Remove(this.level.Getkeys());
                    this.Controls.Add(this.level.SetKeys(value));
                    break;
                case "Score": this.Controls.Remove(this.level.GetScore());
                    this.Controls.Add(this.level.SetScore(value));
                    break;
            }
        }
        void UpdateStatusBox(string param, int value, bool flag)
        {
            switch (param)
            {
                case "HP": this.Controls.Remove(this.level.GetHP());
                    this.Controls.Add(this.level.SetHP(this.level.GetStatusBoxData("HP") - value));
                    break;
                case "Ammo": this.Controls.Remove(this.level.GetAmmo());
                    this.Controls.Add(this.level.SetAmmo(value));
                    break;
                case "Potions": this.Controls.Remove(this.level.GetPotions());
                    this.Controls.Add(this.level.SetPotions(value));
                    break;
                case "Keys": this.Controls.Remove(this.level.Getkeys());
                    this.Controls.Add(this.level.SetKeys(value));
                    break;
            }
        }

        private void ChangeImage(int row, int column, int imageIndex)
        {
            this.Controls.Remove(this.level.GetVisualData(column, row));
            this.level.SetSquareImageIndex(column, row, imageIndex, this.imageList.Images[imageIndex]);
            this.Controls.Add(this.level.GetVisualData(column, row));
        }
        private void ChangeImage(int row, int column, int imageIndex, bool noCallback)
        {
            this.Controls.Remove(this.level.GetVisualData(column, row));
            this.level.SetSquareImageIndex(column, row, imageIndex, this.imageList.Images[imageIndex], true);
            this.Controls.Add(this.level.GetVisualData(column, row));
        }

        protected void MoveEnemy()
        {
            int[,] map = this.level.SimplifeidField();
            MazeSolver playGround = new MazeSolver(map);
            this.enemy.FindDirectionAndMove(playGround, this.player.Character);
        }
        void OnEncounter(string param, int direction)
        {
            switch (param)
            {
                case "Demon": this.enemy.TakeDamage(this.player.Character.DealDamage());
                    break;
                case "PotionRed": this.player.Character.Inventory.Potions.StrengthPotions.AddItem(new StrengthPotion(0, 20));
                    this.UpdateStatusBox("Potions", (this.level.GetStatusBoxData("Potions") + 1));
                    break;
                case "Quiver": this.player.Character.Equipment.Arrows += 10;
                    this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") + 10));
                    break;
                case "Potion": this.player.Character.Inventory.Potions.ManaPotions.AddItem(new ManaPotion(0, 20));
                    this.UpdateStatusBox("Potions", (this.level.GetStatusBoxData("Potions") + 1));
                    break;
                case "Key": this.player.Character.Inventory.Items.AddItem(new Key());
                    this.UpdateStatusBox("Keys", (this.level.GetStatusBoxData("Keys") + 1));
                    this.level.KeysOnMap--;
                    break;
                case "Door": if (this.player.Character.Inventory.Items.Items.Count > 0)
                    {
                        this.player.Character.Inventory.Items.RemoveItemByIndex(0);
                        this.UpdateStatusBox("Keys", (this.level.GetStatusBoxData("Keys") - 1));

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
            }
        }

        bool IsIngame()
        {
            return (this.currentState == "Ingame");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((this.level.GetStatusBoxData("Score") % 1000) == 0)
            {
                this.player.Character.Health = 100;
                this.UpdateStatusBox("HP", 100);
            }
            if (this.IsIngame())
            {
                if (!this.enemy.IsDead())
                {
                    try
                    {
                        this.MoveEnemy();
                    }
                    catch (GameEndException)
                    {
                        this.ExecuteMainMenu();
                        return true;
                    }
                }
                else
                {
                    this.UpdateStatusBox("Score", (this.level.GetStatusBoxData("Score") + 100));
                    LevelGrid.SetGridItemValue(this.enemy.Position.Row, this.enemy.Position.Column, (int)Images.Empty);
                }
                switch (keyData)
                {
                    case Keys.Escape: Execute("Pause menu");
                        return true;
                    case Keys.Left:
                        if (this.player.Character.Direction == (int)Direction.Left && Movement.IsMoveAvailable(this.player.Character))
                        {
                            this.UpdateStatusBox("Score", (this.level.GetStatusBoxData("Score") + 5));
                            Movement.Move(this.player.Character);
                        }
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Left);
                        return true;
                    case Keys.Right:
                        if (this.player.Character.Direction == (int)Direction.Right && Movement.IsMoveAvailable(this.player.Character))
                        {
                            this.UpdateStatusBox("Score", (this.level.GetStatusBoxData("Score") + 5));
                            Movement.Move(this.player.Character);
                        }
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Right);
                        return true;
                    case Keys.Up:
                        if (this.player.Character.Direction == (int)Direction.Up && Movement.IsMoveAvailable(this.player.Character))
                        {
                            this.UpdateStatusBox("Score", (this.level.GetStatusBoxData("Score") + 5));
                            Movement.Move(this.player.Character);
                        }
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Up);
                        return true;
                    case Keys.Down:
                        if (this.player.Character.Direction == (int)Direction.Down && Movement.IsMoveAvailable(this.player.Character))
                        {
                            this.UpdateStatusBox("Score", (this.level.GetStatusBoxData("Score") + 5));
                            Movement.Move(this.player.Character);
                        }
                        else
                            Movement.ChangeDirection(this.player.Character, (int)Direction.Down);
                        return true;
                    case Keys.P: switch (this.player.Character.CharacterClass)
                        {
                            case "Knight": if (this.player.Character.Inventory.Potions.StrengthPotions.Items.Count > 0)
                                {
                                    this.player.Character.Strength += 20;
                                    this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") + 20));
                                    this.player.Character.Inventory.Potions.StrengthPotions.Items.RemoveAt(0);
                                    this.UpdateStatusBox("Potions", (this.level.GetStatusBoxData("Potions") - 1));
                                }
                                break;
                            case "Mage": if (this.player.Character.Inventory.Potions.ManaPotions.Items.Count > 0)
                                {
                                    this.player.Character.Mana += 20;
                                    this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") + 20));
                                    this.player.Character.Inventory.Potions.ManaPotions.Items.RemoveAt(0);
                                    this.UpdateStatusBox("Potions", (this.level.GetStatusBoxData("Potions") - 1));
                                }
                                break;
                        }
                        return true;
                    case Keys.Space:
                        if ((this.player.Character.CharacterClass == "Knight") && (this.player.Character.Strength > 0))
                        {
                            switch (this.player.Character.Direction)
                            {
                                case (int)Direction.Left: if (this.player.Character.Position.Column > 0)
                                    {
                                        if (this.level.GetSquareImageIndex((this.player.Character.Position.Column - 1), this.player.Character.Position.Row) == (int)Images.Demon)
                                        {
                                            this.player.Character.Strength -= 20;
                                            this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") - 20));
                                            this.enemy.TakeDamage(this.player.Character.DealDamage());
                                        }
                                    }
                                    break;
                                case (int)Direction.Right: if (this.player.Character.Position.Column < 30)
                                    {
                                        if (this.level.GetSquareImageIndex((this.player.Character.Position.Column + 1), this.player.Character.Position.Row) == (int)Images.Demon)
                                        {
                                            this.player.Character.Strength -= 20;
                                            this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") - 20));
                                            this.enemy.TakeDamage(this.player.Character.DealDamage());
                                        }
                                    }
                                    break;
                                case (int)Direction.Up: if (this.player.Character.Position.Row > 0)
                                    {
                                        if (this.level.GetSquareImageIndex(this.player.Character.Position.Column, (this.player.Character.Position.Row - 1)) == (int)Images.Demon)
                                        {
                                            this.player.Character.Strength -= 20;
                                            this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") - 20));
                                            this.enemy.TakeDamage(this.player.Character.DealDamage());
                                        }
                                    }
                                    break;
                                case (int)Direction.Down: if (this.player.Character.Position.Row < 30)
                                    {
                                        if (this.level.GetSquareImageIndex(this.player.Character.Position.Column, (this.player.Character.Position.Row + 1)) == (int)Images.Demon)
                                        {
                                            this.player.Character.Strength -= 20;
                                            this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") - 20));
                                            this.enemy.TakeDamage(this.player.Character.DealDamage());
                                        }
                                    }
                                    break;
                            }
                        }
                        else if ((this.player.Character.CharacterClass == "Marksman") && (this.player.Character.Equipment.Arrows > 0))
                        {
                            if (Movement.IsMoveAvailable(this.player.Character))
                            {
                                this.player.Character.Equipment.Arrows--;
                                this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") - 1));
                                DoShoot();
                            }
                            Thread ShotThread = new Thread(new ThreadStart(this.Shot.Shoot));
                            ShotThread.Start();
                        }
                        else if ((this.player.Character.CharacterClass == "Mage") && (this.player.Character.Mana > 0))
                        {
                            if (Movement.IsMoveAvailable(this.player.Character))
                            {
                                this.player.Character.Mana -= 20;
                                this.UpdateStatusBox("Ammo", (this.level.GetStatusBoxData("Ammo") - 20));
                                DoShoot();
                            }
                            Thread ShotThread = new Thread(new ThreadStart(this.Shot.Shoot));
                            ShotThread.Start();
                        }
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DoShoot()
        {
            switch (this.player.Character.Direction)
            {
                case (int)Direction.Left: this.Shot = new ShotLogic(this.player.Character.Position.Row, (this.player.Character.Position.Column - 1), this.player.Character.Direction, this.player.Character.CharacterClass);
                    break;
                case (int)Direction.Right: this.Shot = new ShotLogic(this.player.Character.Position.Row, (this.player.Character.Position.Column + 1), this.player.Character.Direction, this.player.Character.CharacterClass);
                    break;
                case (int)Direction.Up: this.Shot = new ShotLogic((this.player.Character.Position.Row - 1), this.player.Character.Position.Column, this.player.Character.Direction, this.player.Character.CharacterClass);
                    break;
                case (int)Direction.Down: this.Shot = new ShotLogic((this.player.Character.Position.Row + 1), this.player.Character.Position.Column, this.player.Character.Direction, this.player.Character.CharacterClass);
                    break;
            }
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
            Enemy.HpLoss += this.UpdateStatusBox;
            this.currentState = "";
            this.LoadImages();
            this.MainMenu = new MainMenuScreen();
            this.PauseMenu = new PauseMenuScreen();
            this.CharacterSelectMenu = new CharacterSelectMenuScreen();
            Execute("Main menu");
        }
    }
}
