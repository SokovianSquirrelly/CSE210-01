
/******************************************************************************
* Class: Program
* Purpose: The driver behind everything else.  Main() is in this class and it's
*   the script that the compiler follows.
******************************************************************************/

namespace cycles
{
    public class Program
    {
        public static void Main()
        {
            Cast cast = new Cast();

            // Determines the starting point for the snakes.

            Point snakeOnePosition = new Point(Constants.MAX_X/4, Constants.MAX_Y/5);
            Point snakeTwoPosition = new Point(3*Constants.MAX_X/4, Constants.MAX_Y/5);

            // Creates the actual snakes.

            Snake playerOne = new Snake(Constants.RED, snakeOnePosition);
            Snake playerTwo = new Snake(Constants.GREEN, snakeTwoPosition);

            // Creates the starting trail for the snakes and put them into the cast.

            int yTrail = (snakeOnePosition.getY() + Constants.CELL_SIZE);
            int snakeOneX = snakeOnePosition.getX();
            int snakeTwoX = snakeTwoPosition.getX();
            for (int i = 0; i < Constants.START_TRAIL; i++)
            {
                
                cast.addEntity("trailOne", new Trail(Constants.RED, new Point(snakeOneX, yTrail)));
                cast.addEntity("trailTwo", new Trail(Constants.GREEN, new Point(snakeTwoX, yTrail)));
                yTrail += Constants.CELL_SIZE;
            }

            // Creates the "Game Over" message and puts it into the cast.

            Entity message = new Entity();
            message.setPosition(Constants.MAX_X/2, Constants.MAX_Y/2);
            message.setIcon("GAME OVER");
            cast.addEntity("messages", message);

            // Puts the snakes into the cast.

            cast.addEntity("playerOne", playerOne);
            cast.addEntity("playerTwo", playerTwo);

            // Activates the input/output part of the program.

            Keyboard keyboard = new Keyboard();
            Video video = new Video(false);

            // Creates the script to run during gameplay.

            Script script = new Script();
            script.addAction("input", new ControlPlayerOne(keyboard));
            script.addAction("input", new ControlPlayerTwo(keyboard));
            script.addAction("output", new DrawEntities(video));
            script.addAction("update", new MoveEntities());
            script.addAction("collide", new HandleCollisions());

            // Starts the game.

            Game game = new Game(video);
            game.startGame(cast, script);
        }
    }
}