using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClassLibrary1
{
    internal class Key : Item, iOpenable
    {
        List<Room> Keyhole = new List<Room>(2);
        public Key(string name, string description, Room keyhole1, Room keyhole2) : base(name, description)
        {
            Keyhole.Add(keyhole1);
            Keyhole.Add(keyhole2);
        }

        public void Open(World w)
        {
            if (!Keyhole.Contains(w.CurrentRoom))
            {
                Console.WriteLine("I can not use this " + Name + " on any door here");
                return;
            }
            foreach (var room in w.CurrentRoom.LinkedRooms)
            {
                if (Keyhole.Contains(room.Value))
                {
                    Console.WriteLine("I opened the door leading to the " + room.Key + ".");
                    room.Value.Locked = false;
                }

            }
        }

        public override void UseMe(World w)
        {
            Open(w);
        }
    }
}
