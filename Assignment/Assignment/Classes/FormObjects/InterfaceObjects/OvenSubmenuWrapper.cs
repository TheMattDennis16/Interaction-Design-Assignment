using System.Windows.Forms;

namespace Assignment.Classes.InterfaceObjects
{
    class OvenSubmenuWrapper
    {
        private static bool hasOpenSubmenu = false;
        private static OvenControlWindow ovenCtrl = new OvenControlWindow();
        private static Form1 frm = (Form1)Application.OpenForms["Form1"];

        public static void createSubmenu()
        {
            if(!hasOpenSubmenu)
            {
                if(ovenCtrl.IsDisposed) 
                {
                    ovenCtrl  = new OvenControlWindow();
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
            if(hasOpenSubmenu)
            {
                hasOpenSubmenu = false;
            }
        }
    }
}
