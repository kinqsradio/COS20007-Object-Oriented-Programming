using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Maths
{
    public class Divide : Strategy
    {
        public override string SendSummary(List<int> numbers)
        {
            string printSummary = $"Divide: {Div(numbers)}";
            return printSummary;
        }

        public bool active = true;

        public float Div(List<int> numbers)
        {
            float result = numbers[0];
            while (active)
            {
                result = numbers[0];
                numbers.RemoveAt(0);
                int i;
                for (i = 0; i < numbers.Count(); i++)
                {
                    float number = result;
                    result = (float)number / numbers[i];
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
