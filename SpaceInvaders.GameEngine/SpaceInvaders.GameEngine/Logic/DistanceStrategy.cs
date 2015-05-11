using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Logic
{
   public class DistanceStrategy:IDistanceStrategy
   {
       #region Method
       public double GetDistance(Objects.GameObject obj1, Objects.GameObject obj2)
        {
            if ( (obj1.PosX - 1 <= obj2.PosX) && (obj1.PosX + 3 >= obj2.PosX) )
            {
                return obj2.PosY - obj1.PosY;
            }
            return 1.0;
        }

       #endregion
   }
}
