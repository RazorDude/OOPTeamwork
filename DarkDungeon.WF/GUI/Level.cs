﻿using System;
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
            string value;
            PictureBox visualData;
            public int ImageIndex
            {
                get { return this.imageIndex; }
                set { this.imageIndex = value; }
            }
            public string Value
            {
                get { return this.value; }
                set { this.value = value; }
            }
            public PictureBox VisualData
            {
                get { return this.visualData; }
                set { this.visualData = value; }
            }
            public Square(int imageIndex, Image image, int x, int y, int squareWidth)
            {
                this.imageIndex = imageIndex;
                this.value = "";
                switch (this.imageIndex)
                {
                    case 3: this.value = "Stone";
                        break;
                    case 4: this.value = "Brick";
                        break;
                }
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
            horizontalFrameImageIndex = 1, verticalFrameImageIndex = 2;
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
        public Level()
        {
            this.topFrame = new PictureBox();
            this.topFrame.Height = this.frameDimension;
            this.topFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.topFrame.Anchor = AnchorStyles.Top;
            this.topFrame.Dock = DockStyle.Top;
            this.leftFrame = new PictureBox();
            this.leftFrame.Width = this.frameDimension;
            this.leftFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.leftFrame.Anchor = AnchorStyles.Left;
            this.leftFrame.Dock = DockStyle.Left;
            this.bottomFrame = new PictureBox();
            this.bottomFrame.Height = this.frameDimension;
            this.bottomFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.bottomFrame.Anchor = AnchorStyles.Bottom;
            this.bottomFrame.Dock = DockStyle.Bottom;
            this.rightFrame = new PictureBox();
            this.rightFrame.Width = this.frameDimension;
            this.rightFrame.SizeMode = PictureBoxSizeMode.StretchImage;
            this.rightFrame.Anchor = AnchorStyles.Right;
            this.rightFrame.Dock = DockStyle.Right;
            this.levelMap = new Square[this.levelHeight, this.levelWidth];
            this.healthBar = new HealthBar(this.frameDimension, 200, AnchorStyles.Bottom, 0, 0);
        }
        public void LoadLevel(string path, ImageList imageList)
        {
            StreamReader levelData = new StreamReader(path);
            int index, x = -20, y = this.frameDimension;
            for (int i = 0; i < levelHeight; i++)
            {
                x = -20;
                for (int j = 0; j < levelWidth; j++)
                {
                    x += this.squareWidth;
                    index = int.Parse(levelData.ReadLine());
                    levelMap[i, j] = new Square(index, imageList.Images[index], x, y, this.squareWidth);
                }
                y += this.squareWidth;
            }
            this.topFrame.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.bottomFrame.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.leftFrame.Image = imageList.Images[this.verticalFrameImageIndex];
            this.rightFrame.Image = imageList.Images[this.verticalFrameImageIndex];
        }
        public void LoadLevel(int[] savedSlot, ImageList imageList)
        {
            int index = 0, x = -20, y = this.frameDimension;
            for (int i = 0; i < levelHeight; i++)
            {
                x = -20;
                for (int j = 0; j < levelWidth; j++)
                {
                    x += this.squareWidth;
                    levelMap[i, j] = new Square(savedSlot[index], imageList.Images[savedSlot[index]], x, y, this.squareWidth);
                    index++;
                }
                y += this.squareWidth;
            }
            this.topFrame.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.bottomFrame.Image = imageList.Images[this.horizontalFrameImageIndex];
            this.leftFrame.Image = imageList.Images[this.verticalFrameImageIndex];
            this.rightFrame.Image = imageList.Images[this.verticalFrameImageIndex];
        }
        public int GetSquareImageIndex(int x, int y)
        {
            return this.levelMap[y, x].ImageIndex;
        }
        public string GetSquareValue(int x, int y)
        {
            return this.levelMap[y, x].Value;
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
    }
}
