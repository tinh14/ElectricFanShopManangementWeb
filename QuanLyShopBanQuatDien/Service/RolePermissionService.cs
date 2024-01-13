using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.DAO;

namespace QuanLyShopBanQuatDien.Service
{
    public class RolePermissionService
    {
        public static bool isValidPermission(RolePermissionEntity rolePermission)
        {
            return RolePermissionDAO.isValidPermission(rolePermission);
        }
    }
}