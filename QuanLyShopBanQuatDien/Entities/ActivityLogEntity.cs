using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class ActivityLogEntity : LogEntity
    {
        public bool isSuccess { get; set; }
    }
}