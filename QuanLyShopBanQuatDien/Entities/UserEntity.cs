using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class UserEntity
    {
        public string username { get; set; }

        public string password { get; set; }

        public string fullName { get; set; }

        public string avatar { get; set; }

        public RoleEntity role;

        public UserEntity()
        {
            role = new RoleEntity();
        }
    }
}