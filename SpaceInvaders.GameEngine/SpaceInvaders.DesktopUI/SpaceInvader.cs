using SpaceInvaders.DesktopUI.Controls;
using SpaceInvaders.GameEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders.DesktopUI
{
    public partial class SpaceInvader : Form
    {

        public SpaceInvader()
        {
            
          //  ucPlay.Hide();
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            
        }

        private void ucGameMenu_GameStartRequested(object sender, EventArgs e)
        {
            this.ucGameMenu.Hide();
            var ucPlay = new Playground(this);
            this.Controls.Add(ucPlay);
           // this.ucPlay.Show();
           // this.ucPlayground.Run();          
            ucPlay.Run();
        
        }


        public void ucInvaderWin_GameEndInvader(object sender, EventArgs e)
        {
            this.ucPlay.Hide();
            var ucInvaderWin = new InvaderWin();
            this.Controls.Add(ucInvaderWin); 
        //   this.ucInvaderWin.Show();
                             
        }

           
        //private void SpaceInvader_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Right)
        //    {
        //        ucPlayground.UserKey = ChooseKey.Right;
        //        MessageBox.Show("Left key!!!");
        //    }
        //    else if (e.KeyData == Keys.Left)
        //    {
        //        ucPlayground.UserKey = ChooseKey.Left;
        //        MessageBox.Show("Right key!!!");
        //    }
        //    else if (e.KeyData == Keys.Space)
        //    {
        //        ucPlayground.UserKey = ChooseKey.Shot;
        //    }
        //    else if (e.KeyData == Keys.Escape)
        //    {
        //        ucPlayground.UserKey = ChooseKey.Pause;
        //    }
        //    else if (e.KeyData == Keys.Enter)
        //    {
        //        ucPlayground.UserKey = ChooseKey.Restore;

        //    }
        //    else
        //    {
        //        ucPlayground.UserKey = ChooseKey.Wait;
        //        // MessageBox.Show("Wait key!!!");
        //        base.OnKeyDown(e);
        //    }

        //}
    }
}
