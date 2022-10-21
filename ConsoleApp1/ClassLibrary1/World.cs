using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class World
    {
        private Room CurrentRoom;
        public List<Room> Rooms { get; private set; } 
        private Player player;

        public World()
        {
            GenerateRooms();
            AddRoomInfo();
            
        }

        /*
        private Room GetRoom(ROOMS room)
        {
            foreach(Room r in Rooms)
            {
                if(r.EnumName == room)
                {
                    return r;
                }
            }
            return null;
        }
        */

        public void GenerateRooms()
        {
            Rooms = new List<Room>();
            Rooms.Add(new Room("Basement")); //Room 0
            //ROOMS.BASEMENT, "Basement", "", new List<ITEMS>("note"), new Dictionary<string, ROOMS> { { "east", ROOMS.GRAND_HALL } }, null)
            Rooms.Add(new Room("Grand Hall")); //Room 1
            //ROOMS.GRAND_HALL, "Grand Hall", "", null, new Dictionary<string, ROOMS> { { "down", ROOMS.BASEMENT }, {"up", ROOMS.STAIRCASE }, {"east", ROOMS.DINING_ROOM }, {"west", ROOMS.STUDY }, {"north", ROOMS.YARD }, {"south", ROOMS.EXIT } }, null)
            Rooms.Add(new Room("Exit")); //Room 2
            //ROOMS.EXIT, "Exit", "", null, null, null)
            Rooms.Add(new Room("Yard")); //Room 3
            //ROOMS.YARD, "Yard", "", new List<ITEMS>() { ITEMS.ROPE }, new Dictionary<string, ROOMS> { { "south", ROOMS.GRAND_HALL } }, null)
            Rooms.Add(new Room("Study")); //Room 4
            //ROOMS.STUDY, "Study", "", new List<ITEMS>() { ITEMS.KEY_EXIT }, new Dictionary<string, ROOMS> { {"east",  ROOMS.GRAND_HALL } }, null)
            Rooms.Add(new Room("Dining Room")); //Room 5
            //ROOMS.DINING_ROOM, "Dinnig Room", "", null, new Dictionary<string, ROOMS> { { "west", ROOMS.GRAND_HALL }, {"east", ROOMS.KITCHEN }, null)
            Rooms.Add(new Room("Kitchen")); //Room 6
            //ROOMS.KITCHEN, "Kitchen", "", new List<ITEMS>() { ITEMS.RAW_BEEF }, new Dictionary<string, ROOMS> { { "west", ROOMS.DINING_ROOM } }, null)
            Rooms.Add(new Room("Staircase")); //Room 7
            //ROOMS.STAIRCASE, "Staircase", "", null, new Dictionary<string, ROOMS> { { "down", ROOMS.GRAND_HALL },{"up", ROOMS.UPPER_HALL}, null)
            Rooms.Add(new Room("Upper hall")); //Room 8
            //ROOMS.UPPER_HALL, "Upper Hall", "", null, new Dictionary<string, ROOMS> { { "down", ROOMS.STAIRCASE }, {"west", ROOMS.MASTER_BEDROOM }, {"north", ROOMS.SECOND_BEDROOM}, { "east", ROOMS.UTILITY_CLOSET },{"up", ROOMS.ATTIC } }, null)
            Rooms.Add(new Room("Master Bedroom")); //Room 9
            //ROOMS.MASTER_BEDROOM, "Master Bedroom", "", null, new List<ROOMS> { ROOMS.UPPER_HALL, ROOMS.MASTER_BATHROOM}, new Enemy())
            Rooms.Add(new Room("Master Bathroom")); //Room 10
            //ROOMS.MASTER_BATHROOM, "Master Bathroom", "", new List<ITEMS>() { ITEMS.KEY_STUDY }, new List<ROOMS> { ROOMS.MASTER_BEDROOM }, null)
            Rooms.Add(new Room("Guest Bedroom")); //Room 11
            //ROOMS.SECOND_BEDROOM, "Guest Bedroom", "", null, new List<ROOMS> { ROOMS.SECOND_BATHROOM, ROOMS.UPPER_HALL }, null)
            Rooms.Add(new Room("Guest Bathroom")); //Room 12
            //ROOMS.SECOND_BATHROOM, "Guest Bathroom", "", null, new List<ROOMS> { ROOMS.SECOND_BEDROOM}, null)
            Rooms.Add(new Room("Utility closet")); //Room 13
            //ROOMS.UTILITY_CLOSET, "Utility Closet", "", new List<ITEMS>() { ITEMS.FLASHLIGHT }, new List<ROOMS> { ROOMS.UPPER_HALL }, null)
            Rooms.Add(new Room("Attic")); //Room 14
            //ROOMS.ATTIC, "Attic", "", new List<ITEMS>() { ITEMS.LOCKPICK }, new List<ROOMS> { ROOMS.UPPER_HALL }, null)
        }

        public void AddRoomInfo()
        {
            //Room 0 modifications (Basement)
            Rooms[0].Description = "";
            Rooms[0].Items.Add(new TextItem("Note", "Help me! I'm stuck for 10 days already! If I could find the key, I could escape this murderhouse..."));
            Rooms[0].LinkedRooms.Add("up", Rooms[1]);
            //Room 1 modifications (Grand Hall)
            Rooms[1].Description = "";
            //Room 2 modifications (Exit)
            Rooms[2].Description = "";
            Rooms[2].Locked = true;
            //Room 3 modifications (Yard)
            Rooms[3].Description = "";
            Rooms[3].Items.Add(new UselessItem("Rope", "A 10 meter rope in good condition."));
            //Room 4 modifications (Study)
            Rooms[4].Description = "";
            Rooms[4].Locked = true;
            Rooms[4].Items.Add(new Key("Key", "This is a copper key, used to open doors. But what door does it open?"));
            //Room 5 modifications (Dining Room)
            Rooms[5].Description = "";
            //Room 6 modifications (Kitchen)
            Rooms[6].Description = "";
            Rooms[6].Items.Add(new Food("Raw Beef", "Some raw beef, I wouldn't eat it"));
            //Room 7 modifications (Staircase)
            Rooms[7].Description = "";
            //Room 8 modifications (Upper hall)
            Rooms[8].Description = "";
            //Room 9 modifications (Master Bedroom)
            Rooms[9].Description = "";
            Rooms[9].Locked = true;
            Rooms[9].Enemy = new Enemy();
            //Room 10 modifications (Master Bathroom)
            Rooms[10].Description = "";
            Rooms[10].Items.Add(new Key("Key", "This is an iron key, used to open doors. But what door does it open?"));
            //Room 11 modifications (Guest Bedroom)
            Rooms[11].Description = "";
            //Room 12 modifications (Guest Bathroom)
            Rooms[12].Description = "";
            //Room 13 modifications (Utility closet)
            Rooms[13].Description = "";
            Rooms[13].Items.Add(new LightSource("Flashlight", "A  flashlight that still has batteries in it! You can use it to see in the dark"));
            //Room 14 modifications (Attic)
            Rooms[14].Description = "";
            Rooms[14].Items.Add(new Key("Lockpick set", "Tools that can be used to open some doors, if they are easy enough"));
        }
    }
}
