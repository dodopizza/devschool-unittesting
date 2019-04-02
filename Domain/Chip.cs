namespace Domain
{
    public class Chip
    {
        public Chip(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }

        public static bool operator >=(Chip a, Chip b)
        {
            return a.Amount >= b.Amount;
        }

        public static bool operator <=(Chip a, Chip b)
        {
            return a.Amount <= b.Amount;
        }
    }
}