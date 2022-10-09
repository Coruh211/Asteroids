using Infrastructure.Services;

namespace Logic
{
    public interface IScoreController: IService
    {
        public int GetScore();
        public int GetTopScore();
        public void AddScore(int count);
    }
}