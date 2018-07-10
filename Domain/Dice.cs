using System;

namespace Domain
{
    public class Dice : IDice
    {
        public int lastValue;
        
        public int Roll()
        {
            lastValue = new Random(DateTime.Now.Millisecond).Next(1, 6);
            return lastValue;
        }
    }
}