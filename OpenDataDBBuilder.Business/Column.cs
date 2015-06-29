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
        public String ColumnName { get; set; }
        public String OriginalColumnName { get; set; }
        public Boolean IsPK { get; set; }
        public Boolean IsFK { get; set; }
        public Boolean IsIDGenerated { get; set; }
        public KeyValue Reference { get; set; }
        public String sqlType { get; set; }
        public Boolean IsNullable { get; set; }
        public Boolean IsUnique { get; set; }
        public Boolean SKIP { get; set; }
        public String defaulValue { get; set; }
        public String defaulValueOnError { get; set; }

        public Column()
        {
            this.IsPK = false;
            this.IsFK = false;
            this.SKIP = false;
        }
        public Column(String ColumnName) 
        {
            this.ColumnName = ColumnName;
            this.OriginalColumnName = ColumnName;
            this.IsPK = false;
            this.IsFK = false;
            this.SKIP = false;
            this.IsIDGenerated = false;
            this.sqlType = "VARCHAR(40)";
        }

        public Column(String ColumnName, Boolean IsPK, Boolean IsFK, Boolean IsIDGenerated, KeyValue Reference)
        {
            this.ColumnName = ColumnName;
            this.OriginalColumnName = ColumnName;
            this.IsPK = IsPK;
            this.IsFK = IsFK;
            this.IsIDGenerated = IsIDGenerated;
            this.defaulValue = "def";

            if (this.IsFK)
                if (Reference == null || "".Equals(Reference))
                    throw new Exception("NO REFERENCE ON FK");
                else
                    this.Reference = Reference;
        }
    }
}
