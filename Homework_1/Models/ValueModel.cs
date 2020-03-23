using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Publishers_Subscribers.Models
{
    public class ValueModel
    {
        public double Value { get; set; }
        public string Operator { get; set; }

        public ValueModel(double value, string @operator)
        {
            Value = value;
            Operator = @operator;
        }
    }
}
