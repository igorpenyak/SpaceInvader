using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Bullet : GameObject, IRenderable, IUpdateble
    {
        public bool Direction; // направление полета пули. тру - вверх, а фолс соотв вниз
        // public bool _shot;
        public int h;


        public Bullet(int x, int y, bool direction)
            : base("Bullet", x, y)
        {
            Direction = direction;
        }

        public virtual void Update()
        {

            //if (LazerGun.first_shot || meta_key==0)
            //{

            //    this.Move();
            //   // this.Render(this.Name, this.PosX, this.PosY);
            //  //  

            //}
            //this.Move();
            

        }
        public void InsertBull(List<Bullet> blist)
        {
            blist.Add(this);
        }

        public void RemoveBull(List<Bullet> blist,int end)
        {
            if (this.Direction)
            {
                if (this.PosY < 1)
                {
                    blist.RemoveAt(blist.IndexOf(this));
                }
            }
            else 
            {
                if (this.PosY > end-1)
                {
                    blist.RemoveAt(blist.IndexOf(this));
                }
            }
   
 
        }

        public static void bulletBehavior(List <Bullet> blist, int end)  // insert and remove bull from list
        {
            for (var i = 0; i < blist.Count; i++)
                {
                 blist[i].RemoveBull(blist, end);
                }
                                                                                                                 
            for (var i=0;i<blist.Count;i++)
                {
                  blist[i].Move();                                    
                }                    
        }

        public void Move()
        {

            if (this.Direction)
            {

                this.PosY--;  // LazerGun shot
                this.h++;

            }
            else
            {

                this.PosY++; // Invader shot
                this.h++;

            }
        }

        public virtual void Render(string name, int x, int y)
        {

            //    if (this.PosY > 5)
            //    {
            //        Console.SetCursorPosition(this.PosX - 1, this.PosY);
            //        Console.Write("^");
            //        Console.SetCursorPosition(this.PosX - 1, this.PosY + 1);
            //        Console.Write("");
            //    }
            //    else
            //    { LazerGun.first_shot = false; }
            //}

        }
    }
}