/******************************************************************************
* Class: Laser
* Purpose: Shoots down enemy ships.
******************************************************************************/

namespace spaceShooter
{
    public class Laser : Object
    {

        /**********************************************************************
        * Method: Laser()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public Laser(int y)
        {
            icon = "-";
            position = new Point(15, y);
            color = Constants.RED;
            velocity = new Point(15, 0);
        }

        /**********************************************************************
        * Method: moveNext()
        * Purpose: Moves the laserbolt across the screen.
        **********************************************************************/

        public override void moveNext(int maxX)
        {
            int x = ((position.getX() + velocity.getX()) + maxX) % maxX;
            position = new Point(x, position.getY());
        }
    }
}