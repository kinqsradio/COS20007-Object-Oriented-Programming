using System;

namespace HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            Message greetings;
            Message[] messages = {new Message("Welcome back!"),
                                new Message("What a lovely name"),
                                new Message("Great name"),
                                new Message("Oh hi!"),
                                new Message("That is a silly name")
                                };
            string name;

            greetings = new Message("Hello World - from Message Object");
            greetings.Print();

            while (true)
            {
                Console.WriteLine("Enter name: ");
                name = Console.ReadLine();
                if (name.ToLower() == "mark")
                {
                    messages[0].Print();
                }
                else if (name.ToLower() == "fred")
                {
                    messages[1].Print();
                }
                else if (name.ToLower() == "wilma")
                {
                    messages[2].Print();
                }
                else if (name.ToLower() == "alice")
                {
                    messages[3].Print();
                }
                else
                {
                    messages[4].Print();
                }
            }


        }
    }
}