using System;

namespace Domain
{
    public class RandomDiceRoller : IDiceRoller
    {
        public int Roll()
        {
            return new Random().Next(1, 6);
        }
    }
}