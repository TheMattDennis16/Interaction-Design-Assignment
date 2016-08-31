using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Soda : GameMovable
    {
        public Soda()
        {
            frmObj.BackgroundImage = Properties.Resources.Bicarbonate_Of_Soda;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 90, 75 });
            sizes.Add("800x600", new int[] { 75, 60 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Bicarbonate Of Soda");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if (InterfaceObjects.ItemBinding.hasBoundItem())
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
