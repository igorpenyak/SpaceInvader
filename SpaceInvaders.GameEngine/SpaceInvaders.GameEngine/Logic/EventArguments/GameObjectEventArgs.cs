using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Logic.EventArguments
{
    public class GameObjectEventArgs : EventArgs
        {
            public GameObject Gameobj { get; set; }

            public GameObjectEventArgs(GameObject gameobj)
            {
                Gameobj = gameobj;
            }
        }
}
