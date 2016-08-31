using System;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class ChocolateBar : FormObjects.GameMovable
    {
        private int chocAmount = 400;
        private Form1 frm = (Form1)Application.OpenForms["Form1"];

        public ChocolateBar()
        {
            frmObj.BackgroundImage = Properties.Resources.chocolate_bar_full;
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
            tt.SetToolTip(frmObj, "Chocolate Bar");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(!InterfaceObjects.ItemBinding.hasBoundItem())
            {
                if (chocAmount == 400)
                {
                    //Move marker to above new picturebox
                    InteractionMarker mark = frm.formObj["marker"];
                    MeltingBowl bowl = frm.formObj["meltingBowl"];
                    mark.show(new System.Drawing.Point(bowl.frmObj.Location.X, bowl.frmObj.Location.Y - 40));
                }
                else
                {
                    InteractionMarker mark = frm.formObj["marker"];
                    CoveringBowl bowl = frm.formObj["coveringBowl"];
                    mark.show(new System.Drawing.Point(bowl.frmObj.Location.X, bowl.frmObj.Location.Y - 40));
                }
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
            }
            else
            {
                //Potentially replace with window for slicing 200g chocolate.
                var obj = InterfaceObjects.ItemBinding.getBoundClass();
                if (obj is MeltingBowl)
                {
                    consumeChocolate(200);
                    InterfaceObjects.ItemBinding.unbindItem();
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
            }
        }

        public int consumeChocolate(int amount)
        {
            //Returns the amount of chocolate remaining.
            int returnAmount = chocAmount - amount;
            if(returnAmount == 200)
            {
                frmObj.BackgroundImage = Properties.Resources.chocolate_bar_half;
            }
            else if (returnAmount == 0)
            {
                frmObj.Dispose();
            }
            chocAmount -= amount;
            return returnAmount;
        }
    }
}
