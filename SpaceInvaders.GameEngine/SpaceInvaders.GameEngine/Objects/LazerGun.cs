
namespace SpaceInvaders.GameEngine.Objects
{
    public class LazerGun : GameObject
    {
        
        #region Constructor
       
        public LazerGun(int x, int y)
            : base(x, y)
        {
            Live = true;
        }
        #endregion

        #region Methods
        public void MoveRight()
        {
            this.PosX++;
        }
        public void MoveLeft()
        {
            this.PosX--;
        }

        public void Update(KeyPress Key, int endField)
        {
            if (this.Live)
            {
                if (Key == KeyPress.Right && this.PosX < endField - 4)
                {
                    this.MoveRight();
                }
                else if (Key == KeyPress.Left && this.PosX > 2)
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
