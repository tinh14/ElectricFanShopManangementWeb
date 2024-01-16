using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.DTO;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Service
{
    public class RoleService
    {
        public static List<RoleEntity> findAll()
        {
            return RoleDAO.findAll();
        }

        public static List<RoleEntity> findByName(string name)
        {
            return RoleDAO.findByName(name);
        }

        public static RoleEntity findByCode(string code)
        {
            List<RoleEntity> roles = RoleDAO.findByCode(code);
            if (DataUtils.isEmpty(roles))
            {
                return null;
            }

            RoleEntity role = roles[0];

            List<RolePermissionEntity> rolePermissions = RolePermissionDAO.findByRoleCode(code);
            role.rolePermissions = rolePermissions;
            return role;
        }

        public static ResponseObject<RoleEntity> create(RoleEntity role)
        {
            ResponseObject<RoleEntity> res = new ResponseObject<RoleEntity>();
            res.isSuccess = false;

            if (RoleDAO.checkExist(role.code))
            {
                res.errorMessage = "Mã vai trò đã tồn tại";
                return res;
            }

            if (!RoleDAO.create(role))
            {
                res.errorMessage = "Không thể tạo vai trò";
                return res;
            }

            foreach (RolePermissionEntity rolePermission in role.rolePermissions)
            {
                rolePermission.role = role;
                RolePermissionDAO.create(rolePermission);
            }

            res.isSuccess = true;
            return res;
        }

        public static ResponseObject<RoleEntity> update(RoleEntity role)
        {
            ResponseObject<RoleEntity> res = new ResponseObject<RoleEntity>();
            res.isSuccess = false;

            if (!RoleDAO.checkExist(role.code))
            {
                res.errorMessage = "Mã vai trò không tồn tại";
                return res;
            }

            if (role.code == "ADMIN")
            {
                res.errorMessage = "Không thể cập nhật vai trò quản trị viên";
                return res;
            }

            RolePermissionDAO.deleteByRoleCode(role.code);

            foreach (RolePermissionEntity rolePermission in role.rolePermissions)
            {
                rolePermission.role = role;
                RolePermissionDAO.create(rolePermission);
            }

            res.isSuccess = true;
            return res;

        }

        public static ResponseObject<RoleEntity> delete(string code)
        {
            ResponseObject<RoleEntity> res = new ResponseObject<RoleEntity>();
            res.isSuccess = false;

            if (!RoleDAO.checkExist(code))
            {
                res.errorMessage = "Mã vai trò không tồn tại";
                return res;
            }

            if (code == "ADMIN")
            {
                res.errorMessage = "Không thể xóa vai trò quản trị viên";
                return res;
            }

            if (!RoleDAO.delete(code))
            {
                res.errorMessage = "Không thể xóa vai trò";
                return res;
            }

            res.isSuccess = true;
            return res;
        }
    }
}