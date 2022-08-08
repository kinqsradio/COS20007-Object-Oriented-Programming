using System;

namespace CounterTask
{
    public class Program
    {
        private static void PrintCounters(Counter[] counters)
        {
            foreach(Counter c in counters)
            {
                //Console.WriteLine(c.Name + " is " +c.Tick);
                Console.WriteLine("{0} is {1}" ,c.Name, c.Tick);

            }
        }

        public static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];
            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            for (int i=0; i<=9; i++)
            {
                myCounters[0].Increment();
            }
            for (int i = 0; i <= 14; i++)
            {
                myCounters[1].Increment();
            }

            PrintCounters(myCounters);
            Console.ReadLine();
            myCounters[2].Reset();
            PrintCounters(myCounters);
            Console.ReadLine();


        }
    }
}

