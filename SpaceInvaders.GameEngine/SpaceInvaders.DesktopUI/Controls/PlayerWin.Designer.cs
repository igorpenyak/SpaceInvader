using System.Windows.Forms;
namespace SpaceInvaders.DesktopUI.Controls
{
    partial class PlayerWin
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
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblInvaderWin = new System.Windows.Forms.Label();
            this.lblWinnerScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPlayerScore.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.lblPlayerScore.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPlayerScore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlayerScore.Location = new System.Drawing.Point(232, 213);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(21, 23);
            this.lblPlayerScore.TabIndex = 10;
            this.lblPlayerScore.Text = "0";
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRestart.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestart.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.btnRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRestart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRestart.Location = new System.Drawing.Point(131, 286);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(175, 39);
            this.btnRestart.TabIndex = 9;
            this.btnRestart.Text = "RESTART";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblInvaderWin
            // 
            this.lblInvaderWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvaderWin.AutoSize = true;
            this.lblInvaderWin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvaderWin.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.lblInvaderWin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblInvaderWin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInvaderWin.Location = new System.Drawing.Point(75, 157);
            this.lblInvaderWin.Name = "lblInvaderWin";
            this.lblInvaderWin.Size = new System.Drawing.Size(317, 23);
            this.lblInvaderWin.TabIndex = 8;
            this.lblInvaderWin.Text = "Congratulations! You are the winner!";
            // 
            // lblWinnerScore
            // 
            this.lblWinnerScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWinnerScore.AutoSize = true;
            this.lblWinnerScore.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblWinnerScore.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.lblWinnerScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblWinnerScore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWinnerScore.Location = new System.Drawing.Point(173, 213);
            this.lblWinnerScore.Name = "lblWinnerScore";
            this.lblWinnerScore.Size = new System.Drawing.Size(63, 23);
            this.lblWinnerScore.TabIndex = 11;
            this.lblWinnerScore.Text = "Score:";
            // 
            // PlayerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.lblWinnerScore);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblInvaderWin);
            this.Name = "PlayerWin";
            this.Size = new System.Drawing.Size(460, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Form _parentForm;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblInvaderWin;
        private System.Windows.Forms.Label lblWinnerScore;
    }
}
