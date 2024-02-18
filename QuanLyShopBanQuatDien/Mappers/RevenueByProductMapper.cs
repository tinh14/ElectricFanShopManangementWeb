using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DTO;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class RevenueByProductMapper : RowMapper<RevenueByProductDTO>
    {
        public RevenueByProductDTO map(SqlDataReader reader)
        {
            RevenueByProductDTO revenue = new RevenueByProductDTO();
            revenue.code = reader.GetString(reader.GetOrdinal("code"));
            revenue.name = reader.GetString(reader.GetOrdinal("productName"));
            revenue.quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
            revenue.totalAmount = reader.GetInt64(reader.GetOrdinal("amountTotal"));
            return revenue;
        }
    }
}