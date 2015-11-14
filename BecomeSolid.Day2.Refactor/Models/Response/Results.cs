using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day2.Refactor.Models.Response
{
    public class Results
    {
        [JsonProperty("rate")]
        public List<RateDTO> Rate { get; set; }
    }
}
