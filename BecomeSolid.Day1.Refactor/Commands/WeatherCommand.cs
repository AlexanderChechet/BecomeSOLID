using BecomeSolid.Day1.Refactor.Builders;
using BecomeSolid.Day1.Refactor.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Refactor.Commands
{
    public class WeatherCommand : ICommand
    {
        private ILogger logger;
        private WeatherService weatherService;
        private WeatherMessageBuilder messageBuilder;

        public WeatherCommand(ILogger logger)
        {
            this.logger = logger;
            weatherService = new WeatherService(logger);
        }

        public async void Execute(Dictionary<string, object> context)
        {
            var bot = context["bot"] as Api;
            var update = context["update"] as Update;

            var inputMessage = update.Message.Text;
            var messageParts = inputMessage.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();

            var weather = weatherService.GetWeatherInCity(city);
            messageBuilder = new WeatherMessageBuilder(weather);
            var message = messageBuilder.Build();

            var t = await bot.SendTextMessage(update.Message.Chat.Id, message);

            logger.Info(string.Format("Echo Message: {0}", message));
        }

        public bool IsApplicable(Dictionary<string, object> context)
        {
            var update = context["update"] as Update;
            var messageText = update.Message.Text;
            var isTextMessage = update.Message.Type == MessageType.TextMessage;
            return isTextMessage && messageText.ToLowerInvariant().StartsWith("/weather");
        }
    }
}
