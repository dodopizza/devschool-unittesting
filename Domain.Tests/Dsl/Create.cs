namespace Domain.Tests.Dsl
{
    public static class Create
    {
        public static RollDiceGame Game()
        {
            return new RollDiceGame(new Dice.Dice());
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

        public static Bet Bet()
        {
            return new Bet(new Chip(1), 1);
        }

        public static Player WithBet(this Player player)
        {
            player.Bet(Bet());

            return player;
        }

        public static Player WithChips(this Player player)
        {
            player.Buy(Chip());

            return player;
        }
    }
}