using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class PageUtils
    {

        public static void updateTotalOfRecords(Label totalRecordsLabel, int totalRecords)
        {
            totalRecordsLabel.Text = totalRecords.ToString();
        }

        public static void bindData(DataBoundControl control, object obj)
        {
            control.DataSource = obj;
            control.DataBind();
        }

        public static void showMessage(Label label, string message, bool isSuccess = false)
        {
            label.Text = message;
            
            if (isSuccess)
            {
                label.CssClass = "text-success small";
                return;
            }

            label.CssClass = "text-danger small";
        }
    }
}