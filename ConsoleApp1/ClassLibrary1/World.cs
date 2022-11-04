using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ClassLibrary1
{
    public class World
    {
        public Room CurrentRoom { get; private set; }
        public List<Room> Rooms { get; private set; } 
        public Player player { get; private set; }

        public World(string Name)
        {
            GenerateRooms();
            AddRoomInfo();
            player = new Player(Name);
            CurrentRoom = Rooms[0];
        }

        //Makes a list of all the rooms with their names
        public void GenerateRooms()
        {
            Rooms = new List<Room>();
            Rooms.Add(new Room("Basement")); //Room 0
            Rooms.Add(new Room("Grand Hall")); //Room 1
            Rooms.Add(new Room("Exit")); //Room 2
            Rooms.Add(new Room("Yard")); //Room 3
            Rooms.Add(new Room("Study")); //Room 4
            Rooms.Add(new Room("Dining Room")); //Room 5
            Rooms.Add(new Room("Kitchen")); //Room 6
            Rooms.Add(new Room("Staircase")); //Room 7
            Rooms.Add(new Room("Upper hall")); //Room 8
            Rooms.Add(new Room("Master Bedroom")); //Room 9
            Rooms.Add(new Room("Master Bathroom")); //Room 10
            Rooms.Add(new Room("Guest Bedroom")); //Room 11
            Rooms.Add(new Room("Guest Bathroom")); //Room 12
            Rooms.Add(new Room("Utility closet")); //Room 13
            Rooms.Add(new Room("Attic")); //Room 14
        }

        //updates the list with all the correct variables
        public void AddRoomInfo()
        {
            //Room 0 modifications (Basement)
            Rooms[0].Description = "This room looks like a basement. I see some old bottles and a doorway to the floor above me.";
            Rooms[0].Items.Add(new TextItem("Note", "It has some text written on it. Maybe I should read that."));
            Rooms[0].LinkedRooms.Add("up", Rooms[1]);
            Rooms[0].LookAround.Add("bottle", "There are lots of bottles here, some are full and some are empty. I think that 1 of the empty bottles has a note in it!");
            //Room 1 modifications (Grand Hall)
            Rooms[1].Description = "This seems like a big hub. Let's find out what's behind these doors.";
            Rooms[1].LinkedRooms.Add("up", Rooms[7]);
            Rooms[1].LinkedRooms.Add("down", Rooms[0]);
            Rooms[1].LinkedRooms.Add("east", Rooms[5]);
            Rooms[1].LinkedRooms.Add("west", Rooms[4]);
            Rooms[1].LinkedRooms.Add("north", Rooms[3]);
            Rooms[1].LinkedRooms.Add("south", Rooms[2]);
            //Room 2 modifications (Exit)
            Rooms[2].Description = "";
            Rooms[2].Locked = true;
            //Room 3 modifications (Yard)
            Rooms[3].Description = "";
            Rooms[3].LinkedRooms.Add("south", Rooms[1]);
            Rooms[3].Items.Add(new UselessItem("Rope", "A 10 meter rope in good condition."));
            //Room 4 modifications (Study)
            Rooms[4].Description = "";
            Rooms[4].LinkedRooms.Add("east", Rooms[1]);
            Rooms[4].Locked = true;
            Rooms[4].Items.Add(new Key("Key", "This is a copper key, used to open doors. But what door does it open?"));
            //Room 5 modifications (Dining Room)
            Rooms[5].Description = "";
            Rooms[5].LinkedRooms.Add("west", Rooms[1]);
            Rooms[5].LinkedRooms.Add("east", Rooms[6]);
            //Room 6 modifications (Kitchen)
            Rooms[6].Description = "";
            Rooms[6].LinkedRooms.Add("west", Rooms[5]);
            Rooms[6].Items.Add(new Food("Raw Beef", "Some raw beef, I wouldn't eat it"));
            //Room 7 modifications (Staircase)
            Rooms[7].Description = "";
            Rooms[7].LinkedRooms.Add("up", Rooms[8]);
            Rooms[7].LinkedRooms.Add("down", Rooms[1]);
            //Room 8 modifications (Upper hall)
            Rooms[8].Description = "";
            Rooms[8].LinkedRooms.Add("down", Rooms[7]);
            Rooms[8].LinkedRooms.Add("west", Rooms[9]);
            Rooms[8].LinkedRooms.Add("north", Rooms[11]);
            Rooms[8].LinkedRooms.Add("east", Rooms[13]);
            Rooms[8].LinkedRooms.Add("up", Rooms[14]);
            //Room 9 modifications (Master Bedroom)
            Rooms[9].Description = "";
            Rooms[9].LinkedRooms.Add("east", Rooms[8]);
            Rooms[9].LinkedRooms.Add("west", Rooms[10]);
            Rooms[9].Locked = true;
            Rooms[9].Enemy = new Enemy();
            //Room 10 modifications (Master Bathroom)
            Rooms[10].Description = "";
            Rooms[10].LinkedRooms.Add("east", Rooms[9]);
            Rooms[10].Items.Add(new Key("Key", "This is an iron key, used to open doors. But what door does it open?"));
            //Room 11 modifications (Guest Bedroom)
            Rooms[11].Description = "";
            Rooms[11].LinkedRooms.Add("south", Rooms[8]);
            Rooms[11].LinkedRooms.Add("north", Rooms[12]);
            //Room 12 modifications (Guest Bathroom)
            Rooms[12].Description = "";
            Rooms[12].LinkedRooms.Add("south", Rooms[11]);
            //Room 13 modifications (Utility closet)
            Rooms[13].Description = "";
            Rooms[13].LinkedRooms.Add("west", Rooms[8]);
            Rooms[13].Items.Add(new LightSource("Flashlight", "A  flashlight that still has batteries in it! You can use it to see in the dark"));
            //Room 14 modifications (Attic)
            Rooms[14].Description = "";
            Rooms[14].LinkedRooms.Add("down", Rooms[8]);
            Rooms[14].Items.Add(new Key("Lockpick set", "Tools that can be used to open some doors, if they are easy enough"));
        }

        //moves an item from the room to the inventory
        public bool PickUpItem(List<string> kw)
        {
            foreach (string keyword in kw)
            {
                foreach (Item i in CurrentRoom.Items)
                {
                    if (keyword.Contains(i.Name.ToLower()))
                    {
                        Console.WriteLine("I picked the " + i.Name + " up. " + i.Description);
                        CurrentRoom.Items.Remove(i);
                        player.Inventory.Add(i);
                        return true;
                    }
                }
            }
            return false;
        }

        //iterates over the keywords and LookAound property for matches
        public bool LookAroundRoom(List<string> kw)
        {
            foreach (string keyword in kw)
            {
                foreach (var dict in CurrentRoom.LookAround)
                {
                    if (keyword.Contains(dict.Key))
                    {
                        Console.WriteLine(dict.Value);
                        return true;
                    }

                }

            }
            return false;
        }

        //change current room
        public void ChangeCurrentRoom(string Direction)
        {
            if (CurrentRoom.LinkedRooms.ContainsKey(Direction))
            {
                if (CurrentRoom.LinkedRooms[Direction].Locked)
                {
                    Console.WriteLine("I tried to open the door, but it is locked. I'll need to do something else.");
                    return;
                }
                if (Direction == "up")
                    Console.WriteLine("I took the door to the floor above me.");
                else if (Direction == "down")
                    Console.WriteLine("I took the door to the floor beneat me.");
                else
                    Console.WriteLine("I took the door to the " + Direction + ".");
                CurrentRoom = CurrentRoom.LinkedRooms[Direction];
                Console.WriteLine(CurrentRoom.Description);
                return;
            }
            Console.WriteLine("There is no door in this direction...");
            return;
        }

    }
}
