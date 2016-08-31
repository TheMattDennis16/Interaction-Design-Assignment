using System.Windows.Forms;
using System.Collections.Generic;

namespace Assignment.Classes.FormObjects
{
    class MenuButton
    {
        public Button button;
        private Dictionary<string, int[]> sizes;

        public MenuButton()
        {
            button = new Button();
            button.Font = new System.Drawing.Font(button.Font.FontFamily, 13);
            sizes = new Dictionary<string, int[]>();
            sizes.Add("1280x720", new int[] { 140, 75 });
            sizes.Add("800x600" , new int[] { 140, 75 });
        }

        public void setPosition(int x, int y)
        {
            button.Left = x;
            button.Top  = y;
        }

        public int[] getNewSizeFromResolution(string resolution)
        {
            return sizes[resolution];
        }
        
        public int[] getSize()
        {
            return new int[] { button.Width, button.Height };
        }
        public void setSize(string resolution)
        {
            int[] sizes = getNewSizeFromResolution(resolution);
            button.Width  = sizes[0];
            button.Height = sizes[1];
        }
    }
}
