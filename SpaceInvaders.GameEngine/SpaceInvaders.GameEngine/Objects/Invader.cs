using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Invader : GameObject
    {
        #region Field and Properties
        private int _recall=1; // count how many times we update obj        
        public int K { get; set; }
        public int bulletEnd { get; set; } // use for bullet behavior
        public int Speed { get; set; }

        List<Bullet> enem_bullet = new List<Bullet>();

        public int CanShot 
        { 
            get { return enem_bullet.Count; }
        }
        public Bullet EnemyBullet 
        {
            get { return enem_bullet[0]; }             
        }

        #endregion


        #region Constructor
        public Invader(int x, int y, int bulletEnd,int randomShot)
            : base("Invader", x, y)
        {
            this.bulletEnd = bulletEnd;
            this.K = randomShot;
            Live = true;
            Speed = 1;
        }

        #endregion


        #region Methods
        public void Move()
        {
            this.PosY++;
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
       
        public void Update(int time)
        {
            _recall++;
            Bullet b = new Bullet(this.PosX,this.PosY,false);

                if (this.Shot(time) && this.canShot() && enem_bullet.Count == 0)
                {
                    b.InsertBull(enem_bullet);
                    Bullet.bulletBehavior(enem_bullet, bulletEnd);                            
                }
            
                if (enem_bullet.Count != 0)
                {
                    Bullet.bulletBehavior(enem_bullet, bulletEnd);
                }

                if (_recall%Speed==0)
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

        public Bullet GetBullet()
        {
            return enem_bullet[0];
        }

        #endregion


    }
}
