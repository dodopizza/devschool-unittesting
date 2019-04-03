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
            _player.IsLoser = true;
        }
    }
}