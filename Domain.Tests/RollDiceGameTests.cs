using System;
using NUnit.Framework;

namespace Domain.Tests
{
    public class RollDiceGameTests
    {
        [Test]
        public void PlayerWins_WhenBetOnLuckyScore()
        {
            var game = new RollDiceGame(new Randomizer.Randomizer((from, to) => 5));
            var player = new Player();
            player.Join(game);
            player.Bet(new Bet(new Chip(1), 5));
            
            game.Play();
            
            Assert.True(player.Has(new Chip(6)));
        }
    }
}