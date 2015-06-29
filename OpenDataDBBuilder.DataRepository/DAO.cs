using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace OpenDataDBBuilder.DataRepository
{
    public interface DAO
    {
        Boolean isConnectionAvailable(String conn);
        List<String> selectDataBases(String sql);
        String executeSQL(String sql);
        List<String> getTablesFromDataBase(String sql);
        DataTable getDataTable(String sql);
        List<String> getFieldListFromDBTable(String sql);
        void openDataBaseConn();
        void closeDataBaseConn();
        void executeSQLConnectionKeepAlive(String sql, object conn);
        object getOpenConnection();
        void closeConnection(object conn);
    }
}
