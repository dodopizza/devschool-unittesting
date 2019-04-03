namespace Domain.Tests
{
    public class ChipBuilder
    {
        public ChipBuilder WithAmount(int amount)
        {
            Amount = amount;
            return this;
        }

        private int Amount { get; set; }

        public Chip Please()
        {
            return new Chip(Amount);
        }
    }
}