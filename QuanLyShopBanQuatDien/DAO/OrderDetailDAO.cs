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
    }
}