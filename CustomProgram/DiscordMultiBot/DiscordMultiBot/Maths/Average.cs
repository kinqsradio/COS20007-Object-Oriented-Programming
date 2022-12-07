using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Maths
{
    public class Average : Strategy
    {
        public override string SendSummary(List<int> numbers)
        {
            string printSummary = $"Average: {AverageCal(numbers)}";
            return printSummary;
        }

        public float AverageCal(List<int> numbers)
        {
            return (float)numbers.Average();
        }
    }
}
