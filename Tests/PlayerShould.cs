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
    //Я, как игрок, могу купить фишки у казино, чтобы делать ставки
    //Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть
    //Я, как игрок, не могу поставить фишек больше, чем я купил



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

        [Fact]
        public void BeAbleBuyChipsFromCasino()
        {
            var player = new Player();
            var casino = new Casino();

            casino.SellChips(player, 10);

            Assert.Equal(10, player.AvailableChips);
        }
    }

    internal class Casino
    {
        public int Chips { get; set; }

        public void SellChips(Player player, int value)
        {
            player.AvailableChips += value;
            this.Chips -= value;
        }

        public Casino()
        {
            
        }
    }
}
