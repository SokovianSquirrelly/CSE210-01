using System.Collections.Generic;


namespace greed
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        private Player firstPlayer = new Player();
        private Player secondPlayer = new Player();
        private int COLS = 60;
        private int ROWS = 40;
        private int CELL_SIZE = 15;
        private int FONT_SIZE = 15;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void startGame(Cast cast)
        {
            videoService.openWindow();
            while (videoService.isWindowOpen())
            {
                getInputsOne(cast);
                getInputsTwo(cast);
                doUpdates(cast);
                doOutputs(cast);
            }
            videoService.closeWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void getInputsOne(Cast cast)
        {
            Actor playerOne = cast.getFirstActor("player1");
            
            Point velocity = keyboardService.getDirectionOne();
            playerOne.setVelocity(velocity);
            
        }

        private void getInputsTwo(Cast cast)
        {
            Actor playerTwo = cast.getFirstActor("player2");
            Point velocity = keyboardService.getDirectionTwo();
            playerTwo.setVelocity(velocity);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void doUpdates(Cast cast)
        {
            Actor bannerOne = cast.getFirstActor("banner1");
            Actor bannerTwo = cast.getFirstActor("banner2");
            Actor playerOne = cast.getFirstActor("player1");
            Actor playerTwo = cast.getFirstActor("player2");
            List<Actor> stones = cast.getActors("stones");

            Point downward = new Point(0, 15);

            bannerOne.setText($"Points: {firstPlayer.getPoints()}");
            bannerTwo.setText($"Points: {secondPlayer.getPoints()}");
            int maxX = videoService.getWidth();
            int maxY = videoService.getHeight();
            playerOne.moveNext(maxX, maxY);
            playerTwo.moveNext(maxX, maxY);

            foreach (Actor actor in stones)
            {
                Random random = new Random();
                actor.setVelocity(downward);
                actor.moveNext(maxX, maxY);
                if (playerOne.getPosition().equals(actor.getPosition()))
                {
                    firstPlayer.addPoints(actor.getPointValue());
                    cast.removeActor("stones", actor);

                    int x = random.Next(1, COLS);
                    int y = random.Next(1, ROWS);
                    Point position = new Point(x, y);
                    position = position.scale(CELL_SIZE);

                    int selector = random.Next(1, 20);
                    if (selector >= 12)
                    {
                        Rock rock = new Rock();
                        rock.setFontSize(FONT_SIZE);
                        rock.setPosition(position);
                        cast.addActor("stones", rock);
                    }
                    else
                    {
                        Gem gem = new Gem();
                        gem.setFontSize(FONT_SIZE);
                        gem.setPosition(position);
                        gem.selectGem();
                        cast.addActor("stones", gem);
                    }
                }
                if (playerTwo.getPosition().equals(actor.getPosition()))
                {
                    secondPlayer.addPoints(actor.getPointValue());
                    cast.removeActor("stones", actor);

                    int x = random.Next(1, COLS);
                    int y = random.Next(1, ROWS);
                    Point position = new Point(x, y);
                    position = position.scale(CELL_SIZE);

                    int selector = random.Next(1, 20);
                    if (selector >= 12)
                    {
                        Rock rock = new Rock();
                        rock.setFontSize(FONT_SIZE);
                        rock.setPosition(position);
                        cast.addActor("stones", rock);
                    }
                    else
                    {
                        Gem gem = new Gem();
                        gem.setFontSize(FONT_SIZE);
                        gem.setPosition(position);
                        gem.selectGem();
                        cast.addActor("stones", gem);
                    }
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void doOutputs(Cast cast)
        {
            List<Actor> actors = cast.getAllActors();
            videoService.clearBuffer();
            videoService.drawActors(actors);
            videoService.flushBuffer();
        }
    }
}