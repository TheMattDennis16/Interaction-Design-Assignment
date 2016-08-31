using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Caketin : FormObjects.GameMovable
    {
        private bool isButtered = false;
        private bool isFilled = false;
        public bool isCooked = false;
        private bool isCut = false;

        public Caketin()
        {
            sizes.Add("1280x720", new int[] { 125, 90 });
            sizes.Add("800x600", new int[] { 125, 75 });
            frmObj.BackgroundImage = Properties.Resources.EmptyCaketin;
            frmObj.BackgroundImageLayout = ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            frmObj.Visible = true;
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Caketin");
        }

        public bool isBowlFilled()
        {
            return isFilled;
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                interaction();
            }
            else
            {
                if(!isCooked)
                {
                    InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
                }
            }
        }

        public void hide()
        {
            frmObj.Visible = false;
        }

        public void show()
        {
            frmObj.Visible = true;
        }

        private void addButter(Butter butter)
        {
            //Only change if already buttered, prevents later stages being overwritten
            if(!isButtered)
            {
                isButtered = true;
                frmObj.BackgroundImage = Properties.Resources.ButteredCaketin;
                Score.Score.caketinButtered = new SystemObjects.Other.ScoreItem(true, true);
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                var loc = frm.formObj["tasks"] as TaskListBox;
                butter.useButter();
                loc.markTaskComplete(Properties.Resources.INSTRUCTION_1);
                InterfaceObjects.ItemBinding.unbindItem();
            }
        }

        public override void interaction()
        {
            var obj = InterfaceObjects.ItemBinding.getBoundClass();
            if (obj is Butter)
            {
                addButter(obj as Butter);
            }
            else if (obj is MixingBowl)
            {
                MixingBowl bowl = obj as MixingBowl;
                if (bowl.isBowlMixed())
                {
                    isFilled = true;
                    frmObj.BackgroundImage = Properties.Resources.CakeTinFull;
                    bowl.frmObj.Dispose();
                    InterfaceObjects.ItemBinding.unbindItem();
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                }
            }
            else if (obj is CoveringBowl)
            {
                CoveringBowl bowl = obj as CoveringBowl;
                if(bowl.isFinished() && isCut)
                {
                    try
                    {
                        Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                        InterfaceObjects.ItemBinding.blockAction();
                        frm.Controls.Add(Panels.EndPanel.getPanel());
                        Sink sink = frm.formObj["sink"] as Sink;
                        sink.frmObj.Dispose();
                        CoveringBowl bwl = frm.formObj["coveringBowl"] as CoveringBowl;
                        bwl.frmObj.Dispose();
                    }
                    catch (Exception e)
                    {
                        //handled...
                    }
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                }
            }
            else if (obj is Knife)
            {
                if(isCooked)
                {
                    InterfaceObjects.SlicingSubmenuWrapper.createSubmenu();
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                    InterfaceObjects.ItemBinding.unbindItem();
                }
            }
            else
            {
                ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                InterfaceObjects.ItemBinding.unbindItem();
            }
        }

        public bool isCakeCut()
        {
            return isCut;
        }

        public void markCut()
        {
            isCut = true;
            frmObj.BackgroundImage = Properties.Resources.CoolingRackChocolated;
        }
    }
}
