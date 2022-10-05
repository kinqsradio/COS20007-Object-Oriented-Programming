using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Program
    {
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

            Console.Write("\nSetting up player:\nPlayer Name: ");
            name = Console.ReadLine();
            Console.Write("Player Description: ");
            desc = Console.ReadLine();
            Player player = new Player(name, desc);
            Console.Write("\n");
			//End setting up player

			//Set up location

			Location myroom = new Location("My Room", "My room");
            player.Location = myroom; //set up player initial location

            Location gamingroom = new Location("Gaming room", "Gaming room");
            Path myroom2gamingroom = new Path(new string[] { "north" }, "Door", "Travel through door", myroom, gamingroom);
			Path gamingroom2myroom = new Path(new string[] { "south" }, "Door", "Travel through door", gamingroom, myroom);
			myroom.AddPath(myroom2gamingroom);
            gamingroom.AddPath(gamingroom2myroom);

			Location livingroom = new Location("Livingroom", "Livingroom");
			Path myroom2livingroom = new Path(new string[] { "down" }, "Door", "Travel through door", myroom, livingroom);
			Path livingroom2myroom = new Path(new string[] { "up" }, "Door", "Travel through door", livingroom, myroom);
			myroom.AddPath(myroom2livingroom);
            livingroom.AddPath(livingroom2myroom);




			//End set up location

			//Setting up list of items

			Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
            Item diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");
            Item monitor = new Item(new string[] { "monitor" }, "a monitor", "This is a monitor");
            Item computer = new Item(new string[] { "computer" }, "a computer", "This is a computer");
            Item phone = new Item(new string[] { "phone" }, "a diamond", "This is a phone");

            //End setting up list of items

            //Location items

            myroom.Inventory.Put(phone);

			gamingroom.Inventory.Put(monitor);
			gamingroom.Inventory.Put(computer);


			//End location items

			//Setting up inventory

			Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.Inventory.Put(bag);
            bag.Inventory.Put(diamond);

            //End settign up inventory

            //Proccessing input command
            string _input;
			Command c = new CommandProcessor();
			Console.WriteLine(c.Execute(player, new string[] { "look" }));

			while (true)
			{
				Console.Write("Command: ");
				_input = Console.ReadLine();

				if (_input.ToLower() != "quit")
				{
					Console.WriteLine(c.Execute(player, _input.Split()));
				}
				else
				{
					Console.WriteLine("Bye");
					Console.ReadKey();
					break;
				}
			}

			//End Processing input command
		}
    }
}