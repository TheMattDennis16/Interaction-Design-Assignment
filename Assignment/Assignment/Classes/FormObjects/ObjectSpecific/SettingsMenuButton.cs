using System;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class SettingsMenuButton : Classes.FormObjects.MenuButton
    {
        public SettingsMenuButton()
        {
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Form1 act = (Form1)Application.OpenForms["Form1"];
            act.switchPanel("Settings", act.getResolution());
        }
    }
}
