using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Score : ISettings
    {
        public int score { get; set; }
        public string name { get; set; }
        public Score() 
        {
            name = "Score";
            score = 0;
        }

        public void AddScore(int x)
        {
            score += x;
        }

        public virtual void Show(string name, int number)
        {
            score = number;
        }
    }
}
