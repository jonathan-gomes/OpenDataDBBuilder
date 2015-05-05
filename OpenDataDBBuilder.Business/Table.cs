using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataDBBuilder.Business.DB.VO
{
    public class Table
    {
        public Table() { }
        public Table(String tableName) 
        {
            this.TableName = tableName;
        }

        public String TableName { get; set; }
        public String SQLcreate { get; set; }
        public List<Column> Columns { get; set; }
        public List<Row> Rows { get; set; }

    }
}
