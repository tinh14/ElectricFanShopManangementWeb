using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.DTO;

namespace QuanLyShopBanQuatDien.Service
{
    public class ActivityLogService
    {
        public static List<ActivityLogEntity> findAll()
        {
            return ActivityLogDAO.findAll();
        }

        public static List<ActivityLogEntity> findByStartDateAndEndDate(DateTime startDate, DateTime endDate)
        {
            return ActivityLogDAO.findByStartDateAndEndDate(startDate, endDate);
        }

        public static bool create(ActivityLogEntity activityLogEntity)
        {
            Int64 id = LogDAO.create(activityLogEntity);

            if (DataUtils.isNull(id)){
                return false;
            }

            activityLogEntity.id = id;

            return ActivityLogDAO.create(activityLogEntity);
        }

        public static ActivityLogEntity findById(Int64 id)
        {
            List<ActivityLogEntity> logs = ActivityLogDAO.findById(id);

            if (DataUtils.isEmpty(logs))
            {
                return null;
            }

            return logs[0];
        }
    }
}