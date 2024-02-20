using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class GRNDetailDAO
    {
        public static List<GRNDetailEntity> findByGRNCode(string code)
        {
            string sql = "select * from grndetail "
                + "inner join product "
                + "on grndetail.productCode = product.productCode "
                + "where grnCode = @code";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new GRNDetailMapper(), parameters);
        }

        public static bool create(GRNDetailEntity grnDetail)
        {
            string sql = "insert into GRNDetail values (@grnCode, @productCode, @quantity, "
                         + "@price, @subtotal)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@grnCode", grnDetail.grn.code),
                new SqlParameter("@productCode", grnDetail.product.code),
                new SqlParameter("@quantity", grnDetail.quantity),
                new SqlParameter("@price", grnDetail.price),
                new SqlParameter("@subtotal", grnDetail.subtotal)
            };

            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool deleteByGRNCode(string code)
        {
            string sql = "delete from GRNDetail where grnCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}