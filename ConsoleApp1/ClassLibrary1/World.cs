﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class World
    {
        private ROOMS CurrentRoom;
        private List<Room> Rooms = new List<Room>();
        private List<Item> Items = new List<Item>();
        private Player player;

        public World()
        {
            /*
            Items.Add(new Item(ITEMS.KEY_EXIT, "Key", "This is a copper key, used to open doors. But what door does it open?"));
            Items.Add(new Item(ITEMS.KEY_STUDY, "Key", "This is an iron key, used to open doors. But what door does it open?"));
            Items.Add(new Item(ITEMS.FLASHLIGHT, "Flashlight", "A  flashlight that still has batteries in it! You can use it to see in the dark"));
            Items.Add(new Item(ITEMS.ROPE, "Rope", "A 10 meter rope in good condition."));
            Items.Add(new Item(ITEMS.RAW_BEEF, "Raw Beef", "Some raw beef, I wouldn't eat it"));
            Items.Add(new Item(ITEMS))
            */






            Rooms.Add(new Room("Basement")); //Room 0
            //ROOMS.BASEMENT, "Basement", "", new List<ITEMS>("note"), new Dictionary<string, ROOMS> { { "east", ROOMS.GRAND_HALL } }, null)
            Rooms.Add(new Room("Grand Hall")); //Room 1
            //ROOMS.GRAND_HALL, "Grand Hall", "", null, new Dictionary<string, ROOMS> { { "west", ROOMS.BASEMENT }, {"north", ROOMS.STAIRCASE }, {"east1", ROOMS.DINING_ROOM }, {"east2", ROOMS.STUDY }, {"east3", ROOMS.YARD }, {"south", ROOMS.EXIT } }, null)
            Rooms.Add(new Room("Exit")); //Room 2
            //ROOMS.EXIT, "Exit", "", null, null, null)
            Rooms.Add(new Room("Yard")); //Room 3
            //ROOMS.YARD, "Yard", "", new List<ITEMS>() { ITEMS.ROPE }, new Dictionary<string, ROOMS> { { "north", ROOMS.GRAND_HALL } }, null)
            Rooms.Add(new Room("Study")); //Room 4
            //ROOMS.STUDY, "Study", "", new List<ITEMS>() { ITEMS.KEY_EXIT }, new Dictionary<string, ROOMS> { {"north",  ROOMS.GRAND_HALL } }, null)
            Rooms.Add(new Room("Dining Room")); //Room 5
            //ROOMS.DINING_ROOM, "Dinnig Room", "", null, new Dictionary<string, ROOMS> { { "west", ROOMS.GRAND_HALL }, {"east", ROOMS.KITCHEN }, null)
            Rooms.Add(new Room("Kitchen")); //Room 6
            //ROOMS.KITCHEN, "Kitchen", "", new List<ITEMS>() { ITEMS.RAW_BEEF }, new Dictionary<string, ROOMS> { { "west", ROOMS.DINING_ROOM } }, null)
            Rooms.Add(new Room("Staircase")); //Room 7
            //ROOMS.STAIRCASE, "Staircase", "", null, new Dictionary<string, ROOMS> { { "south", ROOMS.GRAND_HALL },{"north", ROOMS.UPPER_HALL}, null)
            Rooms.Add(new Room("Upper hall")); //Room 8
            //ROOMS.UPPER_HALL, "Upper Hall", "", null, new Dictionary<string, ROOMS> { { "south", ROOMS.STAIRCASE }, {"west", ROOMS.MASTER_BEDROOM }, {"north", ROOMS.SECOND_BEDROOM}, { "east", ROOMS.UTILITY_CLOSET },{"north2", ROOMS.ATTIC } }, null)
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

            //Room 0 modifications
            Rooms[0].Description = "";
            Rooms[0].Items.Add(//todo);
            //Room 1 modifications
            Rooms[1].Description = "";
            //Room 2 modifications
            Rooms[2].Description = "";
            //Room 3 modifications
            Rooms[3].Description = "";
            //Room 4 modifications
            Rooms[4].Description = "";
            //Room 5 modifications
            Rooms[5].Description = "";
            //Room 6 modifications
            Rooms[6].Description = "";
            //Room 7 modifications
            Rooms[7].Description = "";
            //Room 8 modifications
            Rooms[8].Description = "";
            //Room 9 modifications
            Rooms[9].Description = "";
            //Room 10 modifications
            Rooms[10].Description = "";
            //Room 11 modifications
            Rooms[11].Description = "";
            //Room 12 modifications
            Rooms[12].Description = "";
            //Room 13 modifications
            Rooms[13].Description = "";
            //Room 14 modifications
            Rooms[14].Description = "";


        }

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
    }
}
