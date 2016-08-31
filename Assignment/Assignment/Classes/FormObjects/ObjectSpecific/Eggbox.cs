using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Eggbox : GameNonmovable
    {
        private int eggCount = 3;

        public Eggbox()
        {
            sizes.Add("1280x720", new int[] { 125, 90 });
            sizes.Add("800x600", new int[] { 125, 75 });
            frmObj.BackgroundImage = Properties.Resources.Eggbox_Three;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Eggs");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
            }
            else
            {
                Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                Egg egg = new Egg();
                egg.setSize(frm.getResolution());
                InterfaceObjects.ItemBinding.bindItemToCursor(egg.frmObj, egg);
                frm.formObj.Add("egg", egg);
                frm.Controls.Add(egg.frmObj);
                InteractionMarker mrk = frm.formObj["marker"] as InteractionMarker;
                MixingBowl bwl = frm.formObj["mixingBowl"] as MixingBowl;
                mrk.show(new System.Drawing.Point(bwl.frmObj.Location.X + (bwl.frmObj.Width / 2), bwl.frmObj.Location.Y - mrk.frmObj.Height));
                updateState();
            }
        }

        private void updateState()
        {
            eggCount--;
            if (eggCount == 2)
            {
                frmObj.BackgroundImage = Properties.Resources.Eggbox_Two;
            }
            else if (eggCount == 1)
            {
                frmObj.BackgroundImage = Properties.Resources.Eggbox_One;
            }
            else if (eggCount == 0)
            {
                frmObj.Dispose();
            }
        }
    }
}
