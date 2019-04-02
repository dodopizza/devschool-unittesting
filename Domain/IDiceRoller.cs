using System;

namespace Domain
{
    public interface IDiceRoller
    {
        int Roll();
    }

    public class DiceRoller : IDiceRoller
    {
        public int Roll()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, 6);
        }
    }
}