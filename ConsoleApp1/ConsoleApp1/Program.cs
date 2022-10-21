using AdventureLib;
using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! ");
            string test = "woord1 woord2 woord3";
            Parser.ParseCommand(test, out List<String> keywords);
            foreach(var keyword in keywords)
            {
                Console.WriteLine(keyword);
            }

            World w = new World();
            foreach (Room x in w.Rooms)
            {
                Console.WriteLine(x.Name + " " + x.Locked);
                if (x.Items.Count > 0)
                {
                    Console.WriteLine("        Item: " + x.Items[0].Name);
                }
            }
        }
    }
}
