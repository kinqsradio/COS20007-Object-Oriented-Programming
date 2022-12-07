using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Maths
{
    public class Error : Strategy
    {
        public override string SendSummary(List<int> numbers)
        {
            string printSummary = "Please select a method:\n1. Average\n2. MinMax\n3. Sum\n4. Div\n5. Sub\nExample command: @Multibot maths sum 1 2 3 4 5 6 7 8 9";
            return printSummary;
        }
    }
}
