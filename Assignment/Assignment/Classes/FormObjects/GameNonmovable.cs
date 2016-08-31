using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Assignment.Classes.FormObjects
{
    class GameNonmovable : Interaction
    {
        public PictureBox frmObj;
        public Dictionary<string, int[]> sizes;

        public GameNonmovable()
        {
            sizes = new Dictionary<string, int[]>();
            frmObj = new PictureBox();
            frmObj.MouseEnter += FrmObj_MouseEnter;
            frmObj.BackColor = Color.Transparent;
            frmObj.SizeMode = PictureBoxSizeMode.Zoom;
            frmObj.Cursor = Cursors.Arrow;
            frmObj.MouseMove += FrmObj_MouseMove;
        }

        private void FrmObj_MouseMove(object sender, MouseEventArgs e)
        {
            if (InterfaceObjects.ItemBinding.hasBoundItem())
            {
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                InterfaceObjects.ItemBinding.getBoundItem().Location = frm.PointToClient(new System.Drawing.Point((Cursor.Position.X + 10), (Cursor.Position.Y + 10)));
            }
        }

        private void FrmObj_MouseEnter(object sender, EventArgs e)
        {
            SystemObjects.Other.Audio.playLowSound();
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
    }
}
