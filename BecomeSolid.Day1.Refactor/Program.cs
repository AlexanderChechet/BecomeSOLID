using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using BecomeSolid.Day1.Refactor.Models.Response;
using BecomeSolid.Day1.Refactor.Models;
using Newtonsoft.Json;
using BecomeSolid.Day1.Refactor.Services;
using NLog;
using BecomeSolid.Day1.Refactor.Commands;

namespace BecomeSolid.Day1.Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            ILogger logger = LogManager.GetLogger("WeatherLogger");
            
            var bot = new Api("153673700:AAEGCovvWRm_m86KSSGQrw3RTbczdixZ12Y");
            var me = await bot.GetMe();

            CommandManager manager = new CommandManager(new DefaultCommand(logger));
            manager.AddCommand("/weather", new WeatherCommand(logger));

            var welcomeString = string.Format("Hello my name is {0}", me.Username);
            logger.Info(welcomeString);
            Console.WriteLine(welcomeString);

            var offset = 0;

            while (true)
            {
                var updates = await bot.GetUpdates(offset);

                foreach (var update in updates)
                {
                    var context = new Dictionary<string, object>()
                    {
                        {"bot", bot},
                        {"update", update}
                    };

                    var command = manager.GetCommand(update.Message.Text);
                    if (command.IsApplicable(context))
                    {
                        command.Execute(context);
                    }

                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }
        }
    }
}
