
/******************************************************************************
* Class: Game
* Purpose: This runs the entire script over and over again until the game is
*   closed.
******************************************************************************/

namespace cycles
{
    public class Game
    {
        private Video video = null;

        // Method: Game()
        // Purpose: The constructor for the class.

        public Game(Video video)
        {
            this.video = video;
        }

        // Method: startGame()
        // Purpose: Runs the game until the window is closed.

        public void startGame(Cast cast, Script script)
        {
            video.openWindow();
            while (video.isWindowOpen())
            {
                executeActions("input", cast, script);
                executeActions("update", cast, script);
                executeActions("output", cast, script);
                executeActions("collide", cast, script);
            }
            video.closeWindow();
        }

        // Method: executeActions()
        // Purpose: Runs the scripts made in Program.cs.

        private void executeActions(string group, Cast cast, Script script)
        {
            List<Action> actions = script.getActions(group);
            foreach(Action action in actions)
            {
                action.execute(cast, script);
            }
        }
    }
}