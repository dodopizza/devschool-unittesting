using Domain.Tests.DSL;
using NUnit.Framework;

namespace Domain.Tests
{
    public class GameResultTests
    {
        private const int UnluckyScore = 3;
        
        private const int LuckyScore = 5;
        
        [Test]
        public void PlayerShouldLose_WhenBetIsUnlucky()
        {
            var player = Create.Player().WithChips(10).Please();
            var game = Create.Game().With(player).WithLuckyScore(LuckyScore).Please();
            var bet = new Bet(10, UnluckyScore);
            player.Bet(bet);

            game.Play();
            
            Assert.AreEqual(0, player.Chips);
        }
        
        [Test]
        public void PlayersBetShouldIncrease6Times_WhenBetIsLucky()
        {
            var player = Create.Player().WithChips(10).Please();
            var game = Create.Game().With(player).WithLuckyScore(LuckyScore).Please();
            var bet = new Bet(10, LuckyScore);
            player.Bet(bet);

            game.Play();
            
            Assert.AreEqual(6 * 10, player.Chips);
        }
    }
}