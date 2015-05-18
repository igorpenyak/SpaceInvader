using System;
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
    public partial class GameMenu : UserControl
    {           

        public event EventHandler GameStartRequested;
        public GameMenu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            OnGameStartRequested();
        }

        private void OnGameStartRequested()
        {
            if (GameStartRequested != null)
            {
                this.GameStartRequested(this, EventArgs.Empty);
            }
        }

    }
}
