using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class ActivityLogMapper : RowMapper<ActivityLogEntity>
    {
        public ActivityLogEntity map(SqlDataReader reader)
        {
            ActivityLogEntity activityLog = new ActivityLogEntity();
            activityLog.id = reader.GetInt64(reader.GetOrdinal("id"));
            activityLog.username = reader.GetString(reader.GetOrdinal("username"));
            activityLog.timestamp = reader.GetDateTime(reader.GetOrdinal("timestamp"));
            activityLog.ip = reader.GetString(reader.GetOrdinal("ip"));
            activityLog.deviceInfo = reader.GetString(reader.GetOrdinal("deviceInfo"));
            activityLog.isSuccess = reader.GetBoolean(reader.GetOrdinal("isSuccess"));

            return activityLog;
        }
    }
}