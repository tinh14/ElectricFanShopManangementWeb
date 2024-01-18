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
            string sql = "insert into Log (username, timestamp, ip, deviceInfo) "
                 +"values (@username, @timestamp, @ip, @deviceInfo)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@username", log.username),
                new SqlParameter("@timestamp", log.timestamp),
                new SqlParameter("@ip", log.ip),
                new SqlParameter("@deviceInfo", log.deviceInfo),
            };
            return DatabaseQueryExecutor.executeScalar(sql, parameters);
        }
    }
}