using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDataDBBuilder.Business.DB.VO;

namespace OpenDataDBBuilder.Business.DB
{
    public static class SQLGenerator
    {

        public static String createDatabase(String dataBase)
        {
            String sql = "CREATE DATABASE " + dataBase + ";";
            return sql;
        }

        public static String selectDataBases()
        {
            String sql = "SHOW DATABASES;";
            return sql;
        }


        public static void prepareTablesSQL(ref List<Table> tables)
        {
            foreach (Table t in tables)
            {
                StringBuilder sql = new StringBuilder("CREATE TABLE " + t.TableName + " (\n");
                StringBuilder sqlConstraints = new StringBuilder();
                for (int i = 0; i < t.Columns.Count; i++)
                {
                    sql.Append(t.Columns.ElementAt(i).ColumnName + " " + t.Columns.ElementAt(i).sqlType);
                    if (t.Columns.ElementAt(i).IsPK)
                         sql.Append(" PRIMARY KEY");
                    if (t.Columns.ElementAt(i).IsFK)
                    {
                        sqlConstraints.Append(",\n");
                        sqlConstraints.Append("FOREIGN KEY ("+t.Columns.ElementAt(i).ColumnName+") ");
                        sqlConstraints.Append("REFERENCES " + t.Columns.ElementAt(i).Reference.Key + "(");
                        sqlConstraints.Append(t.Columns.ElementAt(i).Reference.Value + ")");
                    }
                    if (i < t.Columns.Count - 1)
                        sql.Append(",\n");
                }
                sql.Append(sqlConstraints.ToString());
                sql.Append("\n);");
                t.SQLcreate = sql.ToString();
            }
        }

        public static String useDataBase(String dataBase)
        {
            return "USE " + dataBase + ";";
        }
        public static String getTablesFromDataBase(String dataBase)
        {
            StringBuilder sql = new StringBuilder(useDataBase(dataBase));
            sql.Append("SHOW TABLES;");
            return sql.ToString();
        }

        public static String getTableDescription(String dataBase, String table)
        {
            StringBuilder sql = new StringBuilder(useDataBase(dataBase));
            sql.Append("DESCRIBE "+table+";");
            return sql.ToString();
        }
    }
}
