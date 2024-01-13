using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Database
{
    public class DatabaseConnectionProvider
    {
        private class DatabaseConfiguration
        {
            public static string LOCAL_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Projects\C# Projects\QuanLyShopBanQuatDien\QuanLyShopBanQuatDien\App_Data\QuanLyShopBanQuatDien.mdf;Integrated Security=True;User Instance=True";
        }

        public static SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection(DatabaseConfiguration.LOCAL_CONNECTION_STRING);
            con.Open();
            return con;
        }

        public static void closeConnection(SqlConnection con)
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}