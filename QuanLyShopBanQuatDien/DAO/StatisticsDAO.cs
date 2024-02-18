using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Mappers;
using QuanLyShopBanQuatDien.DTO;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class StatisticsDAO
    {
        public static List<RevenueByProductDTO> findRevenueByProduct(DateTime startDate, DateTime endDate)
        {
            string sql = "select p.productCode as code, p.productName, sum(quantity) as quantity, "
                    +"sum(subtotal) as amountTotal "
                    +"from product p "
                    +"inner join orderdetail od "
                    +"on p.productCode = od.productCode "
                    +"inner join [order] o "
                    +"on o.orderCode = od.orderCode "
                    +"where o.orderDate between @startDate and @endDate "
                    + "group by p.productCode, p.productName";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new RevenueByProductMapper(), parameters);
        }

        public static List<RevenueByCustomerDTO> findRevenueByCustomer(DateTime startDate, DateTime endDate)
        {
            string sql = "select c.customerCode as code, c.customerName, "
                    + "sum(subtotal) as amountTotal "
                    + "from customer c "
                    + "inner join [order] o "
                    + "on c.customerCode = o.customerCode "
                    + "inner join orderdetail od "
                    + "on o.orderCode = od.orderCode "
                    + "where o.orderDate between @startDate and @endDate "
                    + "group by c.customerCode, c.customerName";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new RevenueByCustomerMapper(), parameters);
        }
    }
}