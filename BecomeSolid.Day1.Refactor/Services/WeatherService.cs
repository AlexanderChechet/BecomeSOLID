using BecomeSolid.Day1.Refactor.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Refactor.Services
{
    public class WeatherService
    {
        private ILogger logger;
        private string address = "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric";
        private string weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";

        public WeatherService(ILogger logger)
        {
            this.logger = logger;
        }

        public Weather GetWeatherInCity(string city)
        {
            WebUtility.UrlEncode(city);
            WebRequest request = WebRequest.Create(string.Format(address, city, weatherApiKey));
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();
                
                logger.Info(responseString);

                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

                return new Weather() 
                {
                    Description = weatherResponse.Weather.First().Description,
                    Temperature = weatherResponse.Main.Temp,
                    Name = weatherResponse.Name
                };
            }
        }
    }
}
