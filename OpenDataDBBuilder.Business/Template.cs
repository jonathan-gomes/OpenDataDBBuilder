using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenDataDBBuilder.Business.DB.VO;

namespace OpenDataDBBuilder.Business.VO
{
    public class Template
    {
        public Template(TableList TableList, DBConfig DBconfig)
        {
            this.TableList = TableList;
            this.DBconfig = DBconfig;
        }
        public TableList TableList { get; set; }
        public DBConfig DBconfig { get; set; }
    }
}
