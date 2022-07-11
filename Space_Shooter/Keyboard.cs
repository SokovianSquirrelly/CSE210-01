using Raylib_cs;

/******************************************************************************
* Class: Keyboard
* Purpose: Runs the controls for the player.
******************************************************************************/

namespace spaceShooter
{
    public class Keyboard
    {
        private int cellSize = Constants.CELL_SIZE;
        private bool canProceed = true;

        /**********************************************************************
        * Method: Keyboard()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public Keyboard()
        {
        }

        /**********************************************************************
        * Method: getDirection()
        * Purpose: Returns a velocity point based on the keyboard inputs.
        **********************************************************************/

        public Point getDirection()
        {
            int dx = 0;
            int dy = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                dy = -1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                dy = 1;
            }

            Point direction = new Point(dx, dy);
            direction = direction.scale(cellSize);

            return direction;
        }

        /**********************************************************************
        * Method: fireLaser()
        * Purpose: Fires a laser.  Each laser fired costs the player 1 point.
        **********************************************************************/

        public void fireLaser(int y, Cast cast, Player player)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                Laser laser = new Laser(y);
                cast.addObject("lasers", laser);
                player.setScore(-1);
            }
        }
    }
}