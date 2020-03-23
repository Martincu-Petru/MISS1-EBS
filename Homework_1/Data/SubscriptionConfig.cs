using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Generate_Publishers_Subscribers.Data
{
    class SubscriptionConfig
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        public SubscriptionConfig()
        {
            XElement subscriptions = XElement.Load("../../subscriber-config.xml");
            Companies = subscriptions.Descendants("company").Select(x => x.Value);
            Dates = subscriptions.Descendants("date").Select(x => x.Value);
            MinDrop = Double.Parse(subscriptions.Element("drops").Element("min").Value);
            MaxDrop = Double.Parse(subscriptions.Element("drops").Element("max").Value);
            MinValue = Double.Parse(subscriptions.Element("values").Element("min").Value);
            MaxValue = Double.Parse(subscriptions.Element("values").Element("max").Value);
            MinVariation = Double.Parse(subscriptions.Element("variations").Element("min").Value);
            MaxVariation = Double.Parse(subscriptions.Element("variations").Element("max").Value);
            NumberOfSubscriptions = int.Parse(subscriptions.Element("count").Value);

            CompaniesFrequency = (int)Math.Ceiling(Double.Parse(subscriptions.Element("companies").Element("display-percentage").Value) * NumberOfSubscriptions);
            DatesFrequency = (int)Math.Ceiling(Double.Parse(subscriptions.Element("dates").Element("display-percentage").Value) * NumberOfSubscriptions);
            DropFrequency = (int)Math.Ceiling(Double.Parse(subscriptions.Element("drops").Element("display-percentage").Value) * NumberOfSubscriptions);
            ValueFrequency = (int)Math.Ceiling(Double.Parse(subscriptions.Element("values").Element("display-percentage").Value) * NumberOfSubscriptions);
            VariationFrequency = (int)Math.Ceiling(Double.Parse(subscriptions.Element("variations").Element("display-percentage").Value) * NumberOfSubscriptions);
            EqualOperatorFrequency = (int)Math.Ceiling(Double.Parse(subscriptions.Element("companies").Element("equal-operator-frequency").Value) * CompaniesFrequency);
        }

        public IEnumerable<string> Companies { get; set; }
        public int CompaniesFrequency { get; set; }
        public IEnumerable<string> Dates { get; set; }
        public int DatesFrequency { get; set; }
        public double MinDrop { get; set; }
        public double MaxDrop { get; set; }
        public int DropFrequency { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int ValueFrequency { get; set; }
        public double MinVariation { get; set; }
        public double MaxVariation { get; set; }
        public int VariationFrequency { get; set; }
        public int NumberOfSubscriptions { get; set; }
        public int EqualOperatorFrequency { get; set; }

        public string GetRandomCompany()
        {
            return Companies.ElementAt(_random.Next(Companies.Count() - 1));
        }

        public string GetRandomDate()
        {
            return Dates.ElementAt(_random.Next(Dates.Count() - 1));
        }

        public double GetRandomDrop()
        {
            return Truncate(_random.NextDouble() * (MaxDrop - MinDrop) + MinDrop);
        }

        public double GetRandomValue()
        {
            return Truncate(_random.NextDouble() * (MaxValue - MinValue) + MinValue);
        }

        public double GetRandomVariation()
        {
            return Truncate(_random.NextDouble() * (MaxVariation - MinVariation) + MinVariation);
        }

        public double Truncate(double value)
        {
            return Math.Truncate(100 * value) / 100;
        }
    }
}
