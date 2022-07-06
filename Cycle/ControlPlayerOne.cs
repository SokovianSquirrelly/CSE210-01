
/******************************************************************************
* Class: ControlPlayerOne
* Purpose: This has the control instructions for player one.
******************************************************************************/

namespace cycles
{
    public class ControlPlayerOne : Action
    {
        private Keyboard keyboard;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        // Method: ControlPlayerOne()
        // Purpose: The constructor for this class.

        public ControlPlayerOne(Keyboard keyboard)
        {
            this.keyboard = keyboard;
        }

        // Method: execute()
        // Purpose: Gives moving directions for player one.

        public void execute(Cast cast, Script script)
        {
            if (keyboard.isKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            if (keyboard.isKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            if (keyboard.isKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            if (keyboard.isKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake = (Snake)cast.getFirstEntity("playerOne");
            snake.turnHead(direction);
        }
    }
}