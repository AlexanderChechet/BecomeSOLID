using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day2.Refactor.Models.Response
{
    public class Query
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("lang")]
        public string Lang { get; set; }
        [JsonProperty("results")]
        public Results Results { get; set; }
    }
}
