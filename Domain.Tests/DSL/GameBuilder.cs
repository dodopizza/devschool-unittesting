using System.Collections.Generic;

namespace Domain.Tests.DSL
{
    public class GameBuilder
    {
        private List<Player> _players = new List<Player>();
        
        public Game Please()
        {
            var game = new Game();
            _players.ForEach(p => p.Join(game));
            return game;
        }

        public GameBuilder With(Player player)
        {
            _players.Add(player);
            return this;
        }
    }
}