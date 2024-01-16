using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class OrderDetailMapper : RowMapper<OrderDetailEntity>
    {
        public OrderDetailEntity map(SqlDataReader reader)
        {
            OrderDetailEntity orderDetail = new OrderDetailEntity();
            orderDetail.order.code = reader.GetString(reader.GetOrdinal("orderCode"));
            orderDetail.product.code = reader.GetString(reader.GetOrdinal("productCode"));
            orderDetail.product.name = reader.GetString(reader.GetOrdinal("productName"));
            orderDetail.quantity = reader.GetInt16(reader.GetOrdinal("quantity"));
            orderDetail.price = reader.GetInt16(reader.GetOrdinal("price"));
            orderDetail.discount = reader.GetInt16(reader.GetOrdinal("discount"));
            orderDetail.subtotal = reader.GetInt64(reader.GetOrdinal("subtotal"));

            return orderDetail;
        }
    }
}