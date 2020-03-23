using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Publishers_Subscribers.Models
{
    public class CompanyModel
    {
        public string Value { get; set; }
        public string Operator { get; set; }

        public CompanyModel(string value, string @operator)
        {
            Value = value;
            Operator = @operator;
        }
    }
}
