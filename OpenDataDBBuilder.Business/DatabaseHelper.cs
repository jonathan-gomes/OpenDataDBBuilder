using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using OpenDataDBBuilder.DataRepository;
using OpenDataDBBuilder.DataRepository.Mysql;
using System.Windows.Forms;
using OpenDataDBBuilder.Business.File.Util;

using MySql.Data.MySqlClient;
using System.Configuration;

namespace OpenDataDBBuilder.Business.DB
{
    public class DatabaseHelper
    {
        String mysql = "MySQL";
        String db = "";
        DAO dao;
        public List<String> databases = new List<String>();
        

        public DatabaseHelper(String db)
        {
            this.db = db;
            this.dao = getDataBaseDAO();
            databases.Add(mysql);
        }

        public DAO getDataBaseDAO()
        {
            if (db.Equals(mysql))
            {
                MysqlDao dao = MysqlDao.getInstancy(readDBConfigFile());
                return dao;
            }
            return null;
        }

        public Boolean isConnectionAvailable(String database, String conn)
        {
            return dao.isConnectionAvailable(conn);
        }

        private String readDBConfigFile()
        {
            String appPath = Application.StartupPath;
            String dbConfigPath = appPath + "/DBConfig" + db + ".config";
            List<String> file = FileUtil.openFile(dbConfigPath);
            String config = "";

            foreach (String s in file)
            {
                config += s + ";";
            }
            return config;
        }

        public String addDatabase(String dataBase)
        {
            return dao.executeSQL(SQLGenerator.createDatabase(dataBase));
        }

        public List<String> selectDataBases()
        {
            return dao.selectDataBases(SQLGenerator.selectDataBases());
        }

        public List<String> getTablesFromDataBase(String dataBase)
        {
            return dao.getTablesFromDataBase(SQLGenerator.getTablesFromDataBase(dataBase));
        }

        public DataTable getTableDescription(String dataBase, String table)
        {
            return dao.getTableDescription(SQLGenerator.getTableDescription(dataBase, table));
        }

        public String runSQL(String sql)
        {
           return dao.executeSQL(sql);
        }
        public List<String> getFieldListFromDBTable(String dataBase, String table)
        {
            return dao.getFieldListFromDBTable(SQLGenerator.getTableDescription(dataBase, table));
        }
    }
}
