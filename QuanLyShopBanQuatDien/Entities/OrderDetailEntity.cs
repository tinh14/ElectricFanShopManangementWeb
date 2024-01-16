using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class OrderDetailEntity
    {
        public int quantity { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public Int64 subtotal { get; set; }
        public OrderEntity order { get; set; }
        public ProductEntity product { get; set; }

        public OrderDetailEntity()
        {
            this.order = new OrderEntity();
            this.product = new ProductEntity();
        }
    }
}