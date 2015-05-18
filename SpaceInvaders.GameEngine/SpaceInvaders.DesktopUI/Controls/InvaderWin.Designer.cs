namespace SpaceInvaders.DesktopUI.Controls
{
    partial class InvaderWin
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
            this.lblPlayerScore.ForeColor = System.Drawing.Color.Red;
            this.lblPlayerScore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlayerScore.Location = new System.Drawing.Point(352, 213);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(21, 23);
            this.lblPlayerScore.TabIndex = 7;
            this.lblPlayerScore.Text = "0";
            this.lblPlayerScore.Visible = false;
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
            this.btnRestart.Location = new System.Drawing.Point(139, 303);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(175, 39);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "RESTART";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
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
            this.lblInvaderWin.Location = new System.Drawing.Point(71, 213);
            this.lblInvaderWin.Name = "lblInvaderWin";
            this.lblInvaderWin.Size = new System.Drawing.Size(275, 23);
            this.lblInvaderWin.TabIndex = 5;
            this.lblInvaderWin.Text = "Thanks for playing. Your score: ";
            this.lblInvaderWin.Visible = false;
            // 
            // InvaderWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblInvaderWin);
            this.Name = "InvaderWin";
            this.Size = new System.Drawing.Size(460, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblInvaderWin;
    }
}
