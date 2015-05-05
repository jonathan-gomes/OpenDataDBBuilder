using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDataDBBuilder.DataRepository;
using OpenDataDBBuilder.DataRepository.Mysql;
using System.Windows.Forms;
using OpenDataDBBuilder.Business.File.Util;

using MySql.Data.MySqlClient;
using System.Configuration;

namespace OpenDataDBBuilder.Business.DB
{
    public class DatabaseChooser
    {
        String mysql = "MySQL";
        public List<String> databases = new List<String>();
        

        public DatabaseChooser()
        {
            databases.Add(mysql);
        }

        public DAO getDataBaseDAO(String database)
        {
            if (database.Equals(mysql))
            {
                MysqlDao dao = MysqlDao.getInstancy(readDBConfigFile(database));
                return dao;
            }
            return null;
        }

        public Boolean isConnectionAvailable(String database)
        {
            DAO dao =  getDataBaseDAO(database);
            return dao.isConnectionAvailable();
        }
        public Boolean isConnectionAvailable(String database, String conn)
        {
            DAO dao = getDataBaseDAO(database);
            return dao.isConnectionAvailable(conn);
        }

        private String readDBConfigFile(String db)
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
    }
}
