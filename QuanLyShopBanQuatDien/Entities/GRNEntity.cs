using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class GRNEntity
    {
        public string code { get; set; }
        public DateTime grnDate { get; set; }
        public Int64 totalAmount { get; set; }
        public SupplierEntity supplier { get; set; }
        public UserEntity user { get; set; }
        public List<GRNDetailEntity> grnDetails { get; set; }
        public GRNEntity()
        {
            this.supplier = new SupplierEntity();
            this.user = new UserEntity();
            this.grnDetails = new List<GRNDetailEntity>();
        }
    }
}