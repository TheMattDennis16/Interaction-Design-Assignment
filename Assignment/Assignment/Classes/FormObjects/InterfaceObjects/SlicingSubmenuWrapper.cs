namespace Assignment.Classes.InterfaceObjects
{
    class SlicingSubmenuWrapper
    {
        private static bool hasOpenSubmenu = false;
        private static SlicingWindow ovenCtrl = new SlicingWindow();
        private static Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];

        public static void createSubmenu()
        {
            if (!hasOpenSubmenu)
            {
                if (ovenCtrl.IsDisposed)
                {
                    ovenCtrl = new SlicingWindow();
                }
                ovenCtrl.TopLevel = false;
                ovenCtrl.Parent = frm;
                ovenCtrl.Show();
                ovenCtrl.BringToFront();
                hasOpenSubmenu = true;
            }
        }

        public static void hideSubmenu()
        {
            if (hasOpenSubmenu)
            {
                hasOpenSubmenu = false;
            }
        }
    }
}
