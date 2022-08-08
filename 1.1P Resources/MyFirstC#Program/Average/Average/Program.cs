using System;
using System.Collections.Generic;

namespace Average
{
    class Program
    {
        
        public static void Average(int[] arr, int size)
        {
            int sum = 0; //Setting initialize for Sum = 0
            for (int i = 0; i < size; i++) //This loop adding all the numbers in the array
            {
                sum += arr[i];
            }
            float average = (float)sum / size;
            Console.WriteLine("Current average is: " + average);
            checking_double_digit(average);
        }

        static void checking_double_digit(float avg)
        {
            if(avg < 10)
            {
                Console.WriteLine("Single Digit");
            }
            else if (avg >= 10 && avg < 100)
            {
                Console.WriteLine("Double Digit");
            }
        }

        public static void Main(string[] args)
        {
            List<int> noList = new List<int>(); //Making new List
            while (true)
            {
                Console.WriteLine("Enter number");
                int no = Convert.ToInt32(Console.ReadLine()); //Turning String to Int
                noList.Add(no); //Adding input Number to List
                int[] no_arr = noList.ToArray(); //Converting List Arraay
                Average(no_arr, no_arr.Length); //Passing arguments to average Function
            }
        }
    }
}

