﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace OpenDataDBBuilder.DataRepository.Mysql
{
    public class MysqlDao : DAO
    {
        private static readonly MysqlDao mySQLInstancy = new MysqlDao();
        private static String Conn = "";
        private static MySqlConnection connectionKeepAlive;

        private MysqlDao() { }

        public static MysqlDao getInstancy(String conn)
        {
            Conn = conn;
            return mySQLInstancy;
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



        public List<String> selectDataBases(String sql)
        {
            List<String> databases = new List<String>();
            try
            {
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

        public void openDataBaseConn()
        {
            connectionKeepAlive = new MySqlConnection(Conn);
            connectionKeepAlive.Open();
        }
        public void closeDataBaseConn()
        {
            if (connectionKeepAlive != null)
                connectionKeepAlive.Close();
        }


        public String executeSQLConnectionKeepAlive(String sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, connectionKeepAlive);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        public object getOpenConnection()
        {
            MySqlConnection conn = new MySqlConnection(Conn);
            conn.Open();
            return conn;
        }
        public void closeConnection(object conn)
        {
            try
            {
                ((MySqlConnection)conn).Close();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void executeSQLConnectionKeepAlive(String sql, object conn)
        {
            MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)conn);
            cmd.ExecuteNonQuery();
        }

        public String executeSQL(String sql)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Conn);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteReader();
                connection.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        public List<String> getTablesFromDataBase(String sql)
        {
           return getFirstCollumnListFromSQLReturn(sql);
        }
        public List<String> getFieldListFromDBTable(String sql)
        {
            return getFirstCollumnListFromSQLReturn(sql);
        }
        public DataTable getDataTable(String sql)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlConnection connection = new MySqlConnection(Conn);
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                adapter.Fill(dt);
                
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Out.Write(ex.Message);
            }
            return dt;
        }

        List<String> getFirstCollumnListFromSQLReturn(String sql)
        {
            List<String> lines = new List<String>();
            try
            {
                MySqlConnection connection = new MySqlConnection(Conn);
                MySqlDataReader rdr = null;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lines.Add(rdr.GetString(0));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Out.Write(ex.Message);
            }
            return lines;
        }
    }

    
}
