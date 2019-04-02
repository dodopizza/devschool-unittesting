namespace Domain.Tests
{
    public class FakeDiceRoller: IDiceRoller
    {
        public FakeDiceRoller(int diceToReturn)
        {
            DiceToReturn = diceToReturn;
        }

        public int DiceToReturn { get; set; }
        public int RollDice() => DiceToReturn;
    }
}