namespace Domain
{
    /*
    1е поколение            2е поколение
    -------------           -------------
    |   | Х |   |           |   |   |   |
    -------------           -------------
    | Х |   |   |    ==>    |   |   |   |
    -------------           -------------
    |   | Х |   |           |   |   |   |
    -------------           -------------
    */
    
    
    public class LifeGameTests
    {
        public void GameHasCorrectStateInNextGeneration()
        {
            var game = new Game();
            
            var game =new Game()
            {
                { false, false, false},
                {...}
            };
            
            game = new Game(@"    -   *   -
                                  *   -   -
                                  -   *   -          ");
            
            
            
            game[0, 0] = false;
            game[0, 1] = true;
            game[0, 2] = false;
            game[1, 0] = true;
            game[1, 1] = false;
            game[1, 2] = false;
            game[2, 0] = false;
            game[2, 1] = true;
            game[2, 2] = false;

            game.NextGeneration();

            Assert.True(game == @"      -   -   -
                                        *   *   -
                                        -   -   -          ");
            Assert.True(game[1, 1]);

        }
    }

    public class Game
    {
        private bool[,] _field;

        public Game()
        {
            _field = new bool [3, 3];
        }

        public void NextGeneration()
        {
            
        }
        
        public object this[int x, int y]
        {
            get
            {
                 /* return the specified index here */
            }
            set
            {
                /* set the specified index to value here */
            }
        }
    }
}