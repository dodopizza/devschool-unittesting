namespace Domain.Tests
{
    public class Create
    {
        public static PlayerBuilder Player => new PlayerBuilder();
        public static RollDiceGameBuilder Game => new RollDiceGameBuilder();
        public static DiceBuilder Dice => new DiceBuilder();
        public static  ChipBuilder Chip => new ChipBuilder();
    }
}