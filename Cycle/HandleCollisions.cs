
/******************************************************************************
* Class: HandleCollisions
* Purpose: This handles the collision detection between the two snakes.
******************************************************************************/

namespace cycles
{
    public class HandleCollisions : Action
    {
        private bool isGameOver = false;

        // Method: HandleCollisions()
        // Purpose: The Constructor for this class.

        public HandleCollisions()
        {
        }

        // Method: execute()
        // Purpose: Checks for all collisions in the program until the game is over.

        public void execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                handleTieConditions(cast);
                handleSuicideConditions(cast);
                handleCrashConditions(cast);
                handleGameOver(cast);
            }
        }

        // Method: handleTieConditions()
        // Purpose: Ends the game if the snakes' heads collide.

        private void handleTieConditions(Cast cast)
        {
            Snake firstSnake = (Snake)cast.getFirstEntity("playerOne");
            Snake secondSnake = (Snake)cast.getFirstEntity("playerTwo");

            if (firstSnake.getPosition().Equals(secondSnake.getPosition()))
            {
                isGameOver = true;
            }
        }

        // Method: handleSuicideConditions()
        // Purpose: Deletes the entire trail if a snake runs into itself.

        private void handleSuicideConditions(Cast cast)
        {
            Snake firstSnake = (Snake)cast.getFirstEntity("playerOne");
            Snake secondSnake = (Snake)cast.getFirstEntity("playerTwo");
            List<Entity> firstTrail = cast.getEntities("trailOne");
            List<Entity> secondTrail = cast.getEntities("trailTwo");

            foreach (Trail trail in firstTrail)
            {
                if (firstSnake.getPosition().getX() == trail.getPosition().getX() && firstSnake.getPosition().getY() == trail.getPosition().getY())
                {
                    foreach (Trail oldTrail in firstTrail)
                    {
                        cast.removeEntity("trailOne", oldTrail);
                    }
                }
            }

            foreach (Trail trail in secondTrail)
            {
                if (secondSnake.getPosition().getX() == trail.getPosition().getX() && secondSnake.getPosition().getY() == trail.getPosition().getY())
                {
                    foreach (Trail oldTrail in secondTrail)
                    {
                        cast.removeEntity("trailTwo", oldTrail);
                    }
                }
            }
        }

        // Method: handleCrashConditions()
        // Purpose: Ends the game if one snake runs into the other snake's trail.

        private void handleCrashConditions(Cast cast)
        {
            Snake firstSnake = (Snake)cast.getFirstEntity("playerOne");
            Snake secondSnake = (Snake)cast.getFirstEntity("playerTwo");
            List<Entity> firstTrail = cast.getEntities("trailOne");
            List<Entity> secondTrail = cast.getEntities("trailTwo");

            foreach (Trail trail in firstTrail)
            {
                if (secondSnake.getPosition().getX() == trail.getPosition().getX() && secondSnake.getPosition().getY() == trail.getPosition().getY())
                {
                    isGameOver = true;
                }
            }

            foreach (Trail trail in secondTrail)
            {
                if (firstSnake.getPosition().getX() == trail.getPosition().getX() && firstSnake.getPosition().getY() == trail.getPosition().getY())
                {
                    isGameOver = true;
                }
            }
        }

        // Method: handleGameOver()
        // Purpose: Turns both snakes white if the game ends.

        private void handleGameOver(Cast cast)
        {
            if (isGameOver)
            {
                Snake firstSnake = (Snake)cast.getFirstEntity("playerOne");
                Snake secondSnake = (Snake)cast.getFirstEntity("playerTwo");
                List<Entity> firstTrail = cast.getEntities("trailOne");
                List<Entity> secondTrail = cast.getEntities("trailTwo");

                foreach (Entity trail in firstTrail)
                {
                    trail.setColor(Constants.WHITE);
                }
                foreach (Entity trail in secondTrail)
                {
                    trail.setColor(Constants.WHITE);
                }
                firstSnake.setColor(Constants.WHITE);
                secondSnake.setColor(Constants.WHITE);
            }
        }

        // Method: getStatus()
        // Purpose: Returns a boolean value depending if the game is over or not.

        public bool getStatus()
        {
            return isGameOver;
        }
    }
}