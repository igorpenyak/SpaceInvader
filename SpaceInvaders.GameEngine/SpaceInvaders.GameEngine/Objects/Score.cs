
namespace SpaceInvaders.GameEngine.Objects
{
    public class Score 
    {
        private int _score;
        private string _name;
        public int score 
        {
            get { return this._score; }            
        }
        public string name
        {
             get { return this._name; } 
        }

        public Score() 
        {
            _name = "Score";
            _score = 0;
        }

        public void AddScore(int x)
        {
            _score += x;
        }
               
    }
}
