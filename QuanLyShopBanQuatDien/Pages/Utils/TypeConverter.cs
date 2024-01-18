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
            public const string DATE_PATTERN = "dd/MM/yyyy";
            public const string DATE_TIME_PATTERN = "dd/MM/yyyy HH:mm";
            public const IFormatProvider PROVIDER = null;
            public const DateTimeStyles STYLES = DateTimeStyles.None;
        }

        public static DateTime databaseMinDate()
        {
            return new DateTime(1753, 1, 1);
        }

        public static DateTime databaseMaxDate()
        {
            return new DateTime(9999, 12, 31);
        }

        public static bool isValidDate(string str, string pattern)
        {
            DateTime res;
            if (DateTime.TryParseExact(str, pattern,
                DateTimeConfig.PROVIDER, DateTimeConfig.STYLES, out res))
            {
                return true;
            }
            return false;
        }

        public static DateTime strToDate(string str, string pattern)
        {
            DateTime res;
            DateTime.TryParseExact(str, pattern,
                DateTimeConfig.PROVIDER, DateTimeConfig.STYLES, out res);
            return res;
        }

        public static string dateToStr(DateTime date, string pattern)
        {
            return date.ToString(pattern);
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