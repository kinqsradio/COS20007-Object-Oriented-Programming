using System;
using System.Collections.Generic;

namespace SemesterTest
{
    public class DataAnalyser
    {
        private List<int> _numbers;
        private SummaryStrategy _strategy; //3. Modify DataAnalyser to have a private variable, “_strategy”, that is of the type SummaryStrategy.


		//5. Modify the DataAnalyser constructors to:

		//a) allow the strategy to be set through a parameter

		public DataAnalyser(SummaryStrategy strategy):
			this(strategy, new List<int>())
		{
		}

		//Default when no value is passed => Average Strate
		public DataAnalyser():
			this(new AverageSummary(), new List<int>())
        {
        }
		//

		public DataAnalyser(List<int> numbers):
			this(new AverageSummary(), numbers)
		{
		}

		public DataAnalyser(SummaryStrategy strategy, List<int> numbers)
		{
			_strategy = strategy;
			_numbers = numbers;
		}

		//End 5.

		//4. Add a public property for this new private variable.
		public SummaryStrategy Strategy 
		{
			get => _strategy;
			set => _strategy = value;
		}
		//End 4.


		public void Summarise()
		{
			_strategy.PrintSummary(_numbers);
		}

		public void AddNumbers(int number)
		{
			_numbers.Add(number);
		}
	}
}

