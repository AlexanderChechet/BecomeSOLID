using BecomeSolid.Day2.Refactor.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day2.Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = LogManager.GetLogger("RateLogger");

            var service = new RateService(logger);
            var rate = service.GetRate("USDRUB,RUBUSD");
            Console.WriteLine(rate.Date.ToShortDateString());
            
            foreach(var item in rate.Rates)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
