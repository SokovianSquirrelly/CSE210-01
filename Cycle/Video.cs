using Raylib_cs;

/******************************************************************************
* Class: Video
* Purpose: This is the class that actually draws everything on screen.
******************************************************************************/

namespace cycles
{
    public class Video
    {
        private bool debug = false;

        // Method: Video()
        // Purpose: The constructor for this class.

        public Video(bool debug)
        {
            this.debug = debug;
        }

        // Method: closeWindow()
        // Purpose: Closes the window.

        public void closeWindow()
        {
            Raylib.CloseWindow();
        }

        // Method: clearBuffer()
        // Purpose: The starting point for drawing objects on the screen.

        public void clearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            if (debug)
            {
                drawGrid();
            }
        }

        // Method: drawEntity()
        // Purpose: Puts an entity on the screen.

        public void drawEntity(Entity entity)
        {
            string text = entity.getIcon();
            int x = entity.getPosition().getX();
            int y = entity.getPosition().getY();
            int fontSize = entity.getFontSize();
            Color c = entity.getColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }

        // Method: drawEntities()
        // Purpose: Puts a bunch of entities on the screen.

        public void drawEntities(List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                drawEntity(entity);
            }
        }

        // Method: flushBuffer()
        // Purpose: Tells the program to stop putting stuff on the screen.

        public void flushBuffer()
        {
            Raylib.EndDrawing();
        }

        // Method: isWindowOpen()
        // Purpose: Returns a boolean statement determining if the window is open or not.

        public bool isWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        // Method: openWindow()
        // Purpose: Opens the window...and lets flies in.

        public void openWindow()
        {
            Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.CAPTION);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        // Method: drawGrid()
        // Purpose: Draws a grid if the debug option is turned on.

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

        // Method: ToRaylibColor()
        // Purpose: Gets the color to work on the entities.

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