using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Maths
{
    public class MinMax : Strategy
    {
        public override string SendSummary(List<int> numbers)
        {
            string printSummary = $"Minium: {Minimium(numbers)}\nMaximium: {Maximium(numbers)}";
            return printSummary;
        }

        private int Minimium(List<int> numbers)
        {
            return numbers.Min();
        }

        private int Maximium(List<int> numbers)
        {
            return numbers.Max();
        }
    }
}
