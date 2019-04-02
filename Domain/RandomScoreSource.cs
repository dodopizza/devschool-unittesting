using System;

namespace Domain
{
    public class RandomScoreSource : IScoreSource
    {
        private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

        public int GetScore()
        {
            return _random.Next(1, 6);
        }
    }
}