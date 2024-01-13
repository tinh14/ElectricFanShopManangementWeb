using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class CategoryDAO
    {
        public static List<CategoryEntity> findAll()
        {
            string sql = "select * from category ";
            return DatabaseQueryExecutor.executeQuery(sql, new CategoryMapper());
        }
    }
}