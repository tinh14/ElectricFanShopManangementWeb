using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class master_page : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            UserEntity user = UserSessionManager.currentUser;
            fullNameLabel.Text = user.fullName;
            usernameLabel.Text = user.username;
            userAvatarImage.ImageUrl = user.avatar;
        }

        protected void signoutLinkButton_Click(object sender, EventArgs e)
        {
            UserSessionManager.currentUser = null;
            Response.Redirect("~/Pages/signin_page.aspx");
        }
    }
}