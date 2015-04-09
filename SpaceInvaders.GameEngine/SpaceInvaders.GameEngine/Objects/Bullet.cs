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

        public virtual void Update(int meta_key)
        {

            //if (LazerGun.first_shot || meta_key==0)
            //{

            //    this.Move();
            //   // this.Render(this.Name, this.PosX, this.PosY);
            //  //  

            //}

        }
        public void InsertBull(List<Bullet> blist)
        {
            blist.Add(this);
        }

        public void RemoveBull(List<Bullet> blist)
        {
            blist.Remove(this);
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