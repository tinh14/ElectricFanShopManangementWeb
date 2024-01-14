using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class PermissionEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}