using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Service;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class order_info : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_ORDER;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_ORDER;
            }

            SecurityManager.authorize(this, permission);
        }

        private void updatePageConfig()
        {
            // Updation status
            pageNameLabel.Text = "Sửa hóa đơn";
            deleteLinkButton.Visible = true;
            codeTextBox.Attributes["readonly "] = "readonly";
            OrderEntity order = OrderService.findByCode(PageStatusManager.item(this));

            if (DataUtils.isNull(order))
            {
                return;
            }

            codeTextBox.Text = order.code;
            orderDateTextBox.Text = order.orderDate.ToString("dd/MM/yyyy");
            customerDropDownList.SelectedValue = order.customer.code;
            userTextBox.Text = order.user.username;
            totalAmountTextBox.Text = order.totalAmount.ToString();
        }

        public void createPageConfig()
        {
            userTextBox.Text = UserSessionManager.currentUser.username;
            orderDateTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            List<CustomerEntity> customers = CustomerService.findAll();
            PageUtils.bindData(customerDropDownList, customers);

            if (PageStatusManager.isUpdate(this))
            {
                updatePageConfig();
                return;
            }

            createPageConfig();

        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_ORDER);

            string code = PageStatusManager.item(this);
            if (!OrderService.delete(code))
            {
                PageUtils.showMessage(messageLabel, "Mã hóa đơn không tồn tại");
                return;
            }

            Response.Redirect("~/Pages/order_page.aspx");
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            OrderEntity order = new OrderEntity();
            order.code = codeTextBox.Text;
            order.customer.code = customerDropDownList.SelectedValue;
            order.user.username = userTextBox.Text;
            order.totalAmount = Convert.ToInt64(totalAmountTextBox.Text);

            if (!PageStatusManager.isUpdate(this))
            {
                if (!OrderService.create(order))
                {
                    PageUtils.showMessage(messageLabel, "Mã loại sản phẩm đã tồn tại");
                    return;
                }
            }
            else
            {
                if (!OrderService.update(order))
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
                    codeValidator.ErrorMessage = "Mã hóa đơn không được rỗng";
                    return;
                }
            }

            if (code.Length > 15)
            {
                args.IsValid = false;
                codeValidator.ErrorMessage = "Mã hóa đơn phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }


        protected void orderDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string orderDateString = orderDateTextBox.Text;
;
            DateTime orderDate;
            if (!DateTime.TryParse(orderDateString, out orderDate))
            {
                args.IsValid = false;
                orderDateValidator.ErrorMessage = "Ngày lập hóa đơn không hợp lệ";
                return;
            }

            if (orderDate > DateTime.Now)
            {
                args.IsValid = false;
                orderDateValidator.ErrorMessage = "Ngày lập hóa đơn không thể lớn hơn ngày hiện tại";
                return;
            }

            args.IsValid = true;
        }

        protected void customerValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string customerCode = customerDropDownList.SelectedValue;

            if (string.IsNullOrEmpty(customerCode))
            {
                args.IsValid = false;
                customerValidator.ErrorMessage = "Khách hàng không được rỗng";
                return;
            }

            args.IsValid = true;
        }
    }
}