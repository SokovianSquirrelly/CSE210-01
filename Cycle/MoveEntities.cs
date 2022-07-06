
/******************************************************************************
* Class: MoveEntities
* Purpose: Moves the snakes during each frame of gameplay.
******************************************************************************/

namespace cycles
{
    public class MoveEntities : Action
    {

        // Method: MoveEntities()
        // Purpose: The constructor for this class.

        public MoveEntities()
        {
        }

        // Method: execute()
        // Purpose: Moves both snakes and creates the trail behind them.

        public void execute(Cast cast, Script script)
        {
            Snake playerOne = (Snake)cast.getFirstEntity("playerOne");
            Snake playerTwo = (Snake)cast.getFirstEntity("playerTwo");

            //List<Entity> entities = cast.getAllEntities();
            Point oldPointOne = playerOne.getPosition();
            Point oldPointTwo = playerTwo.getPosition();

            playerOne.moveNext();
            playerTwo.moveNext();
            Trail oneTrail = new Trail(Constants.RED, oldPointOne);
            Trail twoTrail = new Trail(Constants.GREEN, oldPointTwo);

            HandleCollisions collisionTest = (HandleCollisions)script.getFirstAction("collide");
            if (collisionTest.getStatus() == true)
            {
                oneTrail.setColor(Constants.WHITE);
                twoTrail.setColor(Constants.WHITE);
            }

            cast.addEntity("trailOne", oneTrail);
            cast.addEntity("trailTwo", twoTrail);
        }
    }
}