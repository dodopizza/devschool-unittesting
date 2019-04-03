using System;
using Xunit;

namespace JoyCasino.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenJoinsGame_ThenInGame()
        {
            var player = new Player();
            var game = new Game();

            player.JoinGame(game);
            
            Assert.True(player.IsInGame);
        }
    }

    public class Game
    {
    }

    public class Player
    {
        public bool IsInGame { get; set; }

        public void JoinGame(Game game)
        {
            IsInGame = true;
        }
    }
}