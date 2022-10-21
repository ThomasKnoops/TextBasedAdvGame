using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Room
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public List<Item> Items { get; set; }
        public Enemy Enemy { get; set; }
        public Dictionary<string, Room> LinkedRooms { get; set; }
        

        public Room(string name)
        {
            Name = name;
            Description = "";
            Locked = false;
            Items = new List<Item>();
            Enemy = null;
            LinkedRooms = new Dictionary<string, Room>();
        }

    }
}
