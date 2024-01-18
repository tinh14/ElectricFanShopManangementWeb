using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class GRNMapper : RowMapper<GRNEntity>
    {
        public GRNEntity map(SqlDataReader reader)
        {
            GRNEntity grn = new GRNEntity();
            grn.code = reader.GetString(reader.GetOrdinal("grnCode"));
            grn.grnDate = reader.GetDateTime(reader.GetOrdinal("grnDate"));
            grn.totalAmount = reader.GetInt64(reader.GetOrdinal("totalAmount"));
            grn.supplier.code = reader.GetString(reader.GetOrdinal("supplierCode"));
            grn.user.username = reader.GetString(reader.GetOrdinal("username"));
            return grn;
        }
    }
}