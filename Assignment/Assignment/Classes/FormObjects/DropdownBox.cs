using System.Windows.Forms;
using System.Collections.Generic;

namespace Assignment.Classes.FormObjects
{
    class DropdownBox
    {
        public ComboBox box;
        private Dictionary<string, int[]> sizes;

        public DropdownBox()
        {
            box = new ComboBox();
            box.Items.AddRange(SettingsClass.resolutions);
            box.Font = new System.Drawing.Font(box.Font.FontFamily, 13);
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            sizes = new Dictionary<string, int[]>();
            sizes.Add("1280x720", new int[] { 140, 75 });
            sizes.Add("800x600", new int[] { 140, 75 });
        }

        public void setPosition(int x, int y)
        {
            box.Left = x;
            box.Top = y;
        }

        public int[] getNewSizeFromResolution(string resolution)
        {
            return sizes[resolution];
        }

        public int[] getSize()
        {
            return new int[] { box.Width, box.Height };
        }
        public void setSize(string resolution)
        {
            int[] sizes = getNewSizeFromResolution(resolution);
            box.Width = sizes[0];
            box.Height = sizes[1];
        }
    }
}
