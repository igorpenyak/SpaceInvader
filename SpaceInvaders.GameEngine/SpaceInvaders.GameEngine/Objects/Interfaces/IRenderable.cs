using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects.Interfaces
{
   public interface IRenderable
    {
        void Render(string name, int x, int y);     
    }
}
