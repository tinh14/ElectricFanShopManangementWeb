using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class CategoryMapper : RowMapper<CategoryEntity>
    {
        public CategoryEntity map(SqlDataReader reader)
        {
            CategoryEntity category = new CategoryEntity();
            category.code = reader.GetString(reader.GetOrdinal("categoryCode"));
            category.name = reader.GetString(reader.GetOrdinal("categoryName"));

            return category;
        }
    }
}