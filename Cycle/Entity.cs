
/******************************************************************************
* Class: Entity
* Purpose: This is the superclass for all other entities, or on-screen icons.
******************************************************************************/

namespace cycles
{
    public class Entity
    {
        protected Point position = new Point (0, 0);
        protected Color color = Constants.WHITE;
        protected string icon = "";
        protected int fontSize = Constants.FONT_SIZE;
        protected Point velocity = new Point(0,0);

        // Method: Entity()
        // Purpose: The constructor for this class.

        public Entity()
        {
        }

        // Method: getIcon()
        // Purpose: Returns the text used to represent an entity.

        public string getIcon()
        {
            return icon;
        }

        // Method: getPosition()
        // Purpose: Returns the position of an entity.

        public Point getPosition()
        {
            return position;
        }

        // Method: getFontSize()
        // Purpose: Returns the font size of an entity.

        public int getFontSize()
        {
            return fontSize;
        }

        // Method: getColor()
        // Purpose: Returns the color of an entity.

        public Color getColor()
        {
            return color;
        }

        // Method: setColor()
        // Purpose: Sets the color of an entity.

        public void setColor(Color color)
        {
            this.color = color;
        }

        // Method: setPosition()
        // Purpose: Sets the position of an entity.

        public void setPosition(int x, int y)
        {
            position = new Point(x, y);
        }

        // Method: setIcon()
        // Purpose: Sets the text used to represent an entity.

        public void setIcon(string icon)
        {
            this.icon = icon;
        }

        // Method: setVelocity()
        // Purpose: Sets the velocity of an entity.

        public void setVelocity(Point velocity)
        {
            this.velocity = velocity;
        }

        // Method: moveNext()
        // Purpose: Moves an entity depending on its velocity by assigning it a new point.

        public void moveNext()
        {
            int x = ((position.getX() + velocity.getX()) + Constants.MAX_X) % Constants.MAX_X;
            int y = ((position.getY() + velocity.getY()) + Constants.MAX_Y) % Constants.MAX_Y;
            position = new Point (x, y);
        }
    }
}