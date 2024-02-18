using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;

namespace QuanLyShopBanQuatDien.Pages
{
    [Serializable]
    public class ProductEntity
    {
        public string code { get; set; }

        public string name { get; set; }

        public int price { get; set; }

        public string power { get; set; }

        public string brand { get; set; }

        public string size { get; set; }

        public string material { get; set; }

        public string color { get; set; }

        public string speed { get; set; }

        public string image { get; set; }

        public CategoryEntity category { get; set; }

        public ProductEntity()
        {
            category = new CategoryEntity();
        }
    }
}