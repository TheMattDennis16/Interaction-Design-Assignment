using System;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class StartGameMenuButton : Classes.FormObjects.MenuButton
    {
        public StartGameMenuButton()
        {
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Form1 act = (Form1)Application.OpenForms["Form1"];
            act.switchPanel("StartGame", act.getResolution());
        }
    }
}
