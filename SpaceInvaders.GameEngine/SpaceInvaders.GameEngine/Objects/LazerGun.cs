
namespace SpaceInvaders.GameEngine.Objects
{
    public class LazerGun : GameObject
    {
        private int _numberOfLive = 3;
        private int _index;

        
        public int NumberOfLives
        {
            get
            {
                return _numberOfLive;
            }
        }
        #region Constructor
       
        public LazerGun(int x, int y, int i)
            : base(x, y)
        {
            Live = true;
            _index = i;
        }
        #endregion

        #region Methods
        public void MoveRight()
        {
            this.PosX+=1*_index;
        }
        public void MoveLeft()
        {
            this.PosX-=1*_index;
        }

        public void Update(ChooseKey Key, int endField)
        {
            if (this.Live)
            {
                if (Key == ChooseKey.Right && this.PosX < endField - 4)
                {
                    this.MoveRight();
                }
                else if (Key == ChooseKey.Left && this.PosX > 2)
                {
                    this.MoveLeft();
                }
            }
        }                 
        
        public void isDie()
        {            
            if (this.Live)
            {
                _numberOfLive--;                
            }
            if(_numberOfLive < 1)
            {
                this.Live = false;              
            }

        }

        #endregion

    }
}
