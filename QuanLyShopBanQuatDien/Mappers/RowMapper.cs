using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public interface RowMapper<T>
    {
        T map(SqlDataReader reader);
    }
}