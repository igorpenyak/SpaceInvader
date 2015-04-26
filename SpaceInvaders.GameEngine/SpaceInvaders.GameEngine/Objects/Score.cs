
namespace SpaceInvaders.GameEngine.Objects
{
    public class Score 
    {
        private int _score;
        public int score 
        {
            get { return this._score; }            
        }       

        public Score() 
        {            
            _score = 0;
        }

        public void AddScore(int x)
        {
            _score += x;
        }
               
    }
}
