using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Media;

namespace BrickBreaker
{
    
    public partial class Form1 : Form
    {        
        public static List<HighScore> highScores = new List<HighScore>();
        /// <summary>
        /// The Game's Soundplayer.
        /// Note that remember that playSoundFrom and preloadSound will save lines of code when used
        /// </summary>
        public static SoundPlayer SoundPlayer = new SoundPlayer();
        public static GameScreen currentGame;
        public Form1()
        {
            InitializeComponent();
            loadScoresRK();
            Directory.SetCurrentDirectory(Program.FilePath);//Set the program to put files in the created directory
            Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Location = new Point(0, 0);
        }

        //testing
        public static void loadScoresRK()
        {
            //creating Xml reader file 
            XmlReader reader = XmlReader.Create("Resources/HighScores.xml", null);
            string newScoreString;

            //basically highScore1String is going to be highScore #1...and on...etc
            //plan: "highScores" should only contain 5 high "scores"

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    newScoreString = reader.ReadString();

                    HighScore newScore = new HighScore(newScoreString);
                    Form1.highScores.Add(newScore);
                }
            }

            reader.Close();
        }

        /// <summary>
        /// Gets a .wav file from the file path and plays it
        /// </summary>
        /// <param name="filePath"></param>
        public static void playSoundFrom(string filePath)
        {
            if (File.Exists(filePath))
            {
                SoundPlayer.SoundLocation = filePath;
                SoundPlayer.PlaySync();
            }
            else
                throw new Exception("Could not find the required file");
        }

        /// <summary>
        /// Gets the .wav file from specified location and loads it into the soundplayer
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool preloadSound(string filePath)
        {
            if(File.Exists(filePath))
            {
                SoundPlayer.SoundLocation = filePath;
                SoundPlayer.Load();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Changes the displaying screen and deletes the last screen
        /// </summary>
        /// <param name="remove"></param>
        /// <param name="add"></param>
        public void ChangeScreen(UserControl remove, UserControl add)
        {
            if(remove != null)
            {
                Controls.Remove(remove);
                remove.Dispose();
            }
            add.Size = new Size(Width / 3 * 2, Height / 3 * 2);
            add.Location = new Point(Width / 6, Height / 6);
            Controls.Add(add);
        }

        public static void CenterButtons(UserControl userControl, int startSpace = 0, int spaceBetween = 50)
        {
            int lastHeight = startSpace + spaceBetween;
            foreach (var Control in userControl.Controls.OfType<Button>())
            {
                Control.Location = new Point(userControl.Width / 2 - Control.Width / 2, lastHeight);
                lastHeight += spaceBetween + Control.Height;
            }
        }

        /// <summary>
        /// When the form finishes loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeScreen(null, new StartScreen());
        }
    }
}
