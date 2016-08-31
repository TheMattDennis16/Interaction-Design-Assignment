using System.Windows.Forms;
using System.Collections.Generic;

namespace Assignment.Classes.Panels
{
    class SettingsPage
    {
        public static Classes.InterfaceObjects.PanelWrapper getPanel(string resolution)
        {
            Panel newPnl = new Panel();
            string[] dimensions = resolution.Split('x');
            newPnl.Name = "Settings";
            if(resolution == "1280x720")
            {
                newPnl.SetBounds(0, 0, int.Parse(dimensions[0]), int.Parse(dimensions[1]));
            }
            else newPnl.SetBounds(0, 0, int.Parse(dimensions[0]), int.Parse(dimensions[1]));
            newPnl.BackgroundImage = Properties.Resources.SplashBackground;
            newPnl.BackgroundImageLayout = ImageLayout.Zoom;
            Dictionary<string, dynamic> formObj = new Dictionary<string, dynamic>();

            FormObjects.ObjectSpecific.SettingsResolutionDropdown dropdown = new FormObjects.ObjectSpecific.SettingsResolutionDropdown();
            FormObjects.GenericLabel lblResolution = new FormObjects.GenericLabel("Resolution:");
            lblResolution.setSize(resolution);
            lblResolution.lbl.BackColor = System.Drawing.Color.Transparent;
            dropdown.setSize(resolution);

            Button backBtn = new Button();
            backBtn.SetBounds(0, 0, 75, 50);
            backBtn.Text = "Back";
            backBtn.Click += BackBtn_Click;
            newPnl.Controls.Add(backBtn);

            if (resolution == "1280x720")
            {
                lblResolution.setPosition(540,100);
                dropdown.setPosition(640, 100);
            }
            else if (resolution == "800x600")
            {
                lblResolution.setPosition(300, 100);
                dropdown.setPosition(400, 100);
            }
            else new ErrorLogic.Error(ErrorLogic.ErrorType.RESOLUTION, "SettingsPage.cs", "");
            formObj.Add("resolutionDropdown", dropdown);
            newPnl.Controls.Add(dropdown.box);
            formObj.Add("resolutionLabel", lblResolution);
            newPnl.Controls.Add(lblResolution.lbl);

            InterfaceObjects.PanelWrapper panel = new InterfaceObjects.PanelWrapper();
            panel.newPnl = newPnl;
            panel.objects = formObj;
            return panel;
        }

        private static void BackBtn_Click(object sender, System.EventArgs e)
        {
            Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
            frm.switchPanel("Splash", frm.getResolution());
        }
    }
}
