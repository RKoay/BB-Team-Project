namespace BrickBreaker
{
    partial class GameOverScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.gameOverTimer = new System.Windows.Forms.Timer(this.components);
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gameOverLabel.Location = new System.Drawing.Point(543, 376);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(1616, 276);
            this.gameOverLabel.TabIndex = 0;
            // 
            // gameOverTimer
            // 
            this.gameOverTimer.Enabled = true;
            this.gameOverTimer.Interval = 20;
            this.gameOverTimer.Tick += new System.EventHandler(this.gameOverTimer_Tick);
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.Silver;
            this.continueButton.Font = new System.Drawing.Font("Museo Sans For Dell", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(80, 1408);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(700, 102);
            this.continueButton.TabIndex = 3;
            this.continueButton.Text = "Click this to continue";
            this.continueButton.UseVisualStyleBackColor = false;
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.gameOverLabel);
            this.DoubleBuffered = true;
            this.Name = "GameOverScreen";
            this.Size = new System.Drawing.Size(2535, 1565);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOver_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Timer gameOverTimer;
        private System.Windows.Forms.Button continueButton;
    }
}
