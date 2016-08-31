using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class InstantCoffee : GameMovable
    {
        public bool hasAddedToWater = false;

        public InstantCoffee()
        {
            frmObj.BackgroundImage = Properties.Resources.InstantCoffee;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 75, 90 });
            sizes.Add("800x600", new int[] { 75, 90 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Instant Coffee");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
        }

        public void consume()
        {
            frmObj.Dispose();
            frmObj.Location = new System.Drawing.Point(-50, -50);
        }
    }
}
