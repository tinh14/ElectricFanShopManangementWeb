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

        public static List<UserEntity> findAll()
        {
            return UserDAO.findAll();
        }

        public static List<UserEntity> filterByRoleCode(List<UserEntity> users, string code)
        {
            List<UserEntity> newUsers = new List<UserEntity>();

            foreach (UserEntity user in users)
            {
                if (user.role.code == code)
                {
                    newUsers.Add(user);
                }
            }
            return newUsers;
        }

        public static List<UserEntity> findByName(string name)
        {
            return UserDAO.findByName(name);
        }
    }
}