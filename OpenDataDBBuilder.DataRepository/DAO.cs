using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataDBBuilder.DataRepository
{
    public interface DAO
    {
        Boolean isConnectionAvailable();
        Boolean isConnectionAvailable(String conn);
        List<String> selectDataBases();
        void addDatabase(String dataBase);
    }
}
