using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.Mappers
{
    public class ProductMapper : RowMapper<ProductEntity>
    {
        public ProductEntity map(SqlDataReader reader)
        {
            ProductEntity product = new ProductEntity();
            product.code = reader.GetString(reader.GetOrdinal("productCode"));
            product.name = reader.GetString(reader.GetOrdinal("productName"));
            product.price = reader.GetInt32(reader.GetOrdinal("price"));
            product.power = reader.GetString(reader.GetOrdinal("power"));
            product.brand = reader.GetString(reader.GetOrdinal("brand"));
            product.size = reader.GetString(reader.GetOrdinal("size"));
            product.material = reader.GetString(reader.GetOrdinal("material"));
            product.color = reader.GetString(reader.GetOrdinal("color"));
            product.speed = reader.GetString(reader.GetOrdinal("speed"));

            int imageOrdinal = reader.GetOrdinal("image");
            product.image = reader.IsDBNull(imageOrdinal) ? null : reader.GetString(imageOrdinal);

            CategoryEntity category = new CategoryEntity();
            category.code = reader.GetString(reader.GetOrdinal("categoryCode"));
            category.name = reader.GetString(reader.GetOrdinal("categoryName")); ;

            product.category = category;

            return product;
        }
    }
}