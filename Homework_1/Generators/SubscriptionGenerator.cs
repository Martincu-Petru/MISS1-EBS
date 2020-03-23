using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generate_Publishers_Subscribers.Data;
using Generate_Publishers_Subscribers.Models;
using Newtonsoft.Json;

namespace Generate_Publishers_Subscribers.Generators
{
    class SubscriptionGenerator
    {
        private readonly SubscriptionConfig _subscriptionConfig = new SubscriptionConfig();
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        private readonly List<string> stringOperator = new List<string>();
        private readonly List<string> numberOperator = new List<string>();
        public void GenerateSubscriptions()
        {
            stringOperator.Add("!=");
            stringOperator.Add("==");

            numberOperator.Add(">");
            numberOperator.Add("<");
            numberOperator.Add(">=");
            numberOperator.Add("<=");
            numberOperator.Add("==");
            numberOperator.Add("!=");

            var subscriptionConfig = new SubscriptionConfig();
            var numberOfSubscriptions = subscriptionConfig.NumberOfSubscriptions;
            var subscriptions = new List<Subscription>();
            var subscriptionsToFill = numberOfSubscriptions;

            for (int i = 0; i < numberOfSubscriptions; i++)
            {
                subscriptions.Add(new Subscription());
            }

            var companies = GenerateCompanies(_subscriptionConfig.CompaniesFrequency);
            var values = GenerateValues(_subscriptionConfig.ValueFrequency);
            var drops = GenerateDrops(_subscriptionConfig.DropFrequency);
            var variations = GenerateVariations(_subscriptionConfig.VariationFrequency);
            var dates = GenerateDates(_subscriptionConfig.DatesFrequency);
            var remainingEqualOperatorFrequency = subscriptionConfig.EqualOperatorFrequency;

            foreach (var company in companies)
            {
                int index = _random.Next(subscriptions.Count);
                

                if (subscriptionsToFill > 0)
                {
                    while (subscriptions[index].Company != null || subscriptions[index].HasAtLeastOneField == true)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }
                else
                {
                    while (subscriptions[index].Company != null)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }

                
                if (remainingEqualOperatorFrequency > 0)
                {
                    subscriptions[index].Company = new CompanyModel(company, "==");
                    remainingEqualOperatorFrequency--;
                }
                else
                {
                    subscriptions[index].Company = new CompanyModel(company, GenerateRandomStringOperator());
                }

                subscriptions[index].HasAtLeastOneField = true;
                subscriptionsToFill--;
            }

            foreach (var value in values)
            {
                int index = _random.Next(subscriptions.Count);

                if (subscriptionsToFill > 0)
                {
                    while (subscriptions[index].Value != null || subscriptions[index].HasAtLeastOneField == true)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }
                else
                {
                    while (subscriptions[index].Value != null)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }

                subscriptions[index].Value = new ValueModel(value, GenerateRandomNumberOperator());

                subscriptions[index].HasAtLeastOneField = true;
                subscriptionsToFill--;
            }

            foreach (var drop in drops)
            {
                int index = _random.Next(subscriptions.Count);

                if (subscriptionsToFill > 0)
                {
                    while (subscriptions[index].Drop != null || subscriptions[index].HasAtLeastOneField == true)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }
                else
                {
                    while (subscriptions[index].Drop != null)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }

                subscriptions[index].Drop = new DropModel(drop, GenerateRandomNumberOperator());

                subscriptions[index].HasAtLeastOneField = true;
                subscriptionsToFill--;
            }

            foreach (var variation in variations)
            {
                int index = _random.Next(subscriptions.Count);

                if (subscriptionsToFill > 0)
                {
                    while (subscriptions[index].Variation != null || subscriptions[index].HasAtLeastOneField == true)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }
                else
                {
                    while (subscriptions[index].Variation != null)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }
                
                subscriptions[index].Variation = new VariationModel(variation, GenerateRandomNumberOperator());

                subscriptions[index].HasAtLeastOneField = true;
                subscriptionsToFill--;
            }

            foreach (var date in dates)
            {
                int index = _random.Next(subscriptions.Count);

                if (subscriptionsToFill > 0)
                {
                    while (subscriptions[index].Date != null || subscriptions[index].HasAtLeastOneField == true)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }
                else
                {
                    while (subscriptions[index].Date != null)
                    {
                        index = _random.Next(subscriptions.Count);
                    }
                }

                subscriptions[index].Date = new DateModel(date, GenerateRandomStringOperator());

                subscriptions[index].HasAtLeastOneField = true;
                subscriptionsToFill--;
            }
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var subscription in subscriptions)
            {
                if (stringBuilder.Length >= 2)
                {
                    stringBuilder.Append("\n");
                }
                stringBuilder.Append("{");
                if (subscription.Company != null)
                {
                    stringBuilder.Append($"(company,{subscription.Company.Operator},\"{subscription.Company.Value}\");");
                }
                if (subscription.Value != null)
                {
                    stringBuilder.Append($"(value,{subscription.Value.Operator},{subscription.Value.Value});");
                }
                if (subscription.Drop != null)
                {
                    stringBuilder.Append($"(drop,{subscription.Drop.Operator},{subscription.Drop.Value});");
                }
                if (subscription.Variation != null)
                {
                    stringBuilder.Append($"(variation,{subscription.Variation.Operator},{subscription.Variation.Value});");
                }
                if (subscription.Date != null)
                {
                    stringBuilder.Append($"(date,{subscription.Date.Operator},{subscription.Date.Value});");
                }
                stringBuilder.Append("}");
                stringBuilder.Remove(stringBuilder.Length - 2, 1);
            }
            System.IO.File.WriteAllText("subscriptions.txt", stringBuilder.ToString());
            Console.WriteLine(stringBuilder.ToString());
            Console.WriteLine();
        }

        public List<string> GenerateCompanies(int count)
        {
            List<string> companies = new List<string>();
            for (int i = 0; i < count; i++)
            {
                companies.Add(_subscriptionConfig.GetRandomCompany());
            }

            return companies;
        }

        public List<double> GenerateValues(int count)
        {
            List<double> values = new List<double>();
            for (int i = 0; i < count; i++)
            {
                values.Add(_subscriptionConfig.GetRandomValue());
            }

            return values;
        }

        public List<double> GenerateDrops(int count)
        {
            List<double> drops = new List<double>();
            for (int i = 0; i < count; i++)
            {
                drops.Add(_subscriptionConfig.GetRandomDrop());
            }

            return drops;
        }

        public List<double> GenerateVariations(int count)
        {
            List<double> variations = new List<double>();
            for (int i = 0; i < count; i++)
            {
                variations.Add(_subscriptionConfig.GetRandomVariation());
            }

            return variations;
        }

        public List<string> GenerateDates(int count)
        {
            List<string> dates = new List<string>();
            for (int i = 0; i < count; i++)
            {
                dates.Add(_subscriptionConfig.GetRandomDate());
            }

            return dates;
        }

        public string GenerateRandomStringOperator()
        {
            return stringOperator[_random.Next(stringOperator.Count)];
        }

        public string GenerateRandomNumberOperator()
        {
            return numberOperator[_random.Next(numberOperator.Count)];
        }
    }
}
