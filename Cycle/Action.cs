
/******************************************************************************
* Class: Action
* Purpose: This class is just an interface for ? other classes, namely
*   ControlPlayerOne, ControlPlayerTwo, DrawEntities, HandleCollisions, and
*   MoveEntities.  Each one of them will be continuously executed while the
*   game is running.
******************************************************************************/

namespace cycles
{
    public interface Action
    {
        void execute(Cast cast, Script script);
    }
}