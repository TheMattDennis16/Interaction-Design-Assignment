using System;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class MeasuringJug : GameMovable
    {
        private bool hasWater = false;
        private bool hasCoffee = false;

        public MeasuringJug()
        {
            frmObj.BackgroundImage = Properties.Resources.WaterJugEmpty;
            frmObj.BackgroundImageLayout = ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 90, 75 });
            sizes.Add("800x600", new int[] { 75, 60 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Usable Measuring Jug");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if (!InterfaceObjects.ItemBinding.hasBoundItem())
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
                Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                InteractionMarker marker = frm.formObj["marker"] as InteractionMarker;
                MeltingBowl bowl = frm.formObj["meltingBowl"] as MeltingBowl;
                marker.show(new System.Drawing.Point(bowl.frmObj.Location.X + (bowl.frmObj.Width / 2) - marker.frmObj.Width / 2, bowl.frmObj.Location.Y - marker.frmObj.Height));
            }
            else
            {
                var obj = InterfaceObjects.ItemBinding.getBoundClass();
                if(obj is InstantCoffee)
                {
                    var lObj = obj as InstantCoffee;
                    hasCoffee = true;
                    InterfaceObjects.ItemBinding.unbindItem();
                    lObj.hasAddedToWater = true;
                    lObj.frmObj.Dispose();
                    updateImage();
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
            }
        }
        
        public void hide()
        {
            frmObj.Hide();
        }

        public bool isComplete()
        {
            return hasWater && hasCoffee;
        }

        public void addWater()
        {
            hasWater = true;
            updateImage();
        }

        public void addCoffee()
        {
            hasCoffee = true;
            updateImage();
        }

        private void updateImage()
        {
            if (isComplete())
                frmObj.BackgroundImage = Properties.Resources.WaterJugFullCoffee;
            else if (hasWater)
                frmObj.BackgroundImage = Properties.Resources.WaterJugFull;
            else frmObj.BackgroundImage = Properties.Resources.WaterJugEmpty;
        }
    }
}
