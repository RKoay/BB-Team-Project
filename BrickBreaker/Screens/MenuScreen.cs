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
using System.IO;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public void scoreOutput()
        {
            //testing: displaying the scores
            //scoreLabel.Text = Form1.highScores[0].score + " " + "\n" + Form1.highScores[1].score + " " + "\n" + Form1.highScores[2].score
            //    + " " + "\n" + Form1.highScores[3].score + " " + "\n" + Form1.highScores[4].score + " " + "\n";
            foreach (HighScore s in Form1.highScores)
            {
                scoreLabel.Text += "\n" + s.score + " " + "\n";

                //highscoreLabel.Text = s.score[0] + " " + "\n" + s.score[1] + " " + "\n" + s.score[2]
                //    + " " + "\n" + s.score[3] + " " + "\n" + s.score[4] + " " + "\n";
            }
        }
        //testing
        
        private static int index = 0;
        private List<Button> buttons = new List<Button>();
        public MenuScreen()
        {
            InitializeComponent();
            
            //compare the scores

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

            //Adding Labels to Label list for easy management
            //
            buttons.Add(_playButton);
            buttons.Add(_highScoreButton);
            buttons.Add(_exitButton);
        }

        /// <summary>
        /// Only for buttons made by Thayen
        /// </summary>
        private void gainFocus(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Red;
        }

        /// <summary>
        /// Only for buttons made by Thayen
        /// </summary>
        private void lostFocus(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.White;
        }

        /// <summary>
        /// The event code for when the play button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            var form = FindForm() as Form1;
            form.ChangeScreen(this, new GameScreen());
        }        
       
        /// <summary>
        /// The event code for when the Menu Screen finishes initializing loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuScreen_Load(object sender, EventArgs e)
        {
            Form1.CenterButtons(this, 75);

            foreach(var button in buttons)
            {
                button.GotFocus += gainFocus;
                button.LostFocus += lostFocus;
            }
            buttons[0].Focus();
        }

        /// <summary>
        /// The event code for when the Main Menu detects a key press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _newButton(-1).Focus();
                    break;
                case Keys.Down:
                    _newButton(1).Focus();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the newly selected button based on where the last one was. Pass a negative to go back in the list of buttons
        /// </summary>
        /// <param name="changeInIndex"></param>
        /// <returns></returns>
        private Button _newButton(int changeInIndex)
        {
            //Thayen
            index += changeInIndex;
            //If the button is out of range set the button within range
            if (index < 0)
                index = 0;
            else if (index >= buttons.Count)
                index = buttons.Count - 1;
            return buttons[index];
        }


        private void _exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _highScoreButton_Click(object sender, EventArgs e)
        {
            Form1 form = FindForm() as Form1;
            form.ChangeScreen(this, new HighScoreScreen());
        }
    }
}
