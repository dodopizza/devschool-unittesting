using System;

namespace Domain
{
    public class RandomScoreSource : IScoreSource
    {
        private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

        public int GetScore()
        {
            var rollCount = _random.Next(1, 6);

            var lastRoll = 0;
            for (var i = 0; i < rollCount; i++)
            {
                lastRoll = _random.Next(1, 6);
            }

            return lastRoll;
        }
    }
}