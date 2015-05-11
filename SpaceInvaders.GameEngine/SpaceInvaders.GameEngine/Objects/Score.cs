
using System;
namespace SpaceInvaders.GameEngine.Objects
{
    public class Score
    {
        #region Field end Property
        private int _score;
        public int score 
        {
            get { return this._score; }            
        }

        #endregion

        #region Constructor
        public Score() 
        {            
            _score = 0;
        }

        #endregion

        #region Method

        public void AddScore(int x)
        {

        #region Validation

            if (x<0)
            {
                throw new InvalidOperationException("Score can`t be negative!");
            }

        #endregion
            
            _score += x;
        }

        #endregion
    }
}
