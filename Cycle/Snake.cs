
/******************************************************************************
* Class: Snake
* Purpose: This is where the player icons come in and this is what is moving
*   during gameplay.  The snake moves around and leaves a trail behind it.
******************************************************************************/

namespace cycles
{
    class Snake : Entity
    {

        // Method: Snake()
        // Purpose: The constructor for this class.

        public Snake(Color color, Point position)
        {
            this.position = position;
            this.color = color;
            icon = "@";
            velocity = new Point(0, -1);
        }

        // Method: turnHead()
        // Purpose: Changes the velocity of the snake.

        public void turnHead(Point direction)
        {
            setVelocity(direction);
        }
    }
}