using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Mappers;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class OrderDAO
    {
        public static List<OrderEntity> findAll()
        {
            string sql = "select * from [order]";
            return DatabaseQueryExecutor.executeQuery(sql, new OrderMapper());
        }

        public static List<OrderEntity> findByCode(string code)
        {
            string sql = "select * from [order] where orderCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeQuery(sql, new OrderMapper(), parameters);
        }

        public static List<OrderEntity> findByCodeWithWildCard(string code)
        {
            string sql = "select * from [order] where orderCode like @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", "%"+code+"%")
            };
            return DatabaseQueryExecutor.executeQuery(sql, new OrderMapper(), parameters);
        }

        public static bool checkExist(string code)
        {
            string sql = "select * from [order] where orderCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static bool create(OrderEntity order)
        {
            string sql = "insert into [order] values (@code, @orderDate, @totalAmount, @customerCode, @username)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", order.code),
                new SqlParameter("@orderDate", order.orderDate),
                new SqlParameter("@totalAmount", order.totalAmount),
                new SqlParameter("@customerCode", order.customer.code),
                new SqlParameter("@username", order.user.username)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool update(OrderEntity order)
        {
            string sql = "update [order] set orderDate = @orderDate, "
                + "totalAmount = @totalAmount, customerCode = @customerCode, username = @username "
                + "where orderCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@orderDate", order.orderDate),
                new SqlParameter("@totalAmount", order.totalAmount),
                new SqlParameter("@customerCode", order.customer.code),
                new SqlParameter("@username", order.user.username),
                new SqlParameter("@code", order.code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool delete(string code)
        {
            string sql = "delete from [order] where orderCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}