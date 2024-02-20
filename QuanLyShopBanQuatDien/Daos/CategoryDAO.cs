using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Mappers;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class CategoryDAO
    {
        public static List<CategoryEntity> findAll()
        {
            string sql = "select * from category ";
            return DatabaseQueryExecutor.executeQuery(sql, new CategoryMapper());
        }

        public static List<CategoryEntity> findByName(string name)
        {
            string sql = "select * from category "
                       + "where categoryName like @name";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@name", "%" + name + "%")
            };

            return DatabaseQueryExecutor.executeQuery(sql, new CategoryMapper(), parameters);
        }

        public static List<CategoryEntity> findByCode(string code)
        {
            string sql = "select * from category "
                        + "where categoryCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeQuery(sql, new CategoryMapper(), parameters);
        }

        public static bool checkExist(string code)
        {
            string sql = "select * from category "
                       + "where categoryCode = @code";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static bool create(CategoryEntity category)
        {
            string sql = "insert into Category values(@code, @name) ";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", category.code),
                new SqlParameter("@name", category.name)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool update(CategoryEntity category)
        {
            string sql = "update Category "
                        +"set categoryCode = @code, categoryName = @name "
                        +"where categoryCode = @code ";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", category.code),
                new SqlParameter("@name", category.name)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool delete(string code)
        {
            string sql = "delete from Category where categoryCode = @code";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}