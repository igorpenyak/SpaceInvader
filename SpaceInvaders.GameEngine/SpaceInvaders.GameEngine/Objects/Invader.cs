using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Invader : GameObject, IUpdateble, IRenderable
    {
      
        public int Katalizator; // use for time of shot
        private int _recall=1; // count how much we update obj

        public int K;
        public bool Live;
        public int Speed { get; set; }
        public void Move()
        {
            this.PosY++;
        
        }
        public Invader(int x, int y, int katalizator,int k)
            : base("Invader", x, y)
        {
            Katalizator = katalizator;
            K = k;
        }

       
         public bool Shot(int time)
         {
             if (time*0.5%52 == 0)
             {
                 return true;
             }

             return false;
         }
     
        private bool canShot()
         {
             if (K % 7==0 && _recall%7==0 )
             {
                 return true;
             }
             else if (K % 2 == 0 && _recall % 10 == 0)
             {
                 return true;
             }
             else if (K % 4 == 0 && _recall % 5 == 0)
             {
                 return true;
             }
             else if (K % 9 == 0 && _recall % 2 == 0)
             {
                 return true;
             }  

             return false;
        }

        List<Bullet> enem_bullet = new List<Bullet>();
        public override void Update(int time)
        {
            _recall++;
            Bullet b = new Bullet(this.PosX,this.PosY,false);
            if (this.Shot(time) && this.canShot() && enem_bullet.Count == 0)
            {
                b.InsertBull(enem_bullet);
                Bullet.bulletBehavior(enem_bullet,Katalizator);                            
            }
            
            if (enem_bullet.Count != 0)
            {
                Bullet.bulletBehavior(enem_bullet, Katalizator);
            }

            if (_recall%50==0)
            {
            this.Move();
            }
        }

        public bool firstShot()
        {
            if (enem_bullet.Count != 0)
            {
                return true;
            }
            return false;
        }
        public void GetBullet(out string name,out int x,out int y)
        {            
                name = enem_bullet[0].Name;
                x = enem_bullet[0].PosX;
                y = enem_bullet[0].PosY;                   
        }


    }
}
