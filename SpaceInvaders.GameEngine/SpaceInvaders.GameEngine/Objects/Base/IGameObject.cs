using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects.Base
{
    interface IGameObject
    {
        int PosX { get; }
        int PosY { get; }
    }
}
