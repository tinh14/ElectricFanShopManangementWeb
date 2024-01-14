using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Service
{
    public class RoleService
    {
        public static List<RoleEntity> findAll()
        {
            return RoleDAO.findAll();
        }
    }
}