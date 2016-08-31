using System;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class MeltingBowl : FormObjects.GameMovable
    {
        private bool isButtered = false;
        private bool isChocolate = false;
        private bool isWatered = false;
        private bool isMelted = false;
        private Form1 frm = (Form1)Application.OpenForms["Form1"];

        public MeltingBowl()
        {
            sizes.Add("1280x720", new int[] { 120, 80 });
            sizes.Add("800x600", new int[] { 100, 60 });
            frmObj.BackColor = System.Drawing.Color.Transparent;
            frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl;
            frmObj.BackgroundImageLayout = ImageLayout.Zoom;
            frmObj.MouseHover += FrmObj_MouseHover;
            frmObj.Click += FrmObj_Click;
        }

        private void updateImage()
        {
            if (isMelted)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Mixed_Melted;
            else if (isButtered && isChocolate && isWatered)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Mixed;
            else if (isButtered && isChocolate)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Chocolate_Butter;
            else if (isButtered)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Butter;
            else if (isChocolate)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Chocolate;
        }


        private void FrmObj_Click(object sender, EventArgs e)
        {
            if (!InterfaceObjects.ItemBinding.hasBoundItem())
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
            }
            else
            {
                var obj = InterfaceObjects.ItemBinding.getBoundClass();
                if (obj is ChocolateBar)
                {
                    var lObj = obj as ChocolateBar;
                    lObj.consumeChocolate(200);
                    TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                    tasks.markTaskComplete(Properties.Resources.INSTRUCTION_2);
                    isChocolate = true;
                    updateImage();
                }
                else if(obj is Butter)
                {
                    var lObj = obj as Butter;
                    if(!lObj.hasBeenMixed)
                    {
                        lObj.useButter();
                        lObj.hasBeenMixed = true;
                        isButtered = true;
                        TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_3);
                        updateImage();
                    }
                }
                else if (obj is MeasuringJug)
                {
                    MeasuringJug lObj = obj as MeasuringJug;
                    if (lObj.isComplete())
                    {
                        isWatered = true;
                        TaskListBox tasks = frm.formObj["tasks"];
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_4);
                        lObj.hide();
                        lObj.setPosition(-50, -50);
                        updateImage();
                    }
                    else
                    {
                        ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                    }
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
                var marker = frm.formObj["marker"] as InteractionMarker;
                marker.hide();
                InterfaceObjects.ItemBinding.unbindItem();
            }
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(frmObj, "Chocolate Melting Bowl");
        }

        public bool isComplete()
        {
            return isButtered && isChocolate && isWatered;
        }

        public bool isBowlMelted()
        {
            return isMelted;
        }

        public void setMelted()
        {
            isMelted = true;
            updateImage();
        }
    }
}
