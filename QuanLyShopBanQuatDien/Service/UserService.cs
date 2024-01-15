using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.DTO;
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

        public static UserEntity findByUsername(string username)
        {
            List<UserEntity> users = UserDAO.findByUsername(username);
            return DataUtils.isEmpty(users) ? null : users[0];
        }

        public static bool create(UserEntity user)
        {
            if (UserDAO.checkExist(user.username))
            {
                return false;
            }

            return UserDAO.create(user);
        }

        public static ResponseObject<UserEntity> update(UserEntity user)
        {
            List<UserEntity> users = UserDAO.findByUsername(user.username);
            
            ResponseObject<UserEntity> res = new ResponseObject<UserEntity>();
            res.isSuccess = false;

            if (DataUtils.isEmpty(users))
            {
                res.errorMessage = "Tên đăng nhập không tồn tại";
                return res;
            }

            UserEntity foundUser = users[0];

            string foundRoleCode = foundUser.role.code;
            string inputRoleCode = user.role.code;

            if (foundRoleCode == "ADMIN" && foundRoleCode != inputRoleCode)
            {
                res.errorMessage = "Không thể thay đổi vai trò quản trị viên";
                return res;
            }

            if (foundRoleCode != "ADMIN" && inputRoleCode == "ADMIN")
            {
                res.errorMessage = "Không thể thay đổi vai trò quản trị viên";
                return res;
            }

            if (string.IsNullOrWhiteSpace(user.password))
            {
                user.password = foundUser.password;
            }

            if (!UserDAO.update(user))
            {
                res.errorMessage = "Cập nhật không thành công";
                return res;
            }

            res.isSuccess = true;
            return res;
        }

        public static bool delete(string username)
        {
            if (!UserDAO.checkExist(username))
            {
                return false;
            }

            return UserDAO.delete(username);
        }
    }
}