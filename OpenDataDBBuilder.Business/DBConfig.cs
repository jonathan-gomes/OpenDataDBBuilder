using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataDBBuilder.Business.VO
{
    public class DBConfig
    {
        public String Db { get; set; }
        public String Server { get; set; }
        public String Port { get; set; }
        public String User { get; set; }
        public String Password { get; set; }
        public String DbName { get; set; }

        public String getConnectionString()
        {
            StringBuilder conn = new StringBuilder("Server={0};Port={1};Database={2};Uid={3};Pwd={4};");
            conn.Replace("{0}", Server);
            conn.Replace("{1}", Port);
            conn.Replace("{2}", DbName);
            conn.Replace("{3}", User);
            conn.Replace("{4}", Password);
            return conn.ToString();
        }

        public String getConnectionStringNoDB()
        {
            StringBuilder conn = new StringBuilder("Server={0};Port={1};Uid={3};Pwd={4};");
            conn.Replace("{0}", Server);
            conn.Replace("{1}", Port);
            conn.Replace("{3}", User);
            conn.Replace("{4}", Password);
            return conn.ToString();
        }
    }
}
