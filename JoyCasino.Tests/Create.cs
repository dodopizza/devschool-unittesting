using JoyCasino.Tests.Dsl;

namespace JoyCasino.Tests
{
    public static class Create
    {
        public static GameBuilder Game => new GameBuilder();
        public static PlayerBuilder Player => new PlayerBuilder();
    }
}