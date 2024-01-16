using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using System.Web.UI;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class ViewStateManager
    {
        public static List<T> state<T>(StateBag viewState, List<T> value = null)
        {
            string key = typeof(T).Name;

            if (value != null)
            {
                viewState[key] = value;
            }

            return viewState[key] as List<T> ?? new List<T>();
        }
    }
}