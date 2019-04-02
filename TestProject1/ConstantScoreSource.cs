using Domain;

namespace TestProject1
{
    public class ConstantScoreSource : IScoreSource
    {
        private readonly int _score;

        public ConstantScoreSource(int score)
        {
            _score = score;
        }

        public int GetScore()
        {
            return _score;
        }
    }
}