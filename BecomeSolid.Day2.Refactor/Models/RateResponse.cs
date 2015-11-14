using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day2.Refactor.Models.Response;

namespace BecomeSolid.Day2.Refactor.Models
{
    public class RateResponse
    {
        [JsonProperty("query")]
        public Query Query { get; set; }
    }
}
