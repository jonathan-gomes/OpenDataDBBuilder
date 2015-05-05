using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace OpenDataDBBuilder.DataRepository.Mysql
{
    public class MysqlDao : DAO
    {
        private static readonly MysqlDao mySQLInstancy = new MysqlDao();
        private static String Conn = "";

        private MysqlDao() { }

        public static MysqlDao getInstancy(String conn)
        {
            Conn = conn;
            return mySQLInstancy;
        }

        public Boolean isConnectionAvailable()
        {
            try
            {//Database=test;
                MySqlConnection conn = new MySqlConnection("Server=localhost;Port=3306;Uid=root;Pwd=root;");
                conn.Open();
                conn.Close();
                return true;
            }
            catch(Exception ex)
            {
                Console.Out.Write(ex.Message);
            }
            return false;
        }

        public Boolean isConnectionAvailable(String conn)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(conn);
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Out.Write(ex.Message);
            }
            return false;
        }

        public void addDatabase(String dataBase)
        {
            try
            {
                String sql = "CREATE DATABASE " + dataBase + ";";
                MySqlConnection connection = new MySqlConnection(Conn);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteReader();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Out.Write(ex.Message);
            }
        }


        public List<String> selectDataBases()
        {
            List<String> databases = new List<String>();
            try
            {
               
                String sql = "SHOW DATABASES;";
                MySqlConnection connection = new MySqlConnection(Conn);
                MySqlDataReader rdr = null;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    databases.Add(rdr.GetString(0));
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Out.Write(ex.Message);
            }
            return databases;
        }
    }
}
