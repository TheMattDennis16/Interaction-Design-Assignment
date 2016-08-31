using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.ObjectSpecific
{
    class Oven : Classes.FormObjects.GameNonmovable
    {
        private bool isOn;
        private bool isTimerOn;
        private bool hasCaketinInOven;

        private Timer timerTime;
        private Timer ovenOnTime;

        public int alertTime = 0;

        private int elapsedTimeTimer;
        private int elapsedTimeOvenOnTimer;
        private int elapsedTimeInoven;
        private const int cookingTime = 90;

        public int temperature = 0;

        public Oven()
        {
            isOn = false;
            isTimerOn = false;

            hasCaketinInOven = false;

            timerTime = new Timer();
            timerTime.Interval = 333;
            timerTime.Tick += TimerTime_Tick;
            elapsedTimeTimer = 0;
            elapsedTimeInoven = 0;

            ovenOnTime = new Timer();
            ovenOnTime.Interval = 333;
            ovenOnTime.Tick += OvenOnTime_Tick;
            elapsedTimeOvenOnTimer = 0;

            sizes.Add("1280x720", new int[] { 250, 250 });
            sizes.Add("800x600", new int[] { 180, 160 });
            frmObj.Image = Properties.Resources.oven;
            frmObj.Visible = true;

            frmObj.Click += FrmObj_Click;
            frmObj.DoubleClick += FrmObj_DoubleClick;
            frmObj.MouseHover += FrmObj_MouseHover;
        }

        private void FrmObj_MouseHover(object sender, System.EventArgs e)
        {
            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(frmObj, "Usable Oven\nHint: Double click to bring up controls");
        }

        private void FrmObj_DoubleClick(object sender, System.EventArgs e)
        {
            InterfaceObjects.OvenSubmenuWrapper.createSubmenu();
        }

        private void FrmObj_Click(object sender, System.EventArgs e)
        {
            if (InterfaceObjects.ItemBinding.hasBoundItem())
            {
                var loc = InterfaceObjects.ItemBinding.getBoundClass();
                if (loc is Caketin)
                {
                    Caketin lObj = loc as Caketin;
                    if(lObj.isBowlFilled())
                    {
                        hasCaketinInOven = true;
                        lObj.hide();
                        InterfaceObjects.ItemBinding.unbindItem();
                        changeCakeOvenImage();
                        Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                        TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_10);
                    }
                    else
                    {
                        ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                        InterfaceObjects.ItemBinding.unbindItem();
                    }
                }
                else if(loc is MeltingBowl)
                {
                    MeltingBowl lObj = loc as MeltingBowl;
                    if(lObj.isComplete())
                    {
                        lObj.setMelted();
                        Form1 frm = (Form1)Application.OpenForms["Form1"];
                        TaskListBox tasks = frm.formObj["tasks"];
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_5);
                        InterfaceObjects.ItemBinding.unbindItem();
                    }
                    else
                    {
                        ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                    }
                }
                else if (loc is CoveringBowl)
                {
                    CoveringBowl bowl = loc as CoveringBowl;
                    if(bowl.hasIngredients())
                    {
                        bowl.hasHeated = true;
                        bowl.frmObj.BackgroundImage = Properties.Resources.Glass_Mixing_Bowl_Chocolate;
                        Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                        TaskListBox tasks = frm.formObj["tasks"] as TaskListBox;
                        tasks.markTaskComplete(Properties.Resources.INSTRUCTION_12);
                    }
                    else
                    {
                        ErrorLogic.Error.showErrorDialog(Properties.Resources.NOT_READY, 5);
                    }
                    InterfaceObjects.ItemBinding.unbindItem();
                }
                else
                {
                    InterfaceObjects.ItemBinding.unbindItem();
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.NO_INTERACTION, 5);
                }
            }
            else
            {
                if(hasCaketinInOven && elapsedTimeInoven >= (cookingTime + (cookingTime / 4)))
                {
                    Form1 frm = (Form1)Application.OpenForms["Form1"];
                    if (elapsedTimeInoven >= (cookingTime - (cookingTime / 4)))
                    {
                        hasCaketinInOven = false; ;
                        Caketin tin = frm.formObj["caketin"] as Caketin;
                        tin.isCooked = true;
                        tin.frmObj.BackgroundImage = Properties.Resources.CoolingRack;
                        tin.show();
                        changeCakeOvenImage();
                        turnOvenOff();
                        //tin.frmObj.SetBounds(lObj.frmObj.Location.X, lObj.frmObj.Location.X, 280, 150);
                    }
                }
            }
        }

        private void changeCakeOvenImage()
        {
            if (isOn && hasCaketinInOven)
            {
                frmObj.Image = Properties.Resources.oven_on_with_cake;
            }
            else if (hasCaketinInOven)
            {
                frmObj.Image = Properties.Resources.oven_off_with_cake;
            }
            else if (isOn)
            {
                frmObj.Image = Properties.Resources.oven_on;
            }
            else
            {
                frmObj.Image = Properties.Resources.oven;
            }
        }

        private void TimerTime_Tick(object sender, System.EventArgs e)
        {
            if(elapsedTimeTimer >= alertTime)
            {
                SystemObjects.Other.Audio.playOvenAlarm();
                timerTime.Stop();
                timerTime.Enabled = false;
                timerTime = new Timer();
                //Add flashing icon over oven.
            }
            elapsedTimeTimer += 3;
        }

        private void OvenOnTime_Tick(object sender, System.EventArgs e)
        {
            //Cake is >25% overcooked, mark as burning
            if(hasCaketinInOven)
            {
                if (elapsedTimeInoven >= (cookingTime + (cookingTime / 4)) && hasCaketinInOven)
                {
                    if (frmObj.Image != Properties.Resources.oven_on_smoking)
                    {
                        frmObj.Image = Properties.Resources.oven_on_smoking;
                    }
                }
                elapsedTimeInoven++;
            }
            elapsedTimeOvenOnTimer += 3;
        }

        public void turnOvenOn()
        {
            isOn = true;
            ovenOnTime.Start();
            ovenOnTime.Enabled = true;
            SystemObjects.Other.Audio.startOvenSound();
            changeCakeOvenImage();
        }

        public void turnOvenOff()
        {
            isOn = false;
            ovenOnTime.Stop();
            ovenOnTime.Enabled = false;
            SystemObjects.Other.Audio.stopOvenSound();
            changeCakeOvenImage();
        }

        public void turnTimerOn()
        {
            timerTime = new Timer();
            timerTime.Interval = 1000;
            timerTime.Tick += TimerTime_Tick;
            elapsedTimeTimer = 0;
            isTimerOn = true;
            timerTime.Enabled = true;
            timerTime.Start();
        }

        public void turnTimerOff()
        {
            isTimerOn = false;
            timerTime.Stop();
            timerTime.Enabled = false;
        }

        public bool getOvenState()
        {
            return isOn;
        }

        public bool getTimerState()
        {
            return isTimerOn;
        }
    }
}