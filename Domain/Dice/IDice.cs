using System;

namespace Domain.Dice
{
    public interface IDice
    {
        int GetScore();
    }

    public class Dice : IDice
    {
        public int GetScore()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, 6);
        }
    }
}