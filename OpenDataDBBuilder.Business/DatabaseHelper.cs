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
using System.Threading;
using System.Collections.Concurrent;
using OpenDataDBBuilder.Business.VO;

namespace OpenDataDBBuilder.Business.DB
{
    public class DatabaseHelper
    {
        Int16 nConnections;
        List<Thread> insertThreads = new List<Thread>();
        DBConfig dbconfig;
        String mysql = "MYSQL";
        DAO dao;
        String ret;
        public bool skip { get; set; }
        public String msgInserting { get; set; }
        public String LogInsert { get; set; }
        public ConcurrentQueue<String> RowsInsert { get; set; }
        int initialSize = 0;
        public Exception threadException { get; set; }

        public List<String> databases = new List<String>();
        

        public DatabaseHelper(DBConfig dbconfig)
        {
            this.dbconfig = dbconfig;
            RowsInsert = new ConcurrentQueue<String>();
            this.msgInserting = "";
            this.dao = getDataBaseDAO();
            skip = true;
            databases.Add(mysql);
        }

        public DAO getDataBaseDAO()
        {
            if (dbconfig.Db.ToUpper().Equals(mysql))
            {
                MysqlDao dao = MysqlDao.getInstancy(dbconfig.getConnectionStringNoDB());
                return dao;
            }
            return null;
        }

        public DAO getDataBaseDAODB()
        {
            if (dbconfig.Db.ToUpper().Equals(mysql))
            {
                MysqlDao dao = MysqlDao.getInstancy(dbconfig.getConnectionString());
                return dao;
            }
            return null;
        }

        public Boolean isConnectionAvailable(DBConfig dbconfig)
        {
            return dao.isConnectionAvailable(dbconfig.getConnectionString());
        }

        public Boolean isConnectionAvailableNoDB(DBConfig dbconfig)
        {
            return dao.isConnectionAvailable(dbconfig.getConnectionStringNoDB());
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
            return dao.getDataTable(SQLGenerator.getTableDescription(dataBase, table));
        }

        public String runSQL(String sql)
        {
           return dao.executeSQL(sql);
        }
        public List<String> getFieldListFromDBTable(String dataBase, String table)
        {
            return dao.getFieldListFromDBTable(SQLGenerator.getTableDescription(dataBase, table));
        }

        public DataTable getTableRows(String dataBase, String tableName, Int16 limit)
        {
            return dao.getDataTable(SQLGenerator.getTableRows(dataBase, tableName, limit));
        }

        public void insertRowsEnqueue(VO.TableList tablesList)
        {
            this.dao = getDataBaseDAODB();
            if (tablesList != null && tablesList.Tables != null && tablesList.Tables.Count > 0)
            {
               foreach(VO.Table t in tablesList.Tables)
                {
                    String insert = SQLGenerator.getInsertStart(t);
                                       
                    foreach(VO.Row r in t.Rows)
                    {
                        try
                        {
                            RowsInsert.Enqueue(insert + SQLGenerator.insertRow(t.getListColumnsExcluded(), r));
                        }
                        catch(Exception e)
                        {
                            Console.Write(e.Message);
                        }
                     }  
                }
               initialSize = RowsInsert.Count;
            }
        }

        public String insertRowsDequeue(Int16 nConnections)
        {   
            msgInserting = "";
            this.nConnections = nConnections;
            if (RowsInsert.Count > 0)
            {
              initiateInsertThreads();
            }
            return null;
        }

        public void initiateInsertThreads()
        {
             int count = 0;
             while (count <= nConnections)
             {
                 Thread thread  = new Thread(insertRowThread);
                 insertThreads.Add(thread);
                 count++;
             }

            foreach(Thread t in insertThreads)
            {
                t.Start();
            }
        }

        private void insertRowThread()
        {
            object conn = null;
            try
            {
                conn = dao.getOpenConnection();
            }
            catch (Exception ex)
            {
                threadException = ex;
            }

           
            while (RowsInsert.Count > 0)
            {
                int currentItem = initialSize - RowsInsert.Count > 0 ? (initialSize - RowsInsert.Count) + 1 : 1;
                msgInserting = currentItem + "/" + initialSize;
                String insert = "";
                try
                {
                    if (RowsInsert.TryDequeue(out insert))
                    {
                        dao.executeSQLConnectionKeepAlive(insert, conn);
                    }
                        
                }
                catch (Exception e)
                {
                    LogInsert += insert + "error:" + e.Message +Environment.NewLine;
                    msgInserting = e.Message;
                    Console.Write(e.Message);
                    if (!skip)
                    {
                        threadException = e;
                        break;
                    }
                        
                }
            }
            dao.closeConnection(conn);
        }
        public void terminateAllInsertThreads()
        {
            foreach (Thread t in insertThreads)
                t.Abort();
        }
        public string dropTable(string tableName)
        {
            return dao.executeSQL(SQLGenerator.dropTable(tableName));
        }
    }
}
