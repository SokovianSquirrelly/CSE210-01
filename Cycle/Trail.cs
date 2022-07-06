
/******************************************************************************
* Class: Trail
* Purpose: Two lists of trails will be present during gameplay.  These are the
*   trails that the snakes leave behind for their opponent to crash into.
******************************************************************************/

namespace cycles
{
    public class Trail : Entity
    {

        // Method: Trail()
        // Purpose: The constructor for this class.

        public Trail(Color color, Point position)
        {
            icon = "#";
            this.color = color;
            this.position = position;
        }
    }
}