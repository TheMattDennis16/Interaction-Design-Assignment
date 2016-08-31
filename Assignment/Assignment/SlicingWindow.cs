using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class SlicingWindow : Form
    {
        private bool hasCutOne = false;
        private bool hasCutTwo = false;

        public SlicingWindow()
        {
            InitializeComponent();
            this.FormClosing += SlicingWindow_FormClosing;
        }

        private void SlicingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Classes.InterfaceObjects.SlicingSubmenuWrapper.hideSubmenu();
        }

        private void checkFinished()
        {
            if(hasCutOne && hasCutTwo)
            {
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                Classes.FormObjects.ObjectSpecific.TaskListBox tasks = frm.formObj["tasks"] as Classes.FormObjects.ObjectSpecific.TaskListBox;
                tasks.markTaskComplete(Properties.Resources.INSTRUCTION_11);
                Classes.FormObjects.ObjectSpecific.Caketin tin = frm.formObj["caketin"] as Classes.FormObjects.ObjectSpecific.Caketin;
                tin.markCut();
                Dispose();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == trackBar2.Maximum)
            {
                hasCutTwo = true;
                checkFinished();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(trackBar1.Value == trackBar1.Maximum)
            {
                hasCutOne = true;
                checkFinished();
            }
        }
    }
}
