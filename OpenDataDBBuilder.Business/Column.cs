using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDataDBBuilder.Business.VO;

namespace OpenDataDBBuilder.Business.DB.VO
{
    public class Column
    {
        public Column() { }
        public Column(String ColumnName) 
        {
            this.ColumnName = ColumnName;
            this.IsPK = false;
            this.IsFK = false;
            this.IsIDGenerated = false;
            this.sqlType = "VARCHAR(40)";
        }

        public Column(String ColumnName, Boolean IsPK, Boolean IsFK, Boolean IsIDGenerated, KeyValue Reference)
        {
            this.ColumnName = ColumnName;
            this.IsPK = IsPK;
            this.IsFK = IsFK;
            this.IsIDGenerated = IsIDGenerated;
            

            if (this.IsFK)
                if (Reference == null || "".Equals(Reference))
                    throw new Exception("NO REFERENCE ON FK");
                else
                    this.Reference = Reference;
        }


        public String ColumnName { get; set; }
        public Boolean IsPK { get; set; }
        public Boolean IsFK { get; set; }
        public Boolean IsIDGenerated { get; set; }
        public KeyValue Reference { get; set; }
        public String sqlType { get; set; }
    }
}
