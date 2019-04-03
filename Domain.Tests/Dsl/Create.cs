using Domain.Dice;
using Moq;

namespace Domain.Tests.Dsl
{
    public static class Create
    {
        public static RollDiceGame Game(IDice mockDiceObject = default)
        {
            return new RollDiceGame(mockDiceObject ?? new Dice.Dice());
        }

        public static RollDiceGame GameWithStaticDice(int score)
        {
            var mockDice = new Mock<IDice>();
            mockDice.Setup(x => x.GetScore()).Returns(score);

            var game = new RollDiceGame(mockDice.Object);

            return game;
        }

        public static RollDiceGame WithPlayer(this RollDiceGame game, Player player)
        {
            game.AddPlayer(player);

            return game;
        }

        public static Player Player()
        {
            return new Player();
        }

        public static Player InGame(this Player player)
        {
            var game = new RollDiceGame(new Dice.Dice());

            player.Join(game);

            return player;
        }

        public static Chip Chip(int amount = 1)
        {
            return new Chip(amount);
        }

        public static Bet Bet(int chipAmount = default, int score = default)
        {
            return new Bet(Chip(chipAmount), score);
        }

        public static Player WithBet(this Player player, int chipAmount, int score)
        {
            player.Bet(Bet(chipAmount, score));

            return player;
        }

        public static Player WithChips(this Player player)
        {
            player.Buy(Chip());

            return player;
        }
    }
}