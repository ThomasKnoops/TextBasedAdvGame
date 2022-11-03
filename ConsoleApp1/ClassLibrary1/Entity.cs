using System;

namespace ClassLibrary1
{
    public abstract class Entity
    {
        private static int s_nextId = 0;
        public readonly int Id;

        public Entity()
        {
            this.Id = s_nextId++;
        }
    }
}
