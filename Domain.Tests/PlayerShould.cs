using Moq;
using System;
using Xunit;

namespace Domain.Tests
{
    public class PlayerShould
    {
        [Fact]
        //Я, как игрок, могу войти в игру
        public void JoinGameIfNotJoined()
        {
            var dice = new Dice();
            var testedPlayer = new Player();
            var customGame = new RollDiceGame(dice);

            testedPlayer.Join(customGame);

            Assert.True(testedPlayer.IsInGame);
        }

        [Fact]
        //Я, как игрок, могу выйти из игры
        public void LeaveGameIfJoinedBefore()
        {
            var dice = new Dice();
            var testedPlayer = new Player();
            var customGame = new RollDiceGame(dice);

            testedPlayer.Join(customGame);
            testedPlayer.LeaveGame();

            Assert.False(testedPlayer.IsInGame);
        }

        [Fact]
        //Я, как игрок, не могу выйти из игры, если я в нее не входил
        public void NotLeaveGameIfNotJoined()
        {
            var testedPlayer = new Player();

            Action leaveAct = () => testedPlayer.LeaveGame();

            Assert.Throws<InvalidOperationException>(leaveAct);
        }

        [Fact]
        //Я, как игрок, могу играть только в одну игру одновременно
        public void PlayOnlyOneGame()
        {
            var dice = new Dice();
            var testedPlayer = new Player();
            var firstGame = new RollDiceGame(dice);
            var secondGame = new RollDiceGame(dice);

            testedPlayer.Join(firstGame);
            Action joinAct = () => testedPlayer.Join(secondGame);

            Assert.Throws<InvalidOperationException>(joinAct);
        }

        [Fact]
        public void HaveSixBetsAfterWin()
        {
            var diceStub = new Mock<IDice>();
            var game = new RollDiceGame(diceStub.Object);
            var player = new Player();

            diceStub.Setup(d => d.GetLuckyScore()).Returns(5);

            player.Join(game);
            player.Bet(new Bet(new Chip(10), 5));

            game.Play();

            Assert.Equal(60, player.AvailableChips.Amount);
        }
    }
}
