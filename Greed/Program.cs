using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace greed
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static Color WHITE = new Color(255, 255, 255);
        private static Color PINK = new Color(237, 109, 224);
        private static int DEFAULT_STONES = 60;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banners
            Actor bannerOne = new Actor();
            bannerOne.setText("Monkey Brains");
            bannerOne.setFontSize(FONT_SIZE);
            bannerOne.setColor(WHITE);
            bannerOne.setPosition(new Point(0, 0));
            cast.addActor("banner1", bannerOne);

            Actor bannerTwo = new Actor();
            bannerTwo.setText("");
            bannerTwo.setFontSize(FONT_SIZE);
            bannerTwo.setColor(PINK);
            bannerTwo.setPosition(new Point(0, 15));
            cast.addActor("banner2", bannerTwo);

            // create the players
            Player playerOne = new Player();
            playerOne.setFontSize(FONT_SIZE);
            playerOne.setColor(WHITE);
            playerOne.setPosition(new Point(MAX_X / 3, 585));
            cast.addActor("player1", playerOne);

            Player playerTwo = new Player();
            playerTwo.setFontSize(FONT_SIZE);
            playerTwo.setColor(PINK);
            playerTwo.setPosition(new Point(2*MAX_X / 3, 585));
            cast.addActor("player2", playerTwo);

            // create the stones
            Random random = new Random();
            for (int i = 0; i < DEFAULT_STONES; i++)
            {
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

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.startGame(cast);

            // test comment
        }
    }
}