using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Pages
{
    [Serializable]
    public class OrderEntity
    {
        public string code { get; set; }
        public DateTime orderDate { get; set; }
        public Int64 totalAmount { get; set; }
        public CustomerEntity customer { get; set; }
        public UserEntity user { get; set; }
        public List<OrderDetailEntity> orderDetails { get; set; }
        public OrderEntity()
        {
            this.customer = new CustomerEntity();
            this.user = new UserEntity();
            this.orderDetails = new List<OrderDetailEntity>();
        }
    }
}