using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class OrderDetailDAO
    {
        public static List<OrderDetailEntity> findByOrderCode(string code)
        {
            string sql = "select * from orderdetail "
                + "inner join product "
                + "on orderdetail.productCode = product.productCode "
                + "where orderCode = @code";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new OrderDetailMapper(), parameters);
        }

        public static bool create(OrderDetailEntity orderDetail)
        {
            string sql = "insert into OrderDetail values (@orderCode, @productCode, @quantity, "
                         + "@price, @subtotal)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@orderCode", orderDetail.order.code),
                new SqlParameter("@productCode", orderDetail.product.code),
                new SqlParameter("@quantity", orderDetail.quantity),
                new SqlParameter("@price", orderDetail.price),
                new SqlParameter("@subtotal", orderDetail.subtotal)
            };

            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool deleteByOrderCode(string code)
        {
            string sql = "delete from OrderDetail where orderCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}