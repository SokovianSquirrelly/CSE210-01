
/******************************************************************************
* Class: Point
* Purpose: Stores numeric values to place entities on screen and also to move
*   them.
******************************************************************************/

namespace cycles
{
    public class Point
    {
        private int x;
        private int y;

        // Method: Point()
        // Purpose: The constructor for this class.

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Method: getX()
        // Purpose: Returns the X coordinate.

        public int getX()
        {
            return x;
        }

        // Method: getY()
        // Purpose: returns the Y coordinate.

        public int getY()
        {
            return y;
        }
    }
}