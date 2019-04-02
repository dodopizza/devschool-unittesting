using System;

namespace Domain.Randomizer
{
    public interface IRandomizer
    {
        int GetScore(int from, int to);
    }

    public class Randomizer : IRandomizer
    {
        private readonly Func<int, int, int> _func;

        public Randomizer(Func<int, int, int> func)
        {
            _func = func;
        }

        public int GetScore(int from, int to)
        {
            return _func(from, to);
        }
    }
}