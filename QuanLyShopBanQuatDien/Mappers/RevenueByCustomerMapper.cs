using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DTO;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class RevenueByCustomerMapper : RowMapper<RevenueByCustomerDTO>
    {
        public RevenueByCustomerDTO map(SqlDataReader reader)
        {
            RevenueByCustomerDTO revenue = new RevenueByCustomerDTO();
            revenue.code = reader.GetString(reader.GetOrdinal("code"));
            revenue.name = reader.GetString(reader.GetOrdinal("customerName"));
            revenue.totalAmount = reader.GetInt64(reader.GetOrdinal("amountTotal"));
            return revenue;
        }
    }
}