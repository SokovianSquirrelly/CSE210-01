
/******************************************************************************
* Class: Cast
* Purpose: Cast will take the declared entities and store them in a dictionary.
*   This class will be called when adding entities to it, drawing entities, or
*   manipulating entities.
******************************************************************************/

namespace cycles
{
    public class Cast
    {
        private Dictionary<string, List<Entity>> entities = new Dictionary<string, List<Entity>>();

        // Method: Cast()
        // Purpose: Default constructor for this class.

        public Cast()
        {
        }

        // Method: addEntity()
        // Purpose: Places an entity into a group in the dictionary.

        public void addEntity(string group, Entity entity)
        {
            if (!entities.ContainsKey(group))
            {
                entities[group] = new List<Entity>();
            }

            if (!entities[group].Contains(entity))
            {
                entities[group].Add(entity);
            }
        }

        // Method: getEntities()
        // Purpose: Returns a list of entities in a group.

        public List<Entity> getEntities(string group)
        {
            List<Entity> results = new List<Entity>();
            if (entities.ContainsKey(group))
            {
                results.AddRange(entities[group]);
            }
            return results;
        }

        // Method: getFirstEntity()
        // Purpose: Returns the first entity in a group (usually the only entity).

        public Entity getFirstEntity(string group)
        {
            Entity result = null;
            if (entities.ContainsKey(group))
            {
                if (entities[group].Count > 0)
                {
                    result = entities[group][0];
                }
            }
            return result;
        }

        // Method: removeEntity()
        // Purpose: Deletes an entity.

        public void removeEntity(string group, Entity entity)
        {
            if (entities.ContainsKey(group))
            {
                entities[group].Remove(entity);
            }
        }
    }
}