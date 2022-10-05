using System;
using System.Collections.Generic;
//using System.Linq;
using SemesterTest;

//2. Redesign and implement the AverageSummary and MinMaxSummary classes to be child classes of the new SummaryStrategy class. 
namespace SemesterTest
{
	public class AverageSummary:SummaryStrategy
	{
		public override void PrintSummary(List<int> numbers)
		{
			Console.WriteLine($"Average: {Average(numbers)}");
		}

		public float Average(List<int> numbers)
		{
			int sum = 0;
			for (int i = 0; i < numbers.Count; i++)
			{
				sum += numbers[i];
			}
			return (float)sum/numbers.Count;

			//Case, if allow to use:
			//return numbers.Average();
		}
	}
}
//End 2.

