namespace Domain.Tests.DSL
{
    public static class Create
    {
        public static PlayerBuilder Player()
        {
            return new PlayerBuilder();
        }

        public static GameBuilder Game()
        {
            return new GameBuilder();
        }
    }
}