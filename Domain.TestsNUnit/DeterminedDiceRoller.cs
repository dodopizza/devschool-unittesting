using Domain;

namespace Tests
{
    public class DeterminedDiceRoller : IDiceRoller
    {
        private readonly int _result;

        public DeterminedDiceRoller(int result)
        {
            _result = result;
        }

        public int Roll()
        {
            return _result;
        }
    }
}