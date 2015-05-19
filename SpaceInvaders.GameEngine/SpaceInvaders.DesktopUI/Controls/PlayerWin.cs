﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders.DesktopUI.Controls
{
    public partial class PlayerWin : UserControl
    {
        #region Methods
        public PlayerWin(int i, Form f)
        {
            InitializeComponent();
            lblPlayerScore.Text = i.ToString();
            _parentForm = f;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this._parentForm.Controls.Clear();
            Playground ucGame = new Playground(_parentForm);
            this._parentForm.Controls.Add(ucGame);
            ucGame.Focus();
            ucGame.Run();
        }

        #endregion
    }
}
