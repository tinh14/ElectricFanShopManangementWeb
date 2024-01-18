using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class LogEntity
    {
        public Int64 id { get; set; }
        public string username { get; set; }
        public DateTime timestamp { get; set; }
        public string ip { get; set; }
        public string deviceInfo { get; set; }
    }
}