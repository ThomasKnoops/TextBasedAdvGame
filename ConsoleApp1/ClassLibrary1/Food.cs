using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class Food : Item, iEatable
    {
        bool Deadly;
        public Food(string name, string description, bool deadly) : base(name, description)
        {
            Deadly = deadly;
        }

        public void Eat(World w)
        {
            if (w.CurrentRoom == w.Rooms[9])
            {
                w.player.Inventory.Remove(this);
                w.CurrentRoom.Enemy.Distracted = true;
                Console.WriteLine("Now that I fed the dog some food, I can get past him to the next room.");
                return;
            }
            Console.WriteLine("This is raw... I am NOT going to eat this!");
        }

        public override void UseMe(World w)
        {
            Eat(w);
        }
    }
}
