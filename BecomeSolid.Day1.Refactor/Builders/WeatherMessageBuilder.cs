using BecomeSolid.Day1.Refactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Refactor.Builders
{
    public class WeatherMessageBuilder
    {
        private Weather weather;

        public string Name 
        { 
            get { return weather.Name; }
            set { weather.Name = value; }
        }

        public string Description
        {
            get { return weather.Description; }
            set { weather.Description = value; }
        }

        public double Temperature
        {
            get { return weather.Temperature; }
            set { weather.Temperature = value; }
        }

        public WeatherMessageBuilder()
        {
            weather = new Weather();
        }

        public WeatherMessageBuilder(Weather weather)
        {
            this.weather = weather;
        }

        public string Build()
        {
            var message = "In " + weather.Name + " " + weather.Description + " and the temperature is " +
                          weather.Temperature.ToString("+#.#;-#.#") + "°C";
            return message;
        }
    }
}
