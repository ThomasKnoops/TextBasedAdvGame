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
            //random dinges van SenneS
            Console.WriteLine("Hello World! ");
            string test = "woord1 woord2 woord3";
            Parser.ParseCommand(test, out List<String> keywords);
            foreach(var keyword in keywords)
            {
                Console.WriteLine(keyword);
            }

            //Creation of world
            World w = new World();

        }
    }
}
