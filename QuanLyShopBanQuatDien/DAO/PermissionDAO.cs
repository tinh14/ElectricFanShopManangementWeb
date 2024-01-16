using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class PermissionDAO
    {
        public static List<PermissionEntity> findAll()
        {
            string sql = "select * from permission";
            return DatabaseQueryExecutor.executeQuery(sql, new PermissionMapper());
        }
    }
}