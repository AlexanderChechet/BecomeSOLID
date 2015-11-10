using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Refactor.Models.Response
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
