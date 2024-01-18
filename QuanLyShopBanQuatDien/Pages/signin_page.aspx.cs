using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class signin_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        protected void singinButton_Click(object sender, EventArgs e)
        {
            ActivityLogEntity activityLog = new ActivityLogEntity();
            HttpContext context = HttpContext.Current;

            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            activityLog.ip = context.Request.UserHostAddress;
            activityLog.deviceInfo = context.Request.UserAgent;
            activityLog.timestamp = DateTime.Now;
            activityLog.username = username;

            UserEntity user = UserService.signIn(username, password);

            if (DataUtils.isNull(user))
            {
                activityLog.isSuccess = false;
                
                ActivityLogService.create(activityLog);
                
                PageUtils.showMessage(messageLabel, "Tên đăng nhập hoặc mật khẩu không đúng");
                return;
            }

            activityLog.isSuccess = true;
            ActivityLogService.create(activityLog);

            UserSessionManager.currentUser = user;
            Response.Redirect("~/Pages/home_page.aspx");
        }
    }
}