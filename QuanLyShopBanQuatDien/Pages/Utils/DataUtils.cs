using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class DataUtils
    {
        public static string base64(byte[] byteArr)
        {
            string base64Image = System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(byteArr));
            string imageUrl = "data:image/png;base64," + base64Image;
            return imageUrl;
        }

        public static bool isEmpty<T>(List<T> obj)
        {
            return isNull(obj) || obj.Count == 0;
        }

        public static bool isNull(object obj)
        {
            return obj == null;
        }

        public static bool strCompare(string str1, string str2)
        {
            return str1.ToLower() == str2.ToLower();
        }

        
    }
}