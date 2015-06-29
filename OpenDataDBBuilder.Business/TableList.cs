using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataDBBuilder.Business.DB.VO
{
    public class TableList
    {
        public List<Table> Tables { get; set; }
        private List<String> tablesNames;

        public TableList(List<Table> Tables)
        {
            this.Tables = Tables;
           
        }

        public List<String> TablesNames
        {
            get
            {
                foreach (Table t in Tables)
                {
                    tablesNames = new List<String>();
                    tablesNames.Add(t.TableName);
                }
                return this.tablesNames;
            }
            set
            {
                this.tablesNames = value;  
            }
        }

        public static int getIndexColumnPerName(String name, Table table) 
        {
            for(int i = 0; i < table.Columns.Count;i++)
            {
                if(table.Columns[i].ColumnName.Equals(name))
                    return i;
            }
            return -1;
        }
    }
}
