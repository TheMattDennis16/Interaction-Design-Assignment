using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class CoveringBowl : GameMovable
    {
        public bool hasChocolate = false;
        public bool hasCream = false;
        public bool hasHeated = false;

        public CoveringBowl()
        {
            sizes.Add("1280x720", new int[] { 120, 80 });
            sizes.Add("800x600", new int[] { 100, 60 });
            frmObj.BackColor = System.Drawing.Color.Transparent;
            frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.MouseHover += FrmObj_MouseHover;
            frmObj.Click += FrmObj_Click;
        }

        private void updateImage()
        {
            if (hasChocolate && hasCream && hasHeated)
            {
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Mixed_Melted;
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                tasks.markTaskComplete(Properties.Resources.INSTRUCTION_2);
            }
            else if (hasChocolate && hasCream)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Cream_Chocolate;
            else if (hasChocolate)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Chocolate;
            else if (hasCream)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Flower;
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                var obj = InterfaceObjects.ItemBinding.getBoundClass();
                Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];

                if (obj is ChocolateBar)
                {
                    hasChocolate = true;
                    updateImage();
                    ChocolateBar choc = obj as ChocolateBar;
                    choc.consumeChocolate(200);
                    InteractionMarker marker = frm.formObj["marker"] as InteractionMarker;
                    marker.hide();
                }
                else if (obj is Cream)
                {
                    hasCream = true;
                    updateImage();
                    Cream cream = obj as Cream;
                    cream.frmObj.Dispose();
                    InteractionMarker marker = frm.formObj["marker"] as InteractionMarker;
                    marker.hide();
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
                InterfaceObjects.ItemBinding.unbindItem();
            }
            else
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
            }
        }

        public bool hasIngredients()
        {
            return hasChocolate && hasCream;
        }

        public bool isFinished()
        {
            return hasChocolate && hasCream && hasHeated;
        }
        
        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(frmObj, "Chocolate Covering Bowl");
        }
    }
}
