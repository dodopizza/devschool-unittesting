using Domain;

namespace TestProject1
{
    public static class Player
    {
        public static IPlayer InGame(this IPlayer player, RollDiceGame game = null)
        {
            var gameLocal = game ?? Game.WithRandomLuckyScore();
            player.Join(gameLocal);
            return player;
        }

        public static IPlayer New()
        {
            return new Domain.Player();
        }

        public static IPlayer WithChips(this IPlayer player, int chips)
        {
            player.Buy(new Chip(chips));
            return player;
        }

        public static IPlayer MakeBet(this IPlayer player, int chips, int score)
        {
            player.Bet(new Domain.Bet(new Chip(chips), score));
            return player;
        }


    }
}