using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Flour : GameMovable
    {
        public Flour()
        {
            frmObj.BackgroundImage = Properties.Resources.Flour;
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
            tt.SetToolTip(frmObj, "Self Raising Flour");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if (!InterfaceObjects.ItemBinding.hasBoundItem())
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
                Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                InteractionMarker marker = frm.formObj["marker"] as InteractionMarker;
                Scales scale = frm.formObj["scales"] as Scales;
                marker.show(new System.Drawing.Point(scale.frmObj.Location.X - (marker.frmObj.Width / 2), scale.frmObj.Location.Y - marker.frmObj.Height));
            }
            else
            {
                if(InterfaceObjects.ItemBinding.getBoundClass() is Flour)
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.CANT_USE_ITSELF, 5);
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
            }
        }

        public void hide()
        {
            frmObj.Dispose();
        }
    }
}
