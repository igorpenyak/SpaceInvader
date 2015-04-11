using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Objects
{
    public abstract class GameObject 
    {
        protected bool _live = true;
        public int meta_key {get; set;}

       // List<Bullet> b_list = new List<Bullet>();

        

        // public int speed;  // скорость объектов
        public int PosX { get; set; } // кординаты положения объектов
        public int PosY { get; set; }
        public string Name { get; protected set; }

        



        public GameObject(string name, int x, int y)
        {
            PosX = x;
            PosY = y;
            Name = name;
        }



      
        public virtual bool isDie()
        {
            return true;
        }

        public virtual void Render(string name, int x, int y)
        {

        }

        public virtual void Update(int meta_key)
        {

        }

     


    }
}
