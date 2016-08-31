using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Scales : GameNonmovable
    {
        public Scales()
        {
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackgroundImage = Properties.Resources.Scales;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 75, 100 });
            sizes.Add("800x600", new int[] { 75, 100 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Usable Weighing Scales");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            var obj = InterfaceObjects.ItemBinding.getBoundClass();
            if(obj is Flour)
            {
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                Flour flour = obj as Flour;
                flour.frmObj.Dispose();
                InterfaceObjects.ItemBinding.unbindItem();
                FlourAmount amt = new FlourAmount();
                amt.setSize(frm.getResolution());
                frm.Controls.Add(amt.frmObj);
                InterfaceObjects.ItemBinding.bindItemToCursor(amt.frmObj, amt);
                InteractionMarker marker = frm.formObj["marker"] as InteractionMarker;
                MixingBowl mixing = frm.formObj["mixingBowl"];
                marker.setPosition(mixing.frmObj.Location.X, mixing.frmObj.Location.Y);
            }
            else if (obj is Sugar)
            {
                Sugar sug = obj as Sugar;
                sug.frmObj.Dispose();
                InterfaceObjects.ItemBinding.unbindItem();
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                SugarAmount amt = new SugarAmount();
                amt.setSize(frm.getResolution());
                frm.Controls.Add(amt.frmObj);
                InterfaceObjects.ItemBinding.bindItemToCursor(amt.frmObj, amt);
                InteractionMarker marker = frm.formObj["marker"] as InteractionMarker;
                MixingBowl mixing = frm.formObj["mixingBowl"];
                marker.setPosition(mixing.frmObj.Location.X, mixing.frmObj.Location.Y);
            }
            else
            {
                ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
            }
        }
    }
}
