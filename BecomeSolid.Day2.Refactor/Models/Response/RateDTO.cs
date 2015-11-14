using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day2.Refactor.Models.Response
{
    public class RateDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Rate")]
        public string Rate { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("Ask")]
        public string Ask { get; set; }
        [JsonProperty("Bid")]
        public string Bid { get; set; }
    }
}
