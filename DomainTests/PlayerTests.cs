using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Domain;
using Moq;
using Xunit;

namespace DomainTests
{
    public class PlayerTests
    {
        [Fact]
        [Description("Я, как игрок, могу войти в игру")]
        public void ShouldBeInGame_WhenJoinGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);
            
            Assert.Equal(true, player.IsInGame);
        }
        
        [Fact]
        [Description("Я, как игрок не могу войти в игру 2 раза")]
        public void ShouldThrowException_WhenJoinGameSecondTime()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => { player.Join(game); });
        }
        
        [Fact]
        [Description("Я, как игрок, могу играть только в одну игру одновременно")]
        public void ShouldThrowException_WhenJoinAnotherGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            var anotherGame = new RollDiceGame();
            
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => { player.Join(anotherGame); });
        }
        
        [Fact]
        [Description("Я, как игрок, не могу выйти из игры, если я в нее не входил")]
        public void ShouldThrowException_WhenLeaveGameIfNotInGame()
        {
            var player = new Player();
            
            Assert.Throws<InvalidOperationException>(() => { player.LeaveGame(); });
        }
        
        [Fact]
        [Description("Я, как игрок, могу выйти из игры")]
        public void ShouldLeaveGame_WhenInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);
            player.LeaveGame();
            
            Assert.Equal(false, player.IsInGame);
        }
        
        [Fact]
        [Description("Я, как игрок, могу купить фишки у казино, чтобы делать ставки")]
        public void ShouldHasChip_WhenBuy()
        {
            var player = new Player();
            var chip = new Chip(10);
            
            player.Buy(chip);
            var hasChip = player.Has(chip);
            
            Assert.Equal(true, hasChip);
        }
        
        [Fact]
        [Description("Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть")]
        public void ShouldHasCurrentBet_WhenBet()
        {
            var player = new Player();
            var chip = new Chip(10);
            var bet = new Bet(chip, 10);
            
            player.Bet(bet);
            
            Assert.Equal(bet.Chips, player.CurrentBet.Chips);
            Assert.Equal(bet.Score, player.CurrentBet.Score);
        }
        
        [Fact]
        [Description("Я, как игрок, не могу поставить фишек больше, чем я купил")]
        public void ShouldntBet_WhenHasNotEnoughChips()
        {
            var player = new Player();
            var chip = new Chip(10);
            player.Buy(chip);
            
            chip = new Chip(20);
            var bet = new Bet(chip, 10);
            
            player.Bet(bet);
            
            Assert.Equal(null, player.CurrentBet);
        }
        
//        [Fact]
//        [Description("Я, как игрок, могу проиграть, если сделал неправильную ставку")]
//        public void CanLoose_WhenBetWrong()
//        {
//            var luckyBet = 6;
//            var badBet = 5;
//            var player = new Player();
//            var chip = new Chip(1);
//            var bet = new Bet(chip, badBet);
//            var game = new RollDiceGame(luckyBet);
//            player.Join(game);
//            player.Bet(bet);
//
//            game.Play();
//
//            Assert.Equal(null, player.CurrentBet);
//        }
//        
//        [Fact]
//        [Description("Я, как игрок, могу выиграть 6 ставок, если сделал правильную ставку")]
//        public void CanWin6Chips_WhenRightBet()
//        {
//            var chipAmount = 10;
//            var luckyBet = 6;
//            var player = new PlayerMock();
//            var chip = new Chip(chipAmount);
//            var bet = new Bet(chip, luckyBet);
//            var game = new RollDiceGame(luckyBet);
//            player.Join(game);
//            player.Bet(bet);
//
//            game.Play();
//
//            Assert.Equal(chipAmount * 6, player.lastWin);
//        }
        
        [Fact]
        [Description("Game.Play() вызывает Player.Win() для всех игроков в игре, сделавших правильную ставку")]
        public void ShouldWin_WhenGoodBet()
        {
            var luckyBet = 1;
            var dice = new Mock<IDice>();
            dice.Setup(x => x.Roll()).Returns(luckyBet);
            var player = new Mock<IPlayer>();
            var chipAmount = 10;
            var chip = new Chip(chipAmount);
            var game = new RollDiceGame(dice.Object);
            
            var bet = new Bet(chip, luckyBet);
            player.Setup(x => x.CurrentBet).Returns(bet);
            player.Setup(x => x.Win(It.IsAny<int>()));

            game.AddPlayer(player.Object);
            game.Play();

            player.Verify(x => x.Win(It.IsAny<int>()), Times.Once);
        }
        
        [Fact]
        [Description("Game.Play() вызывает Player.Lose() для всех игроков в игре, сделавших неправильную ставку")]
        public void ShouldLose_WhenBadBet()
        {
            var luckyBet = 1;
            var dice = new Mock<IDice>();
            dice.Setup(x => x.Roll()).Returns(luckyBet);
            var player = new Mock<IPlayer>();
            var chipAmount = 10;
            var chip = new Chip(chipAmount);
            var game = new RollDiceGame(dice.Object);
            
            var bet = new Bet(chip, 2);
            player.Setup(x => x.CurrentBet).Returns(bet);

            game.AddPlayer(player.Object);
            game.Play();

            player.Verify(x => x.Lose(), Times.Once);
        }
    }
}
