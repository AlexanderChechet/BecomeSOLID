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
    public class DefaultCommand : ICommand
    {
        private ILogger logger;

        public DefaultCommand(ILogger logger)
        {
            this.logger = logger;
        }

        public async void Execute(Dictionary<string, object> context)
        {
            var bot = context["bot"] as Api;
            var update = context["update"] as Update;

            await bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
            await Task.Delay(2000);
            var t = await bot.SendTextMessage(update.Message.Chat.Id, update.Message.Text);

            logger.Info(string.Format("Echo Message: {0}", update.Message.Text));
        }

        public bool IsApplicable(Dictionary<string, object> context)
        {
            return true;
        }
    }
}
