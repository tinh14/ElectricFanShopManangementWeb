using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;

namespace QuanLyShopBanQuatDien.Pages
{
    [Serializable]
    public class RoleEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public List<RolePermissionEntity> rolePermissions { get; set; }

        public RoleEntity(){
            rolePermissions = new List<RolePermissionEntity>();
        }
    }
}