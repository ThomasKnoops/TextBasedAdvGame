using AdventureLib;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creation of world with a name for the player
            Console.WriteLine("I wake up in a dark room. I don't know where I am, or how I got here. But do I still remember my name?");
            string Name = Console.ReadLine();
            World w = new World(Name);
            Console.WriteLine("Ah yes... My name is " + Name + ". Maybe I should start by looking around a little more.");
            Console.WriteLine(w.CurrentRoom.Description);
            bool playing = true; 

            //while playing == true --> spel is bezig
            while (playing)
            {
                Console.WriteLine("What will I do?");
                string input = Console.ReadLine();
                input = input.ToLower();
                if (input == "help" || input == "help me")
                    HelpMe();
                else if (input == "inv" || input == "inventory")
                    ShowInventory(w);
                else
                {
                    Parser.CommandType commandType = Parser.ParseCommand(input, out List<string> keywords);
                    switch (commandType)
                    {
                        case Parser.CommandType.Undefined:
                            Console.WriteLine("I don't know what to do with that...");
                            break;
                        case Parser.CommandType.Use:
                            //TODO
                            break;
                        case Parser.CommandType.Take:
                            TakeItem(keywords, w);
                            break;
                        case Parser.CommandType.Look:
                            LookAround(keywords, w);
                            break;
                        case Parser.CommandType.Move:
                            MoveAround(keywords, w);
                            break;
                        case Parser.CommandType.Exit:
                            playing = StopPlaying();
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }

        //prints out all the commands
        private static void HelpMe()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("I can do the follow things:");
            Console.WriteLine("     use [item] --> to use an item in my inventory.");
            Console.WriteLine("     take [item] --> to take an item from the room.");
            Console.WriteLine("     look [object/place] --> to get an better view.");
            Console.WriteLine("     move [north/east/south/west/up/down] --> to move into the specified direction.");
            Console.WriteLine("     exit --> to give up.");
            Console.WriteLine("     help --> to see this handy list;");
            Console.WriteLine("     inv --> to see my inventory");
            Console.WriteLine("---------------------------------------------------------------------------------------");

        }

        //show all the item the player has in its inventory
        private static void ShowInventory(World w)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            foreach (Item i in w.player.Inventory)
                Console.WriteLine(i.Name + ": " + i.Description);
            Console.WriteLine("---------------------------------------------------------------------------------------");
        }

        //Tries to take an item from the ground
        private static void TakeItem(List<string> kw, World w)
        {
            bool tookSomething = w.PickUpItem(kw);
            if (!tookSomething)
                Console.WriteLine("I could not pick that up.");
        }

        //gives extra info about the object you look at
        private static void LookAround(List<string> kw, World w)
        {
            bool sawSomething = w.LookAroundRoom(kw);
            if (!sawSomething)
                Console.WriteLine("I do not see anything special.");
        }

        //Move around in the world
        private static void MoveAround(List<string> kw, World w)
        {
            if (kw.Count > 1)
            {
                Console.WriteLine("I can only move in 1 direction at a time...");
                return;
            } else if (kw.Count < 1)
            {
                Console.WriteLine("That is just standing still... I need a direction to move to...");
                return;
            }
            if (kw[0] == "up" || kw[0] == "down" || kw[0] == "north" || kw[0] == "east" || kw[0] == "south" || kw[0] == "west")
            {
                w.ChangeCurrentRoom(kw[0]);
                return;
            }
            Console.WriteLine("I do not know which direction that is...");
            return;
        }

        //stops the game
        private static bool StopPlaying()
        {
            Console.WriteLine("Am I really gonna give up and die in here?");
            string inp = Console.ReadLine();
            inp = inp.ToLower();
            if (inp == "y" || inp == "yes" || inp == "yeah" || inp == "ja")
                return false;
            return true;
        }
    }
}
