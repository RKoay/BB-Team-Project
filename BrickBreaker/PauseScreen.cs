using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class PauseScreen : Form
    {
        private static int index = 0;
        private List<Button> buttons = new List<Button>();
        private static PauseScreen pauseForm;
        private static DialogResult buttonResult = new DialogResult();

        public PauseScreen()
        {
            InitializeComponent();
            foreach (var c in Controls.OfType<Button>().Reverse())
            {
                c.GotFocus += gainFocus;
                c.LostFocus += lostFocus;
                buttons.Add(c);
            }
        }

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

        public static DialogResult Show()
        {
            pauseForm = new PauseScreen();

            pauseForm.ShowDialog();
            return buttonResult;
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "RESUME GAME":
                    buttonResult = DialogResult.Cancel;
                    break;
                case "EXIT GAME":
                    buttonResult = DialogResult.Abort;
                    break;
            }

            pauseForm.Close();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Cancel;
            pauseForm.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Abort;
            pauseForm.Close();
        }

        private void PauseScreen_Load(object sender, EventArgs e)
        {
            resumeButton.Focus();
        }

        private void PauseScreen_KeyDown(object sender, KeyEventArgs e)
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
            button.ForeColor = Color.Black;
        }
    }
}
