using System;
using Xunit;

namespace Domain.Tests
{
    public class PlayerTests
    {
        //Я, как игрок, могу выйти из игры
        //Я, как игрок, не могу выйти из игры, если я в нее не входил
        //Я, как игрок, могу играть только в одну игру одновременно
        //Я, как игра, не позволяю войти более чем 6 игрокам

        [Fact]
        //Я, как игрок, могу войти в игру
        public void PlayerCanJoinGame()
        {
            var testedPlayer = new Player();
            var customGame = new RollDiceGame();

            testedPlayer.Join(customGame);

            Assert.True(testedPlayer.IsInGame);
        }

        [Fact]
        //Я, как игрок, могу выйти из игры
        public void PlayerCanLeaveGame()
        {
            var testedPlayer = new Player();
            var customGame = new RollDiceGame();

            testedPlayer.Join(customGame);
            testedPlayer.LeaveGame();

            Assert.False(testedPlayer.IsInGame);
        }
    }
}
