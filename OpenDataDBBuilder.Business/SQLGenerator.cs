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

        public static String insertRowsPreview(TableList tablesList)
        {
            return SQLGenerator.getSQLRows(tablesList, 10);
        }

        public static String insertRows(TableList tablesList)
        {
            return SQLGenerator.getSQLRows(tablesList, -1);
        }

        private static String getSQLRows(TableList tablesList, int limit)
        {
            StringBuilder sql = new StringBuilder();

            foreach (Table t in tablesList.Tables)
            {
                List<Column> columnsExcluded = t.getListColumnsExcluded();
                
                List<String> columnNames = t.columnNames();
                if ((columnNames != null && columnNames.Count > 0)
                    && (t.Rows != null && t.Rows.Count > 0))
                {
                    sql.Append("INSERT INTO " + t.TableName);
                    sql.Append("(");
                    sql.Append(t.columnNames()[0]);
                    for (int i = 1; i < t.columnNames().Count(); i++)
                        sql.Append("," + t.columnNames()[i]);
                    sql.Append(") ");
                    sql.Append(Environment.NewLine);
                    sql.Append("VALUES ");
                    sql.Append(Environment.NewLine);
                    sql.Append("(" + t.Rows[0].ToString(columnsExcluded) + ")");
                    if (limit > -1)
                    {
                        for (int i = 1; i < limit && i < t.Rows.Count; i++)
                        {
                            sql.Append(", " + Environment.NewLine + "(" + t.Rows[i].ToString(columnsExcluded) + ")");
                        }
                        sql.Append(";");
                    }
                    else
                    {
                        for (int i = 1; i < t.Rows.Count; i++)
                        {
                            sql.Append(", " + Environment.NewLine + "(" + t.Rows[i].ToString(columnsExcluded) + ")");
                        }
                        sql.Append(";");
                    }
                }
            }

            return sql.ToString();
        }
        public static void prepareTablesSQL(ref List<Table> tables)
        {
            foreach (Table t in tables)
            {
                StringBuilder sql = new StringBuilder("CREATE TABLE " + t.TableName + " (\n");
                StringBuilder sqlConstraints = new StringBuilder();
                StringBuilder sqlConstraintsPK = new StringBuilder();
                List<String> pks = new List<String>();
                for (int i = 0; i < t.Columns.Count; i++)
                {
                    if (!t.Columns.ElementAt(i).SKIP)
                    {
                        if (sql.Length > ("CREATE TABLE " + t.TableName + " (\n").Length)
                            sql.Append(",\n");                        
                        sql.Append(t.Columns.ElementAt(i).ColumnName + " " + t.Columns.ElementAt(i).sqlType);
                        if (t.Columns.ElementAt(i).IsPK)
                        {
                            pks.Add(t.Columns.ElementAt(i).ColumnName);
                        }
                        if (!t.Columns.ElementAt(i).IsNullable)
                            sql.Append(" NOT NULL ");
                        if (t.Columns.ElementAt(i).IsUnique)
                            sql.Append(" UNIQUE ");
                        if (t.Columns.ElementAt(i).defaulValue != null && !"".Equals(t.Columns.ElementAt(i).defaulValue))
                            sql.Append(" DEFAULT '" + t.Columns.ElementAt(i).defaulValue + "' ");
                        if (t.Columns.ElementAt(i).IsFK)
                        {
                            sqlConstraints.Append(",\n");
                            sqlConstraints.Append("FOREIGN KEY ("+t.Columns.ElementAt(i).ColumnName+") ");
                            sqlConstraints.Append("REFERENCES " + t.Columns.ElementAt(i).Reference.Key + "(");
                            sqlConstraints.Append(t.Columns.ElementAt(i).Reference.Value + ")");
                        }
                    }
                   
                }
                sql.Append(sqlConstraints.ToString());
                sql.Append("\n);\n");
                int countPK = 0;
                foreach (String pk in pks)
                {
                    countPK++;
                    if (countPK > 1)
                        sqlConstraintsPK.Append(",");
                    else
                        sqlConstraintsPK.Append("ALTER TABLE "+t.TableName+ " ADD PRIMARY KEY(");
                    sqlConstraintsPK.Append(pk);
                }
                if (countPK > 0)
                    sqlConstraintsPK.Append(");");
                sql.Append(sqlConstraintsPK.ToString());
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

        public static String getTableRows(String dataBase, String tableName, Int16 limit)
        {
            StringBuilder sql = new StringBuilder(useDataBase(dataBase));
            sql.Append("SELECT * FROM " + tableName);
            sql.Append(" LIMIT " + limit + ";");
            return sql.ToString();
        }

        public static String dropTable(string tableName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DROP TABLE "+ tableName + ";");
            return sql.ToString();
        }

        public static String insertRow(List<Column> excludedColumns, Row r)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("(" + r.ToString(excludedColumns) + ");");
            return sql.ToString();
        }

        public static String getInsertStart(Table t)
        {
            StringBuilder sql = new StringBuilder();
            List<String> columnNames = t.columnNames();
            if ((columnNames != null && columnNames.Count > 0)
                && (t.Rows != null && t.Rows.Count > 0))
            {
                sql.Append("INSERT INTO " + t.TableName);
                sql.Append("(");
                sql.Append(t.columnNames()[0]);
                for (int i = 1; i < t.columnNames().Count(); i++)
                    sql.Append("," + t.columnNames()[i]);
                sql.Append(") ");
                sql.Append(Environment.NewLine);
                sql.Append("VALUES ");
                sql.Append(Environment.NewLine);
            }
            return sql.ToString();
        }
    }
}
