using System.Windows.Forms;
namespace SpaceInvaders.DesktopUI.Controls
{
    partial class Playground
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
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNumderScore = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.lblNumderLives = new System.Windows.Forms.Label();
            this.lblNumberOfLevel = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblScore.Location = new System.Drawing.Point(318, 16);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(72, 21);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "SCORE";
            // 
            // lblNumderScore
            // 
            this.lblNumderScore.AutoSize = true;
            this.lblNumderScore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumderScore.ForeColor = System.Drawing.Color.Red;
            this.lblNumderScore.Location = new System.Drawing.Point(396, 18);
            this.lblNumderScore.Name = "lblNumderScore";
            this.lblNumderScore.Size = new System.Drawing.Size(17, 19);
            this.lblNumderScore.TabIndex = 1;
            this.lblNumderScore.Text = "0";
            // 
            // lblLives
            // 
            this.lblLives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLives.AutoSize = true;
            this.lblLives.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblLives.Location = new System.Drawing.Point(44, 16);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(62, 21);
            this.lblLives.TabIndex = 2;
            this.lblLives.Text = "LIVES";
            // 
            // lblNumderLives
            // 
            this.lblNumderLives.AutoSize = true;
            this.lblNumderLives.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumderLives.ForeColor = System.Drawing.Color.Red;
            this.lblNumderLives.Location = new System.Drawing.Point(112, 16);
            this.lblNumderLives.Name = "lblNumderLives";
            this.lblNumderLives.Size = new System.Drawing.Size(17, 19);
            this.lblNumderLives.TabIndex = 3;
            this.lblNumderLives.Text = "3";
            // 
            // lblNumberOfLevel
            // 
            this.lblNumberOfLevel.AutoSize = true;
            this.lblNumberOfLevel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberOfLevel.ForeColor = System.Drawing.Color.Red;
            this.lblNumberOfLevel.Location = new System.Drawing.Point(252, 18);
            this.lblNumberOfLevel.Name = "lblNumberOfLevel";
            this.lblNumberOfLevel.Size = new System.Drawing.Size(17, 19);
            this.lblNumberOfLevel.TabIndex = 5;
            this.lblNumberOfLevel.Text = "0";
            // 
            // lblLevel
            // 
            this.lblLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblLevel.Location = new System.Drawing.Point(174, 16);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(67, 21);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "LEVEL";
            // 
            // Playground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.lblNumberOfLevel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblNumderLives);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.lblNumderScore);
            this.Controls.Add(this.lblScore);
            this.DoubleBuffered = true;
            this.Name = "Playground";
            this.Size = new System.Drawing.Size(470, 600);
            this.Load += new System.EventHandler(this.Playground_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Playground_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Form _parentForm;
        private Label lblScore;
        private Label lblNumderScore;
        private Label lblLives;
        private Label lblNumderLives;
        private Label lblNumberOfLevel;
        private Label lblLevel;


    }
}

