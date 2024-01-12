using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Entities
{
    public class ProductEntity
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Power { get; set; }

        public string Brand { get; set; }

        public double Size { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public int Speed { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }

        // Assuming Category is another entity or a simple type
        public CategoryEntity Category { get; set; }
    }
}