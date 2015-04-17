
namespace SpaceInvaders.GameEngine.Objects
{
    public class Score 
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
               
    }
}
