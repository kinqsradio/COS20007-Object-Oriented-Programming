using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Maths
{
    public class Sum : Strategy
    {
        public override string SendSummary(List<int> numbers)
        {
            string printSummary = $"Sum: {Suming(numbers)}";
            return printSummary;
        }

        public float Suming(List<int> numbers)
        {
            return numbers.Sum();
        }
    }
}
