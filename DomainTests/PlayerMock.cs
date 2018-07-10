using Domain;

namespace DomainTests
{
     public class PlayerMock : Player
    {
        public int lastWin;
        
        public override void Win(int chipsAmount)
        {
            lastWin = chipsAmount;
        }
    }
}