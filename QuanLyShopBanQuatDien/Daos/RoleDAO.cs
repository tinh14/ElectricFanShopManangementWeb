using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Mappers;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class RoleDAO
    {
        public static List<RoleEntity> findAll()
        {
            string sql = "select * from [role]";
            return DatabaseQueryExecutor.executeQuery(sql, new RoleMapper());
        }

        public static List<RoleEntity> findByName(string name)
        {
            string sql = "select * from [role] where roleName like @name";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name", "%"+name+"%")
            };
            return DatabaseQueryExecutor.executeQuery(sql, new RoleMapper(), parameters);
        }

        public static bool checkExist(string code)
        {
            string sql = "select roleCode from [role] where roleCode = @code";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static List<RoleEntity> findByCode(string code)
        {
            string sql = "select * from [role] where roleCode = @code";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new RoleMapper(), parameters);
        }

        public static bool create(RoleEntity role)
        {
            string sql = "insert into [role] values (@code, @name)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", role.code),
                new SqlParameter("@name", role.name)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }



        public static bool delete(string code)
        {
            string sql = "delete from [role] where roleCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}