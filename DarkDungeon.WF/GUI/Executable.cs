using System;
using System.Windows.Forms;

namespace GUI
{
    abstract class Executable : Form
    {
        public abstract Control[] GetControlData();
    }
}
