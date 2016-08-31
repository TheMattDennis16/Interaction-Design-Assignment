using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Sink : GameNonmovable
    {
        public Sink()
        {
            frmObj.BackgroundImageLayout = ImageLayout.Zoom;
            frmObj.BackgroundImage = Properties.Resources.Sink;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 225, 175 });
            sizes.Add("800x600", new int[] { 150, 100 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Usable Sink for getting Water");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                var obj = InterfaceObjects.ItemBinding.getBoundClass();
                if (obj is MeasuringJug)
                {
                    var lobj = obj as MeasuringJug;
                    lobj.addWater();
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
                InterfaceObjects.ItemBinding.unbindItem();
            }
        }
    }
}
