using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    public class LazerGun : GameObject, IRenderable, IUpdateble
    {
        private int numberOfLive;
        // public static int pre_x;
        // public static int pre_y;
        public static bool first_shot;
        public LazerGun(int x, int y)
            : base("Gun", x, y)
        {

        }


        public void MoveRight()
        {
            this.PosX++;
        }

        public void MoveLeft()
        {
            this.PosX--;
        }

        //public static void Shot(Bullet b)
        //{                                      

        //    b.Move();
        //   // pre_x = b.PosX;
        //    //pre_y = b.PosY;
        //}

     
        public void Shot()
        {
            //Bullet bullet = new Bullet(PosX + 1, PosY, true);
            //b_list.Add(bullet);
            //if (first_shot)
            //{
            //    bullet.Move();
            //};
            first_shot = true;
            
            //bullet.Render(bullet.Name, bullet.PosX, bullet.PosY);
            

        }

        public virtual void Render(string name, int x, int y)
        {
     
           // Console.Write("Called a virtual method");
        }

        public override void Update(int meta_key)
        {                              
            if (meta_key == 1)
            {
                this.MoveRight();
               
            }
            else if (meta_key == -1)
            {
                this.MoveLeft();
               
            }
            else if (meta_key == 5)
            {
                 Shot();
            }           
        }

        public static string GetName()
        {
            return "Gun";
        }
        public override bool isDie()
        {
            if (numberOfLive > 0)
            {
                numberOfLive--;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
