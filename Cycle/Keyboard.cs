using Raylib_cs;

/******************************************************************************
* Class: Keyboard
* Purpose: This is the basis for the keyboard instructions in ControlPlayerOne
*   and ControlPlayerTwo.
******************************************************************************/

namespace cycles
{
    public class Keyboard
    {
        private Dictionary<string, KeyboardKey> keys = new Dictionary<string, KeyboardKey>();

        // Method: Keyboard()
        // Purpose: The constructor for this class.

        public Keyboard()
        {
            keys["w"] = KeyboardKey.KEY_W;
            keys["a"] = KeyboardKey.KEY_A;
            keys["s"] = KeyboardKey.KEY_S;
            keys["d"] = KeyboardKey.KEY_D;
            keys["i"] = KeyboardKey.KEY_I;
            keys["j"] = KeyboardKey.KEY_J;
            keys["k"] = KeyboardKey.KEY_K;
            keys["l"] = KeyboardKey.KEY_L; 
        }

        // Method: isKeyDown()
        // Purpose: Checks to see if a key is pressed.

        public bool isKeyDown(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyDown(raylibKey);
        }
    }
}