using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot
{
    public abstract class Strategy
    {
        public abstract string SendSummary(List<int> numbers);
    }
}
