using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Database;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class ProductDAO
    {
        public static List<ProductEntity> findAll()
        {
            string sql = "select * from product "
                       + "inner join category on product.categoryCode = category.categoryCode";

            return DatabaseQueryExecutor.executeQuery(sql, new ProductMapper());
        }

        public static List<ProductEntity> findByCode(string code)
        {
            string sql = "select * from product "
                       + "inner join category on product.categoryCode = category.categoryCode "
                       + "where productCode = @code";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new ProductMapper(), parameters);
        }


        public static List<ProductEntity> findByName(string name)
        {
            string sql = "select * from product "
                       + "inner join category on product.categoryCode = category.categoryCode "
                       + "where productName like @name";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@name", "%" + name + "%")
            };

            return DatabaseQueryExecutor.executeQuery(sql, new ProductMapper(), parameters);
        }

        public static bool checkExist(string code)
        {
            string sql = "select * from product "
                       + "where productCode like @code";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static bool create(ProductEntity product)
        {
            string sql = "insert into product "
                       + "values(@code, @name, @brand, @power, @size, @material, @color, "
                       + "@speed, @image, @categoryCode)";
            
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", product.code),
                new SqlParameter("@name", product.name),
                new SqlParameter("@brand", product.brand),
                new SqlParameter("@power", product.power),
                new SqlParameter("@size", product.size),
                new SqlParameter("@material", product.material),
                new SqlParameter("@color", product.color),
                new SqlParameter("@speed", product.speed),
                new SqlParameter("@image", product.image),
                new SqlParameter("@categoryCode", product.category.code)
            };

            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool update(ProductEntity product)
        {
            string sql = "update product "
                       + "set productCode = @code, productName = @name, brand = @brand, power = @power, "
                       + "size = @size, material = @material, color = @color, speed = @speed, "
                       + "image = @image, categoryCode = @categoryCode "
                       + "where productCode = @code";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", product.code),
                new SqlParameter("@name", product.name),
                new SqlParameter("@brand", product.brand),
                new SqlParameter("@power", product.power),
                new SqlParameter("@size", product.size),
                new SqlParameter("@material", product.material),
                new SqlParameter("@color", product.color),
                new SqlParameter("@speed", product.speed),
                new SqlParameter("@image", product.image),
                new SqlParameter("@categoryCode", product.category.code),
            };

            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }


        public static bool delete(string code)
        {
            string sql = "delete from product "
                        +"where productCode = @code";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}