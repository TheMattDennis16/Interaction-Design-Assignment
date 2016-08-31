using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class InteractionMarker : GameMovable
    {
        public InteractionMarker()
        {
            sizes.Add("1280x720", new int[] { 30, 30 });
            sizes.Add("800x600", new int[] { 30, 30 });
            frmObj.MouseEnter += FrmObj_MouseEnter;
            frmObj.Click += FrmObj_Click;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            frmObj.BackgroundImage = Properties.Resources.Marker;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            hide();
        }

        private void FrmObj_MouseEnter(object sender, EventArgs e)
        {
            //Overwriting inherited behaviour
        }

        public void show(System.Drawing.Point pt)
        {
            frmObj.Location = pt;
            frmObj.Show();
        }

        public void hide()
        {
            frmObj.Hide();
            frmObj.Location = new System.Drawing.Point(-50, -50);
        }
    }
}
