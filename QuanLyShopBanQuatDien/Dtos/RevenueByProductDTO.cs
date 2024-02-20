using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.DTO
{
    [Serializable]
    public class RevenueByProductDTO
    {
        public string code { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public Int64 totalAmount { get; set; }
    }
}