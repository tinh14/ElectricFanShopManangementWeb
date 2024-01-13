using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.DAO;

namespace QuanLyShopBanQuatDien.Service
{
    public class CategoryService
    {
        public static List<CategoryEntity> findAll()
        {
            return CategoryDAO.findAll();
        }
    }
}