namespace Tests
{
    public static class Create
    {
        public static GameBuilder Game()
        {
            return new GameBuilder();
        }

        public static BetBuilder Bet()
        {
            return new BetBuilder();
        }
    }
}