using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Logic.EventArguments
{
   public class ScoreEventArgs: EventArgs
        {
            public Score ScoreNumber { get; set; }

            public ScoreEventArgs(Score score)
            {
                ScoreNumber = score;
            }
        }

}
