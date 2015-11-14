using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BecomeSolid.Day2.Refactor.Commands
{
    public class RateContext : CommandContext
    {
        public Update Update { get; set; }
    }
}
