using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Knife : GameMovable
    {
        public Knife()
        {
            frmObj.BackgroundImage = Properties.Resources.Knife;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 100, 55 });
            sizes.Add("800x600", new int[] { 100, 55 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Usable Knife");
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
