using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class StartScreen : UserControl
    {
        static int i = 1;
        public StartScreen()
        {
            InitializeComponent();
            startTimer.Enabled = true;
            Intro.Size = Size;
            Intro.Location = new Point(0, 0);
        }
        private void StartScreen_KeyDown(object sender, KeyEventArgs e)
        {
            MenuScreen ms = new MenuScreen();
            Form1 form = FindForm() as Form1;

            form.ChangeScreen(this, ms);
        }

        bool switched = false;
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            switched = !switched;

            switch(switched)
            {
                case false:
                    BackColor = Color.Black;
                    ForeColor = Color.White;
                    break;
                case true:
                    BackColor = Color.White;
                    ForeColor = Color.Black;
                    break;
            }
        }
    }
}
