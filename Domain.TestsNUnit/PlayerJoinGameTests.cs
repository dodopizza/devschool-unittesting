using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerJoinGameTests
    {
        private Player _player;
        private RollDiceGame _game;

        [SetUp]
        public void SetUp()
        {
            _player = new Player();
            _game = new RollDiceGame();
        }
        
        [Test]
        public void PlayerShouldNotJoinGame_IfAlreadyInGame()
        {
            _player.Join(_game);

            Assert.Throws<InvalidOperationException>(() => _player.Join(_game));
        }
        
        [Test]
        public void PlayerShouldJoinGame_IfNotInGame()
        {            
            _player.Join(_game);

            Assert.True(_player.IsInGame);
        }
        
        [Test]
        public void PlayerShouldNotLeaveGame_IfNotInGame()
        {   
            Assert.Throws<InvalidOperationException>(() => _player.LeaveGame());
        }
    }
}