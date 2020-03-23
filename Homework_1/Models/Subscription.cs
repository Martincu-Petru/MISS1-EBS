using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Generate_Publishers_Subscribers.Models
{
    public class Subscription
    {
        public CompanyModel Company { get; set; }
        public ValueModel Value { get; set; }
        public DropModel Drop { get; set; }
        public VariationModel Variation { get; set; }
        public DateModel Date { get; set; }
        [JsonIgnore]
        public bool HasAtLeastOneField { get; set; }
    }
}
