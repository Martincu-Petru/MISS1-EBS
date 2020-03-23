using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generate_Publishers_Subscribers.Data;
using Generate_Publishers_Subscribers.Generators;

namespace Generate_Publishers_Subscribers
{
    class Program
    {
        static void Main(string[] args)
        {
            PublicationConfig publicationConfig = new PublicationConfig();
            PublicationGenerator publicationGenerator = new PublicationGenerator(); 
            publicationGenerator.GeneratePublications();
            SubscriptionGenerator subscriptionGenerator = new SubscriptionGenerator();
            subscriptionGenerator.GenerateSubscriptions();

        }
    }
}
