using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Generate_Publishers_Subscribers.Data
{
    class PublicationConfig
    {
        private readonly Random _random = new Random();
        public PublicationConfig()
        {
            XElement publications = XElement.Load("../../publications-config.xml");
            Companies = publications.Descendants("company").Select(x => x.Value);
            Dates = publications.Descendants("date").Select(x => x.Value);
            MinDrop = Double.Parse(publications.Element("drop").Element("min").Value);
            MaxDrop = Double.Parse(publications.Element("drop").Element("max").Value);
            MinValue = Double.Parse(publications.Element("value").Element("min").Value);
            MaxValue = Double.Parse(publications.Element("value").Element("max").Value);
            MinVariation = Double.Parse(publications.Element("variation").Element("min").Value);
            MaxVariation = Double.Parse(publications.Element("variation").Element("max").Value);
            NumberOfPublications = int.Parse(publications.Element("count").Value);
        }

        public IEnumerable<string> Companies { get; set; }

        public IEnumerable<string> Dates { get; set; }

        public double MinDrop { get; set; }

        public double MaxDrop { get; set; }

        public double MinValue { get; set; }

        public double MaxValue { get; set; }

        public double MinVariation { get; set; }

        public double MaxVariation { get; set; }
        public int NumberOfPublications { get; set; }

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
