using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.Pages.Utils;
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
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            UserEntity user = UserService.signIn(username, password);

            if (DataUtils.isNull(user)){
                PageUtils.showMessage(messageLabel, "Tên đăng nhập hoặc mật khẩu không đúng");
                return;
            }

            UserSessionManager.currentUser = user;

            Response.Redirect("~/Pages/home_page.aspx");
        }
    }
}