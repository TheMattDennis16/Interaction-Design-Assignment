using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Cream : GameMovable
    {
        public Cream()
        {
            sizes.Add("1280x720", new int[] { 60, 85 });
            sizes.Add("800x600", new int[] { 60, 85 });
            frmObj.BackColor = System.Drawing.Color.Transparent;
            frmObj.BackgroundImage = Properties.Resources.DoubleCream;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Double Cream");
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
                Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                InteractionMarker marker = frm.formObj["marker"] as InteractionMarker;
                CoveringBowl bowl = frm.formObj["coveringBowl"] as CoveringBowl;
                marker.show(bowl.frmObj.Location);
            }
        }
    }
}
