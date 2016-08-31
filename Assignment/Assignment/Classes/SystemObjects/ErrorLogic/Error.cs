using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment.Classes.ErrorLogic
{
    class Error
    {
        private Dictionary<ErrorType, string[]> errorSet = new Dictionary<ErrorType, string[]>();
        private static Form1 frm = (Form1)Application.OpenForms["Form1"];

        public Error(ErrorType type, string className, string additional = "")
        {
            errorSet.Add(ErrorType.RESOLUTION, new string[] { "Unable to switch resolution. Please try again.", "Unable to switch resolution. Please try again." });
            errorSet.Add(ErrorType.UNHANDLED, new string[] { "An Unknown error has occured.", "The caught error was unhandled." });
            errorSet.Add(ErrorType.OUT_OF_BOUNDS, new string[] { "An Unknown error has occured.", "Out of bounds element accessed or entry not found." });
            MessageBox.Show
            (
                null,
                " Error: "+errorSet[type][0],
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private static int dtime = 0;
        private static int currTime = 0;
        private static Panel dialogBox;

        public static void showErrorDialog(string message, int duration)
        {
            dtime = duration;
            currTime = 0;
            dialogBox = new Panel();
            Label lbl = new Label();
            Timer time = new Timer();
            time.Interval = 1000;
            time.Tick += Time_Tick;
            dialogBox.SetBounds((frm.Width / 2) - (dialogBox.Width / 2), frm.Height - (dialogBox.Height + 30) , 250, 60);

            lbl.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 11);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Text = message;
            lbl.SetBounds(0, 0, dialogBox.Width, dialogBox.Height);
            lbl.Visible = true;

            dialogBox.Visible = true;
            dialogBox.Controls.Add(lbl);
            frm.Controls.Add(dialogBox);
            time.Start();
            time.Enabled = true;
        }

        private static void Time_Tick(object sender, System.EventArgs e)
        {
            if(currTime >= dtime)
            {
                frm.Controls.Remove(dialogBox);
                var timer = sender as Timer;
                timer.Stop();
                timer.Enabled = false;
            }
            currTime++;
        }
    }
}
