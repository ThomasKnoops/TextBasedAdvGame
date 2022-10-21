using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
