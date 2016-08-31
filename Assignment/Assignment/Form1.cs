using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment
{
    public partial class Form1 : Form
    {
        private string activeResolution = null;
        private Classes.InterfaceObjects.PanelWrapper activePanel = null;
        public Dictionary<string, dynamic> formObj = new Dictionary<string, dynamic>();

        public Form1()
        {             
            InitializeComponent();
            //Force visible ready for adjustment in setDimensions function and access calls outside this class. Double buffer to reduce screen tearing.
            this.Visible = true;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            setDimensions();
            switchPanel("Splash", activeResolution);
            DoubleBuffered = true;
        }

        public Classes.InterfaceObjects.PanelWrapper getActivePanel()
        {
            return activePanel;
        }

        private void setDimensions()
        {
            //Parse the current setting, apply resolution to current form instance.
            string resolution = Classes.SettingsClass.getSetting("resolution");
            activeResolution = resolution;
            string[] dimensions = resolution.Split('x');
            this.Width = int.Parse(dimensions[0]);
            this.Height = int.Parse(dimensions[1]);
            
            //Deprecated, used for resizing elements when there's an active panel on the form.
            /*if(activePanel != null)
            {
                
                switchResolutionLayout(resolution);
            }*/
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public string getResolution()
        {
            return activeResolution;
        }
        
        public void setResolution(string resolution)
        {
            activeResolution = resolution;
        }

        public void startGame()
        {
            activePanel.newPnl.Controls.Clear();
            activePanel.newPnl.Visible = false;
            activePanel.objects.Clear();
            activePanel.objects = null;
            this.Controls.Clear();
            activePanel = null;
            Classes.Panels.GamePanel.startGame();
        }

        private void switchPanelToNew(Classes.InterfaceObjects.PanelWrapper panelWrap)
        {
            this.Controls.Clear();
            this.Controls.Add(panelWrap.newPnl);
            activePanel = panelWrap;
        }

        public void switchPanel(string newPanel, string newResolution)
        {
            if (newPanel == "Splash")
                switchPanelToNew(Classes.Panels.SplashPanel.getPanel(newResolution));
            else if (newPanel == "Settings")
                switchPanelToNew(Classes.Panels.SettingsPage.getPanel(newResolution));
            else if (newPanel == "StartGame")
                startGame();
        }
        
        public void switchResolutionLayout(string newResolution)
        {
            //Won't work on the game screen. Panel can't buffer two overlapping controls
            Panel newPnl = null;
            if (activePanel.newPnl.Name == "Splash")
                newPnl = Classes.Panels.SplashPanel.getPanel(newResolution).newPnl;
            else if (activePanel.newPnl.Name == "Settings")
                newPnl = Classes.Panels.SettingsPage.getPanel(newResolution).newPnl;
            else if (activePanel.newPnl.Name == "Game")
                startGame();

            string[] size = newResolution.Split('x');
            this.Size = new System.Drawing.Size(int.Parse(size[0]), int.Parse(size[1]));
            this.Controls.Clear();
            this.Controls.Add(newPnl);
        }
    }
}
