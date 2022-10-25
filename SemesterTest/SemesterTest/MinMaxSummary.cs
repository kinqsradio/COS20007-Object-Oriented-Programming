using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;


//2. Redesign and implement the AverageSummary and MinMaxSummary classes to be child classes of the new SummaryStrategy class. 
namespace SemesterTest
{
	public class MinMaxSummary:SummaryStrategy
	{
		public override void PrintSummary(List<int> numbers)
		{
			Console.WriteLine($"Minium:{Minimium(numbers)}\nMaximium:{Maximium(numbers)}");
		}

		private int Minimium(List<int> numbers)
		{
			//numbers.Sort(); I'm not too sure if it's possible using .Sort()? Otherwise the code below is no difference from .Sort()
            int result = numbers[0];
            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];
                if (number < result)
                    result = number;
            }
            return result;

            //Sort ascending
            //int temp = 0;
            //for (int i = 0; i <= numbers.Count - 1; i++)
            //{
            //	for (int j = i + 1; j < numbers.Count; j++)
            //	{
            //		if (numbers[i] > numbers[j])
            //		{
            //			temp = numbers[i];
            //			numbers[i] = numbers[j];
            //			numbers[j] = temp;
            //		}
            //	}
            //}
            //return numbers[0];

            //Case, if allow to use:
            //return numbers.Min();

        }

        private int Maximium(List<int> numbers)
		{
			//numbers.Sort(); I'm not too sure if it's possible using .Sort()? Otherwise the code below is no difference from .Sort()
            int result = numbers[0];
            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];
                if (number > result)
                    result = number;
            }
            return result;

            //Sort ascending
            //int temp = 0;
            //for (int i = 0; i <= numbers.Count - 1; i++)
            //{
            //	for (int j = i + 1; j < numbers.Count; j++)
            //	{
            //		if (numbers[i] > numbers[j])
            //		{
            //			temp = numbers[i];
            //			numbers[i] = numbers[j];
            //			numbers[j] = temp;
            //		}
            //	}
            //}
            //return numbers[numbers.Count - 1];

            //Descending can also be used down below.
            //for (int i = 0; i <= numbers.Count - 1; i++)
            //{
            //	for (int j = i + 1; j < numbers.Count; j++)
            //	{
            //		if (numbers[i] < numbers[j])
            //		{
            //			temp = numbers[i];
            //			numbers[i] = numbers[j];
            //			numbers[j] = temp;
            //		}
            //	}
            //}
            //return numbers[0];

            //Case, if allow to use:
            //return numbers.Max();
        }
    }
}
//End 2.

