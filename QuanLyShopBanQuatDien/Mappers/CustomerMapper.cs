using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class CustomerMapper : RowMapper<CustomerEntity>
    {
        public CustomerEntity map(SqlDataReader reader)
        {
            CustomerEntity customer = new CustomerEntity();
            customer.code = reader.GetString(reader.GetOrdinal("customerCode"));
            customer.name = reader.GetString(reader.GetOrdinal("customerName"));
            customer.phoneNumber = reader.GetString(reader.GetOrdinal("phoneNumber"));
            return customer;
        }
    }
}