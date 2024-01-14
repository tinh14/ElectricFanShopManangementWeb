using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class RoleDAO
    {
        public static List<RoleEntity> findAll()
        {
            string sql = "select * from [role]";
            return DatabaseQueryExecutor.executeQuery(sql, new RoleMapper());
        }
    }
}