using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Entities
{
    public class RoleEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<RolePermissionEntity> rolePermissions { get; set; }

        public RoleEntity(){
            rolePermissions = new List<RolePermissionEntity>();
        }
    }
}