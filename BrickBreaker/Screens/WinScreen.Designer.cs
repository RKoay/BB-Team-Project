﻿namespace BrickBreaker
{
    partial class WinScreen
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
            this.winnerLabel = new System.Windows.Forms.Label();
            this.winnerTimer = new System.Windows.Forms.Timer(this.components);
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // winnerLabel
            // 
            this.winnerLabel.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.winnerLabel.Location = new System.Drawing.Point(696, 291);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(1563, 306);
            this.winnerLabel.TabIndex = 0;
            // 
            // winnerTimer
            // 
            this.winnerTimer.Enabled = true;
            this.winnerTimer.Interval = 20;
            this.winnerTimer.Tick += new System.EventHandler(this.winnerTimer_Tick);
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.Silver;
            this.continueButton.Font = new System.Drawing.Font("Museo Sans For Dell", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(55, 1404);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(700, 102);
            this.continueButton.TabIndex = 2;
            this.continueButton.Text = "Click this to continue";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.winnerLabel);
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(2535, 1565);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WinScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.Timer winnerTimer;
        private System.Windows.Forms.Button continueButton;
    }
}
