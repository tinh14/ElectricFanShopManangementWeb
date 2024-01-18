using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class ActivityLogDAO
    {
        public static List<ActivityLogEntity> findAll()
        {
            string sql = "select * from Log "
                + "inner join ActivityLog "
                + "on Log.id = ActivityLog.id ";

            return DatabaseQueryExecutor.executeQuery(sql, new ActivityLogMapper());
        }

        public static bool create(ActivityLogEntity activityLog)
        {
            string sql = "insert into ActivityLog values (@id, @isSuccess)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@id", activityLog.id),
                new SqlParameter("@isSuccess", activityLog.isSuccess)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static List<ActivityLogEntity> findByStartDateAndEndDate(DateTime startDate, DateTime endDate)
        {
            string sql = "select * from Log "
                + "inner join ActivityLog "
                + "on Log.id = ActivityLog.id "
                + "where timestamp between @startDate and @endDate";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            };
            return DatabaseQueryExecutor.executeQuery(sql, new ActivityLogMapper(), parameters);
        }
    }
}