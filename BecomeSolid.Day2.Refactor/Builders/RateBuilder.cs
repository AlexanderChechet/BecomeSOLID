using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day2.Refactor.Builders
{
    public class RateBuilder
    {
        private List<string> rates;
        private DateTime date;

        public RateBuilder()
        {
            rates = new List<string>();
        }

        public RateBuilder WithRates(List<string> rates)
        {
            this.rates = rates;
            return this;
        }

        public RateBuilder WithRate(string rate)
        {
            rates.Add(rate);
            return this;
        }

        public RateBuilder OnDate(DateTime date)
        {
            this.date = date;
            return this;
        }

        public string Build()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine(date.ToShortDateString());
            foreach (var rate in rates)
            {
                strBuilder.AppendLine(rate);
            }
            return strBuilder.ToString();
        }
    }
}
