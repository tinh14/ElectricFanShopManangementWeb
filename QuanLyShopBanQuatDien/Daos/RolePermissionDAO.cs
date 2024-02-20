using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class RolePermissionDAO
    {

        public static bool isValidPermission(RolePermissionEntity rolePermission)
        {
            string sql = "select permissionCode from RolePermission "
                        +"where roleCode = @roleCode and permissionCode = @permissionCode";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@roleCode", rolePermission.role.code),
                new SqlParameter("@permissionCode", rolePermission.permission.code)
            };

            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static void create(RolePermissionEntity rolePermission)
        {
            string sql = "insert into RolePermission values (@roleCode, @permissionCode)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@roleCode", rolePermission.role.code),
                new SqlParameter("@permissionCode", rolePermission.permission.code)
            };

            DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static List<RolePermissionEntity> findByRoleCode(string code)
        {
            string sql = "select * from RolePermission where roleCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new RolePermissionMapper(), parameters);
        }

        public static bool deleteByRoleCode(string code)
        {
            string sql = "delete from RolePermission where roleCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}