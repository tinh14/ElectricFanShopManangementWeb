using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class UserSessionManager
    {
        public const string USER_KEY = "user";

        public static UserEntity currentUser
        {
            get
            {
                if (HttpContext.Current.Session[USER_KEY] == null)
                {
                    return null;
                }
                return (UserEntity)HttpContext.Current.Session[USER_KEY];
            }

            set
            {
                HttpContext.Current.Session[USER_KEY] = value;
            }
        }
    }
}