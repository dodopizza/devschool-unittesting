using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerPlay
    {
        [Fact]
        public void AndTheyWinThenChipsUpdated()
        {
            var game = RollDiceGameBuilder.GetGame().WithLuckyScore(2).Build();
            var player = PlayerBuilder.GetPlayer().JoinRollDiceGame(game).WithBet(1, 2).Build();

            game.Play();

            Assert.True(player.Has(new Chip(2)));
        }

        [Fact]
        public void AndTheyLoseThenChipsUpdated()
        {
            var game = RollDiceGameBuilder.GetGame().WithLuckyScore(2).Build();
            var player = PlayerBuilder.GetPlayer().JoinRollDiceGame(game).WithBet(1, 1).Build();

            game.Play();

            Assert.True(player.Has(new Chip(0)));
        }
        
        [Fact]
        public void AndTheyWinThenPlayerAckAboutWin()
        {
            var game = RollDiceGameBuilder.GetGame().WithLuckyScore(1).Build();
            var player1 = new PlayerFake(1);
            var player2 = new PlayerFake(1);
            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Play();

            Assert.Equal(1,player1.WinCount);
            Assert.Equal(0, player1.LoseCount);
            
            Assert.Equal(1,player2.WinCount);
            Assert.Equal(0, player2.LoseCount);
        }
        
        [Fact]
        public void AndTheyLoseThenPlayerAckAboutLose()
        {
            var game = RollDiceGameBuilder.GetGame().WithLuckyScore(1).Build();
            var player1 = new PlayerFake(2);
            var player2 = new PlayerFake(2);
            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Play();

            Assert.Equal(0,player1.WinCount);
            Assert.Equal(1, player1.LoseCount);
            
            Assert.Equal(0,player2.WinCount);
            Assert.Equal(1, player2.LoseCount);
        }
        
        [Fact]
        public void ThenPlayersAckAboutWinAndLose()
        {
            var game = RollDiceGameBuilder.GetGame().WithLuckyScore(1).Build();
            var player1 = new PlayerFake(1);
            var player2 = new PlayerFake(2);
            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Play();

            Assert.Equal(1,player1.WinCount);
            Assert.Equal(0, player1.LoseCount);
            
            Assert.Equal(0,player2.WinCount);
            Assert.Equal(1, player2.LoseCount);
        }
    }
}