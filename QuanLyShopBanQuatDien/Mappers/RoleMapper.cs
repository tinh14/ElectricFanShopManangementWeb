using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class RoleMapper : RowMapper<RoleEntity>
    {
        public RoleEntity map(SqlDataReader reader)
        {
            RoleEntity role = new RoleEntity();
            role.code = reader.GetString(reader.GetOrdinal("roleCode"));
            role.name = reader.GetString(reader.GetOrdinal("roleName"));
            return role;
        }
    }
}