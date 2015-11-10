using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Refactor
{
    public class CommandManager
    {
        private Dictionary<string, ICommand> commands;

        public CommandManager(ICommand defaultCommand)
        {
            commands = new Dictionary<string, ICommand>();
            commands.Add("/default", defaultCommand);
        }

        public void AddCommand(string name, ICommand command)
        {
            commands.Add(name, command);
        }

        public ICommand GetCommand(string message)
        {
            string name = string.Empty;
            message = message.TrimStart();
            message = message.ToLowerInvariant();
            if (message.StartsWith("/"))
            {
                var parts = message.Split(' ');
                name = parts[0];
            }

            ICommand result;
            commands.TryGetValue(name, out result);
            if (result == null)
                result = commands["/default"];
            return result;
        }
    }
}
