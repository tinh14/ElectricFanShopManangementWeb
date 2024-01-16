using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Service;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class category_info : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_CATEGORY;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_CATEGORY;
            }

            SecurityManager.authorize(this, permission);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            // Check page status and handle page
            if (!PageStatusManager.isUpdate(this))
            {
                return;
            }

            // Updation status
            pageNameLabel.Text = "Sửa loại sản phẩm";
            deleteLinkButton.Visible = true;
            codeTextBox.Attributes["readonly "] = "readonly";
            CategoryEntity category = CategoryService.findByCode(PageStatusManager.item(this));

            if (DataUtils.isNull(category))
            {
                return;
            }

            codeTextBox.Text = category.code;
            nameTextBox.Text = category.name;
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_CATEGORY);

            string code = PageStatusManager.item(this);
            if (!CategoryService.delete(code))
            {
                PageUtils.showMessage(messageLabel, "Mã loại sản phẩm không tồn tại");
                return;
            }

            Response.Redirect("~/Pages/category_page.aspx");
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            CategoryEntity category = new CategoryEntity();
            category.code = codeTextBox.Text;
            category.name = nameTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (!CategoryService.create(category))
                {
                    PageUtils.showMessage(messageLabel, "Mã loại sản phẩm đã tồn tại");
                    return;
                }
            }
            else
            {
                if (!CategoryService.update(category))
                {
                    PageUtils.showMessage(messageLabel, "Mã loại sản phẩm không tồn tại");
                    return;
                }
            }

            PageUtils.showMessage(messageLabel, "Lưu thành công", true);
        }

        protected void codeValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string code = codeTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    args.IsValid = false;
                    codeValidator.ErrorMessage = "Mã loại sản phẩm không được rỗng";
                    return;
                }
            }

            if (code.Length > 15)
            {
                args.IsValid = false;
                codeValidator.ErrorMessage = "Mã loại sản phẩm phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void nameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = nameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên loại sản phẩm không được rỗng";
                return;
            }

            if (name.Length > 50)
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên loại sản phẩm phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }
    }
}