using Raylib_cs;

/******************************************************************************
* Class: Video
* Purpose: Runs the output for this program using Raylib.
******************************************************************************/

namespace spaceShooter
{
    public class Video
    {
        private bool debug = false;

        /**********************************************************************
        * Method: Video()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public Video(bool debug)
        {
            this.debug = debug;
        }

        /**********************************************************************
        * Method: closeWindow()
        * Purpose: Closes the window to stop letting flies into the house.
        **********************************************************************/

        public void closeWindow()
        {
            Raylib.CloseWindow();
        }

        /**********************************************************************
        * Method: clearBuffer()
        * Purpose: Starts drawing all of the icons.
        **********************************************************************/

        public void clearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            if (debug)
            {
                drawGrid();
            }
        }

        /**********************************************************************
        * Method: drawObject()
        * Purpose: Draws an object.
        **********************************************************************/

        private void drawObject(Object item)
        {
            string text = item.getIcon();
            int x = item.getPosition().getX();
            int y = item.getPosition().getY();
            int fontSize = Constants.FONT_SIZE;
            Color c = item.getColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }

        /**********************************************************************
        * Method: drawObjects()
        * Purpose: Draws multiple objects.
        **********************************************************************/

        public void drawObjects(List<Object> objects)
        {
            foreach (Object item in objects)
            {
                drawObject(item);
            }
        }

        /**********************************************************************
        * Method: flushBuffer()
        * Purpose: Stops drawing.
        **********************************************************************/

        public void flushBuffer()
        {
            Raylib.EndDrawing();
        }

        /**********************************************************************
        * Method: isWindowOpen()
        * Purpose: Returns a boolean statement based on if the game is still
        *   running or not.
        **********************************************************************/

        public bool isWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        /**********************************************************************
        * Method: openWindow()
        * Purpose: Opens the window so we can let flies into the house.
        **********************************************************************/

        public void openWindow()
        {
            Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.CAPTION);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        /**********************************************************************
        * Method: drawGrid()
        * Purpose: For debug purposes.  Draws a grid on the screen.
        **********************************************************************/

        private void drawGrid()
        {
            for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, Constants.MAX_X, y, Raylib_cs.Color.GRAY);
            }
        }

        /**********************************************************************
        * Method: ToRaylibColor()
        * Purpose: Converts the numeric value of color to an actual color.
        **********************************************************************/

        private Raylib_cs.Color ToRaylibColor(Color color)
        {
            int r = color.getRed();
            int g = color.getGreen();
            int b = color.getBlue();
            int a = color.getAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }
    }
}