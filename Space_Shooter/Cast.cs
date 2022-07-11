/******************************************************************************
* Class: Cast
* Purpose: Stores all on-screen objects in the program and accesses their
*   values and methods.
******************************************************************************/

namespace spaceShooter
{
    public class Cast
    {
        private Dictionary<string, List<Object>> objects = new Dictionary<string, List<Object>>();

        /**********************************************************************
        * Method: Cast()
        * Purpose: The constructor for this class.
        **********************************************************************/

        public Cast()
        {
        }

        /**********************************************************************
        * Method: addObject()
        * Purpose: Places an object into a group in the dictionary.
        **********************************************************************/

        public void addObject(string group, Object item)
        {
            if (!objects.ContainsKey(group))
            {
                objects[group] = new List<Object>();
            }

            if (!objects[group].Contains(item))
            {
                objects[group].Add(item);
            }
        }

        /**********************************************************************
        * Method: getObjects()
        * Purpose: Returns a list of objects in a group.
        **********************************************************************/

        public List<Object> getObjects(string group)
        {
            List<Object> results = new List<Object>();
            if (objects.ContainsKey(group))
            {
                results.AddRange(objects[group]);
            }
            return results;
        }

        /**********************************************************************
        * Method: getAllObjects()
        * Purpose: Returns all objects in the dictionary.
        **********************************************************************/

        public List<Object> getAllObjects()
        {
            List<Object> results = new List<Object>();
            foreach (List<Object> result in objects.Values)
            {
                results.AddRange(result);
            }
            return results;
        }

        /**********************************************************************
        * Method: getFirstObject()
        * Purpose: Returns the first object in a group (usually the only one).
        **********************************************************************/

        public Object getFirstObject(string group)
        {
            Object result = null;
            if (objects.ContainsKey(group))
            {
                if (objects[group].Count > 0)
                {
                    result = objects[group][0];
                }
            }
            return result;
        }

        /**********************************************************************
        * Method: removeObject()
        * Purpose: Deletes an object.
        **********************************************************************/

        public void removeObject(string group, Object item)
        {
            if (objects.ContainsKey(group))
            {
                objects[group].Remove(item);
            }
        }
    }
}