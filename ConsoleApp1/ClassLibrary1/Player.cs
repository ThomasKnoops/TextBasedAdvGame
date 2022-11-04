using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Player : Entity
    {
        public List<Item> Inventory = new List<Item>();
        public string Name {get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        //for debugging purpose
        public override string ToString()
        {
            return "Name: " + Name + "ID: " + this.Id;
        }
    }
}
