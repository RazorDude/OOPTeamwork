using Data.GridItem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    class Level : Executable
    {
        struct Square
        {
            int imageIndex;
            PictureBox visualData;
            public int ImageIndex
            {
                get { return this.imageIndex; }
                set { this.imageIndex = value; }
            }
            public PictureBox VisualData
            {
                get { return this.visualData; }
                set { this.visualData = value; }
            }
            public Square(int imageIndex, Image image, int x, int y, int row, int column, int squareWidth)
            {
                this.imageIndex = imageIndex;
                LevelGrid.InitializeGridItem(row, column, imageIndex);
                this.visualData = new PictureBox();
                this.visualData.Width = squareWidth;
                this.visualData.Height = squareWidth;
                this.visualData.Image = image;
                this.visualData.SizeMode = PictureBoxSizeMode.StretchImage;
                this.visualData.Anchor = AnchorStyles.Left;
                this.visualData.Location = new System.Drawing.Point(x, y);
            }
            public Square(int imageIndex, Image image, int x, int y, int row, int column, int squareWidth, string charClass)
            {
                this.imageIndex = imageIndex;
                LevelGrid.InitializeGridItem(row, column, imageIndex);
                this.visualData = new PictureBox();
                this.visualData.Width = squareWidth;
                this.visualData.Height = squareWidth;
                this.visualData.Image = image;
                this.visualData.SizeMode = PictureBoxSizeMode.StretchImage;
                this.visualData.Anchor = AnchorStyles.Left;
                this.visualData.Location = new System.Drawing.Point(x, y);
            }
        }
        int squareWidth = 40, levelWidth = 31, levelHeight = 19, frameDimension = 20,
            horizontalFrameImageIndex = (int)Images.HorizontalFrame, verticalFrameImageIndex = (int)Images.VerticalFrame, keysOnMap = 0;

        string playerName, characterName, charaterClass;
        PictureBox topFrame, topFrame2, topFrame3, topFrame4, topFrame5, topFrame6, leftFrame, rightFrame, bottomFrame;
        Label HP, Ammo, Potions, Keys, Score;
        Square[,] levelMap;
        public int LevelWidth
        {
            get { return this.levelWidth; }
        }
        public int LevelHeight
        {
            get { return this.levelHeight; }
        }
        public int KeysOnMap
        {
            get { return this.keysOnMap; }
            set { this.keysOnMap = value; }
        }
        public string PlayerName
        {
            get { return this.playerName; }
        }
        public string CharacterName
        {
            get { return this.characterName; }
        }
        public string CharacterClass
        {
            get { return this.charaterClass; }
        }
        void LoadFrames(ImageList imageList)
        {
            this.topFrame.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.topFrame2.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.topFrame3.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.topFrame4.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.topFrame5.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.topFrame6.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.bottomFrame.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.leftFrame.Image = imageList.Images[this.verticalFrameImageIndex];
            this.rightFrame.Image = imageList.Images[this.verticalFrameImageIndex];
        }
        public Level()
        {
            this.topFrame = new PictureBox();
            this.topFrame.Width = 200;
            this.topFrame.Height = this.frameDimension;
            this.topFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame.Anchor = AnchorStyles.Top;
            this.topFrame.Location = new Point(0, 0);
            this.topFrame.SizeMode = PictureBoxSizeMode.StretchImage;

            this.HP = new Label();
            this.HP.Width = 50;
            this.HP.Height = this.frameDimension;
            this.HP.Text = "100";
            this.HP.TextAlign = ContentAlignment.MiddleCenter;
            this.HP.BackColor = Color.Red;
            this.HP.Anchor = AnchorStyles.Top;
            this.HP.Location = new Point(200, 0);

            this.topFrame2 = new PictureBox();
            this.topFrame2.Width = 50;
            this.topFrame2.Height = this.frameDimension;
            this.topFrame2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame2.Anchor = AnchorStyles.Top;
            this.topFrame2.Location = new Point(250, 0);
            this.topFrame2.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Ammo = new Label();
            this.Ammo.Width = 50;
            this.Ammo.Height = this.frameDimension;
            this.Ammo.TextAlign = ContentAlignment.MiddleCenter;
            this.Ammo.BackColor = Color.DarkGray;
            this.Ammo.Anchor = AnchorStyles.Top;
            this.Ammo.Location = new Point(300, 0);

            this.topFrame3 = new PictureBox();
            this.topFrame3.Width = 50;
            this.topFrame3.Height = this.frameDimension;
            this.topFrame3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame3.Anchor = AnchorStyles.Top;
            this.topFrame3.Location = new Point(350, 0);
            this.topFrame3.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Potions = new Label();
            this.Potions.Width = 50;
            this.Potions.Height = this.frameDimension;
            this.Potions.Text = "0";
            this.Potions.TextAlign = ContentAlignment.MiddleCenter;
            this.Potions.BackColor = Color.Yellow;
            this.Potions.Anchor = AnchorStyles.Top;
            this.Potions.Location = new Point(400, 0);

            this.topFrame4 = new PictureBox();
            this.topFrame4.Width = 50;
            this.topFrame4.Height = this.frameDimension;
            this.topFrame4.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame4.Anchor = AnchorStyles.Top;
            this.topFrame4.Location = new Point(450, 0);
            this.topFrame4.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Keys = new Label();
            this.Keys.Width = 50;
            this.Keys.Height = this.frameDimension;
            this.Keys.Text = "0";
            this.Keys.TextAlign = ContentAlignment.MiddleCenter;
            this.Keys.BackColor = Color.Purple;
            this.Keys.Anchor = AnchorStyles.Top;
            this.Keys.Location = new Point(500, 0);

            this.topFrame5 = new PictureBox();
            this.topFrame5.Width = 50;
            this.topFrame5.Height = this.frameDimension;
            this.topFrame5.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame5.Anchor = AnchorStyles.Top;
            this.topFrame5.Location = new Point(550, 0);
            this.topFrame5.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Score = new Label();
            this.Score.Width = 50;
            this.Score.Height = this.frameDimension;
            this.Score.Text = "0";
            this.Score.TextAlign = ContentAlignment.MiddleCenter;
            this.Score.BackColor = Color.Blue;
            this.Score.Anchor = AnchorStyles.Top;
            this.Score.Location = new Point(600, 0);

            this.topFrame6 = new PictureBox();
            this.topFrame6.Width = Screen.PrimaryScreen.Bounds.Width - 650;
            this.topFrame6.Height = this.frameDimension;
            this.topFrame6.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame6.Anchor = AnchorStyles.Top;
            this.topFrame6.Location = new Point(650, 0);
            this.topFrame6.SizeMode = PictureBoxSizeMode.StretchImage;

            this.leftFrame = new PictureBox();
            this.leftFrame.Width = this.frameDimension;
            this.leftFrame.Height = Screen.PrimaryScreen.Bounds.Height;
            this.leftFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.leftFrame.Anchor = AnchorStyles.Left;
            this.leftFrame.Location = new Point(0, 0);
            this.leftFrame.SizeMode = PictureBoxSizeMode.StretchImage;

            this.bottomFrame = new PictureBox();
            this.bottomFrame.Width = Screen.PrimaryScreen.Bounds.Width;
            this.bottomFrame.Height = this.frameDimension;
            this.bottomFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.bottomFrame.Anchor = AnchorStyles.Bottom;
            this.bottomFrame.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - 500));
            this.bottomFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.bottomFrame.Dock = DockStyle.Bottom;

            this.rightFrame = new PictureBox();
            this.rightFrame.Width = this.frameDimension;
            this.rightFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.rightFrame.Anchor = AnchorStyles.Right;
            this.rightFrame.Dock = DockStyle.Right;
            this.rightFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.levelMap = new Square[this.levelHeight, this.levelWidth];

        }
        public void LoadLevel(string path, ImageList imageList, string charClass)
        {
            this.keysOnMap = 0;
            StreamReader levelData = new StreamReader(path);
            int index, x = -20, y = this.frameDimension;
            for (int i = 0; i < levelHeight; i++)
            {
                x = -20;
                for (int j = 0; j < levelWidth; j++)
                {
                    x += this.squareWidth;
                    index = int.Parse(levelData.ReadLine());
                    if ((index == (int)Images.CharacterLeft) || (index == (int)Images.CharacterRight) || (index == (int)Images.CharacterUp) ||
                        (index == (int)Images.CharacterDown) || (index == (int)Images.Demon))
                    {
                        Window.LoadCharacter(i, j, index);
                    }
                    if (index == (int)Images.Sword)
                    {
                        switch (charClass)
                        {
                            case "Marksman":
                                index = (int)Images.Bow;
                                break;
                            case "Mage":
                                index = (int)Images.Scroll;
                                break;
                        }
                    }
                    else if (index == (int)Images.Potion)
                    {
                        switch (charClass)
                        {
                            case "Knight": index = (int)Images.PotionRed;
                                break;
                            case "Marksman": index = (int)Images.Quiver;
                                break;
                        }
                    }
                    else if (index == (int)Images.Key) this.keysOnMap++;
                    levelMap[i, j] = new Square(index, imageList.Images[index], x, y, i, j, this.squareWidth);
                }
                y += this.squareWidth;
            }
            this.LoadFrames(imageList);
        }
        public void LoadLevel(int[] savedSlot, string[] playerData, ImageList imageList)
        {
            this.keysOnMap = 0;
            int index = 0, x = -20, y = this.frameDimension;
            this.playerName = playerData[0];
            this.characterName = playerData[1];
            this.charaterClass = playerData[2];
            for (int i = 0; i < levelHeight; i++)
            {
                x = -20;
                for (int j = 0; j < levelWidth; j++)
                {
                    x += this.squareWidth;
                    if ((savedSlot[index] == (int)Images.CharacterLeft) || (savedSlot[index] == (int)Images.CharacterRight) ||
                        (savedSlot[index] == (int)Images.CharacterUp) || (savedSlot[index] == (int)Images.CharacterDown) || (savedSlot[index] == (int)Images.Demon))
                    {
                        Window.LoadCharacter(i, j, index);
                    }
                    else if (savedSlot[index] == 8) this.keysOnMap++;
                    levelMap[i, j] = new Square(savedSlot[index], imageList.Images[savedSlot[index]], x, y, i, j, this.squareWidth);
                    index++;
                }
                y += this.squareWidth;
            }
            this.LoadFrames(imageList);
        }
        public int GetSquareImageIndex(int x, int y)
        {
            return this.levelMap[y, x].ImageIndex;
        }
        public void SetSquareImageIndex(int x, int y, int imageIndex, Image image)
        {
            this.levelMap[y, x].ImageIndex = imageIndex;
            this.levelMap[y, x].VisualData.Image = image;
            LevelGrid.SetGridItemValue(y, x, imageIndex);
        }
        public void SetSquareImageIndex(int x, int y, int imageIndex, Image image, bool noCallBack)
        {
            this.levelMap[y, x].ImageIndex = imageIndex;
            this.levelMap[y, x].VisualData.Image = image;
        }
        public Control GetHP()
        {
            return this.HP;
        }
        public Control SetHP(int hp)
        {
            string HP = "";
            int factor = 1, temp = hp;
            if (hp == 0) HP = "0";
            else
            {
                while (hp > 0)
                {
                    factor *= 10;
                    hp /= 10;
                }
                hp = temp;
                factor /= 10;
                while (factor > 0)
                {
                    HP += (char)(hp / factor % 10 + '0');
                    factor /= 10;
                }
            }
            this.HP.Text = HP;
            return this.HP;
        }
        public Control GetAmmo()
        {
            return this.Ammo;
        }
        public Control SetAmmo(int ammo)
        {
            string Ammo = "";
            int factor = 1, temp = ammo;
            if (ammo == 0) Ammo = "0";
            else
            {
                while (ammo > 0)
                {
                    factor *= 10;
                    ammo /= 10;
                }
                ammo = temp;
                factor /= 10;
                while (factor > 0)
                {
                    Ammo += (char)(ammo / factor % 10 + '0');
                    factor /= 10;
                }
            }
            this.Ammo.Text = Ammo;
            return this.Ammo;
        }
        public Control GetPotions()
        {
            return this.Potions;
        }
        public Control SetPotions(int potions)
        {
            string Potions = "";
            int factor = 1, temp = potions;
            if (potions == 0) Potions = "0";
            else
            {
                while (potions > 0)
                {
                    factor *= 10;
                    potions /= 10;
                }
                potions = temp;
                factor /= 10;
                while (factor > 0)
                {
                    Potions += (char)(potions / factor % 10 + '0');
                    factor /= 10;
                }
            }
            this.Potions.Text = Potions;
            return this.Potions;
        }
        public Control Getkeys()
        {
            return this.Keys;
        }
        public Control SetKeys(int keys)
        {
            string Keys = "";
            int factor = 1, temp = keys;
            if (keys == 0) Keys = "0";
            else
            {
                while (keys > 0)
                {
                    factor *= 10;
                    keys /= 10;
                }
                keys = temp;
                factor /= 10;
                while (factor > 0)
                {
                    Keys += (char)(keys / factor % 10 + '0');
                    factor /= 10;
                }
            }
            this.Keys.Text = Keys;
            return this.Keys;
        }
        public Control GetScore()
        {
            return this.Score;
        }
        public Control SetScore(int score)
        {
            string Score = "";
            int factor = 1, temp = score;
            if (score == 0) Score = "0";
            else
            {
                while (score > 0)
                {
                    factor *= 10;
                    score /= 10;
                }
                score = temp;
                factor /= 10;
                while (factor > 0)
                {
                    Score += (char)(score / factor % 10 + '0');
                    factor /= 10;
                }
            }
            this.Score.Text = Score;
            return this.Score;
        }
        public int GetStatusBoxData(string param)
        {
            switch (param)
            {
                case "HP": return int.Parse(this.HP.Text);
                case "Ammo": return int.Parse(this.Ammo.Text);
                case "Keys": return int.Parse(this.Keys.Text);
                case "Score": return int.Parse(this.Score.Text);
            }
            return int.Parse(this.Potions.Text);
        }
        public Control GetVisualData(int x, int y)
        {
            return this.levelMap[y, x].VisualData;
        }
        public override Control[] GetControlData()
        {
            List<Control> visualDataList = new List<Control>();
            Control[] visualData;
            for (int i = 0; i < this.levelHeight; i++)
            {
                for (int j = 0; j < this.levelWidth; j++) visualDataList.Add(levelMap[i, j].VisualData);
            }
            visualDataList.Add(this.topFrame);
            visualDataList.Add(this.HP);
            visualDataList.Add(this.topFrame2);
            visualDataList.Add(this.Ammo);
            visualDataList.Add(this.topFrame3);
            visualDataList.Add(this.Potions);
            visualDataList.Add(this.topFrame4);
            visualDataList.Add(this.Keys);
            visualDataList.Add(this.topFrame5);
            visualDataList.Add(this.Score);
            visualDataList.Add(this.topFrame6);
            visualDataList.Add(this.bottomFrame);
            visualDataList.Add(this.leftFrame);
            visualDataList.Add(this.rightFrame);
            visualData = new Control[visualDataList.Count];
            for (int i = 0; i < visualDataList.Count; i++) visualData[i] = visualDataList[i];
            return visualData;
        }

        public int[,] SimplifeidField()
        {
            int[,] result = new int[this.LevelHeight, this.LevelWidth];

            for (int row = 0; row < this.LevelHeight; row++)
            {
                for (int col = 0; col < this.LevelWidth; col++)
                {
                    var curElem = this.levelMap[row, col];
                    if (curElem.ImageIndex == (int)Images.Empty || curElem.ImageIndex == (int)Images.CharacterLeft || curElem.ImageIndex == (int)Images.CharacterRight ||
                        curElem.ImageIndex == (int)Images.CharacterUp || curElem.ImageIndex == (int)Images.CharacterDown || curElem.ImageIndex == (int)Images.Demon)
                    {
                        result[row, col] = 0; // if it's an empty space
                    }
                    else result[row, col] = 1;
                }
            }
            return result;
        }
    }
}
