
/******************************************************************************
* Class: Script
* Purpose: This contains the dictionary of actions that will happen during each
*   frame of gameplay.
******************************************************************************/

namespace cycles
{
    public class Script
    {
        private Dictionary<string, List<Action>> actions = new Dictionary<string, List<Action>>();
    
        // Method: Script()
        // Purpose: The constructor for this class.

        public Script()
        {
        }

        // Method: addAction()
        // Purpose: Adds an action object into the script.

        public void addAction(string group, Action action)
        {
            if (!actions.ContainsKey(group))
            {
                actions[group] = new List<Action>();
            }

            if (!actions[group].Contains(action))
            {
                actions[group].Add(action);
            }
        }

        // Method: getFirstAction
        // Purpose: Returns the first action object in a group.

        public Action getFirstAction(string group)
        {
            Action result = null;
            if (actions.ContainsKey(group))
            {
                if (actions[group].Count > 0)
                {
                    result = actions[group][0];
                }
            }
            return result;
        }

        // Method: getActions()
        // Purpose: Returns all actions from a group.

        public List<Action> getActions(string group)
        {
            List<Action> results = new List<Action>();
            if (actions.ContainsKey(group))
            {
                results.AddRange(actions[group]);
            }
            return results;
        }
    }
}