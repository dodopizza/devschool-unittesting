using System;
using Domain;
using Xunit;

namespace TestProject1
{
    public class WhenPlayer
    {
        [Fact]
        public void StartsGame_ItIsInGame()
        {
            var player = new Player();

            player.Join(new RollDiceGame());

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void IsInGame_ItCanNotStartsGameAgain()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            Assert.Throws<InvalidOperationException>(
                () => player.Join(new RollDiceGame())
            );
        }

        [Fact]
        public void EndsGame_ItIsNoMoreInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void Buys10Chips_ItHasMoreThen5Chips()
        {
            var player = new Player();

            player.Buy(new Chip(10));

            Assert.True(player.Has(new Chip(5)));
        }

        [Fact]
        public void MakeBet_ItHasCurrentBet()
        {
            var player = new Player();

            var bet = new Bet(new Chip(5), 13);
            player.Bet(bet);

            Assert.Equal(bet, player.CurrentBet);
        }

        [Fact]
        public void MakeBetAndLoose_ItHasNoCurrentBet()
        {
            var player = new Player();

            var bet = new Bet(new Chip(5), 13);
            player.Bet(bet);
            player.Lose();
            
            Assert.Null(player.CurrentBet);
        }
    }
}