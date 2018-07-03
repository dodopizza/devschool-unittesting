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
            var testedPlayer = new Player();
            var customGame = new RollDiceGame();

            testedPlayer.Join(customGame);

            Assert.True(testedPlayer.IsInGame);
        }

        [Fact]
        //Я, как игрок, могу выйти из игры
        public void LeaveGameIfJoinedBefore()
        {
            var testedPlayer = new Player();
            var customGame = new RollDiceGame();

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
            var testedPlayer = new Player();
            var firstGame = new RollDiceGame();
            var secondGame = new RollDiceGame();

            testedPlayer.Join(firstGame);
            Action joinAct = () => testedPlayer.Join(secondGame);

            Assert.Throws<InvalidOperationException>(joinAct);
        }
    }
}