namespace greed
{
    /// <summary>
    /// <para>A distance from a relative origin (0, 0).</para>
    /// <para>
    /// The responsibility of Point is to hold and provide information about itself. Point has a few 
    /// convenience methods for adding, scaling, and comparing them.
    /// </para>
    /// </summary>
    public class Point
    {
        private int x = 0;
        private int y = 0;

        /// <summary>
        /// Constructs a new instance of Point using the given x and y values.
        /// </summary>
        /// <param name="x">The given x value.</param>
        /// <param name="y">The given y value.</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Adds the given point to this one by summing the x and y values.
        /// </summary>
        /// <param name="other">The point to add.</param>
        /// <returns>The sum as a new Point.</returns>
        public Point add(Point other)
        {
            int x = this.x + other.getX();
            int y = this.y + other.getY();
            return new Point(x, y);
        }

        /// <summary>
        /// Whether or not this Point is equal to the given one.
        /// </summary>
        /// <param name="other">The point to compare.</param>
        /// <returns>True if both x and y are equal; false if otherwise.</returns>
        public bool equals(Point other)
        {
            return this.x == other.getX() && this.y == other.getY();
        }

        /// <summary>
        /// Gets the value of the x coordinate.
        /// </summary>
        /// <returns>The x coordinate.</returns>
        public int getX()
        {
            return x;
        }

        /// <summary>
        /// Gets the value of the y coordinate.
        /// </summary>
        /// <returns>The y coordinate.</returns>
        public int getY()
        {
            return y;
        }

        /// <summary>
        /// Scales the point by multiplying the x and y values by the provided factor.
        /// </summary>
        /// <param name="factor">The scaling factor.</param>
        /// <returns>A scaled instance of Point.</returns>
        public Point scale(int factor)
        {
            int x = this.x * factor;
            int y = this.y * factor;
            return new Point(x, y);
        }
    }
}