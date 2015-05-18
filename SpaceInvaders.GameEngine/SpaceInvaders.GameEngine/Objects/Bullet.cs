using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Bullet : GameObject
    {
        #region Field and Property
        private int _index;
        private readonly bool _direction; // if it`s true, bullet moves up
        public bool Direction
        {
            get 
            {
                return _direction;
            }
        }

        #endregion

        #region Constructor

        public Bullet(int x, int y, bool direction, int i)
            : base(x, y)
        {
            _direction = direction;
            _index = i;
        }

        #endregion

        #region Methods
        public void InsertBull(List<Bullet> blist)
        {
            blist.Add(this);
            this.Live = true;
        }

        public void RemoveBull(List<Bullet> blist,int end)
        {
            if (this._direction)
            {
                if (this.PosY < 5*_index)
                {
                    blist.RemoveAt(blist.IndexOf(this));
                    this.Live = false;
                }
            }
            else 
            {
                if (this.PosY > end-1*_index)
                {
                    blist.RemoveAt(blist.IndexOf(this));
                    this.Live = false;
                }
            } 
        }

        public static void BulletBehavior(List <Bullet> blist, int end)  // insert and remove bull from list
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
            if (this._direction)
            {
                this.PosY-=2*_index;  // LazerGun shot                
            }
            else
            {
                this.PosY+=2*_index; // Invader shot                
            }
        }

        #endregion
    }
}