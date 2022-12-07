using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Maths
{
    public class Subtract : Strategy
    {
        public override string SendSummary(List<int> numbers)
        {
            string printSummary = $"Subtract: {Sub(numbers)}";
            return printSummary;
        }

        public bool active = true;

        public float Sub(List<int> numbers)
        {
            int result = numbers[0];
            while (active)
            {
                result = numbers[0];
                numbers.RemoveAt(0);
                int i;
                for (i = 0; i < numbers.Count(); i++)
                {
                    int number = result;
                    result = number - numbers[i];
                }

                if (numbers.Count == 0)
                {
                    active = false;
                }
                return result;
            }
            return result;

        }
    }
}
