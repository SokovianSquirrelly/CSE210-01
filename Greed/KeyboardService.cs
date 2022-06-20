using Raylib_cs;


namespace greed
{
    /// <summary>
    /// <para>Detects player input.</para>
    /// <para>
    /// The responsibility of a KeyboardService is to detect player key presses and translate them 
    /// into a point representing a direction.
    /// </para>
    /// </summary>
    public class KeyboardService
    {
        private int cellSize = 15;

        /// <summary>
        /// Constructs a new instance of KeyboardService using the given cell size.
        /// </summary>
        /// <param name="cellSize">The cell size (in pixels).</param>
        public KeyboardService(int cellSize)
        {
            this.cellSize = cellSize;
        }

        /// <summary>
        /// Gets the selected direction based on the currently pressed keys.
        /// </summary>
        /// <returns>The direction as an instance of Point.</returns>
        public Point getDirectionOne()
        {
            int dx = 0;
            int dy = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx = 1;
            }

            Point direction = new Point(dx, dy);
            direction = direction.scale(cellSize);

            return direction;
        }

        // I decided to add this method because this iteration of Greed is
        // designed to be two-player.  Player two will use the A and D keys to
        // move left and right.

        public Point getDirectionTwo()
        {
            int dx = 0;
            int dy = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                dx = 1;
            }

            Point direction = new Point(dx, dy);
            direction = direction.scale(cellSize);

            return direction;
        }
    }
}