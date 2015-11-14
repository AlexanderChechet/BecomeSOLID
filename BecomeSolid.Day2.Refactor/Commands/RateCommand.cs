using BecomeSolid.Day2.Refactor.Builders;
using BecomeSolid.Day2.Refactor.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BecomeSolid.Day2.Refactor.Commands
{
    public class RateCommand : ICommand
    {
        private ILogger logger;
        private IRateService rateService;

        public RateCommand(ILogger logger, IRateService rateService)
        {
            this.logger = logger;
            this.rateService = rateService;
        }

        public async void Execute(CommandContext context)
        {
            var rateContext = context as RateContext;
            var rates = GetRatesFromMessage(rateContext.Update.Message.Text);
            var rate = rateService.GetRate(rates);

            var message = (new RateBuilder())
                .OnDate(rate.Date)
                .WithRates(rate.Rates)
                .Build();

            await rateContext.Bot.SendTextMessage(rateContext.Update.Message.Chat.Id, message);

            logger.Info(string.Format("Echo Message: {0}", message));
        }

        private string GetRatesFromMessage(string message)
        {
            var parts = message.Split(' ');
            string result = String.Empty;
            for (int i = 1; i < parts.Length; i++)
            {
                result += parts[i];
            }
            return result;
        }
    }
}
