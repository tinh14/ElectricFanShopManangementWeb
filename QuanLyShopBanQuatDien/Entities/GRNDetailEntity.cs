using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class GRNDetailEntity
    {
        public int quantity { get; set; }
        public int price { get; set; }
        public Int64 subtotal { get; set; }
        public GRNEntity grn { get; set; }
        public ProductEntity product { get; set; }

        public GRNDetailEntity()
        {
            this.grn = new GRNEntity();
            this.product = new ProductEntity();
        }
    }
}