using BecomeSolid.Day2.Refactor.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day2.Refactor.Services
{
    public class RateService
    {
        private ILogger logger;
        private string address = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22{0}%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

        public RateService(ILogger logger)
        { 
            this.logger = logger;
        }

        public Rate GetRate(string money)
        {
            WebRequest request = WebRequest.Create(string.Format(address, money + ','));
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();

                logger.Info(responseString);

                RateResponse rateResponse = JsonConvert.DeserializeObject<RateResponse>(responseString);

                List<string> temp = new List<string>();
                foreach(var item in rateResponse.Query.Results.Rate)
                {
                    temp.Add(item.Name + " = " + item.Rate);
                }
                temp.RemoveAt(temp.Count - 1);
                return new Rate()
                {
                    Date = rateResponse.Query.Created,
                    Rates = temp
                };
            }
        }
    }
}
