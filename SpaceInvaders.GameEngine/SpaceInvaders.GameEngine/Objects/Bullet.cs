using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Bullet : GameObject, IRenderable
    {
        public bool Direction; // направление полета пули. тру - вверх, а фолс соотв вниз
        // public bool _shot;
        


        public Bullet(int x, int y, bool direction)
            : base("Bullet", x, y)
        {
            Direction = direction;
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
            }
            else
            {
                this.PosY++; // Invader shot                
            }
        }

        public virtual void Render(string name, int x, int y)
        {
            Test = 2;
        }
    }
}