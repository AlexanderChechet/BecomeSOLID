using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Refactor
{
    public interface ICommand
    {
        void Execute(Dictionary<string, object> context);

        bool IsApplicable(Dictionary<string, object> context);
    }
}
