using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Logic
{
    public interface IDistanceStrategy
    {
        double GetDistance(GameObject obj1, GameObject obj2); 
    }
}
