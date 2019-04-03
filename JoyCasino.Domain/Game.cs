namespace JoyCasino.Domain
{
    public class Game
    {
        private Player _player;

        public void AddPlayer(Player player)
        {
            _player = player;
        }
        
        public void Play(int luckyScore)
        {
            _player.Win(_player.GetBetForScore(luckyScore) * 6);
            
            _player.IsLoser = true;
        }
    }
}