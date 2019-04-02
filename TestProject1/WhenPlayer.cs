using System;
using Domain;
using Xunit;

namespace TestProject1
{
    public class WhenPlayer
    {
        private Player player = new Player();

        public WhenPlayer()
        {
            player.Join(new RollDiceGame());
        }

        [Fact]
        public void StartsGame_ItIsInGame()
        {
            Assert.True(player.IsInGame);
        }

        [Fact]
        public void IsInGame_ItCanNotStartsGameAgain()
        {
            Assert.Throws<InvalidOperationException>(
                () => player.Join(new RollDiceGame())
            );
        }

        [Fact]
        public void EndsGame_ItIsNoMoreInGame()
        {
            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void Buys10Chips_ItHasMoreThan5Chips()
        {
            player.Buy(new Chip(10));

            Assert.True(player.Has(new Chip(5)));
        }

        [Fact]
        public void MakeBet_ItHasCurrentBet()
        {
            var bet = new Bet(new Chip(5), 13);
            player.Bet(bet);

            Assert.Equal(bet, player.CurrentBet);
        }

        [Fact]
        public void MakeBetAndLoose_ItHasNoCurrentBet()
        {
            var bet = new Bet(new Chip(5), 13);
            player.Bet(bet);
            player.Lose();

            Assert.Null(player.CurrentBet);
        }
    }
}