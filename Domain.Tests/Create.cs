namespace Domain.Tests
{
    public class Create
    {
        public static PlayerBuilder Player => new PlayerBuilder();

        public static GameBuilder Game => new GameBuilder();
    }

    public class PlayerBuilder
    {
        public Player Please => new Player();
    }

    public class GameBuilder
    {
        public Game Please => new Game();
    }
}