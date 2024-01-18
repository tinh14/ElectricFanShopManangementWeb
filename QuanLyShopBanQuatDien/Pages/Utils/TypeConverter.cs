using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class TypeConverter
    {
        public class DateTimeConfig
        {
            public const string PATTERN = "dd/MM/yyyy";
            public const IFormatProvider PROVIDER = null;
            public const DateTimeStyles STYLES = DateTimeStyles.None;
        }

        public static bool isValidDate(string str)
        {
            DateTime res;
            if (DateTime.TryParseExact(str, DateTimeConfig.PATTERN,
                DateTimeConfig.PROVIDER, DateTimeConfig.STYLES, out res))
            {
                return true;
            }
            return false;
        }

        public static DateTime strToDate(string str)
        {
            DateTime res;
            DateTime.TryParseExact(str, DateTimeConfig.PATTERN,
                DateTimeConfig.PROVIDER, DateTimeConfig.STYLES, out res);
            return res;
        }

        public static string dateToStr(DateTime date)
        {
            return date.ToString(DateTimeConfig.PATTERN);
        }

        public static DateTime currentDate()
        {
            DateTime currentDate = DateTime.Now;
            string str = dateToStr(currentDate);
            return strToDate(str);
        }

        public static bool isValidInt(string str)
        {
            int val;
            if (int.TryParse(str, out val))
            {
                return true;
            }
            return false;
        }

        public static bool isValidInt64(string str)
        {
            Int64 val;
            if (Int64.TryParse(str, out val))
            {
                return true;
            }
            return false;
        }

        public static int strToInt(string str)
        {
            return int.Parse(str);
        }

        public static Int64 strToInt64(string str)
        {
            return Int64.Parse(str);
        }

    }
}