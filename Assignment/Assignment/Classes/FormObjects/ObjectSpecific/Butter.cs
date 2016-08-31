
namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Butter : GameMovable
    {
        private int butterAmount = 1;
        public bool hasBeenMixed = false;

        public Butter()
        {
            frmObj.BackgroundImage = Properties.Resources.Butter;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 75, 60 });
            sizes.Add("800x600", new int[] { 75, 60 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, System.EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Butter");
        }

        public void useButter()
        {
            if(butterAmount > 0)
            {
                butterAmount--;
            }
            else
            {
                frmObj.Dispose();
            }
        }

        private void FrmObj_Click(object sender, System.EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                InterfaceObjects.ItemBinding.unbindItem();
            }
            else
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
            }
        }
    }
}
