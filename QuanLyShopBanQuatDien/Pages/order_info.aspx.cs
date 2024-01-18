using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.Entities;
using System.Globalization;

using QuanLyShopBanQuatDien.DTO;

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

            // if order code is wrong
            if (DataUtils.isNull(order))
            {
                Response.Redirect("~/Pages/order_page.aspx");
            }

            codeTextBox.Text = order.code;
            orderDateTextBox.Text = TypeConverter.dateToStr(order.orderDate);
            customerDropDownList.SelectedValue = order.customer.code;
            userTextBox.Text = order.user.username;
            totalAmountTextBox.Text = order.totalAmount.ToString();

            ViewStateManager.state(ViewState, order.orderDetails);
            PageUtils.bindData(gridView, order.orderDetails);
        }

        public void createPageConfig()
        {
            userTextBox.Text = UserSessionManager.currentUser.username;
            orderDateTextBox.Text = TypeConverter.dateToStr(DateTime.Now);
            List<OrderDetailEntity> orderDetails = new List<OrderDetailEntity>();
            ViewStateManager.state(ViewState, orderDetails);
            PageUtils.bindData(gridView, orderDetails);
        }

        private Int64 getTotalAmount(List<OrderDetailEntity> orderDetails)
        {
            Int64 totalAmount = 0;
            foreach (OrderDetailEntity orderDetail in orderDetails)
            {
                totalAmount += (orderDetail.price * orderDetail.quantity);
            }
            return totalAmount;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            // For first load
            List<CustomerEntity> customers = CustomerService.findAll();
            PageUtils.bindData(customerDropDownList, customers);

            if (PageStatusManager.isUpdate(this))
            {
                updatePageConfig();
            }
            else
            {
                createPageConfig();
            }

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
            order.orderDate = TypeConverter.strToDate(orderDateTextBox.Text);
            order.customer.code = customerDropDownList.SelectedValue;
            order.user.username = UserSessionManager.currentUser.username;

            List<OrderDetailEntity> orderDetails = ViewStateManager.state<OrderDetailEntity>(ViewState);
            orderDetails = updateDataToOrderDetails(orderDetails);

            order.orderDetails = orderDetails;

            ResponseObject<OrderEntity> res = null;
            if (PageStatusManager.isUpdate(this))
            {
                res = OrderService.update(order);
            }
            else
            {
                res = OrderService.create(order);
            }

            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }

            totalAmountTextBox.Text = getTotalAmount(orderDetails).ToString();
            PageUtils.bindData(gridView, orderDetails);
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
            
            if (!TypeConverter.isValidDate(orderDateString))
            {
                args.IsValid = false;
                orderDateValidator.ErrorMessage = "Ngày lập hóa đơn không hợp lệ";
                return;
            }

            DateTime orderDate = TypeConverter.strToDate(orderDateString);
            DateTime currentDate = TypeConverter.currentDate();

            if (orderDate > currentDate)
            {
                args.IsValid = false;
                orderDateValidator.ErrorMessage = "Ngày lập không thể lớn hơn ngày hiện tại";
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

        private List<OrderDetailEntity> updateDataToOrderDetails(List<OrderDetailEntity> orderDetails)
        {
            foreach (GridViewRow row in gridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label productCodeLabel = (Label)row.FindControl("productCodeLabel");
                    TextBox quantityTextBox = (TextBox)row.FindControl("quantityTextBox");
                    TextBox priceTextBox = (TextBox)row.FindControl("priceTextBox");

                    foreach (OrderDetailEntity orderDetail in orderDetails)
                    {
                        if (orderDetail.product.code == productCodeLabel.Text)
                        {
                            if (TypeConverter.isValidInt(quantityTextBox.Text))
                            {
                                orderDetail.quantity = TypeConverter.strToInt(quantityTextBox.Text);
                            }

                            if (TypeConverter.isValidInt(priceTextBox.Text))
                            {
                                orderDetail.price = TypeConverter.strToInt(priceTextBox.Text);
                            }
                            orderDetail.subtotal = orderDetail.quantity * orderDetail.price;
                        }
                    }
                }
            }
            return orderDetails;
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            Label productCodeLabel = gridView.Rows[rowIndex].Cells[2].FindControl("productCodeLabel") as Label;

            string code = productCodeLabel.Text;

            List<OrderDetailEntity> orderDetails = ViewStateManager.state<OrderDetailEntity>(ViewState);
            foreach (OrderDetailEntity orderDetail in orderDetails)
            {
                if (orderDetail.product.code == code)
                {
                    orderDetails.Remove(orderDetail);
                    break;
                }
            }

            orderDetails = updateDataToOrderDetails(orderDetails);

            ViewStateManager.state(ViewState, orderDetails);
            PageUtils.bindData(gridView, orderDetails);
            totalAmountTextBox.Text = getTotalAmount(orderDetails).ToString();

            PageUtils.showMessage(productMessageLabel, "Xóa thành công", true);
        }


        protected void addButton_Click(object sender, EventArgs e)
        {

            string productCode = findTextBox.Text;

            List<OrderDetailEntity> orderDetails = ViewStateManager.state<OrderDetailEntity>(ViewState);
            orderDetails = updateDataToOrderDetails(orderDetails);
            ViewStateManager.state(ViewState, orderDetails);

            ProductEntity product = ProductService.findByCode(productCode);
            if (DataUtils.isNull(product))
            {
                PageUtils.bindData(gridView, orderDetails);
                totalAmountTextBox.Text = getTotalAmount(orderDetails).ToString();
                PageUtils.showMessage(productMessageLabel, "Mã sản phẩm không chính xác");
                return;
            }

            foreach (OrderDetailEntity orderDetail in orderDetails)
            {
                if (DataUtils.strCompare(orderDetail.product.code, productCode))
                {
                    PageUtils.bindData(gridView, orderDetails);
                    totalAmountTextBox.Text = getTotalAmount(orderDetails).ToString();
                    PageUtils.showMessage(productMessageLabel, "Sản phẩm đã tồn tại trong hóa đơn");
                    return;
                }
            }

            OrderDetailEntity newOrderDetail = new OrderDetailEntity();
            newOrderDetail.product = product;
            orderDetails.Add(newOrderDetail);
            
            ViewStateManager.state(ViewState, orderDetails);
            PageUtils.bindData(gridView, orderDetails);
            totalAmountTextBox.Text = getTotalAmount(orderDetails).ToString();
            PageUtils.showMessage(productMessageLabel, "Thêm thành công", true);
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_ORDER);

            string code = PageStatusManager.item(this);
            ResponseObject<OrderEntity> res = OrderService.delete(code);
            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }

            Response.Redirect("~/Pages/order_page.aspx");
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}