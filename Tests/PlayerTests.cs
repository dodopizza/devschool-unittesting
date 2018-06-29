using System;
using Domain;
using NUnit.Framework;
using Tests.DSL;

namespace Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Join_IsInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void ByDefault_NotInGame()
        {
            var player = new Player();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void Leave_DefaultPlayer_ThrowsInvalidOperationException()
        {
            var player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.LeaveGame());
        }

        [Test]
        public void Leave_AfterJoin_IsNotInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void Leave_TwoTimesAfterJoin_ThrowsInvalidOperationException()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            player.LeaveGame();

            Assert.Catch<InvalidOperationException>(() => player.LeaveGame());
        }

        [Test]
        public void JoinAnotherGame_AlreadyInGame_ThrowsInvalidOperationException()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            Assert.Catch<InvalidOperationException>(() =>
                    player.Join(new RollDiceGame()));
        }

        [Test]
        public void JoinTheSameGame_AlreadyInGame_ThrowsInvalidOperationException()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Catch<InvalidOperationException>(() =>
                    player.Join(game));
        }

        [Test]
        public void CanJoinGame_AfterLeavingPreviousGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);
            player.LeaveGame();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void TwoPlayersCanJoinAGame()
        {
            var game = new RollDiceGame();
            new Player().Join(game);
            var player = new Player();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void SixPlayersCanJoinAGame()
        {
            var game = Create.Game.With(5.Players());
            var player6 = new Player();

            player6.Join(game);

            Assert.True(player6.IsInGame);
        }

        [Test]
        public void SeventhPlayerCanNotJoinAGame()
        {
            RollDiceGame game = Create.Game.With(6.Players());
            var player7 = new Player();

            Assert.Catch<TooManyPlayersException>(() => player7.Join(game));
        }

        [Test]
        public void PlayerWith1Chip_CanMake1ChipBet()
        {
            var player = new Player();
            player.Buy(1.Chips());

            player.Bet(new Bet(1.Chips(), 3.Score()));
            
            Assert.False(player.Has(1.Chips()));
        }

        [SetUp]
        public void SetUp()
        {
            Create = new Father();
        }

        public Father Create;
    }
}