using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataDBBuilder.Business.VO
{
    public class KeyValue
    {
        public KeyValue() { }

        public KeyValue(String key, Object value) 
        {
            this.Key = key;
            this.Value = value;
        }
        public String Key { get; set; }
        public Object Value { get; set; }
    }
}
