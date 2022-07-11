/******************************************************************************
* Class: Game
* Purpose: Runs all the game instructions.
******************************************************************************/

namespace spaceShooter
{
    public class Game
    {
        private Keyboard keyboard = null;
        private Video video = null;

        /**********************************************************************
        * Method: Game()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public Game(Keyboard keyboard, Video video)
        {
            this.keyboard = keyboard;
            this.video = video;
        }

        /**********************************************************************
        * Method: startGame()
        * Purpose: Opens up the game and runs it unti the window is closed.
        **********************************************************************/

        public void startGame(Cast cast)
        {
            video.openWindow();
            while (video.isWindowOpen())
            {
                getInputs(cast);
                doUpdates(cast);
                doOutputs(cast);
            }
            video.closeWindow();
        }

        /**********************************************************************
        * Method: getInputs()
        * Purpose: Gets keyboard inputs for the player.
        **********************************************************************/

        private void getInputs(Cast cast)
        {
            Player player = (Player)cast.getFirstObject("player");

            Point velocity = keyboard.getDirection();
            player.setVelocity(velocity);
            keyboard.fireLaser(player.getPosition().getY(), cast, player);
        }

        /**********************************************************************
        * Method: doUpdates()
        * Purpose: Changes values based on certain in-game conditions.
        **********************************************************************/

        private void doUpdates(Cast cast)
        {
            Player player = (Player)cast.getFirstObject("player");
            player.moveNext(Constants.MAX_Y);

            Object banner = cast.getFirstObject("banner");
            banner.setIcon($"Score: {player.getScore()}");

            List<Object> lasers = cast.getObjects("lasers");
            List<Object> ships = cast.getObjects("aliens");

            foreach (UFO ship in ships)
            {
                ship.moveNext(Constants.MAX_X);

                // These 'if' statements are meant to make the ship look like
                // it's exploding and then deletes the ship.

                if (ship.getIcon() == "*")
                {
                    ship.die();
                }
                else if (ship.getIcon() == "#")
                {
                    cast.removeObject("aliens", ship);
                }

                // If the ship reaches the player, the player loses ten points.
                // It is then replaced by a new ship.

                if (ship.getPosition().getX() <= 15)
                {
                    player.setScore(-10);
                    cast.removeObject("aliens", ship);

                    Random random = new Random();
                    int x = Constants.COLS - 1;
                    int y = random.Next(1, Constants.ROWS - 1);
                    Point position = new Point(x, y);
                    position = position.scale(Constants.CELL_SIZE);
                    UFO newShip = new UFO(position);
                    cast.addObject("aliens", newShip);
                }
            }

            foreach (Laser laser in lasers)
            {
                laser.moveNext(Constants.MAX_X);
                foreach (UFO ufo in ships)
                {
                    if (laser.getPosition().getY() == ufo.getPosition().getY())
                    {

                        // In plain English, this is what happens when the laser hits an enemy ship.
                        // The player gains 15 points.

                        if (laser.getPosition().getX() >= ufo.getPosition().getX() && ufo.getIcon() == "0")
                        {
                            ufo.explode();
                            
                            Random random = new Random();
                            int x = Constants.COLS - 1;
                            int y = random.Next(1, Constants.ROWS - 1);
                            Point position = new Point(x, y);
                            position = position.scale(Constants.CELL_SIZE);
                            UFO newShip = new UFO(position);
                            cast.addObject("aliens", newShip);

                            player.setScore(15);
                        }
                    }
                }

                // This removes the laser if it reaches the end of the screen.

                if (laser.getPosition().getX() == 0)
                {
                    cast.removeObject("lasers", laser);
                }
            }
        }

        /**********************************************************************
        * Method: doOutputs()
        * Purpose: Redraws all of the on-screen objects.
        **********************************************************************/

        private void doOutputs(Cast cast)
        {
            List<Object> items = cast.getAllObjects();
            video.clearBuffer();
            video.drawObjects(items);
            video.flushBuffer();
        }
    }
}