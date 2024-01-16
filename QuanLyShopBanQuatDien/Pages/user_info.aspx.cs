using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.DTO;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class user_info : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_USER;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_USER;
            }

            SecurityManager.authorize(this, permission);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // For upload image
                if (imageFileUpload.HasFile)
                {
                    bool isValidImage = imageFileUpload.PostedFile.ContentType.StartsWith("image/");
                    avatarImage.ImageUrl = !isValidImage ? "" : DataUtils.base64(imageFileUpload.FileBytes);
                }

                return;
            }

            List<RoleEntity> roles = RoleService.findAll();
            PageUtils.bindData(roleDropdownList, roles);

            // Check page status and handle page
            if (PageStatusManager.isUpdate(this))
            {
                updatePageConfig();
            }
        }

        private void updatePageConfig()
        {
            pageNameLabel.Text = "Sửa người dùng";
            deleteLinkButton.Visible = true;
            usernameTextBox.Attributes["readonly "] = "readonly";

            // get user info from passed username parameter
            UserEntity user = UserService.findByUsername(PageStatusManager.item(this));

            // if cannot find user info then redirect back to user_page
            if (DataUtils.isNull(user))
            {
                Response.Redirect("~/Pages/user_page.aspx");
            }

            if (user.role.code == "ADMIN")
            {
                roleDropdownList.Attributes["disabled"] = "disabled";
            }

            // If can find user info then render it to the control
            usernameTextBox.Text = user.username;
            fullNameTextBox.Text = user.fullName;
            avatarImage.ImageUrl = user.avatar;
            roleDropdownList.SelectedValue = user.role.code;
        }
        
        protected void usernameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = usernameTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    args.IsValid = false;
                    usernameValidator.ErrorMessage = "Tên đăng nhập không được rỗng";
                    return;
                }
            }

            if (username.Length > 15)
            {
                args.IsValid = false;
                usernameValidator.ErrorMessage = "Tên đăng nhập phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void passwordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string password = passwordTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    args.IsValid = false;
                    passwordValidator.ErrorMessage = "Mật khẩu không được rỗng";
                    return;
                }
            }
            
            if (password.Length > 15)
            {
                args.IsValid = false;
                passwordValidator.ErrorMessage = "Mật khẩu phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void fullNameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fullName = fullNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                args.IsValid = false;
                fullNameValidator.ErrorMessage = "Họ tên không được rỗng";
                return;
            }

            if (fullName.Length > 50)
            {
                args.IsValid = false;
                fullNameValidator.ErrorMessage = "Họ tên phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }


        protected void roleValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string roleCode = roleDropdownList.SelectedValue;

            if (!string.IsNullOrEmpty(roleCode))
            {
                args.IsValid = true;
                return;
                
            }

            args.IsValid = false;
            roleValidator.ErrorMessage = "Vai trò không được rỗng";
        }


        protected void avatarValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (avatarImage.ImageUrl != "")
            {
                args.IsValid = true;
                return;
            }

            args.IsValid = false;
            avatarValidator.ErrorMessage = "Hình ảnh không hợp lệ";
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            UserEntity user = new UserEntity();
            user.username = usernameTextBox.Text;
            user.password = passwordTextBox.Text;
            user.fullName = fullNameTextBox.Text;
            user.avatar = avatarImage.ImageUrl;
            user.role.code = roleDropdownList.SelectedValue;

            ResponseObject<UserEntity> res = null;

            if (PageStatusManager.isUpdate(this))
            {
                res = UserService.update(user);
            }
            else
            {
                res = UserService.create(user);
            }

            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }

            PageUtils.showMessage(messageLabel, "Lưu thành công", true);
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_USER);

            string code = PageStatusManager.item(this);
            ResponseObject<UserEntity> res = UserService.delete(code);

            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }

            Response.Redirect("~/Pages/user_page.aspx");
        }


    }
}