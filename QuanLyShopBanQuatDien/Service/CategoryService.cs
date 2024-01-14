using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Service
{
    public class CategoryService
    {
        public static List<CategoryEntity> findAll()
        {
            return CategoryDAO.findAll();
        }

        public static List<CategoryEntity> findByName(string name)
        {
            return CategoryDAO.findByName(name);
        }

        public static CategoryEntity findByCode(string code)
        {
            List<CategoryEntity> categories = CategoryDAO.findByCode(code);
            return DataUtils.isEmpty(categories) ? null : categories[0];
        }

        public static bool create(CategoryEntity category)
        {
            if (CategoryDAO.checkExist(category.code))
            {
                return false;
            }

            return CategoryDAO.create(category);
        }

        public static bool update(CategoryEntity category)
        {
            if (!CategoryDAO.checkExist(category.code))
            {
                return false;
            }
            return CategoryDAO.update(category);
        }

        public static bool delete(string code)
        {
            if (!CategoryDAO.checkExist(code))
            {
                return false;
            }
            return CategoryDAO.delete(code);
        }
    }
}