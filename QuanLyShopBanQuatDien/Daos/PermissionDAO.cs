using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Mappers;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class PermissionDAO
    {
        public static List<PermissionEntity> findAll()
        {
            string sql = "select * from permission";
            return DatabaseQueryExecutor.executeQuery(sql, new PermissionMapper());
        }

        public static List<PermissionEntity> findByCode(string code)
        {
            string sql = "Select * from permission "
                + "where permissionCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeQuery(sql, new PermissionMapper(), parameters);
        }
    }
}