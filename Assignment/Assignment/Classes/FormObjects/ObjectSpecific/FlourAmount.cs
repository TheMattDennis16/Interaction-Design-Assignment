namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class FlourAmount : GameMovable
    {
        public FlourAmount()
        {
            frmObj.BackgroundImage = Properties.Resources.Cup_Flower;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 40, 40 });
            sizes.Add("800x600", new int[] { 40, 40 });
        }
    }
}
