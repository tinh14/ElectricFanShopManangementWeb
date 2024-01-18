using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class GRNDetailMapper : RowMapper<GRNDetailEntity>
    {
        public GRNDetailEntity map(SqlDataReader reader)
        {
            GRNDetailEntity grnDetail = new GRNDetailEntity();
            grnDetail.grn.code = reader.GetString(reader.GetOrdinal("grnCode"));
            grnDetail.product.code = reader.GetString(reader.GetOrdinal("productCode"));
            grnDetail.product.name = reader.GetString(reader.GetOrdinal("productName"));
            grnDetail.product.image = reader.GetString(reader.GetOrdinal("image"));
            grnDetail.quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
            grnDetail.price = reader.GetInt32(reader.GetOrdinal("price"));
            grnDetail.subtotal = reader.GetInt64(reader.GetOrdinal("subtotal"));

            return grnDetail;
        }
    }
}