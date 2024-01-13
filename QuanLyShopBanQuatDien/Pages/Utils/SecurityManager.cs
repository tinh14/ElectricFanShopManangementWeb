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
            VIEW_PRODUCT, VIEW_CATEGORY, VIEW_ORDER,
            CREATE_PRODUCT,
            UPDATE_PRODUCT
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