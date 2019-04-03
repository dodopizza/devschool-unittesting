using System;
using Xunit;

namespace JoyCasino.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenJoinsGame_ThenInGame()
        {
            var game = Create.Game.Build();
            var player = Create.Player.Build();

            player.JoinGame(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void WhenLeaveGame_ThenNotInGame()
        {
            var game = Create.Game.Build();
            var player = Create.Player.InGame(game).Build();

            player.LeaveGame(game);

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void WhenBuysChips_ThenHasChips()
        {
            var player = Create.Player.Build();

            player.BuyChips(1);

            Assert.Equal(1, player.ChipsAmount);
        }

        [Fact]
        public void WhenBet_ThenBetIsRegistered()
        {
            var player = Create.Player.WithChips(10).InGame().Build();

            player.Bet(10, 1);

            Assert.Equal(10, player.GetBetForScore(1));
        }

        [Fact]
        public void WhenBetMoreThanBought_ThenFail()
        {
            var player = Create.Player.WithChips(10).Build();

            Assert.Throws<InvalidOperationException>(() => player.Bet(20, 1));
        }

        [Fact]
        public void WhenBetTwoTimes_ThenTwoBetsRegistered()
        {
            var player = Create.Player.InGame().WithChips(40).Build();
            
            player.Bet(10, 1);
            player.Bet(20, 2);
            
            Assert.Equal(10, player.GetBetForScore(1));
            Assert.Equal(20, player.GetBetForScore(2));
        }
    }
}