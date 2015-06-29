using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenDataDBBuilder.Business.VO;
using OpenDataDBBuilder.Business.DB.VO;

namespace OpenDataDBBuilder.Business.File.Util
{
    public class TemplateFileUtil : FileUtil
    {
        String templateFilePath = "";
        public Template getTemplateFile(String templateFilePath)
        {
            this.templateFilePath = templateFilePath;
            List<String> file = openFile(this.templateFilePath);
            DBConfig dbConfig = new DBConfig();
            TableList tablelist = new TableList(new List<Table>());
            Table table = null;
            foreach (String s in file)
            {
                if (!s.Equals(""))
                {
                    if ("//".Equals(s))
                        tablelist.Tables.Add(table);
                    else
                    {
                        String key = s.Split('=')[0];
                        String value = s.Split('=')[1];

                        if ("Db".Equals(key))
                            dbConfig.Db = value;
                        if ("Server".Equals(key))
                            dbConfig.Server = value;
                        if ("Port".Equals(key))
                            dbConfig.Port = value;
                        if ("User".Equals(key))
                            dbConfig.User = value;
                        if ("Password".Equals(key))
                            dbConfig.Password = value;
                        if("DbName".Equals(key))
                            dbConfig.DbName = value;

                        if ("Table".Equals(key))
                        {
                            table = new Table();
                            table.OriginalTableName = value.Split(':')[0];
                            table.TableName = value.Split(':')[1];
                            table.Columns = new List<Column>();
                        }
                        if ("Column".Equals(key))
                        {
                            String columnNames = value.Split(';')[0];
                            String sqlType = value.Split(';')[1];
                            String pk = value.Split(';')[2];
                            String fk = value.Split(';')[3];
                            String nullabe = value.Split(';')[4];
                            String unique = value.Split(';')[5];
                            String defValue = value.Split(';')[6];
                            String defValueOnError = value.Split(';')[7];
                            String referenceDB = value.Split(';')[8];
                            String referenceTableColum = value.Split(';')[9];
                            String skip = value.Split(';')[10];

                            Column column = new Column(columnNames.Split(':')[0]);
                            column.ColumnName = columnNames.Split(':')[1] == null || columnNames.Split(':')[1].Equals("") ? column.ColumnName : columnNames.Split(':')[1];
                            column.sqlType = sqlType.Split(':')[1] == null || sqlType.Split(':')[1].Equals("") ? column.sqlType : sqlType.Split(':')[1];
                            column.IsPK = pk.Split(':')[1] != null && pk.Split(':')[1].ToLower().Equals("true");
                            column.IsFK = fk.Split(':')[1] != null && fk.Split(':')[1].ToLower().Equals("true");
                            column.IsNullable = nullabe.Split(':')[1] != null && nullabe.Split(':')[1].ToLower().Equals("true");
                            column.IsUnique = unique.Split(':')[1] != null && unique.Split(':')[1].ToLower().Equals("true");
                            column.defaulValue = defValue.Split(':')[1] != null ? defValue.Split(':')[1] : "";
                            column.defaulValueOnError = defValueOnError.Split(':')[1] != null ? defValueOnError.Split(':')[1] : "";
                            column.SKIP = skip.Split(':')[1] != null && skip.Split(':')[1].ToLower().Equals("true");

                            if (column.IsFK)
                                column.Reference = new VO.KeyValue(referenceDB.Split(':')[1], referenceTableColum.Split(':')[1]);
                            table.Columns.Add(column);
                        }
                    }
                }
            }
            return new Template(tablelist, dbConfig);
        }
        
        public void createTemplateFile(Template template, String templateFilePath)
        {
            StringBuilder builder = new StringBuilder();

            if (template != null)
            {
                if (template.DBconfig != null)
                {
                    builder.Append("Db=" + template.DBconfig.Db);
                    builder.Append(Environment.NewLine);
                    builder.Append("Server=" + template.DBconfig.Server);
                    builder.Append(Environment.NewLine);
                    builder.Append("Port=" + template.DBconfig.Port);
                    builder.Append(Environment.NewLine);
                    builder.Append("User=" + template.DBconfig.User);
                    builder.Append(Environment.NewLine);
                    builder.Append("Password=" + template.DBconfig.Password);
                    builder.Append(Environment.NewLine);
                    builder.Append("DbName=" + template.DBconfig.DbName);
                }
                else
                {
                    throw new Exception("No database conection details found!");
                }
                if (template.TableList != null && template.TableList.Tables != null && template.TableList.Tables.Count > 0)
                {
                    foreach (Table t in template.TableList.Tables)
                    {
                        builder.Append(Environment.NewLine);
                        builder.Append("Table="+t.OriginalTableName+":"+t.TableName);
                        foreach (Column c in t.Columns)
                        {
                            builder.Append(Environment.NewLine);
                            builder.Append("Column="+c.OriginalColumnName+":"+c.ColumnName+";");
                            builder.Append("type:" + c.sqlType + ";");
                            builder.Append("pk:" + c.IsPK.ToString() + ";");
                            builder.Append("fk:" + c.IsFK.ToString() + ";");
                            builder.Append("null:" + c.IsNullable.ToString() + ";");
                            builder.Append("unique:" + c.IsUnique.ToString() + ";");
                            builder.Append("defValue:" + c.defaulValue + ";");
                            builder.Append("defValueOnError:" + c.defaulValueOnError + ";");
                            String referenceDB = c.Reference != null && c.Reference.Key != null ? c.Reference.Key : "";
                            builder.Append("referenceDB:" + referenceDB + ";");
                            String referenceTableColum = c.Reference != null && c.Reference.Value != null ? c.Reference.Value.ToString() : "";
                            builder.Append("referenceTableColum:" + referenceTableColum + ";");
                            builder.Append("skip:" + c.SKIP.ToString() + ";");
                        }
                        builder.Append(Environment.NewLine);
                        builder.Append("//");
                    }
                }
            }
            createFile(templateFilePath, builder.ToString(), true);
        }
    }
}
