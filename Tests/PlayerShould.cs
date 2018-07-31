using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
//    Упражнение 1. Создание нового домена с нуля Игрок и игра "Кости"
//Я, как игрок, могу войти в игру
//Я, как игрок, могу выйти из игры
//Я, как игрок, не могу выйти из игры, если я в нее не входил
//Я, как игрок, могу играть только в одну игру одновременно
//Я, как игра, не позволяю войти более чем 6 игрокам



    public class PlayerShould
    {
        [Fact]
        public void EnterTheGame()
        {
            var player = new Player();
            var game = new Game();

            player.EnterGame(game);


            Assert.True(game.HasPlayer(player));
        }
    }
}
