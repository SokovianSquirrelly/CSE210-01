/******************************************************************************
* Class: Object
* Purpose: A superclass that is displayed onto the screen and is updated every
*   frame.
******************************************************************************/

namespace spaceShooter
{
    public class Object
    {
        protected string icon;
        protected Point position;
        protected Color color;
        protected Point velocity = new Point(0,0);

        /**********************************************************************
        * Method: Object()
        * Purpose: The default constructor for this class (subclasses use this
        *   constructor).
        **********************************************************************/

        public Object()
        {
            icon = "";
            position = new Point(0, 0);
            color = Constants.WHITE;
        }

        /**********************************************************************
        * Method: Object()
        * Purpose: Another constructor for this class.
        **********************************************************************/

        public Object(string icon, int x, int y)
        {
            setIcon(icon);
            position = new Point(x, y);
            color = Constants.WHITE;
        }

        /**********************************************************************
        * Method: getIcon()
        * Purpose: Returns the object's on-screen text.
        **********************************************************************/

        public string getIcon()
        {
            return icon;
        }

        /**********************************************************************
        * Method: getColor()
        * Purpose: Returns the object's color.
        **********************************************************************/

        public Color getColor()
        {
            return color;
        }

        /**********************************************************************
        * Method: getPosition()
        * Purpose: Returns the object's position.
        **********************************************************************/

        public Point getPosition()
        {
            return position;
        }

        /**********************************************************************
        * Method: moveNext()
        * Purpose: The base method for moving an object on the screen.
        **********************************************************************/

        public virtual void moveNext(int space)
        {
        }

        /**********************************************************************
        * Method: setIcon()
        * Purpose: Sets an object's icon.
        **********************************************************************/

        public void setIcon(string icon)
        {
            this.icon = icon;
        }
    }
}