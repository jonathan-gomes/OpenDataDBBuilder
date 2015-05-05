using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDataDBBuilder.Business.VO;

namespace OpenDataDBBuilder.Business.DB.VO
{
    public class Row
    {
        public Row(){}
        public List<KeyValue> Values { get; set; }
    }
}
