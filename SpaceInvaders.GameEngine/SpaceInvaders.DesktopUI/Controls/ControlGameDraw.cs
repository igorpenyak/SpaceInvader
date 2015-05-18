using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Objects;
using SpaceInvaders.GameEngine.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders.DesktopUI.Controls
{
   public class ControlGameDraw
    {
         #region Methods
       
      private  Image _gunImage = DesktopUI.Properties.Resources.gun;
      private Image _bulletImage = DesktopUI.Properties.Resources.bullet;
      private Image _enemyImage = DesktopUI.Properties.Resources.invader;
    
       private int _x;
       private int _y;
  
      private  Graphics _graphic;

      public bool RenderFlag{get; set;}
       public ControlGameDraw(Graphics g, int Width, int Height)
       {
          _graphic = g;
          _x = Width;
          _y = Height;
           
       }
       //public void Render( GameObject obj, PaintEventArgs e)
       //{

       //    if (obj is LazerGun)
       //    {
       //        this.RenderGun((LazerGun)obj, e);
       //    }
       //    else if (obj is Invader)
       //    {
       //        this.RenderInvader((Invader)obj, e);
       //    }
       //    else
       //    {
       //        this.RenderBullet((Bullet)obj, e);
       //        RenderFlag = true;

       //    }

       //}

        //   private static Rectangle EnemyDrawingRect(Invader obj)
        //{
        //    return new Rectangle(obj.PosX, obj.PosY, 20, 20);
        //}

        //private static Rectangle GunDrawingRect(LazerGun obj)
        //{
        //    return new Rectangle(obj.PosX,obj.PosY, 4, 1);
        //}

       private static Rectangle BulletDrawingRect(Bullet obj)
       {
           return new Rectangle(obj.PosX, obj.PosY, 5, 15);
       }



        public void RenderGun(LazerGun obj, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_gunImage, obj.PosX-15, obj.PosY-5, 30, 15);           
        }


        private  void RenderInvader(Invader obj, PaintEventArgs e)
        {                           
            // Draw image to screen.
            e.Graphics.DrawImage(DesktopUI.Properties.Resources.invader, obj.PosX-5, obj.PosY+15, 20, 15);
        }

   
        private  void RenderBullet(Bullet obj,  PaintEventArgs e)
        {

            e.Graphics.DrawImage(_bulletImage, BulletDrawingRect(obj));

        }

        public void Show(object sender, Score sc)
        {

        }
        //public void Clear(object sender, EventArgs e)
        //{
        //    _graphic.Clear(Color.Gray);
        //}

         #endregion

        public void RenderGamePlay(GameCommand game, PaintEventArgs e)
        {
            foreach (var b in game.GunBulletList)
            {
                this.RenderBullet(b, e);
            }
            this.RenderGun(game.LazerGun, e);
            foreach(var i in game.InvadersArray)
            {
                if (i.Live)
                {
                    this.RenderInvader(i, e);
                    if (i.CanShot!=0)
                    {
                        this.RenderBullet(i.EnemyBullet, e);
                    }
                }
            }
        }
       
    }
}
