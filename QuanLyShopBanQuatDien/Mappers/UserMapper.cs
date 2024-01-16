using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class UserMapper : RowMapper<UserEntity>
    {
        public UserEntity map(SqlDataReader reader) {

            UserEntity user = new UserEntity();
            user.username = reader.GetString(reader.GetOrdinal("username"));
            user.password = reader.GetString(reader.GetOrdinal("password"));
            user.fullName = reader.GetString(reader.GetOrdinal("fullName"));
            user.avatar = reader.GetString(reader.GetOrdinal("avatar"));
            user.role.code = reader.GetString(reader.GetOrdinal("roleCode"));
            user.role.name = reader.GetString(reader.GetOrdinal("roleName"));

            return user;
        }

    }
}