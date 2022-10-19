using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class Room
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Enemy Enemy { get; set; }
        public Dictionary<string, Room> LinkedRooms { get; set; }
        

        public Room(string name)
        {
            Name = name;
        }

    }
}
