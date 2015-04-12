using SpaceInvaders.GameEngine.Objects;
using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine
{
    public class Game : GameObject, IRenderable
    {
        public Game(int x, int y)
            : base("Field", x, y)
        {}
         
    }
}
