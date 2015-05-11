using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Invader : GameObject
    {
        #region Field and Properties

        private const double _multiply = 0.5;
        private const int _evenDivider = 52;
        private const int _shotConditionOne = 7;
        private const int _shotConditionTwo = 10;
        private const int _shotConditionTree = 5;
        private const int _shotConditionFour = 2;
        private const int _shotDividerOne = 7;
        private const int _shotDividerTwo = 2;
        private const int _shotDividerTree = 4;
        private const int _shotDividerFour = 9;
     


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
             if ( ((time * _multiply) % _evenDivider) == 0)
             {
                 return true;
             }
             return false;
         }
     
        private bool EnemyCanShot()
         {
             if ( (K % _shotDividerOne==0) && (_recall%_shotConditionOne==0) )
             {
                 return true;
             }
             else if ( (K % _shotDividerTwo == 0) && (_recall % _shotConditionTwo == 0) )
             {
                 return true;
             }
             else if ( (K % _shotDividerTree == 0) && (_recall % _shotConditionFour == 0) )
             {
                 return true;
             }
             else if ( (K % _shotDividerFour == 0) && (_recall % _shotConditionFour == 0) )
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
