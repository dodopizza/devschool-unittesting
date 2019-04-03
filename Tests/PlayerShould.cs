using System;
using System.Runtime.InteropServices;
using Domain;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class PlayerShould
    {
        [Fact]
        public void JoinGame()
        {
            var player = new Player();
            var game = new Game();

            player.JoinGame(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void LeaveGame()
        {
            var player = new Player();
            var game = new Game();
            player.JoinGame(game);

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void CantLeaveGameIfNotJoined()
        {
            var player = new Player();

            Assert.Throws<Exception>(() => player.LeaveGame());
        }

        [Fact]
        public void JoinOnlyOneGame()
        {
            var player = new Player();
            var game1 = new Game();
            var game2 = new Game();

            player.JoinGame(game1);

            Assert.Throws<Exception>(() => player.JoinGame(game2));
        }

        [Fact]
        public void CanBuyChips()
        {
            var player = new Player();

            player.BuyChips(1);

            Assert.Equal(1, player.Chips);
        }

        [Fact]
        public void CanBet()
        {
            var player = new Player();
            player.BuyChips(1);

            player.Bet(1, 2);

            Assert.Equal(1, player.Bets[0].Chips);
            Assert.Equal(2, player.Bets[0].Score);
        }

        [Fact]
        public void CanBetMoreChipsThenHave()
        {
            var player = new Player();
            player.BuyChips(1);

            Assert.Throws<Exception>(
                () => player.Bet(2, 2)
            );
        }

        [Fact]
        public void CanBetManyTimes()
        {
            var player = new Player();
            player.BuyChips(6);

            player.Bet(2,3);
            player.Bet(4,5);

            Assert.Equal(2,player.Bets.Length);
        }


    }
}