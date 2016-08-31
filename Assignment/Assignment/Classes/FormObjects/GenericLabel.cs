using System.Windows.Forms;
using System.Collections.Generic;

namespace Assignment.Classes.FormObjects
{
    class GenericLabel
    {
        public Label lbl = new Label();
        private Dictionary<string, int[]> sizes;

        public GenericLabel(string message)
        {
            lbl.Text = message;
            lbl.Font = new System.Drawing.Font(lbl.Font.FontFamily, 13);
            sizes = new Dictionary<string, int[]>();
            sizes.Add("1280x720", new int[] { 140, 75 });
            sizes.Add("800x600", new int[] { 140, 75 });
        }

        public void setPosition(int x, int y)
        {
            lbl.Left = x;
            lbl.Top = y;
        }

        public int[] getNewSizeFromResolution(string resolution)
        {
            return sizes[resolution];
        }

        public int[] getSize()
        {
            return new int[] { lbl.Width, lbl.Height };
        }
        public void setSize(string resolution)
        {
            int[] sizes = getNewSizeFromResolution(resolution);
            lbl.Width = sizes[0];
            lbl.Height = sizes[1];
        }
    }
}
