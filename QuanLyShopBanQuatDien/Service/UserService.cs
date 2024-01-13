using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Service
{
    public class UserService
    {
        public static UserEntity signIn(string username, string password)
        {
            List<UserEntity> users = UserDAO.findByUsernameAndPassword(username, password);

            return DataUtils.isEmpty<UserEntity>(users) ? null : users[0];
        }
    }
}