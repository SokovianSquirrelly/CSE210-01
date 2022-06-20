using System;


namespace greed
{
    /// <summary>
    /// <para>A thing that participates in the game.</para>
    /// <para>
    /// The responsibility of Actor is to keep track of its appearance, position and velocity in 2d 
    /// space.
    /// </para>
    /// </summary>
    public class Actor
    {
        private string text = "";
        private int fontSize = 15;
        private Color color = new Color(255, 255, 255); // white
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);
        private int pointValue = 0;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Actor()
        {
        }

        /// <summary>
        /// Gets the actor's color.
        /// </summary>
        /// <returns>The color.</returns>
        public Color getColor()
        {
            return color;
        }

        /// <summary>
        /// Gets the actor's font size.
        /// </summary>
        /// <returns>The font size.</returns>
        public int getFontSize()
        {
            return fontSize;
        }

        /// <summary>
        /// Gets the actor's position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point getPosition()
        {
            return position;
        }

        /// <summary>
        /// Gets the actor's text.
        /// </summary>
        /// <returns>The text.</returns>
        public string getText()
        {
            return text;
        }

        /// <summary>
        /// Gets the actor's current velocity.
        /// </summary>
        /// <returns>The velocity.</returns>
        public Point getVelocity()
        {
            return velocity;
        }

        /// <summary>
        /// Moves the actor to its next position according to its velocity. Will wrap the position 
        /// from one side of the screen to the other when it reaches the maximum x and y 
        /// values.
        /// </summary>
        /// <param name="maxX">The maximum x value.</param>
        /// <param name="maxY">The maximum y value.</param>
        public void moveNext(int maxX, int maxY)
        {
            int x = ((position.getX() + velocity.getX()) + maxX) % maxX;
            int y = ((position.getY() + velocity.getY()) + maxY) % maxY;
            position = new Point(x, y);
        }

        /// <summary>
        /// Sets the actor's color to the given value.
        /// </summary>
        /// <param name="color">The given color.</param>
        /// <exception cref="ArgumentException">When color is null.</exception>
        public void setColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentException("color can't be null");
            }
            this.color = color;
        }

        /// <summary>
        /// Sets the actor's font size to the given value.
        /// </summary>
        /// <param name="fontSize">The given font size.</param>
        /// <exception cref="ArgumentException">
        /// When font size is less than or equal to zero.
        /// </exception>
        public void setFontSize(int fontSize)
        {
            if (fontSize <= 0)
            {
                throw new ArgumentException("fontSize must be greater than zero");
            }
            this.fontSize = fontSize;
        }

        /// <summary>
        /// Sets the actor's position to the given value.
        /// </summary>
        /// <param name="position">The given position.</param>
        /// <exception cref="ArgumentException">When position is null.</exception>
        public void setPosition(Point position)
        {
            if (position == null)
            {
                throw new ArgumentException("position can't be null");
            }
            this.position = position;
        }

        /// <summary>
        /// Sets the actor's text to the given value.
        /// </summary>
        /// <param name="text">The given text.</param>
        /// <exception cref="ArgumentException">When text is null.</exception>
        public void setText(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("text can't be null");
            }
            this.text = text;
        }

        /// <summary>
        /// Sets the actor's velocity to the given value.
        /// </summary>
        /// <param name="velocity">The given velocity.</param>
        /// <exception cref="ArgumentException">When velocity is null.</exception>
        public void setVelocity(Point velocity)
        {
            if (velocity == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            this.velocity = velocity;
        }

        public int getPointValue()
        {
            return pointValue;
        }

        public void setPointValue(int pointValue)
        {
            this.pointValue = pointValue;
        }
    }
}