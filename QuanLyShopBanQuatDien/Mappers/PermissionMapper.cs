using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class PermissionMapper : RowMapper<PermissionEntity>
    {
        public PermissionEntity map(SqlDataReader reader)
        {
            PermissionEntity permission = new PermissionEntity();
            permission.code = reader.GetString(reader.GetOrdinal("permissionCode"));
            permission.name = reader.GetString(reader.GetOrdinal("permissionName"));

            return permission;
        }
    }
}