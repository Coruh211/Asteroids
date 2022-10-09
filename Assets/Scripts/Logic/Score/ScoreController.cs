using UnityEngine;

namespace Logic
{
    public class ScoreController: IScoreController
    {
        private int currentScore;
        private PrefsValue<int> Score = new PrefsValue<int>("Score", 0);
        
        public void AddScore(int count)
        {
            currentScore += count;
            
            if(Score.Value < currentScore)
                Score.Value = currentScore;
        }
        
        public int GetTopScore() => 
            Score.Value;
        public int GetScore() => 
            currentScore;
        
    }
}