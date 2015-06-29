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

        public String ToString(List<Column> excludedColumns)
        {
            StringBuilder row = new StringBuilder("");
            if (Values.Count > 0)
            {
                DateTime dateTime = new DateTime();
                dateTime.GetDateTimeFormats();
                for (int i = 0; i < Values.Count; i++)
                {
                    if (!isExcludedValue(excludedColumns, Values[i]))
                    {
                        if (row.Length > 0)
                            row.Append(",");
                        if (isValidValue(Values[i].Value.ToString()))
                        {
                            if (!isDate(Values[i].Value.ToString(), out dateTime))
                                row.Append("'" + Values[i].Value + "'");
                            else
                                row.Append("'" + dateTime.ToString("yyyy-MM-dd") + "'");
                        }
                        else
                        {
                            row.Append("NULL");
                        }
                    }
                }
            }
            return row.ToString();
        }

        private Boolean isDate(String date, out DateTime dateTime)
        {
            if (!date.Contains(':') && date.Length > 8)
                return DateTime.TryParse(date, out dateTime);
            else
            {
                dateTime = DateTime.UtcNow;
                return false;
            }
               
        }

        private Boolean isExcludedValue(List<Column> excludedColumns, KeyValue kv){
            if(excludedColumns != null)
            {
                foreach (Column c in excludedColumns)
                {
                    if (kv.Key.Equals(c.OriginalColumnName) || kv.Key.Equals(c.ColumnName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    
        private Boolean isValidValue(String value)
        {
            if (value != null && !value.Contains("#NE#") && !value.Contains("#NULL#"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
