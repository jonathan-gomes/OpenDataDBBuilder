using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.VO;
using OpenDataDBBuilder.Business.File.Util;

namespace OpenDataDBBuilder.Business
{
    public class TablesLayout
    {
        public String createNewTableLayout(TableList tablesList)
        {
            StringBuilder fileContent = new StringBuilder("");
            foreach (Table t in tablesList.Tables)
            {
                fileContent.Append(t.OriginalTableName + ":" + t.TableName + "\n");
                fileContent.Append("{\n");
                foreach (Column c in t.Columns)
                {
                    fileContent.Append(c.OriginalColumnName + ":" + c.ColumnName + ";");
                    fileContent.Append("PK:" + c.IsPK.ToString() + ";");
                    if (c.IsFK)
                    {
                        fileContent.Append("FK:" + c.IsFK.ToString() + ";");
                        fileContent.Append("ReferenceDB:" + c.Reference.Key + ";");
                        fileContent.Append("ReferenceTableColumn:" + c.Reference.Value.ToString() + ";");
                    }
                    fileContent.Append("\n");
                }
                fileContent.Append("}\n");
            }
            return fileContent.ToString();
        }

        public void readTableLayoutFile(String tableLayoutFilePath, ref TableList tablesList)
        {
            int countTable = 0;
            int countColumn = 0;

            foreach (String s in FileUtil.openFile(tableLayoutFilePath))
            {
                if (countTable == 0 && !s.Contains("Table1"))
                    return;
                if (!s.Equals("=="))
                {
                    List<String> values = s.Split(';').ToList();
                    if (values[0].Split(':')[0].Equals(tablesList.Tables[countTable].OriginalTableName))
                    {
                        if (values[0].Split(':')[1] != null && !values[0].Split(':')[1].Equals(""))
                        {
                            tablesList.Tables[countTable].TableName = values[1];
                        }
                    }
                    else if (values[0].Split(':')[0].Equals(tablesList.Tables[countTable].Columns[countColumn].OriginalColumnName))
                    {
                        if (values[0].Split(':')[1] != null && !values[0].Split(':')[1].Equals(""))
                            tablesList.Tables[countTable].Columns[countColumn].ColumnName = values[1];
                        if (values[1].Split(':')[0] != null && values[1].Split(':')[0].Equals("PK"))
                            if (values[1].Split(':')[1] != null)
                                tablesList.Tables[countTable].Columns[countColumn].IsPK = Boolean.Parse(values[1].Split(':')[1]);
                        if (values[2].Split(':')[0] != null && values[1].Split(':')[0].Equals("FK"))
                        {
                            if (values[2].Split(':')[1] != null)
                                tablesList.Tables[countTable].Columns[countColumn].IsPK = Boolean.Parse(values[2].Split(':')[1]);
                            if (tablesList.Tables[countTable].Columns[countColumn].IsPK)
                            {
                                KeyValue reference = new KeyValue();
                                if (values[3].Split(':')[0].Equals("ReferenceDB") && values[3].Split(':')[1] != null)
                                    reference.Key = values[3].Split(':')[1];
                                if (values[4].Split(':')[0].Equals("ReferenceTableColumn") && values[4].Split(':')[1] != null)
                                    reference.Value = values[4].Split(':')[1];
                            }
                            else
                            {
                                tablesList.Tables[countTable].Columns[countColumn].Reference = null;
                            }
                            countColumn++;
                        }
                    }
                }
                else
                {
                    countTable++;
                }
            }
        }
    }
}
