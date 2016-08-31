using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Cocoa : GameMovable
    {
        public Cocoa()
        {
            frmObj.BackgroundImage = Properties.Resources.Cocoa;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 75, 80 });
            sizes.Add("800x600", new int[] { 75, 80 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Cocoa Powder");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
            }
            else
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
            }
        }
    }
}
