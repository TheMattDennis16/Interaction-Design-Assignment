using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class SugarAmount : GameMovable
    {
        public SugarAmount()
        {
            frmObj.BackgroundImage = Properties.Resources.Cup_Flower;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 40, 40 });
            sizes.Add("800x600", new int[] { 40, 40 });
        }
    }
}
