namespace BrickBreaker
{
    partial class StartScreen
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
            this.anyButtonPB = new System.Windows.Forms.PictureBox();
            this.startScreenPB = new System.Windows.Forms.PictureBox();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.anyButtonPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScreenPB)).BeginInit();
            this.SuspendLayout();
            // 
            // anyButtonPB
            // 
            this.anyButtonPB.Location = new System.Drawing.Point(258, 548);
            this.anyButtonPB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.anyButtonPB.Name = "anyButtonPB";
            this.anyButtonPB.Size = new System.Drawing.Size(533, 56);
            this.anyButtonPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.anyButtonPB.TabIndex = 1;
            this.anyButtonPB.TabStop = false;
            // 
            // startScreenPB
            // 
            this.startScreenPB.Location = new System.Drawing.Point(-3, -2);
            this.startScreenPB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startScreenPB.Name = "startScreenPB";
            this.startScreenPB.Size = new System.Drawing.Size(1067, 640);
            this.startScreenPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.startScreenPB.TabIndex = 0;
            this.startScreenPB.TabStop = false;
            // 
            // startTimer
            // 
            this.startTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.anyButtonPB);
            this.Controls.Add(this.startScreenPB);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StartScreen";
            this.Size = new System.Drawing.Size(1067, 640);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.anyButtonPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScreenPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox startScreenPB;
        private System.Windows.Forms.PictureBox anyButtonPB;
        private System.Windows.Forms.Timer startTimer;
    }
}
