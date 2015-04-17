﻿using System;
using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public abstract class GameObject
    {

        #region Field and Properties


        protected bool _live = true;
      //  public int meta_key {get; set;}       
        public int PosX { get; set; } // position of objects
        public int PosY { get; set; }
        public string Name { get; protected set; }
        public bool Live { get; set; }

        public int FakeTest { get; set; }

        protected int _numberOfLive=3;
        public int NumberOfLives
        {
            get
            {
                return _numberOfLive;
            }
        }

        
        #endregion
        
        #region Constructor
        public GameObject(string name, int x, int y)
        {
            PosX = x;
            PosY = y;
            Name = name;
            this.Live =true;
        }
        #endregion
              
        #region Virtual Methods
        public virtual void isDie()
        {
            if (_numberOfLive != 0)
            { 
                this.Live = true;
            }
        }
        
        public virtual void Update(int meta_key, int x)
        {
            FakeTest = x;
        }        
               
        #endregion
        
    }
}
