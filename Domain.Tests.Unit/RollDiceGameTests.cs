using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class RollDiceGameTests
    {
        [Test]
        public void GameIsPlayed_WhenPlayerBetsOnLuckyScore_ThenPlayerWins()
        {
            var player = new FakePlayer
            {
                CurrentBet = 15.Chips().BetOn(5)
            };
            var roller = new FakeDiceRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(player);

            game.Play();

            Assert.AreEqual(1, player.WinWasCalled);
        }

        [Test]
        public void GameIsPlayed_WhenPlayerBetsOnUnluckyScore_ThenPlayerLoses()
        {
            var player = new FakePlayer
            {
                CurrentBet = 15.Chips().BetOn(4)
            };
            var roller = new FakeDiceRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(player);
            
            game.Play();

            Assert.AreEqual(1, player.LoseWasCalled);
        }
    }
}