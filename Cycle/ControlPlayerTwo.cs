
/******************************************************************************
* Class: ControlPlayerTwo
* Purpose: This has the control instructions for player two.
******************************************************************************/

namespace cycles
{
    public class ControlPlayerTwo : Action
    {
        private Keyboard keyboard;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        // Method: ControlPlayerOne()
        // Purpose: The constructor for this class.

        public ControlPlayerTwo(Keyboard keyboard)
        {
            this.keyboard = keyboard;
        }

        // Method: execute()
        // Purpose: Gives moving directions for player two.

        public void execute(Cast cast, Script script)
        {
            if (keyboard.isKeyDown("j"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            if (keyboard.isKeyDown("l"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            if (keyboard.isKeyDown("i"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            if (keyboard.isKeyDown("k"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake = (Snake)cast.getFirstEntity("playerTwo");
            snake.turnHead(direction);
        }
    }
}