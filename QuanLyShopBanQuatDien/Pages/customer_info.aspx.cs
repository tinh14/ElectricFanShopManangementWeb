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
    public partial class customer_info : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_CUSTOMER;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_CUSTOMER;
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
            pageNameLabel.Text = "Sửa khách hàng";
            deleteLinkButton.Visible = true;
            codeTextBox.Attributes["readonly "] = "readonly";
            CustomerEntity customer = CustomerService.findByCode(PageStatusManager.item(this));

            if (DataUtils.isNull(customer))
            {
                return;
            }

            codeTextBox.Text = customer.code;
            nameTextBox.Text = customer.name;
            phoneNumberTextBox.Text = customer.phoneNumber;
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_CUSTOMER);

            string code = PageStatusManager.item(this);
            if (!CustomerService.delete(code))
            {
                PageUtils.showMessage(messageLabel, "Mã khách hàng không tồn tại");
                return;
            }

            Response.Redirect("~/Pages/customer_page.aspx");
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            CustomerEntity customer = new CustomerEntity();
            customer.code = codeTextBox.Text;
            customer.name = nameTextBox.Text;
            customer.phoneNumber = phoneNumberTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (!CustomerService.create(customer))
                {
                    PageUtils.showMessage(messageLabel, "Mã khách hàng đã tồn tại");
                    return;
                }
            }
            else
            {
                if (!CustomerService.update(customer))
                {
                    PageUtils.showMessage(messageLabel, "Mã khách hàng không tồn tại");
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
                    codeValidator.ErrorMessage = "Mã khách hàng không được rỗng";
                    return;
                }
            }

            if (code.Length > 15)
            {
                args.IsValid = false;
                codeValidator.ErrorMessage = "Mã khách hàng phải ít hơn 15 ký tự";
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
                nameValidator.ErrorMessage = "Tên khách hàng không được rỗng";
                return;
            }

            if (name.Length > 50)
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên khách hàng phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void phoneNumberValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string phoneNumber = phoneNumberTextBox.Text;

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                args.IsValid = false;
                phoneNumberValidator.ErrorMessage = "Số điện thoại không được rỗng";
                return;
            }

            if (phoneNumber.Length > 15)
            {
                args.IsValid = false;
                phoneNumberValidator.ErrorMessage = "Số điện thoại phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }
    }
}