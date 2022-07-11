/******************************************************************************
* Class: Program
* Purpose: The driver of the rest of the program.
******************************************************************************/

namespace spaceShooter
{
    public class Program
    {
        static void Main()
        {
            // Create the cast, score banner, and player.

            Cast cast = new Cast();

            Player player = new Player();
            cast.addObject("player", player);

            Object scoreBanner = new Object($"Score: {player.getScore()}", 0, 0);
            cast.addObject("banner", scoreBanner);

            // Places the initial enemy ships on the screen.

            Random random = new Random();
            for (int i = 0; i < Constants.ENEMIES; i++)
            {
                int x = Constants.COLS - 1;
                int y = random.Next(1, (Constants.ROWS - 1));
                Point position = new Point(x, y);
                position = position.scale(Constants.CELL_SIZE);
                UFO ship = new UFO(position);

                cast.addObject("aliens", ship);
            }

            // Sets up the inputs and outputs for this game.

            Keyboard keyboard = new Keyboard();
            Video video = new Video(false);

            // Runs the game.

            Game game = new Game(keyboard, video);
            game.startGame(cast);
        }
    }
}