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
                + "on Log.id = ActivityLog.id "
                + "order by timestamp desc";

            return DatabaseQueryExecutor.executeQuery(sql, new ActivityLogMapper());
        }

        public static bool create(ActivityLogEntity activityLog)
        {
            string sql = "insert into ActivityLog values (@id, @isSuccess, @ip, @deviceInfo)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@id", activityLog.id),
                new SqlParameter("@isSuccess", activityLog.isSuccess),
                new SqlParameter("@ip", activityLog.ip),
                new SqlParameter("@deviceInfo", activityLog.deviceInfo)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static List<ActivityLogEntity> findByStartDateAndEndDate(DateTime startDate, DateTime endDate)
        {
            string sql = "select * from Log "
                + "inner join ActivityLog "
                + "on Log.id = ActivityLog.id "
                + "where timestamp between @startDate and @endDate "
                + "order by timestamp desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            };
            return DatabaseQueryExecutor.executeQuery(sql, new ActivityLogMapper(), parameters);
        }

        public static List<ActivityLogEntity> findById(long id)
        {
            string sql = "select * from Log "
                + "inner join ActivityLog "
                + "on Log.id = ActivityLog.id "
                + "where Log.id = @id "
                + "order by timestamp desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@id", id)
            };
            return DatabaseQueryExecutor.executeQuery(sql, new ActivityLogMapper(), parameters);
        }
    }
}