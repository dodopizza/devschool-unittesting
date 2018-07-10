namespace Domain
{
    public class Chip
    {
        public int Amount { get; }

        public Chip(int amount)
        {
            Amount = amount;
        }

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