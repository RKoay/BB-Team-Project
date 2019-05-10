using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BrickBreaker
{
    public partial class HighScoreScreen : UserControl
    {
        public HighScoreScreen()
        {
            InitializeComponent();

            //Sorting the code
            Form1.highScores.Sort(delegate (HighScore x, HighScore y)
            {
                return y.score.CompareTo(x.score);
            });

            //removing scores at destined number 
            if (Form1.highScores.Count() > 5)
            {
                Form1.highScores.RemoveAt(5);
            }

            //showing the score 
            scoreOutput();
        }

        public void scoreOutput()
        {
            //testing: displaying the scores
            foreach (HighScore s in Form1.highScores)
            {
                highScores.Text += "\n" + s.score + " " + "\n";

                //highscoreLabel.Text = s.score[0] + " " + "\n" + s.score[1] + " " + "\n" + s.score[2]
                //    + " " + "\n" + s.score[3] + " " + "\n" + s.score[4] + " " + "\n";
            }
        }

        

        private void continueButton_Click(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();
            Form form = this.FindForm();

            form.Controls.Add(ms);
            form.Controls.Remove(this);

            ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
        }
    }
}
