using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.DAO;

namespace QuanLyShopBanQuatDien.Service
{
    public class PermissionService
    {
        public static List<PermissionEntity> findAll()
        {
            return PermissionDAO.findAll();
        }
    }
}