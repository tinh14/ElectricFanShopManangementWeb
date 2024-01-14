using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Service;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class SecurityManager
    {
        public enum Permission
        {
            VIEW_PRODUCT, CREATE_PRODUCT, UPDATE_PRODUCT, DELETE_PRODUCT,
            VIEW_CATEGORY, CREATE_CATEGORY, UPDATE_CATEGORY, DELETE_CATEGORY,
            VIEW_CUSTOMER, CREATE_CUSTOMER, UPDATE_CUSTOMER, DELETE_CUSTOMER,
            VIEW_SUPPLIER, CREATE_SUPPLIER, UPDATE_SUPPLIER, DELETE_SUPPLIER,
            VIEW_USER, CREATE_USER, UPDATE_USER, DELETE_USER
        }

        public static void authenticate(System.Web.UI.Page page)
        {
            if (UserSessionManager.currentUser == null)
            {
                page.Response.Redirect("~/Pages/signin_page.aspx");
            }
        }

        public static void authorize(System.Web.UI.Page page, SecurityManager.Permission permission)
        {
            RolePermissionEntity rolePermission = new RolePermissionEntity();
            rolePermission.role = UserSessionManager.currentUser.role;
            rolePermission.permission.code = permission.ToString();

            if (!RolePermissionService.isValidPermission(rolePermission))
            {
                page.Response.Redirect("~/Pages/access_denied.aspx");
            }
        }

        public static void authenticateAndAuthorize(System.Web.UI.Page page, SecurityManager.Permission permission)
        {
            authenticate(page);
            authorize(page, permission);
        }
    }
}