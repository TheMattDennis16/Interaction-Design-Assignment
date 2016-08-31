using System;
using System.Windows.Forms;

namespace Assignment.Classes.FormObjects.Panels
{
    class EndPanel
    {
        public static Panel getPanel()
        {
            Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
            
            Panel pnl = new Panel();
            pnl.SetBounds(100, 100, 300, 300);

            Label congratulations = new Label();
            congratulations.Text = "Congratulations! You won!";
            congratulations.Location = new System.Drawing.Point((pnl.Width / 2) - (congratulations.Width / 2), 0);
            pnl.Controls.Add(congratulations);


            Button end = new Button(); Label score = new Label();
            end.Location = new System.Drawing.Point((pnl.Width / 2) - (end.Width / 2), (pnl.Height - end.Height));
            end.Click += End_Click;
            end.Text = "Close Game";
            pnl.Controls.Add(end);

            Score.ScoreReturn userScore = Score.Score.getScore();
            score.Location = new System.Drawing.Point(5, 30);
            score.Width = pnl.Width;
            score.Height = pnl.Height - (congratulations.Height + end.Height);
            score.Text = "Your score was: " + userScore.score + "\n This score is gained from additional goals, such as using the oven Timer.\n The total score available was " + userScore.total;
            pnl.Controls.Add(score);
            pnl.BringToFront();

            return pnl;
        }

        private static void End_Click(object sender, EventArgs e)
        {
            Form1 frm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
            frm.Close();
        }
    }
}
