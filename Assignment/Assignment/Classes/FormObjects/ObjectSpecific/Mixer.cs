using System;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Mixer : GameMovable
    {
        public Mixer()
        {
            frmObj.BackgroundImage = Properties.Resources.Whisk;
            frmObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            frmObj.BackColor = System.Drawing.Color.Transparent;
            sizes.Add("1280x720", new int[] { 70, 75 });
            sizes.Add("800x600", new int[] { 70, 75 });
            frmObj.Click += FrmObj_Click;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Usable Mixer");
        }

        private void FrmObj_Click(object sender, EventArgs e)
        {
            if(InterfaceObjects.ItemBinding.hasBoundItem())
            {
                var obj = InterfaceObjects.ItemBinding.getBoundClass();
                if (obj is MixingBowl)
                {
                    MixingBowl bowl = obj as MixingBowl;
                    if (bowl.isFinished())
                    {
                        bowl.setMixed();
                        Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                        TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_9);
                    }
                    else
                    {
                        ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                    }
                    InterfaceObjects.ItemBinding.unbindItem();
                }
                else
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
            }
            else
            {
                InterfaceObjects.ItemBinding.bindItemToCursor(frmObj, this);
            }
        }
    }
}
