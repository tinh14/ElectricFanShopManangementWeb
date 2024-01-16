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
    public partial class supplier_info : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_SUPPLIER;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_SUPPLIER;
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
            pageNameLabel.Text = "Sửa nhà cung cấp";
            deleteLinkButton.Visible = true;
            codeTextBox.Attributes["readonly "] = "readonly";
            SupplierEntity supplier = SupplierService.findByCode(PageStatusManager.item(this));

            if (DataUtils.isNull(supplier))
            {
                return;
            }

            codeTextBox.Text = supplier.code;
            nameTextBox.Text = supplier.name;
            contactPersonTextBox.Text = supplier.contactPerson;
            phoneNumberTextBox.Text = supplier.phoneNumber;
            addressTextBox.Text = supplier.address;
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_SUPPLIER);

            string code = PageStatusManager.item(this);
            if (!SupplierService.delete(code))
            {
                PageUtils.showMessage(messageLabel, "Mã nhà cung cấp không tồn tại");
                return;
            }

            Response.Redirect("~/Pages/supplier_page.aspx");
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            SupplierEntity supplier = new SupplierEntity();
            supplier.code = codeTextBox.Text;
            supplier.name = nameTextBox.Text;
            supplier.contactPerson = contactPersonTextBox.Text;
            supplier.phoneNumber = phoneNumberTextBox.Text;
            supplier.address = addressTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (!SupplierService.create(supplier))
                {
                    PageUtils.showMessage(messageLabel, "Mã nhà cung cấp đã tồn tại");
                    return;
                }
            }
            else
            {
                if (!SupplierService.update(supplier))
                {
                    PageUtils.showMessage(messageLabel, "Mã nhà cung cấp không tồn tại");
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
                    codeValidator.ErrorMessage = "Mã nhà cung cấp không được rỗng";
                    return;
                }
            }

            if (code.Length > 15)
            {
                args.IsValid = false;
                codeValidator.ErrorMessage = "Mã nhà cung cấp phải ít hơn 15 ký tự";
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
                nameValidator.ErrorMessage = "Tên nhà cung cấp không được rỗng";
                return;
            }

            if (name.Length > 50)
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên nhà cung cấp phải ít hơn 50 ký tự";
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

        protected void contactPersonValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string contactPerson = contactPersonTextBox.Text;

            if (string.IsNullOrWhiteSpace(contactPerson))
            {
                args.IsValid = false;
                contactPersonValidator.ErrorMessage = "Người liên hệ không được rỗng";
                return;
            }

            if (contactPerson.Length > 15)
            {
                args.IsValid = false;
                contactPersonValidator.ErrorMessage = "Người liên hệ phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void addressValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string adress = addressTextBox.Text;

            if (string.IsNullOrWhiteSpace(adress))
            {
                args.IsValid = false;
                addressValidator.ErrorMessage = "Địa chỉ không được rỗng";
                return;
            }
            args.IsValid = true;
        }
    }
}