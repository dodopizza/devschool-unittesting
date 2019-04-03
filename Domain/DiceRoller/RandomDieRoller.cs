using System;

namespace Domain
{
    public class RandomDieRoller : IDieRoller
    {
        public int RollDice()
        {
            var times = new Random(DateTime.Now.Millisecond).Next(1, 6);
            int result = 0;
            for (int i = 0; i < times; i++)
            {
                result = new Random(DateTime.Now.Millisecond).Next(1, 6);
            }
            return result;
        }
    }
}