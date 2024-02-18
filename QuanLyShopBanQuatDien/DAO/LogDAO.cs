using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class LogDAO
    {
        public static Int64 create(LogEntity log)
        {
            string sql = "insert into Log (username, timestamp) "
                 +"values (@username, @timestamp)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@username", log.username),
                new SqlParameter("@timestamp", log.timestamp)
            };
            return DatabaseQueryExecutor.executeScalar(sql, parameters);
        }
    }
}