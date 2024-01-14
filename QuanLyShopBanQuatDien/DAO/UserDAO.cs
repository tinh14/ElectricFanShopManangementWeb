using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Mappers;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.DAO
{
    public class UserDAO
    {
        public static List<UserEntity> findByUsernameAndPassword(string username, string password)
        {
            string sql = "select * from [user] "
                        + "inner join [role] "
                        + "on [user].roleCode = [role].roleCode "
                        + "where (username = @username) and (password = @password)";

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            return DatabaseQueryExecutor.executeQuery<UserEntity>(sql, new UserMapper(), parameters);
        }


        public static List<UserEntity> findAll()
        {
            string sql = "select * from [user] "
                        + "inner join [role] "
                        + "on [user].roleCode = [role].roleCode ";
            return DatabaseQueryExecutor.executeQuery(sql, new UserMapper());
        }

        public static List<UserEntity> findByName(string name)
        {
            string sql = "select * from [user]"
                        + "inner join [role] "
                        + "on [user].roleCode = [role].roleCode "
                        + "where [user].fullName like @name";

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@name", "%"+name+"%")
            };

            return DatabaseQueryExecutor.executeQuery<UserEntity>(sql, new UserMapper(), parameters);
        }
    }
}