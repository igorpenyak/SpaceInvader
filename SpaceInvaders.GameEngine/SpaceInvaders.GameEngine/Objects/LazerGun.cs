
namespace SpaceInvaders.GameEngine.Objects
{
    public class LazerGun : GameObject
    {
        
        #region Constructor
       
        public LazerGun(int x, int y)
            : base("Gun", x, y)
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

        public static string GetName()
        {
            return "Gun";
        }             

        public override void Update(int meta_key, int endField)
        {
            if (this.Live)
            {
                if (meta_key == 1 && this.PosX < endField - 4)
                {
                    this.MoveRight();
                }
                else if (meta_key == -1 && this.PosX > 2)
                {
                    this.MoveLeft();
                }
            }
        }                 
        
        public override void isDie()
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
