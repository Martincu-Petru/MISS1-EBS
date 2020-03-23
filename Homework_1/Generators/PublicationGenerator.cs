using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generate_Publishers_Subscribers.Data;
using Newtonsoft.Json;

namespace Generate_Publishers_Subscribers.Generators
{
    class PublicationGenerator
    {
        public void GeneratePublications()
        {
            var publicationConfig = new PublicationConfig();
            var numberOfPublications = publicationConfig.NumberOfPublications;
            var publications = new List<object>();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < numberOfPublications; i++)
            {
                var publication = new
                {
                    company = publicationConfig.GetRandomCompany(),
                    value = publicationConfig.GetRandomValue(),
                    drop = publicationConfig.GetRandomDrop(),
                    variation = publicationConfig.GetRandomVariation(),
                    date = publicationConfig.GetRandomDate()
                };
                publications.Add(publication);

                if (stringBuilder.Length >= 2)
                {
                    stringBuilder.Append("\n");
                }
                stringBuilder.Append("{");
                stringBuilder.Append($"(company,\"{publication.company}\");");
                stringBuilder.Append($"(value,{publication.value});");
                stringBuilder.Append($"(drop,{publication.drop});");
                stringBuilder.Append($"(variation,{publication.variation});");
                stringBuilder.Append($"(date,{publication.date});");
                stringBuilder.Append("}");
                stringBuilder.Remove(stringBuilder.Length - 2, 1);
            }

            System.IO.File.WriteAllText("publications.txt", stringBuilder.ToString());
            Console.WriteLine(stringBuilder.ToString());
            Console.WriteLine();
        }
    }
}
