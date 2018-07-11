using System;
using System.Dynamic;
using Domain;
using Tests.DSL;
using Xunit;

namespace Tests
{
    public class PlayerTests
    {
        private readonly Father Create = new Father();
        
        [Fact]
        public void Join_IsInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void ByDefault_NotInGame()
        {
            var player = new Player();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void Leave_DefaultPlayer_ThrowsInvalidOperationException()
        {
            var player = new Player();

            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }

        [Fact]
        public void Leave_AfterJoin_IsNotInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void Leave_TwoTimesAfterJoin_ThrowsInvalidOperationException()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            player.LeaveGame();

            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }

        [Fact]
        public void JoinAnotherGame_AlreadyInGame_ThrowsInvalidOperationException()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            Assert.Throws<InvalidOperationException>(() =>
                    player.Join(new RollDiceGame()));
        }

        [Fact]
        public void JoinTheSameGame_AlreadyInGame_ThrowsInvalidOperationException()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() =>
                    player.Join(game));
        }

        [Fact]
        public void CanJoinGame_AfterLeavingPreviousGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);
            player.LeaveGame();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void TwoPlayersCanJoinAGame()
        {
            var game = new RollDiceGame();
            new Player().Join(game);
            var player = new Player();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void SixPlayersCanJoinAGame()
        {
            var game = Create.Game.With(5.Players());
            var player6 = new Player();

            player6.Join(game);

            Assert.True(player6.IsInGame);
        }

        [Fact]
        public void SeventhPlayerCanNotJoinAGame()
        {
            RollDiceGame game = Create.Game.With(6.Players());
            var player7 = new Player();

            Assert.Throws<TooManyPlayersException>(() => player7.Join(game));
        }

        [Fact]
        public void PlayerWith1Chip_CanMake1ChipBet()
        {
            var player = new Player();
            player.Buy(1.Chips());

            player.Bet(new Bet(1.Chips(), 3.Score()));
            
            Assert.False(player.Has(1.Chips()));
        }
    }
}