using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Program
    {
        static void LookCommandExe(Command l, string input, Player player)
        {
            Console.WriteLine(l.Execute(player, input.Split()));

        }

        static void Main(string[] args)
        {
            //Greeting + info
            string name, desc;
            string help = "-look\n\nGetting list of item:\n-look at me\n-look at bag\n\nGetting item description:\nlook at {item}\nlook at {item} in me\nlook at {item} in bag\n\n";

            Message greetings;
            greetings = new Message("Welcome to SwinAdventure\n\nHere are some helpful command:\n-look\n\nGetting list of item:\n-look at me\n-look at bag\n\nGetting item description:\nlook at {item}\nlook at {item} in me\nlook at {item} in bag");
            greetings.Print();
            Console.WriteLine("Press anything to continue...");
            Console.ReadLine();

            //End Greeting + info

            //Setting up player

            Console.Write("Setting up plater:\nPlayer Name: ");
            name = Console.ReadLine();
            Console.Write("Player Description: ");
            desc = Console.ReadLine();
            Player player = new Player(name, desc);

            //End setting up player

            //Setting up list of items

            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
            Item diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");


            //End setting up list of items

            //Setting up inventory

            Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.Inventory.Put(bag);
            bag.Inventory.Put(diamond);

            //End settign up inventory

            //Proccessing input command
            string _input;
            Command l = new LookCommand();

            while (true)
            {
                Console.Write("Command: ");
                _input = Console.ReadLine();
                if (_input == "quit")
                {
                    break;
                }else if (_input == "help")
                {
                    Console.Write(help);
                }
                else
                {
                    LookCommandExe(l, _input, player);
                }

            }

            //End Processing input command
        }
    }
}