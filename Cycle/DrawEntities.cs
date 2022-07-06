
/******************************************************************************
* Class: DrawEntities
* Purpose: This will draw all of the entities on screen during each frame.
******************************************************************************/

namespace cycles
{
    public class DrawEntities : Action
    {
        private Video video;

        // Method: DrawEntities()
        // Purpose: The constructor for this class.

        public DrawEntities(Video video)
        {
            this.video = video;
        }

        // Method: execute()
        // Purpose: Puts all of the sprites on the screen.

        public void execute(Cast cast, Script script)
        {
            Snake playerOne = (Snake)cast.getFirstEntity("playerOne");
            Snake playerTwo = (Snake)cast.getFirstEntity("playerTwo");
            List<Entity> firstTrail = cast.getEntities("trailOne");
            List<Entity> secondTrail = cast.getEntities("trailTwo");
            Entity message = cast.getFirstEntity("messages");
            HandleCollisions collisions = (HandleCollisions)script.getFirstAction("collide");

            video.clearBuffer();
            video.drawEntity(playerOne);
            video.drawEntity(playerTwo);
            video.drawEntities(firstTrail);
            video.drawEntities(secondTrail);
            if (collisions.getStatus() == true)
            {
                video.drawEntity(message);
            }
            video.flushBuffer();
        }
    }
}