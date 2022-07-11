/******************************************************************************
* Class: Point
* Purpose: Specifies a location for an object on the screen.
******************************************************************************/

namespace spaceShooter
{
    public class Point
    {
        private int x;
        private int y;

        /**********************************************************************
        * Method: Point()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /**********************************************************************
        * Method: getX()
        * Purpose: Returns the x-coordinate.
        **********************************************************************/

        public int getX()
        {
            return x;
        }

        /**********************************************************************
        * Method: getY()
        * Purpose: Returns the y-coordinate.
        **********************************************************************/

        public int getY()
        {
            return y;
        }

        /**********************************************************************
        * Method: scale()
        * Purpose: Places an object onto the screen based on its cell size.
        **********************************************************************/

        public Point scale(int factor)
        {
            int x = this.x * factor;
            int y = this.y * factor;
            return new Point(x, y);
        }
    }
}