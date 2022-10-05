using System;
using System.Collections.Generic;

namespace SemesterTest
{
	class Program
	{
		static void Main(string[] args)
		{
			MinMaxSummary minmaxstrate = new MinMaxSummary();
			AverageSummary averagesummary = new AverageSummary();

			Console.WriteLine("Tran Duc Anh Dang - 103995439 - Semester Test");
			//a) Create a DataAnalyser object with a list containing the individual digits of your student ID(so if your student ID was 12345, the list would contain the numbers 1, 2, 3, 4, and 5), and the minmax summary strategy.
			List<int> numbers = new List<int> {1,0,3,9,9,5,4,3,9}; //List of student id
			DataAnalyser dataanalyser = new DataAnalyser(minmaxstrate, numbers); //DataAnalyser object with minimax summary strategy

			//b) Call the Summarise method.
			dataanalyser.Summarise();

			//c) Add three more numbers to the data analyser.
			dataanalyser.AddNumbers(1000);
			dataanalyser.AddNumbers(2000);
			dataanalyser.AddNumbers(3000);

			//d) Set the summary strategy to the average strategy. 
			dataanalyser.Strategy = averagesummary;

			//e) Call the Summarise method. 
			dataanalyser.Summarise();
		}
	}
}

