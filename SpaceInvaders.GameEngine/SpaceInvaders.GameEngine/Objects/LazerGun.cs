using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    public class LazerGun : GameObject, IRenderable, IUpdateble, ISettings
    {
        
        public static bool first_shot;

        
    


        #region Constructor
       
        public LazerGun(int x, int y)
            : base("Gun", x, y)
        {
            Live = true;
        }
        #endregion
              


        public void MoveRight()
        {
            this.PosX++;
        }
        public void MoveLeft()
        {
            this.PosX--;
        }
                  
        public void Shot()
        {}        
        public static string GetName()
        {
            return "Gun";
        }
        public virtual void Render(string name, int x, int y)
        {}
               

        public override void Update(int meta_key)
        {
            if (this.Live)
            {
                if (meta_key == 1)
                {
                    this.MoveRight();
                }
                else if (meta_key == -1)
                {
                    this.MoveLeft();
                }
                //else if (meta_key == 5)
                //{
                //    // Shot();
                //}
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

        public virtual void Show(string name, int number)
        { }


    }
}
