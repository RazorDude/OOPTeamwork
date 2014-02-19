using System;
using System.Windows.Forms;

namespace GUI
{
    class MenuScreen : Executable
    {
        protected Button[] buttons;
        protected void InitializeButton(int index, string name, string text, int width, int height, int startX, int startY, OnClick click)
        {
            try
            {
                buttons[index] = new Button();
                buttons[index].Name = name;
                buttons[index].Text = text;
                buttons[index].Size = new System.Drawing.Size(width, height);
                buttons[index].Location = new System.Drawing.Point(startX, startY);
                buttons[index].Anchor = AnchorStyles.Left;
                buttons[index].Visible = true;
                buttons[index].Click += new EventHandler(click);
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
        }
        public override Control[] GetControlData()
        {
            return this.buttons;
        }
    }
}
