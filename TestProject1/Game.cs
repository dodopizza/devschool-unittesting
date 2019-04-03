using System;
using Domain;
using Moq;

namespace TestProject1
{
    public static class Game
    {
        public static RollDiceGame WithLuckyScore(int score)
        {
            var scoreSource = new Mock<IScoreSource>();
            scoreSource.Setup(source => source.GetScore()).Returns(score);
            return new RollDiceGame(scoreSource.Object);
        }

        public static RollDiceGame WithRandomLuckyScore()
        {
            return new RollDiceGame(new RandomScoreSource());
        }

        public static RollDiceGame JoinPlayer(this RollDiceGame game, IPlayer player = null)
        {
            game.AddPlayer(player ?? new Domain.Player());
            return game;
        }
    }
}