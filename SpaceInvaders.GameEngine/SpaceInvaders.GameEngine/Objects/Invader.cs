using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Invader : GameObject
    {
        #region Field and Properties
        private int _recall=1; // count how many times we update obj        
        public int K { get; set; }
        public int EndOfField { get; set; } // use for bullet behavior
        public int Speed { get; set; }

        List<Bullet> _enemyBullet = new List<Bullet>();

        public int CanShot 
        { 
            get { return _enemyBullet.Count; }
        }
        public Bullet EnemyBullet 
        {
            get { return _enemyBullet[0]; }             
        }

        #endregion


        #region Constructor
        public Invader(int x, int y, int endOfField, int randomShot)
            : base(x, y)
        {
            this.EndOfField = endOfField;
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
     
        private bool EnemyCanShot()
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

                if (this.Shot(time) && this.EnemyCanShot() && _enemyBullet.Count == 0)
                {
                    b.InsertBull(_enemyBullet);
                    Bullet.BulletBehavior(_enemyBullet, EndOfField);                            
                }
            
                if (_enemyBullet.Count != 0)
                {
                    Bullet.BulletBehavior(_enemyBullet, EndOfField);
                }

                if (_recall%Speed==0)
                {
                    this.Move();
                }
            }

        public bool IsFirstShot()
        {
            if (_enemyBullet.Count != 0)
            {
                return true;
            }
            return false;
        }

        public Bullet GetEnemyBullet()
        {
            return _enemyBullet[0];
        }

        #endregion


    }
}
