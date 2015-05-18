using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Invader : GameObject
    {
        #region Field and Properties

        private const double THE_MULTIPLY = 0.5;
        private const int THE_EVENDIVIDER = 52;
        private const int THE_SHOTCONDITIONONE = 7;
        private const int THE_SHOTCONDITIONTWO = 10;
        private const int THE_SHOTCONDITIONTHREE = 5;
        private const int THE_SHOTCONDITIONFOUR = 2;
        private const int THE_SHOTDIVIDERONE = 7;
        private const int THE_SHOTDIVIDERTWO = 2;
        private const int THE_SHOTDIVIDERTHREE = 4;
        private const int THE_SHOTDIVIDERFOUR = 9;

        private int _index;
     


        private byte _recall=1; // count how many times we update obj        
        public int K { get; set; }
        public int EndOfField { get; set; } // use for bullet behavior
        public int Speed { get; set; }

        private List<Bullet> _enemyBullet = new List<Bullet>();

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
        public Invader(int x, int y, int endOfField, int randomShot, int i)
            : base(x, y)
        {
            this.EndOfField = endOfField;
            this.K = randomShot;
            Live = true;
            Speed = 1;
            _index = i;
        }

        #endregion


        #region Methods
        public void Move()
        {
            this.PosY+=1*_index;
        }

        public bool Shot(int time)
         {
             if ( ((time * THE_MULTIPLY) % THE_EVENDIVIDER) == 0)
             {
                 return true;
             }
             return false;
         }
     
        private bool EnemyCanShot()
         {
             if ( (K % THE_SHOTDIVIDERONE==0) && (_recall%THE_SHOTCONDITIONONE==0) )
             {
                 return true;
             }
             else if ( (K % THE_SHOTDIVIDERTWO == 0) && (_recall % THE_SHOTCONDITIONTWO != 0) )
             {
                 return true;
             }
             else if ( (K % THE_SHOTDIVIDERTHREE == 0) && (_recall % THE_SHOTCONDITIONFOUR == 0) )
             {
                 return true;
             }
             else if ( (K % THE_SHOTDIVIDERFOUR == 0) && (_recall % THE_SHOTCONDITIONFOUR != 0) )
             {
                 return true;
             }  
             return false;
        }
       
        public void Update(int time)
        {
            _recall++;
            Bullet b = new Bullet(this.PosX,this.PosY,false, _index-5);

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
