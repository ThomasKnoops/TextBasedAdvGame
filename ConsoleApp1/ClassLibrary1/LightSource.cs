using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class LightSource : Item, iLightable
    {
        public LightSource(string name, string description):base(name, description) { }

        public void Light(World w)
        {
            if (w.CurrentRoom != w.Rooms[14])
            {
                Console.WriteLine("The room is well-lit. I have no use for that here.");
                return;
            }
            w.CurrentRoom.Description = "This is the attic. I see some old boxes against the wall with lots of dust on them.";
            Console.WriteLine("Finally! I can see in this room. It looks like this is the attic. I see some old boxes against the wall with lots of dust on them.");
            return;
        }

        public override void UseMe(World w)
        {
            Light(w);
        }
    }
}
