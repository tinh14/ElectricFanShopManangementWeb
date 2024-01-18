using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Service;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class activity_log_info : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.VIEW_ACTIVITY_LOG;

            SecurityManager.authorize(this, permission);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            if (!TypeConverter.isValidInt64(PageStatusManager.item(this)))
            {
                Response.Redirect("~/Pages/activities_log.aspx");
            }

            Int64 id = TypeConverter.strToInt64(PageStatusManager.item(this));

            ActivityLogEntity activityLog = ActivityLogService.findById(id);

            if (DataUtils.isNull(activityLog))
            {
                Response.Redirect("~/Pages/activities_log.aspx");
            }

            codeTextBox.Text = activityLog.id.ToString();
            usernameTextBox.Text = activityLog.username;
            statusTextBox.Text = activityLog.isSuccess ? "Thành công" : "Thất bại";
            timestampTextBox.Text = TypeConverter.dateToStr(activityLog.timestamp, TypeConverter.DateTimeConfig.DATE_TIME_PATTERN);
            ipTextBox.Text = activityLog.ip;
            deviceInfoTextBox.Text = activityLog.deviceInfo;
        }
    }
}