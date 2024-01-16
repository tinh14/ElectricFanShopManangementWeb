using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class OrderMapper : RowMapper<OrderEntity>
    {
        public OrderEntity map(SqlDataReader reader)
        {
            OrderEntity order = new OrderEntity();
            order.code = reader.GetString(reader.GetOrdinal("orderCode"));
            order.orderDate = reader.GetDateTime(reader.GetOrdinal("orderDate"));
            order.totalAmount = reader.GetInt64(reader.GetOrdinal("totalAmount"));
            order.customer.code = reader.GetString(reader.GetOrdinal("customerCode"));
            order.user.username= reader.GetString(reader.GetOrdinal("username"));

            return order;
        }
    }
}