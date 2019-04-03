using Domain;

namespace TestProject1
{
    public class Bet
    {
        public static Domain.Bet New(int chip, int score)
        {
            return new Domain.Bet(new Chip(chip), score);
        }
    }
}