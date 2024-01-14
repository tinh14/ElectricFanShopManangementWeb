using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class SupplierMapper : RowMapper<SupplierEntity>
    {
        public SupplierEntity map(SqlDataReader reader)
        {
            SupplierEntity supplier = new SupplierEntity();
            supplier.code = reader.GetString(reader.GetOrdinal("supplierCode"));
            supplier.name = reader.GetString(reader.GetOrdinal("supplierName"));
            supplier.contactPerson = reader.GetString(reader.GetOrdinal("contactPerson"));
            supplier.phoneNumber = reader.GetString(reader.GetOrdinal("phoneNumber"));
            supplier.address = reader.GetString(reader.GetOrdinal("address"));
            return supplier;
        }
    }
}