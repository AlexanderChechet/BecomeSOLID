using BecomeSolid.Day2.Refactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day2.Refactor.Services
{
    public interface IRateService
    {
        Rate GetRate(string money);
    } 
}
