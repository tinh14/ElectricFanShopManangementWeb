using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class PageStatusManager
    {
        private static string KEY = "code";

        public static bool isUpdate(Page page)
        {
            return !string.IsNullOrEmpty(page.Request.QueryString[KEY]);
        }

        public static string item(Page page) {
            return page.Request.QueryString[KEY];
        }


    }
}