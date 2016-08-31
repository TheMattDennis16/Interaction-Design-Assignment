using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class MixingBowl : GameMovable
    {
        private Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
        private bool hasFlower = false;
        private bool hasSoda = false;
        private bool hasSugar = false;
        private bool hasCocoa = false;
        private bool hasButtermilk = false;
        private bool hasChocolate = false;
        private int eggCount = 0;
        private bool isMixed = false;
        
        public MixingBowl()
        {
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 120, 80 });
            sizes.Add("800x600", new int[] { 100, 60 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Final Melting Bowl");
        }

        private void updateImage()
        {
            if (isMixed)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Mixed;
            else if (hasChocolate)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Chocolate;
            else if (hasSugar && hasFlower && hasCocoa && eggCount >= 1)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Flower_Cocoa_Eggs;
            else if (eggCount >= 1 && hasSugar || hasFlower)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Flower_Egg;
            else if (hasSugar && hasFlower && hasCocoa)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Flower_Cocoa;
            else if (hasFlower || hasSugar || hasFlower && hasSugar)
                frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Flower;
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                var obj = InterfaceObjects.ItemBinding.getBoundClass();
                if(obj is FlourAmount)
                {
                    hasFlower = true;
                    FlourAmount amt = obj as FlourAmount;
                    amt.frmObj.Dispose();
                    InterfaceObjects.ItemBinding.unbindItem(true);
                    updateImage();
                }
                else if (obj is SugarAmount)
                {
                    hasSugar = true;
                    SugarAmount sug = obj as SugarAmount;
                    sug.frmObj.Dispose();
                    InterfaceObjects.ItemBinding.unbindItem(true);
                    updateImage();
                }
                else if (obj is Egg)
                {
                    eggCount++;
                    Egg egg = obj as Egg;
                    frm.formObj.Remove("egg");
                    frm.Controls.Remove(egg.frmObj);
                    InterfaceObjects.ItemBinding.unbindItem(true);
                    updateImage();
                }
                else if (obj is Soda)
                {
                    hasSoda = true;
                    Soda soda = obj as Soda;
                    soda.frmObj.Dispose();
                    InterfaceObjects.ItemBinding.unbindItem();
                }
                else if (obj is ButterMilk)
                {
                    hasButtermilk = true;
                    ButterMilk milk = obj as ButterMilk;
                    milk.frmObj.Dispose();
                    InterfaceObjects.ItemBinding.unbindItem();
                }
                else if (obj is Cocoa)
                {
                    hasCocoa = true;
                    Cocoa cocoa = obj as Cocoa;
                    cocoa.frmObj.Dispose();
                    InterfaceObjects.ItemBinding.unbindItem();
                    updateImage();
                }
                else if (obj is Mixer)
                {
                    Mixer mixer = obj as Mixer;
                    if(isFinished())
                    {
                        isMixed = true;
                        mixer.frmObj.Dispose();
                        InterfaceObjects.ItemBinding.unbindItem();
                        TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_9);
                        updateImage();
                    }
                }
                else if (obj is MeltingBowl)
                {
                    MeltingBowl bowl = obj as MeltingBowl;
                    if(bowl.isBowlMelted())
                    {
                        hasChocolate = true;
                        bowl.frmObj.Dispose();
                        InterfaceObjects.ItemBinding.unbindItem();
                        TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_8);
                        updateImage();
                    }
                    else
                    {
                        ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                    }
                }
                else if (obj is Flour || obj is Sugar)
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
                checkState();
                InteractionMarker mrk = frm.formObj["marker"] as InteractionMarker;
                mrk.hide();
            }
            else
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
            }
        }

        public void checkState()
        {
            if (isNearlyFinished())
            {
                TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                tasks.markTaskComplete(Properties.Resources.INSTRUCTION_6);
            }
            if (isFinished())
            {
                TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                tasks.markTaskComplete(Properties.Resources.INSTRUCTION_7);
            }
        }

        public void setMixed()
        {
            isMixed = true;
        }

        public bool isBowlMixed()
        {
            return isMixed;
        }

        public bool isNearlyFinished()
        {

            return hasCocoa && hasFlower && hasSoda && hasSugar;
        }

        public bool isFinished()
        {
            return hasCocoa && hasFlower && hasSoda && hasSugar && eggCount == 3 && hasButtermilk;
        }
    }
}