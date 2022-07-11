/******************************************************************************
* Class: Player
* Purpose: Represents the player's ship and stores a score value throughout the
*   game.
******************************************************************************/

namespace spaceShooter
{
    public class Player : Object
    {
        private int score;

        /**********************************************************************
        * Method: Player()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public Player()
        {
            icon = ">";
            position = new Point(0, Constants.MAX_Y/2);
            color = Constants.WHITE;
            score = 0;
        }

        /**********************************************************************
        * Method: setVelocity()
        * Purpose: Sets the player's velocity.
        **********************************************************************/

        public void setVelocity(Point velocity)
        {
            this.velocity = velocity;
        }

        /**********************************************************************
        * Method: moveNext()
        * Purpose: Moves the player's ship up and down the screen.
        **********************************************************************/

        public override void moveNext(int maxY)
        {
            int y = ((position.getY() + velocity.getY()) + maxY) % maxY;
            position = new Point(0, y);
        }

        /**********************************************************************
        * Method: getScore()
        * Purpose: Returns the player's score.
        **********************************************************************/

        public int getScore()
        {
            return score;
        }

        /**********************************************************************
        * Method: setScore()
        * Purpose: Sets a new score for the player.  The value that is passed
        *   into the method determines how many points the player gained or
        *   lost.
        **********************************************************************/

        public void setScore(int points)
        {
            score = score += points;
        }
    }
}