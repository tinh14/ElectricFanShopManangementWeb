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
    }
}