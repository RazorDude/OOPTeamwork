using System;
using Data.GridItem;
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
        struct HealthBar
        {
            int statusWidth, backgroundHeight, backgroundWidth, startX, startY;
            AnchorStyles anchor;
            PictureBox status, background;
            public PictureBox Status
            {
                get { return this.Status; }
            }
            public PictureBox Background
            {
                get { return this.background; }
            }
            public HealthBar(int backgroundHeight, int backgroundWidth, AnchorStyles anchor, int startX, int startY)
            {
                this.statusWidth = backgroundWidth;
                this.backgroundHeight = backgroundHeight;
                this.backgroundWidth = backgroundWidth;
                this.anchor = anchor;
                this.startX = startX;
                this.startY = startY;
                this.status = new PictureBox();
                this.status.BackColor = Color.Red;
                this.status.Height = this.backgroundHeight - 3;
                this.status.Width = this.statusWidth;
                this.status.Anchor = this.anchor;
                this.status.Location = new System.Drawing.Point(this.startX, this.startY);
                this.background = new PictureBox();
                this.background.BackColor = Color.Black;
                this.background.Height = this.backgroundHeight;
                this.background.Width = this.backgroundWidth;
                this.background.Anchor = this.anchor;
                this.background.Location = new System.Drawing.Point(this.startX, this.startY);
            }
            public void SetStatusWidth(int statusWidth)
            {
                this.statusWidth = statusWidth;
                this.status.Width = this.statusWidth;
            }
        }

        int squareWidth = 40, levelWidth = 31, levelHeight = 19, frameDimension = 20,
            horizontalFrameImageIndex = 1, verticalFrameImageIndex = 2, keysOnMap = 0;
        string playerName, characterName, charaterClass;
        PictureBox topFrame, leftFrame, rightFrame, bottomFrame;
        HealthBar healthBar;
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
            this.bottomFrame.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.leftFrame.Image = imageList.Images[this.verticalFrameImageIndex];
            this.rightFrame.Image = imageList.Images[this.verticalFrameImageIndex];
        }
        public Level()
        {
            this.topFrame = new PictureBox();
            this.topFrame.Height = this.frameDimension;
            this.topFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame.Anchor = AnchorStyles.Top;
            this.topFrame.Dock = DockStyle.Top;
            this.topFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.leftFrame = new PictureBox();
            this.leftFrame.Width = this.frameDimension;
            this.leftFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.leftFrame.Anchor = AnchorStyles.Left;
            this.leftFrame.Dock = DockStyle.Left;
            this.leftFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.bottomFrame = new PictureBox();
            this.bottomFrame.Height = this.frameDimension;
            this.bottomFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.bottomFrame.Anchor = AnchorStyles.Bottom;
            this.bottomFrame.Dock = DockStyle.Bottom;
            this.bottomFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.rightFrame = new PictureBox();
            this.rightFrame.Width = this.frameDimension;
            this.rightFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.rightFrame.Anchor = AnchorStyles.Right;
            this.rightFrame.Dock = DockStyle.Right;
            this.rightFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.levelMap = new Square[this.levelHeight, this.levelWidth];
            this.healthBar = new HealthBar(this.frameDimension, 200, AnchorStyles.Bottom, 0, 0);
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
                    if ((index == 10) || (index == 11) || (index == 12) || (index == 13) || (index == 14))
                    {
                        Window.LoadCharacter(i, j, index);
                    }
                    if (index == 15)
                    {
                        switch (charClass)
                        {
                            case "Marksman":
                                index = 16;
                                break;
                            case "Mage":
                                index = 27;
                                break;
                        }
                    }
                    else if (index == 19)
                    {
                        switch (charClass)
                        {
                            case "Knight": index = 26;
                                break;
                            case "Marksman": index = 18;
                                break;
                        }
                    }
                    else if (index == 8) this.keysOnMap++;
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
                    if ((savedSlot[index] == 10) || (savedSlot[index] == 11) || (savedSlot[index] == 12) || (savedSlot[index] == 13) || (savedSlot[index] == 14))
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
            visualDataList.Add(this.bottomFrame);
            visualDataList.Add(this.leftFrame);
            visualDataList.Add(this.rightFrame);
            //visualDataList.Add(this.healthBar.Background);
            //visualDataList.Add(this.healthBar.Status);
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
                    if (curElem.ImageIndex == 3 && curElem.ImageIndex == 4 && curElem.ImageIndex == 5 && curElem.ImageIndex == 6)
                    {
                        result[row, col] = 1;
                    }
                    else result[row, col] = 0; // if it's an empty space
                }
            }
            return result;
        }
    }
}
