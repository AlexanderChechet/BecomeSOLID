using BecomeSolid.Day2.Refactor.Builders;
using BecomeSolid.Day2.Refactor.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day2.Refactor.Commands;
using Telegram.Bot;

namespace BecomeSolid.Day2.Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            Api bot = new Api("153673700:AAEGCovvWRm_m86KSSGQrw3RTbczdixZ12Y");
            var me = await bot.GetMe();
            
            ILogger logger = LogManager.GetLogger("RateLogger");
            var welcomeString = string.Format("Hello my name is {0}", me.Username);
            logger.Info(welcomeString);
            Console.WriteLine(welcomeString);


            
            RateService service = new RateService(logger);

            ICommand command = new RateCommand(logger, service);

            var offset = 0;

            while (true)
            {
                var updates = await bot.GetUpdates(offset);

                foreach (var update in updates)
                {
                    var context = new RateContext()
                    {
                        Update = update,
                        Bot = bot
                    };
                    command.Execute(context);
                    
                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }
        }
    }
}
