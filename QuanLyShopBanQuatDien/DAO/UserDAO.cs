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

            return DatabaseQueryExecutor.executeQuery(sql, new UserMapper(), parameters);
        }

        public static List<UserEntity> findByUsername(string username)
        {
            string sql = "select * from [user]"
                        + "inner join [role] "
                        + "on [user].roleCode = [role].roleCode "
                        + "where [user].username = @username";

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@username", username)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new UserMapper(), parameters);
        }

        public static bool checkExist(string username)
        {
            string sql = "select username from [user]"
            + "where [user].username = @username";

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@username", username)
            };

            return DatabaseQueryExecutor.executeExist(sql, parameters);

        }

        public static bool create(UserEntity user)
        {
            string sql = "insert into [user] "
                        + "values (@username, @password, @fullName, @avatar, @roleCode)";

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@username", user.username),
                new SqlParameter("@password", user.password),
                new SqlParameter("@fullName", user.fullName),
                new SqlParameter("@avatar", user.avatar),
                new SqlParameter("@roleCode", user.role.code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool update(UserEntity user)
        {
            string sql = "update [user] set password = @password, "
                        + "fullName = @fullName, avatar = @avatar, roleCode = @roleCode "
                        + "where username = @username";

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@password", user.password),
                new SqlParameter("@fullName", user.fullName),
                new SqlParameter("@avatar", user.avatar),
                new SqlParameter("@roleCode", user.role.code),
                new SqlParameter("@username", user.username)
            };

            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool delete(string username)
        {
            string sql = "delete from [user] where username = @username";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@username", username)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}