using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    abstract class Shield : GameObject, IRenderable, IUpdateble
    {
        public Shield(int x, int y)
            : base("Shield", x, y)
        {
        }

        //public override void Update() 
        //{
        //    if (this._live)
        //    {
        //        Draw(); // если наша стена цела, то мы ее рисуем
        //    }

        //  }            

    }
}
