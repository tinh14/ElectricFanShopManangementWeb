using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class RolePermissionMapper : RowMapper<RolePermissionEntity>
    {
        public RolePermissionEntity map(SqlDataReader reader)
        {
            RolePermissionEntity rolePermission = new RolePermissionEntity();
            rolePermission.role.code = reader.GetString(reader.GetOrdinal("roleCode"));
            rolePermission.permission.code = reader.GetString(reader.GetOrdinal("permissionCode"));

            return rolePermission;
        }
    }
}