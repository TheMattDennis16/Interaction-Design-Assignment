using System.Windows.Forms;
using System.Collections.Generic;

namespace Assignment.Classes.Panels
{
    class SplashPanel
    {
        public static Classes.InterfaceObjects.PanelWrapper getPanel(string resolution)
        {
            int spacing = 30;
            Classes.InterfaceObjects.PanelWrapper pnl = new Classes.InterfaceObjects.PanelWrapper();
            Panel newPnl = new Panel();
            Dictionary<string, dynamic> formObj = new Dictionary<string, dynamic>();
            string[] dimensions = resolution.Split('x');
            newPnl.Name = "Splash";
            newPnl.SetBounds(0, 0, int.Parse(dimensions[0]), int.Parse(dimensions[1]));
            newPnl.BackgroundImage = Properties.Resources.SplashBackground;
            newPnl.BackgroundImageLayout = ImageLayout.Zoom;

            Label newlbl = new Label();
            newlbl.BackColor = System.Drawing.Color.Transparent;
            newlbl.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 15);
            newlbl.Text = "Let's bake a cake!";
            newlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            newlbl.SetBounds((newPnl.Width / 2) - (newlbl.Width / 2), 50, 160, 50);
            newlbl.Visible = true;
            formObj.Add("welcomeLabel", newlbl);
            newPnl.Controls.Add(newlbl);

            Label instructions = new Label();
            instructions.BackColor = System.Drawing.Color.Transparent;
            instructions.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 12);
            instructions.Text = "Instructions / Hints:\n - To select an ingredient or item simply click it Once.\n- The oven controls can be accessed by double clicking it's icon.\n- Feel free to click around, you can experiment with nearly every combination of items!\n- Some ingredients when clicked on will create markers to show you which item they should be used on next!\n- Hovering over an item will bring up its description\n\nYou are advised to play in 1280x720.";
            instructions.SetBounds(50, 100, 250, 500);
            instructions.Visible = true;
            formObj.Add("hints", instructions);
            newPnl.Controls.Add(instructions);

            FormObjects.ObjectSpecific.StartGameMenuButton startGame = new FormObjects.ObjectSpecific.StartGameMenuButton();
            startGame.button.Name = "Start Game";
            startGame.button.Text = "Start Game";
            startGame.setSize(resolution);
            startGame.setPosition((newPnl.Width / 2) - (startGame.button.Width / 2), 140);
            formObj.Add("btnStart", startGame);

            FormObjects.ObjectSpecific.SettingsMenuButton loadSettings = new FormObjects.ObjectSpecific.SettingsMenuButton();
            loadSettings.button.Name = "Open Settings";
            loadSettings.button.Text = "Open Settings";
            loadSettings.setSize(resolution);
            loadSettings.setPosition((newPnl.Width / 2 ) - (startGame.button.Width / 2), (startGame.button.Top + startGame.button.Height) + spacing);
            formObj.Add("btnLoadSettings", loadSettings);

            newPnl.Controls.Add(startGame.button);
            newPnl.Controls.Add(loadSettings.button);

            pnl.newPnl = newPnl;
            pnl.objects = formObj;
            return pnl;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
