using System;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class SettingsResolutionDropdown : Classes.FormObjects.DropdownBox
    {
        private bool isSetup = false;

        public SettingsResolutionDropdown()
        {
            box.SelectedIndexChanged += Box_SelectedIndexChanged;
            box.SelectedIndex = 0;
            isSetup = true;
        }

        private void Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isSetup)
            {
                SettingsClass.setSetting("resolution", box.Items[box.SelectedIndex].ToString());
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                frm.setResolution(box.Items[box.SelectedIndex].ToString());
                frm.switchResolutionLayout(box.Items[box.SelectedIndex].ToString());
            }
        }
    }
}
