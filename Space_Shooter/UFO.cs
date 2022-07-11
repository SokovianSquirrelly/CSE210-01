/******************************************************************************
* Class: UFO
* Purpose: On-screen enemies that need to be shot down by the player.
******************************************************************************/

namespace spaceShooter
{
    public class UFO : Object
    {

        /**********************************************************************
        * Method: UFO()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public UFO(Point position)
        {
            icon = "0";
            color = Constants.GRAY;
            this.position = position;
            velocity = new Point(-1, 0);
        }

        /**********************************************************************
        * Method: explode()
        * Purpose: Changes the icon of the ship to make it appear like it's
        *   exploding.
        **********************************************************************/

        public void explode()
        {
            icon = "*";
        }

        /**********************************************************************
        * Method: die()
        * Purpose: Continues the explosion.
        **********************************************************************/

        public void die()
        {
            icon = "#";
        }

        /**********************************************************************
        * Method: moveNext()
        * Purpose: Moves the UFO across the screen.
        **********************************************************************/

        public override void moveNext(int maxX)
        {
            int x = ((position.getX() + velocity.getX()) + maxX) % maxX;
            position = new Point(x, position.getY());
        }
    }
}