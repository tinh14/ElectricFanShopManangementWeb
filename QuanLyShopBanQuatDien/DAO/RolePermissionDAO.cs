using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

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
    }
}