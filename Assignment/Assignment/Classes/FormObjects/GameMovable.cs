using System;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects
{
    class GameMovable : Interaction
    {
        public PictureBox frmObj;
        public Dictionary<string, int[]> sizes;

        public GameMovable()
        {
            sizes = new Dictionary<string, int[]>();
            frmObj = new PictureBox();
            frmObj.MouseEnter += FrmObj_MouseEnter;
            frmObj.MouseMove += FrmObj_MouseMove;
            frmObj.Cursor = Cursors.Hand;
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
            if(!InterfaceObjects.ItemBinding.hasBoundItem())
            {
                SystemObjects.Other.Audio.playHighSound();
            }
        }

        public void playHoverSound()
        {
            SystemObjects.Other.Audio.playHighSound();
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
