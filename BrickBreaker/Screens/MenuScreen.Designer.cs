namespace BrickBreaker
{
    partial class MenuScreen
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.highscoreLabel = new System.Windows.Forms.Label();
            this.brickWallPic = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this._playButton = new System.Windows.Forms.Button();
            this._highScoreButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.brickWallPic)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.titleLabel.Location = new System.Drawing.Point(304, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(496, 91);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "MAIN MENU";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.highscoreLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highscoreLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.highscoreLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.highscoreLabel.Location = new System.Drawing.Point(1308, 97);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(1196, 1331);
            this.highscoreLabel.TabIndex = 2;
            this.highscoreLabel.Text = "High Score For Testing Purposes";
            this.highscoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.highscoreLabel.Visible = false;
            // 
            // brickWallPic
            // 
            this.brickWallPic.Location = new System.Drawing.Point(16, 0);
            this.brickWallPic.Name = "brickWallPic";
            this.brickWallPic.Size = new System.Drawing.Size(23, 637);
            this.brickWallPic.TabIndex = 4;
            this.brickWallPic.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.scoreLabel.Location = new System.Drawing.Point(844, 104);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(211, 389);
            this.scoreLabel.TabIndex = 5;
            this.scoreLabel.Visible = false;
            // 
            // _playButton
            // 
            this._playButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._playButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._playButton.Location = new System.Drawing.Point(477, 169);
            this._playButton.Name = "_playButton";
            this._playButton.Size = new System.Drawing.Size(127, 54);
            this._playButton.TabIndex = 6;
            this._playButton.Text = "Play";
            this._playButton.UseVisualStyleBackColor = true;
            this._playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // _highScoreButton
            // 
            this._highScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._highScoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._highScoreButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._highScoreButton.Location = new System.Drawing.Point(477, 293);
            this._highScoreButton.Name = "_highScoreButton";
            this._highScoreButton.Size = new System.Drawing.Size(127, 54);
            this._highScoreButton.TabIndex = 7;
            this._highScoreButton.Text = "Highscores";
            this._highScoreButton.UseVisualStyleBackColor = true;
            this._highScoreButton.Click += new System.EventHandler(this._highScoreButton_Click);
            // 
            // _exitButton
            // 
            this._exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._exitButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._exitButton.Location = new System.Drawing.Point(477, 429);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(127, 54);
            this._exitButton.TabIndex = 8;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._highScoreButton);
            this.Controls.Add(this._playButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.brickWallPic);
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1067, 640);
            this.Load += new System.EventHandler(this.MenuScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brickWallPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label highscoreLabel;
        private System.Windows.Forms.Timer menuTimer;
        private System.Windows.Forms.PictureBox brickWallPic;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button _playButton;
        private System.Windows.Forms.Button _highScoreButton;
        private System.Windows.Forms.Button _exitButton;
    }
}
