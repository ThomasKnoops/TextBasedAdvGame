using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class Player : Entity
    {
        private List<Item> Inventory = new List<Item>();
        public string Name {get; private set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
