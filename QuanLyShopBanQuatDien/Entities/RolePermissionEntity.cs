using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class RolePermissionEntity
    {
        public RoleEntity role { get; set; }
        public PermissionEntity permission { get; set; }

        public RolePermissionEntity()
        {
            role = new RoleEntity();
            permission = new PermissionEntity();
        }
    }
}