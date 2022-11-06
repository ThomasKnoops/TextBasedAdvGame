using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
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
            Rooms[0].Items.Add(new TextItem("Note", "It has some text written on it. Maybe I should read that.", "I have been stuck here for 3 days now. I tried every door and window of this house to escape. Nothing worked. I think that I'm gonna die in here. I just can't find the right Key..."));
            Rooms[0].LinkedRooms.Add("up", Rooms[1]);
            Rooms[0].LookAround.Add("bottle", "There are lots of bottles here, some are full and some are empty. I think that 1 of the empty bottles has a note in it!");
            Rooms[0].LookAround.Add("note", "I can't read the note without taking it out of the bottle.");
            //Room 1 modifications (Grand Hall)
            Rooms[1].Description = "This seems like a big hub. Let's find out what's behind these doors.";
            Rooms[1].LinkedRooms.Add("up", Rooms[8]);
            Rooms[1].LinkedRooms.Add("down", Rooms[0]);
            Rooms[1].LinkedRooms.Add("east", Rooms[5]);
            Rooms[1].LinkedRooms.Add("west", Rooms[4]);
            Rooms[1].LinkedRooms.Add("north", Rooms[3]);
            Rooms[1].LinkedRooms.Add("south", Rooms[2]);
            //Room 2 modifications (Exit)
            Rooms[2].Description = "Is this the exit?";
            Rooms[2].Locked = true;
            //Room 3 modifications (Yard)
            Rooms[3].Description = "Wow! This is the biggest yard I've seen in my whole life! There is a flower patch, shrubbery and a swimming pool!";
            Rooms[3].LinkedRooms.Add("south", Rooms[1]);
            Rooms[3].Items.Add(new UselessItem("Rope", "A 10 meter rope in good condition."));
            Rooms[3].LookAround.Add("shrubbery", "Between all the shrubbery is a long rope, maybe I can use it later on.");
            Rooms[3].LookAround.Add("flower", "There are all sort of flowers in all colors with a lot of bugs on them. I can't see anything usefull.");
            Rooms[3].LookAround.Add("pool", "The pool is completely dried up. The bottom of the pool is full with leaves.");
            //Room 4 modifications (Study)
            Rooms[4].Description = "There are so much books in this room, it seems like a study room. I see a beautiful desk in the middle of the room.";
            Rooms[4].LinkedRooms.Add("east", Rooms[1]);
            Rooms[4].Locked = true;
            Rooms[4].Items.Add(new Key("Key", "This is a copper key, used to open doors. But what door does it open?", Rooms[1], Rooms[2]));
            Rooms[4].LookAround.Add("desk", "Let me carefully check all the drawers and see what is inside. " +
                "..." +
                "In the last drawer I see something coppery that looks like a key.");
            Rooms[4].LookAround.Add("book", "I tried pulling at each book to open a secret entrance, like in the movies. But I didn't find anything... I have just been wasting my time.");
            //Room 5 modifications (Dining Room)
            Rooms[5].Description = "This looks like a dining room, there is a lot of leftovers on the table. There is a room to the left and one to the right.";
            Rooms[5].LinkedRooms.Add("west", Rooms[1]);
            Rooms[5].LinkedRooms.Add("east", Rooms[6]);
            Rooms[5].LookAround.Add("table", "I can only see some leftover vegetables. All are being swarmed by ants.");
            //Room 6 modifications (Kitchen)
            Rooms[6].Description = "I took the room to the right, which is definitely a kitchen, a dirty one in fact. There is even a piece of raw beef in a pan. Luckily the stove isn't on!" +
                "\n There is nothing else of interest in this room...";
            Rooms[6].LinkedRooms.Add("west", Rooms[5]);
            Rooms[6].Items.Add(new Food("Beef", "Some raw beef, I wouldn't eat it", true));
            //Room 7 modifications (Staircase)
            //Rooms[7].Description = "There is a lot of stairs... Should I go up or down?";
            //Rooms[7].LinkedRooms.Add("up", Rooms[8]);
            //Rooms[7].LinkedRooms.Add("down", Rooms[1]);
            //Room 8 modifications (Upper hall)
            Rooms[8].Description = "Wow! There are doors to each direction! What should I do next?";
            Rooms[8].LinkedRooms.Add("down", Rooms[1]);
            Rooms[8].LinkedRooms.Add("west", Rooms[9]);
            Rooms[8].LinkedRooms.Add("north", Rooms[11]);
            Rooms[8].LinkedRooms.Add("east", Rooms[13]);
            Rooms[8].LinkedRooms.Add("up", Rooms[14]);
            //Room 9 modifications (Master Bedroom)
            Rooms[9].Description = "A big bedroom, it is probably the bedroom of the owner of the house. Wow an angry dog! Watch out!";
            Rooms[9].LinkedRooms.Add("east", Rooms[8]);
            Rooms[9].LinkedRooms.Add("west", Rooms[10]);
            Rooms[9].Locked = true;
            Rooms[9].Enemy = new Enemy();
            Rooms[9].LookAround.Add("bed", "There is nothing hidden undernead the pillow or between the sheets.");
            //Room 10 modifications (Master Bathroom)
            Rooms[10].Description = "A big luxurious bathroom with a big tub in the middle. This must be the owner's bathroom. There is a medicin cabinet above the sink.";
            Rooms[10].LinkedRooms.Add("east", Rooms[9]);
            Rooms[10].Items.Add(new Key("Key", "This is an iron key, used to open doors. But what door does it open?", Rooms[1], Rooms[4]));
            Rooms[10].LookAround.Add("cabinet", "What do I see there? An iron key?");
            //Room 11 modifications (Guest Bedroom)
            Rooms[11].Description = "This is a small bedroom and there is a door right in front of me.";
            Rooms[11].LinkedRooms.Add("south", Rooms[8]);
            Rooms[11].LinkedRooms.Add("north", Rooms[12]);
            Rooms[11].LookAround.Add("bed", "There is nothing hidden undernead the pillow or between the sheets.");
            //Room 12 modifications (Guest Bathroom)
            Rooms[12].Description = "Just a small bathroom with a medicin cabinet above the sink, nothing else.";
            Rooms[12].LinkedRooms.Add("south", Rooms[11]);
            Rooms[12].LookAround.Add("cabinet", "What do I see there? nothing...");
            //Room 13 modifications (Utility closet)
            Rooms[13].Description = "A small room full of utility. Let mee see what I can find here..." +
                "Oh! A flashlight. ";
            Rooms[13].LinkedRooms.Add("west", Rooms[8]);
            Rooms[13].Items.Add(new LightSource("Flashlight", "A  flashlight that still has batteries in it! You can use it to see in the dark"));
            //Room 14 modifications (Attic)
            Rooms[14].Description = "I can not see a single thing in here... It is way to dark.";
            Rooms[14].LinkedRooms.Add("down", Rooms[8]);
            Rooms[14].Items.Add(new Key("Lockpick", "Tools that can be used to open some doors, if they are easy enough", Rooms[8], Rooms[9])); // TODO: Hoe moet de gebruiker weten dat er een lockpick zit in deze ruimte?
        }

        //Uses an Item
        public void UseIt(List<string> kw)
        {
            foreach (string keyword in kw)
            {
                foreach (Item i in player.Inventory)
                {
                    if (keyword.Contains(i.Name.ToLower())) 
                    {
                        i.UseMe(this);
                        return;
                    }
                }
            }
            Console.WriteLine("I do not have that item with me.");
        }

        //moves an item from the room to the inventory
        public bool PickUpItem(List<string> kw)
        {
            bool returntype = false;
            foreach (string keyword in kw)
            {
                foreach (Item i in CurrentRoom.Items)
                {
                    if (keyword.Contains(i.Name.ToLower()))
                    {
                        Console.WriteLine("I picked the " + i.Name + " up. " + i.Description);
                        CurrentRoom.Items.Remove(i);
                        player.Inventory.Add(i);
                        returntype = true;
                    }
                }
            }
            return returntype;
        }

        //iterates over the keywords and LookAound property for matches
        public bool LookAroundRoom(List<string> kw)
        {
            bool returntype = false;
            foreach (string keyword in kw)
            {
                foreach (var dict in CurrentRoom.LookAround)
                {
                    if (keyword.Contains(dict.Key))
                    {
                        Console.WriteLine(dict.Value);
                        returntype = true;
                    }

                }

            }
            return returntype;
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
                if (CurrentRoom.Enemy != null)
                {
                    if (Direction == "west")
                    {
                        if (!CurrentRoom.Enemy.Distracted)
                        {
                            Console.WriteLine("There is a bloodthirsty, starving dog between me and the next room. I can not safely get past him.");
                            return;
                        }
                    }
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
