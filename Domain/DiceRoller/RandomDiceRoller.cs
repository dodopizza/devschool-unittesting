using System;

namespace Domain
{
    class RandomDiceRoller : IDiceRoller
    {
        public int RollDice()
        {
            var random = new Random(DateTime.Now.Millisecond).Next(1, 6);
            return random;
        }
    }
}