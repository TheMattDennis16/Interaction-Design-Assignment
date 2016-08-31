using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class OvenControlWindow : Form
    {
        private static Form1 frm = (Form1)Application.OpenForms["Form1"];
        private static Classes.FormObjects.ObjectSpecific.Oven oven = frm.formObj["oven"];

        public OvenControlWindow()
        {
            InitializeComponent();
        }

        private void OvenControlWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Classes.InterfaceObjects.OvenSubmenuWrapper.hideSubmenu();
        }

        private void OvenControlWindow_Load(object sender, EventArgs e)
        {
            temperatureDial.Value = oven.temperature;
            timerDial.Value = oven.alertTime;
            label3.Text = timerDial.Value.ToString() + " minutes";
            label4.Text = temperatureDial.Value.ToString() + " Degrees";
        }

        private void temperatureDial_Click(object sender, EventArgs e)
        {
            const int correctTemperature = 0;
            if (temperatureDial.Value > 0 && temperatureDial.Value <= 250)
            {
                if (!oven.getOvenState())
                {
                    oven.turnOvenOn();
                    if (temperatureDial.Value <= (correctTemperature - (correctTemperature / 10))
                        && temperatureDial.Value >= (correctTemperature + (correctTemperature / 10)))
                    {
                        Score.Score.ovenRightTemperature.modified = true;
                        Score.Score.ovenRightTemperature.correct = true;
                    }
                    else
                    {
                        Score.Score.ovenRightTemperature.modified = true;
                        Score.Score.ovenRightTemperature.correct = false;
                    }
                }
                oven.temperature = temperatureDial.Value;
            }
            else
            {
                oven.turnOvenOff();
                oven.temperature = 0;
            }
        }

        private void timerDial_Click(object sender, EventArgs e)
        {
            int timeValue = timerDial.Value;
            const int correctTime = 120;
            if (timeValue != 0)
            {
                Score.Score.ovenTimerUsed.modified = true;
                Score.Score.ovenTimerUsed.correct = true;

                oven.turnTimerOn();
                if (timeValue <= (correctTime - (correctTime / 10))
                    && timeValue >= (correctTime + (correctTime / 10)))
                {
                    Score.Score.ovenTimerRightTemperature.modified = true;
                    Score.Score.ovenTimerRightTemperature.correct = true;
                }
                else
                {
                    Score.Score.ovenTimerRightTemperature.modified = true;
                    Score.Score.ovenTimerRightTemperature.correct = false;
                }
                oven.alertTime = timeValue;
            }
            else
            {
                oven.turnTimerOff();
                oven.alertTime = 0;
            }
        }

        private void temperatureDial_ValueChanged(object Sender)
        {
            label4.Text = temperatureDial.Value.ToString() + " Degrees";
        }

        private void timerDial_ValueChanged(object Sender)
        {
            label3.Text = timerDial.Value.ToString() + " minutes";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
