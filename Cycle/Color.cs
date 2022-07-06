
/******************************************************************************
* Class: Color
* Purpose: This class stores numeric values for colors to be set for the stuff
*   on screen.
******************************************************************************/

namespace cycles
{
    public class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha = 255;

        // Method: Color()
        // Purpose: The constructor for this class

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        // Method: getRed()
        // Purpose: Returns the numeric value for red.

        public int getRed()
        {
            return red;
        }

        // Method: getGreen()
        // Purpose: Returns the numeric value for green.

        public int getGreen()
        {
            return green;
        }

        // Method: getBlue()
        // Purpose: Returns the numeric value for blue.

        public int getBlue()
        {
            return blue;
        }

        // Method: getAlpha()
        // Purpose: Returns the numeric value for alpha...whatever that means.

        public int getAlpha()
        {
            return alpha;
        }
    }
}