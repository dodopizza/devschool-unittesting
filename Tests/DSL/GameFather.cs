using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Tests.DSL
{
    public class GameFather
    {
        private IEnumerable<Player> players;

        public GameFather With(IEnumerable<Player> players)
        {
            this.players = players;
            return this;
        }

        public static implicit operator RollDiceGame(GameFather father)
        {
            var game = new RollDiceGame();
            father.players.ToList().ForEach(_ => _.Join(game));
            return game;
        }
    }
}