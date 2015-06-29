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
            this.OriginalTableName = tableName;
        }

        public String TableName { get; set; }
        public String OriginalTableName { get; set; }
        public String SQLcreate { get; set; }
        public List<Column> Columns { get; set; }
        public List<Row> Rows { get; set; }

        public List<String> columnNames()
        {
            List<String> columnNames = new List<String>();
            foreach(Column c in this.Columns)
            {
                if(!c.SKIP)
                    columnNames.Add(c.ColumnName);
            }
            return columnNames.Count() != 0 ? columnNames : null;
        }


        internal List<Column> getListColumnsExcluded()
        {
            List<Column> columnsExcluded = new List<Column>();
            foreach (Column c in this.Columns)
            {
                if(c.SKIP)
                    columnsExcluded.Add(c);

            }
            return columnsExcluded.Count > 0 ? columnsExcluded : null;
        }
    }
}
