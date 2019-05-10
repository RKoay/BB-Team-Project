﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown, ADown, DDown;

        // TODO: Work on block collision

        // Paddle and Ball objects
        public static Paddle paddle = new Paddle(0, 0, 0, 0, 0, Color.Black);
        public static List<Ball> ballList = new List<Ball>();
        public static List<Ball> removeBalls = new List<Ball>();
        public static int paddleWidth = 140;
        public static int paddleHeight = 20;

        // list of all currentlevel for current level
        List<Block> currentlevel = new List<Block>();
        List<Block> removeBlocks = new List<Block>();

        //Powerups
        List<Powerups> powerup = new List<Powerups>();
        Boolean activated = false;
        public static int randomPowerupChance;

        SolidBrush powerups3Brush = new SolidBrush(Color.Green);
        SolidBrush powerupsLBrush = new SolidBrush(Color.Blue);
        SolidBrush powerupslBrush = new SolidBrush(Color.Red);
        SolidBrush powerupsBSBrush = new SolidBrush(Color.Purple);
        SolidBrush powerupsbsBrush = new SolidBrush(Color.Orange);

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
        Pen linePen = new Pen(Color.White);
        Pen testPen = new Pen(Color.Red);

        //Testing: Declaring variables;
        // Lives
        public int player1Lives = 5;
        public int? player2Lives = null;
        public static int score = 0;
        #endregion

        // start for game loop
        public static bool start = false;

        // Creates a new ball
        int xSpeed = 6;
        int ySpeed = 6;
        int ballSize = 20;

        // angle change buttons
        public static int angleposition = 3;

        // angle points for the line aim
        Point p1 = new Point(1,1), p2 = new Point(1, 1);
        public string direction = "left";

        // font and brush for text
        Font textFont = new Font("Verdana", 20, FontStyle.Regular);
        SolidBrush sb = new SolidBrush(Color.White);

        // level variables
        List<XmlReader> levelList = new List<XmlReader>();
        int currentlevelnum = 1;
        bool levelLoadstart = true;

        public GameScreen(bool multiplayer = false)
        {
            InitializeComponent();
            //OnStart(); 
            if (multiplayer)
                player2Lives = 3;
        }

        public void levelLoad()
        {
            if (levelLoadstart)
            {
                // need ten total items, think of list as actual level number -1
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/testlevel.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level1.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level2.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level3.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level4.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level5.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level6.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level7.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level8.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level9.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level10.xml"));
            }

            XmlReader reader = levelList[0];
            switch (currentlevelnum)
            {
                case 0:
                    reader = levelList[0];
                    break;
                case 1:
                    reader = levelList[1];
                    break;
                case 2:
                    reader = levelList[2];
                    break;
                case 3:
                    reader = levelList[3];
                    break;
                case 4:
                    reader = levelList[4];
                    break;
                case 5:
                    reader = levelList[5];
                    break;
                case 6:
                    reader = levelList[6];
                    break;
                case 7:
                    reader = levelList[7];
                    break;
                case 8:
                    reader = levelList[8];
                    break;
                case 9:
                    reader = levelList[9];
                    break;
            }

            powerup.Clear();
            currentlevel.Clear();
            while (reader.Read())
            {
                string X, Y, HP;
                reader.ReadToFollowing("brick");
                X = reader.GetAttribute("x");
                Y = reader.GetAttribute("y");
                HP = reader.GetAttribute("hp");

                currentlevel.Add(new Block(X, Y, HP));
            }
            currentlevel.RemoveAt(currentlevel.Count - 1);
            reader.Close();
            Refresh();
        }


        public void OnStart()
        {
            levelLoad();

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // reset score
            score = 0;

            // setup starting paddle values and create paddle object
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = 700;
            int paddleSpeed = 16;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = ((paddle.x - ballSize) + (paddle.width / 2));
            int ballY = paddle.y - 21;
            ballList.Clear();
            ballList.Add(new Ball(ballX, ballY, xSpeed, ySpeed, ballSize, 1, -1));

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;

                DialogResult result = PauseScreen.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    Form1 form = FindForm() as Form1;
                    form.ChangeScreen(this, new MenuScreen());
                }
            }

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    direction = "left"; 
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    direction = "right";
                    break;
                case Keys.Space:
                    start = true;
                    break;
                case Keys.Escape:
                    break;
                default:
                    break;
            }

            if (!start)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        // move left
                        if (angleposition >= 1 && angleposition < 6)
                        {
                            angleposition++;
                        }
                        break;
                    case Keys.D:
                        // move right
                        if (angleposition <= 6 && angleposition > 1)
                        {
                            angleposition--;
                        }
                        break;
                }
            }
        }

        private void anglechange()
        {
            switch (angleposition)
            {
                // right
                case 1:
                    ballList[0].Xangle = 0.8944;
                    ballList[0].Yangle = -0.4472;
                    break;
                case 2:
                    ballList[0].Xangle = 0.7071;
                    ballList[0].Yangle = -0.7071;
                    break;
                case 3:
                    ballList[0].Xangle = 0.4472;
                    ballList[0].Yangle = -0.8944;
                    break;
                case 4:
                    ballList[0].Xangle = -0.4472;
                    ballList[0].Yangle = -0.8944;
                    break;
                case 5:
                    ballList[0].Xangle = -0.7071;
                    ballList[0].Yangle = -0.7071;
                    break;
                case 6:
                    ballList[0].Xangle = -0.8944;
                    ballList[0].Yangle = -0.4472;
                    break;
                    // left
            }
            Refresh();
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        //Nit: Can you make the ball fall a little farther before resetting the ball, something doesn't feel right when it falls
        //Nit: Can you make the ball go in whatever the player last moved
        //Note Form1 has a soundplayer, you can access it with Form1.SoundPlayer
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //   angleLable.Text = angleposition.ToString();
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            if (start)
            {
                foreach (Ball b in ballList)
                {
                    anglechange();

                    // Move ball
                    b.Move();


                    // Check for collision with top and side walls
                    b.WallCollision(this);

                    // Check for ball hitting bottom of screen and if there is only one ball
                    Rectangle curball = new Rectangle(Convert.ToInt32(b.x), Convert.ToInt32(b.y), b.size, b.size);

                    if((b.BottomCollision(this, paddle) && ballList.Count == 1)|| (curball.IntersectsWith(new Rectangle(0, paddle.y + 9, this.Width, 10))))
                    {
                        // decrease player 1 lives
                        player1Lives--;

                        // move the ball and paddle back
                        start = false;

                        // reset ball angle
                        angleposition = 3;
                        anglechange();

                        // reset paddle x and y
                        //paddle.x = paddleX;
                        //paddle.y = paddleY;

                        ballList[0].x = ((paddle.x - ballSize) + (paddle.width / 2));
                        ballList[0].y = paddle.y - 40;
                        ballList[0].Yangle *= -1;

                        // reset x and y speeds
                        ballList[0].xSpeed = 6;
                        ballList[0].ySpeed = 6;

                        if (player1Lives < 1)
                        {
                            start = false;
                            if (player2Lives < 0)
                            {
                                gameTimer.Enabled = false;
                                scores();
                            }
                            gameTimer.Enabled = false;
                            scores();
                        }
                    }
                    else if (b.BottomCollision(this, paddle))
                    {
                        //Remove ball that hit bottom from list
                        ballList.Remove(b);
                        break;
                    }

                    // Check for collision of ball with paddle, (incl. paddle movement)
                    b.PaddleCollision(paddle, leftArrowDown, rightArrowDown);

                    if (currentlevel.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }
                }
                // remove any balls that need to be removed
                foreach (Ball b in removeBalls)
                {
                    ballList.Remove(b);
                }
            }

            //Testing Purposes: Score Tracker...1st Tracker...Adding the number to scores
            foreach (Block b in currentlevel)
            {
                if (ballList[0].ScoreTracker(b))
                {
                    score++;
                }
            }

            // Check if ball has collided with any currentlevel
            //foreach (Ball ba in ballList)
            for(int i = 0; i < ballList.Count(); i++)
            {
                ballList[i].Move();
                foreach (Block b in currentlevel)
                {
                    Rectangle curball = new Rectangle(Convert.ToInt32(ballList[i].x), Convert.ToInt32(ballList[i].y), ballList[i].size, ballList[i].size);

                    if (ballList[i].side_collision(b.leftSide) || ballList[i].side_collision(b.rightSide))
                    {
                        ballList[i].xSpeed *= -1;
                    }
                    

                    if (ballList[i].BlockCollision(b))
                    {
                        b.hp--;
                        if (b.hp < 1)
                            currentlevel.Remove(b);

                        score += 100;
                        
                        //Powerup Chance 
                        Random randPower = new Random();
                        randomPowerupChance = randPower.Next(1, 21);

                        if (randomPowerupChance == 1)
                        {
                            Powerups p = new Powerups(b.x, b.y, 5, "3");
                            powerup.Add(p);
                            activated = false;
                        }
                        if (randomPowerupChance == 2)
                        {
                            Powerups p = new Powerups(b.x, b.y, 5, "L");
                            powerup.Add(p);
                            activated = false;
                        }
                        if (randomPowerupChance == 3)
                        {
                            Powerups p = new Powerups(b.x, b.y, 5, "l");
                            powerup.Add(p);
                            activated = false;
                        }
                        if (randomPowerupChance == 4)
                        {
                            Powerups p = new Powerups(b.x, b.y, 5, "BS");
                            powerup.Add(p);
                            activated = false;
                        }
                        if (randomPowerupChance == 5)
                        {
                            Powerups p = new Powerups(b.x, b.y, 5, "bs");
                            powerup.Add(p);
                            activated = false;
                        }
                        
                        if (currentlevel.Count < 1)
                        {
                            if (currentlevelnum == levelList.Count())
                            {
                                OnEnd();
                            }
                        }
                        break;
                    }
                }

                if (!start)
                {
                    //center the ball over the paddle
                    ballList[0].x = paddle.x + (paddle.width / 2) - (ballList[0].size / 2);
                    ballList[0].y = paddle.y - 21;

                    //clear the powerups from the screen
                    powerup.Clear();

                    p1 = new Point(Convert.ToInt16(ballList[0].x + (ballList[0].size / 2)), Convert.ToInt16(ballList[0].y));

                    switch (angleposition)
                    {
                        // right
                        case 1:
                            p2 = new Point(Convert.ToInt16(ballList[0].x) + 89, Convert.ToInt16(ballList[0].y) - 44);
                            break;
                        case 2:
                            p2 = new Point(Convert.ToInt16(ballList[0].x) + 70, Convert.ToInt16(ballList[0].y) - 70);
                            break;
                        case 3:
                            p2 = new Point(Convert.ToInt16(ballList[0].x) + 44, Convert.ToInt16(ballList[0].y) - 89);
                            break;
                        case 4:
                            p2 = new Point(Convert.ToInt16(ballList[0].x) - 44, Convert.ToInt16(ballList[0].y) - 89);
                            break;
                        case 5:
                            p2 = new Point(Convert.ToInt16(ballList[0].x) - 70, Convert.ToInt16(ballList[0].y) - 70);
                            break;
                        case 6:
                            p2 = new Point(Convert.ToInt16(ballList[0].x) - 89, Convert.ToInt16(ballList[0].y) - 44);
                            break;
                        // left
                        default:
                            break;
                    }
                }
                else
                {
                    if (currentlevel.Count == 0)
                    {
                        if (currentlevelnum == 9)
                        {
                            //OnEnd();
                            //testing
                            WinScreen ws = new WinScreen();
                            Form form = this.FindForm();

                            form.Controls.Add(ws);
                            form.Controls.Remove(this);

                            ws.Location = new Point((form.Width - ws.Width) / 2, (form.Height - ws.Height) / 2);
                        }
                        else
                        {
                            currentlevelnum++;
                            player1Lives++;
                            levelLoad();
                            start = false;
                            ballList[0].x = paddle.x + (paddle.width / 2) - (ballList[0].size / 2);
                            ballList[0].y = paddle.y - 21;
                        }

                    }
                }

                //Move powerups down
                foreach (Powerups p in powerup)
                {
                    p.powerupMove();
                }

                //Check for collision of powerups
                foreach (Powerups p in powerup)
                {
                    if (p.PowerupCollision() == true && activated == false)
                    {
                        if (p.type == "3")
                        {
                            Random randGen = new Random();
                            int x, y;

                            x = randGen.Next(1, 301);
                            y = randGen.Next(1, 301);

                            //activate powerup
                            ballList.Add(new Ball(x, y, xSpeed, ySpeed, ballSize, 1, -1));
                            ballList.Add(new Ball(y, x, xSpeed, ySpeed, ballSize, 1, -1));

                            break;
                        }
                        else if (p.type == "L")
                        {
                            paddle.width += 25;
                        }
                        else if (p.type == "l")
                        {
                            if(paddle.width > 25)
                            {
                                paddle.width -= 25;
                            }
                            else
                            {
                                paddle.width /= 2;
                            }

                        }
                        else if (p.type == "BS")
                        {
                            foreach (Ball b in ballList)
                            {
                                b.ySpeed -= 2;
                                // If the ball gets way too slow at anglepositions of 1 & 6, the ball can get stuck at the top
                            }
                        }
                        else if (p.type == "bs")
                        {
                            foreach (Ball b in ballList)
                            {
                                b.ySpeed += 2;
                            }
                        }

                        activated = true;
                        powerup.Remove(p);
                        break;
                    }
                }
                //redraw the screen
                Refresh();
            }
        }


        //testing 
        public void scores()
        {
            string scoreNumber = score.ToString();
            HighScore s = new HighScore(scoreNumber);
            Form1.highScores.Add(s);
            OnEnd();
        }

        //testing
        public void saveScoresRK()
        {
            XmlWriter writer = XmlWriter.Create("Resources/HighScores.xml", null);

            writer.WriteStartElement("TheScores");

            foreach (HighScore s in Form1.highScores)
            {
                writer.WriteStartElement("TheScore");

                writer.WriteElementString("Score", s.score);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();
            //redraw the screen
        }    

        private void GameScreen_Load(object sender, EventArgs e)
        {
            OnStart();
        }

        //testing
        public void GameOver()
        {
            Form1 form = FindForm() as Form1;
            form.ChangeScreen(this, new GameOverScreen());
        }

        public void OnEnd()
        {
            
            //Testing: Saving the scores
            saveScoresRK();
            // Goes to the game over screen
            //Form1 form = FindForm() as Form1;
            //form.ChangeScreen(this, new MenuScreen());

            GameOverScreen gos = new GameOverScreen();
            Form form = this.FindForm();

            form.Controls.Add(gos);
            form.Controls.Remove(this);

            gos.Location = new Point((form.Width - gos.Width) / 2, (form.Height - gos.Height) / 2);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws currentlevel
            foreach (Block b in currentlevel)
            {
                blockBrush = new SolidBrush(b.colour());
                e.Graphics.FillRectangle(blockBrush, Convert.ToInt32(b.x), Convert.ToInt32(b.y), b.width, b.height);
            }

            // Draws ball
            foreach (Ball b in ballList)
            {
                e.Graphics.FillEllipse(ballBrush, Convert.ToInt32(b.x), Convert.ToInt32(b.y), b.size, b.size);
            }

            //Draws Powerups
            foreach (Powerups p in powerup)
            {
                if (p.type == "3")
                {
                    e.Graphics.FillRectangle(powerups3Brush, p.x, p.y, p.width, p.height);
                }
                else if (p.type == "L")
                {
                    e.Graphics.FillRectangle(powerupsLBrush, p.x, p.y, p.width, p.height);
                }
                else if (p.type == "l")
                {
                    e.Graphics.FillRectangle(powerupslBrush, p.x, p.y, p.width, p.height);
                }
                else if (p.type == "BS")
                {
                    e.Graphics.FillRectangle(powerupsBSBrush, p.x, p.y, p.width, p.height);
                }
                else if (p.type == "bs")
                {
                    e.Graphics.FillRectangle(powerupsbsBrush, p.x, p.y, p.width, p.height);
                }
            }

            // Draw lives and font
            e.Graphics.DrawString("Lives: " + player1Lives.ToString(), textFont, sb, new Point(25, this.Height - 25));
            e.Graphics.DrawString(score.ToString(), textFont, sb, new Point(25, 75));

            // draw line aim
            if (!start)
            {
                // draw line to show ball aim
                e.Graphics.DrawLine(linePen, p1, p2);
            }

            // Draw lives and score
            e.Graphics.DrawString("angle position: " + angleposition.ToString(), textFont, sb, new Point(25, this.Height - 100));
            e.Graphics.DrawString("block number: " + currentlevel.Count().ToString(), textFont, sb, new Point(this.Width - 300, this.Height - 100));

            switch (player1Lives)
            {
                case 4:
                    life5Output.Visible = false;
                    break;
                case 3:
                    life4Output.Visible = false;
                    break;
                case 2:
                    life3Output.Visible = false;
                    break;
                case 1:
                    life2Output.Visible = false;
                    break;
                case 0:
                    life1Output.Visible = false;
                    break;
                default:
                    break;
            }
        }

        [Obsolete("Please rename this method to what it is supposed to do", true)]
        public void NickMethod()
        {
            //set all button presses to false.
            leftArrowDown = rightArrowDown = ADown = DDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2)) - ((this.Width / 2) / 2);
            int newPaddleX = ((this.Width / 2) - (paddleWidth / 2)) + ((this.Width / 2) / 2);
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 40;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.Firebrick);
            //newPaddle = new Paddle(newPaddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.RoyalBlue);

            // setup starting ball values
            int ballX = (this.Width / 2 - 10) - ((this.Width / 2) / 2);
            int ballY = this.Height - paddle.height - 80;

            /// BallList[0] is P1
            /// BallList[1] is P2
            ballList.Clear();
            ballList.Add(new Ball(ballX, ballY, 6, 6, 20, 1, 1));
            ballList.Add(new Ball(ballX, this.Height - ballY, 6, 6, 20, 1, 1));
            // Creates a new ball

            // start the game engine loop
            gameTimer.Enabled = true;
        }
    }
}