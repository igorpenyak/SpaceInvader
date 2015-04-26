using SpaceInvaders.GameEngine.Objects.Base;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public abstract class GameObject : IGameObject
    {

        #region Field and Properties

        private int _posx;   // position of objects
        private int _posy;
        protected bool _live = true;
        protected int _numberOfLive = 3;
           
        public int PosX 
        {
            get { return this._posx; }
            protected set { this._posx = value; }
        } 
        public int PosY 
        {
            get { return this._posy; }
            protected set { this._posy = value; }
        }
      
        public bool Live { get; set; }
                        
        public int NumberOfLives
        {
            get
            {
                return _numberOfLive;
            }
        }

        
        #endregion
        
        #region Constructor
        public GameObject(int x, int y)
        {
            PosX = x;
            PosY = y;            
            this.Live =true;
        }
        #endregion              
          
    }
}
