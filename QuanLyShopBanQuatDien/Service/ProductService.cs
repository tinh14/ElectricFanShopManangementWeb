using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Service
{
    public class ProductService
    {
        public static List<ProductEntity> findAll()
        {
            return ProductDAO.findAll();
        }

        public static ProductEntity findByCode(string code)
        {
            List<ProductEntity> products = ProductDAO.findByCode(code);

            return DataUtils.isEmpty<ProductEntity>(products) ? null : products[0]; 
        }

        public static List<ProductEntity> findByName(string name)
        {
            return ProductDAO.findByName(name);
        }

        public static List<ProductEntity> filterByCategoryCode(List<ProductEntity> products, string code)
        {
            List<ProductEntity> newProducts = new List<ProductEntity>();

            foreach (ProductEntity product in products)
            {
                if (product.category.code == code)
                {
                    newProducts.Add(product);
                }
            }
            return newProducts;
        }

        public static bool create(ProductEntity product)
        {
            if (ProductDAO.checkExist(product.code))
            {
                return false;
            }

            return ProductDAO.create(product);
        }

        public static bool update(ProductEntity product)
        {
            if (!ProductDAO.checkExist(product.code))
            {
                return false;
            }

            return ProductDAO.update(product);
        }

        public static bool delete(string code)
        {
            if (!ProductDAO.checkExist(code))
            {
                return false;
            }

            return ProductDAO.delete(code);
        }
    }
}