using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class TaskListBox
    {
        public ListBox frmObj;
        public Dictionary<string, int[]> sizes;
        public Dictionary<string, bool> isComplete;

        private System.Drawing.Font normal = new System.Drawing.Font(
                    FontFamily.GenericSansSerif,
                    10);
        private System.Drawing.Font strikethrough = new System.Drawing.Font(
                    FontFamily.GenericSansSerif,
                    9,
                    FontStyle.Strikeout);

        public TaskListBox()
        {
            sizes = new Dictionary<string, int[]>();
            isComplete = new Dictionary<string, bool>();
            frmObj = new ListBox();
            frmObj.DrawMode = DrawMode.OwnerDrawVariable;
            frmObj.Enabled = true;
            frmObj.DrawItem += FrmObj_DrawItem;
            frmObj.MeasureItem += FrmObj_MeasureItem;
            frmObj.MouseMove += FrmObj_MouseMove;
            PopulateBox();

            sizes.Add("1280x720", new int[] { 200, 270 });
            sizes.Add("800x600", new int[] { 180, 230 });
        }

        private void FrmObj_MouseMove(object sender, MouseEventArgs e)
        {
            if (InterfaceObjects.ItemBinding.hasBoundItem())
            {
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                InterfaceObjects.ItemBinding.getBoundItem().Location = frm.PointToClient(new System.Drawing.Point((Cursor.Position.X + 10), (Cursor.Position.Y + 10)));
            }
        }

        private void FrmObj_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            string text = frmObj.Items[e.Index].ToString();
            if (isComplete[text])
            {
                e.ItemHeight = (int)e.Graphics.MeasureString(text, normal, frmObj.Width-20).Height + 10;
            }
            else
            {
                e.ItemHeight = (int)e.Graphics.MeasureString(text, strikethrough, frmObj.Width-20).Height + 10;
            }
        }

        public void setPosition(int x, int y)
        {
            frmObj.Left = x;
            frmObj.Top = y;
        }

        public int[] getNewSizeFromResolution(string resolution)
        {
            return sizes[resolution];
        }

        public int[] getSize()
        {
            return new int[] { frmObj.Width, frmObj.Height };
        }

        public void setSize(string resolution)
        {
            int[] sizes = getNewSizeFromResolution(resolution);
            frmObj.Width = sizes[0];
            frmObj.Height = sizes[1];
        }


        private void FrmObj_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            string text = frmObj.Items[e.Index].ToString();
            if (isComplete[text])
            {
                e.Graphics.DrawString(text, new System.Drawing.Font(
                    FontFamily.GenericSansSerif,
                    9,
                    FontStyle.Strikeout), myBrush, e.Bounds, StringFormat.GenericDefault);
            }
            else
            {
                e.Graphics.DrawString(text, new System.Drawing.Font(
                    FontFamily.GenericSansSerif,
                    9), myBrush, e.Bounds);
            }
        }

        public void markTaskComplete(string task)
        {
            //Mark as complete, push to back. Redraw box.
            isComplete[task] = true;
            frmObj.Items.Remove(task);
            frmObj.Items.Add(task);
        }

        private void PopulateBox()
        {
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_1);
            isComplete.Add(Properties.Resources.INSTRUCTION_1, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_2);
            isComplete.Add(Properties.Resources.INSTRUCTION_2, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_3);
            isComplete.Add(Properties.Resources.INSTRUCTION_3, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_4);
            isComplete.Add(Properties.Resources.INSTRUCTION_4, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_5);
            isComplete.Add(Properties.Resources.INSTRUCTION_5, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_6);
            isComplete.Add(Properties.Resources.INSTRUCTION_6, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_7);
            isComplete.Add(Properties.Resources.INSTRUCTION_7, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_8);
            isComplete.Add(Properties.Resources.INSTRUCTION_8, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_10);
            isComplete.Add(Properties.Resources.INSTRUCTION_10, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_11);
            isComplete.Add(Properties.Resources.INSTRUCTION_11, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_12);
            isComplete.Add(Properties.Resources.INSTRUCTION_12, false);
            frmObj.Items.Add(Properties.Resources.INSTRUCTION_13);
            isComplete.Add(Properties.Resources.INSTRUCTION_13, false);
        }
    }
}
