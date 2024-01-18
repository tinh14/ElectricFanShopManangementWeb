using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.DTO;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class grn_info : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_GRN;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_GRN;
            }

            SecurityManager.authorize(this, permission);
        }

        private void updatePageConfig()
        {
            // Updation status
            pageNameLabel.Text = "Sửa phiếu nhập";
            deleteLinkButton.Visible = true;
            codeTextBox.Attributes["readonly "] = "readonly";
            GRNEntity grn = GRNService.findByCode(PageStatusManager.item(this));

            // if grn code is wrong
            if (DataUtils.isNull(grn))
            {
                Response.Redirect("~/Pages/grn_page.aspx");
            }

            codeTextBox.Text = grn.code;
            grnDateTextBox.Text = TypeConverter.dateToStr(grn.grnDate, TypeConverter.DateTimeConfig.DATE_PATTERN);
            supplierDropDownList.SelectedValue = grn.supplier.code;
            userTextBox.Text = grn.user.username;
            totalAmountTextBox.Text = grn.totalAmount.ToString();

            ViewStateManager.state(ViewState, grn.grnDetails);
            PageUtils.bindData(gridView, grn.grnDetails);
        }

        public void createPageConfig()
        {
            userTextBox.Text = UserSessionManager.currentUser.username;
            grnDateTextBox.Text = TypeConverter.dateToStr(DateTime.Now, TypeConverter.DateTimeConfig.DATE_PATTERN);
            List<GRNDetailEntity> grnDetails = new List<GRNDetailEntity>();
            ViewStateManager.state(ViewState, grnDetails);
            PageUtils.bindData(gridView, grnDetails);
        }

        private Int64 getTotalAmount(List<GRNDetailEntity> grnDetails)
        {
            Int64 totalAmount = 0;
            foreach (GRNDetailEntity grnDetail in grnDetails)
            {
                totalAmount += (grnDetail.price * grnDetail.quantity);
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
            List<SupplierEntity> suppliers = SupplierService.findAll();
            PageUtils.bindData(supplierDropDownList, suppliers);

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

            GRNEntity grn = new GRNEntity();
            grn.code = codeTextBox.Text;
            grn.grnDate = TypeConverter.strToDate(grnDateTextBox.Text, TypeConverter.DateTimeConfig.DATE_PATTERN);
            grn.supplier.code = supplierDropDownList.SelectedValue;
            grn.user.username = UserSessionManager.currentUser.username;

            List<GRNDetailEntity> grnDetails = ViewStateManager.state<GRNDetailEntity>(ViewState);
            grnDetails = updateDataToGRNDetails(grnDetails);

            grn.grnDetails = grnDetails;

            ResponseObject<GRNEntity> res = null;
            if (PageStatusManager.isUpdate(this))
            {
                res = GRNService.update(grn);
            }
            else
            {
                res = GRNService.create(grn);
            }

            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }

            totalAmountTextBox.Text = getTotalAmount(grnDetails).ToString();
            PageUtils.bindData(gridView, grnDetails);
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
                    codeValidator.ErrorMessage = "Mã phiếu nhập không được rỗng";
                    return;
                }
            }

            if (code.Length > 15)
            {
                args.IsValid = false;
                codeValidator.ErrorMessage = "Mã phiếu nhập phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }


        protected void grnDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string grnDateString = grnDateTextBox.Text;

            if (!TypeConverter.isValidDate(grnDateString, TypeConverter.DateTimeConfig.DATE_PATTERN))
            {
                args.IsValid = false;
                grnDateValidator.ErrorMessage = "Ngày lập phiếu nhập không hợp lệ";
                return;
            }

            DateTime grnDate = TypeConverter.strToDate(grnDateString, TypeConverter.DateTimeConfig.DATE_PATTERN);
            DateTime currentDate = DateTime.Now;

            if (grnDate > currentDate)
            {
                args.IsValid = false;
                grnDateValidator.ErrorMessage = "Ngày lập không thể lớn hơn ngày hiện tại";
                return;
            }

            args.IsValid = true;
        }

        protected void supplierValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string supplierCode = supplierDropDownList.SelectedValue;

            if (string.IsNullOrEmpty(supplierCode))
            {
                args.IsValid = false;
                supplierValidator.ErrorMessage = "Khách hàng không được rỗng";
                return;
            }

            args.IsValid = true;
        }

        private List<GRNDetailEntity> updateDataToGRNDetails(List<GRNDetailEntity> grnDetails)
        {
            foreach (GridViewRow row in gridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label productCodeLabel = (Label)row.FindControl("productCodeLabel");
                    TextBox quantityTextBox = (TextBox)row.FindControl("quantityTextBox");
                    TextBox priceTextBox = (TextBox)row.FindControl("priceTextBox");

                    foreach (GRNDetailEntity grnDetail in grnDetails)
                    {
                        if (grnDetail.product.code == productCodeLabel.Text)
                        {
                            if (TypeConverter.isValidInt(quantityTextBox.Text))
                            {
                                grnDetail.quantity = TypeConverter.strToInt(quantityTextBox.Text);
                            }

                            if (TypeConverter.isValidInt(priceTextBox.Text))
                            {
                                grnDetail.price = TypeConverter.strToInt(priceTextBox.Text);
                            }
                            grnDetail.subtotal = grnDetail.quantity * grnDetail.price;
                        }
                    }
                }
            }
            return grnDetails;
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            Label productCodeLabel = gridView.Rows[rowIndex].Cells[2].FindControl("productCodeLabel") as Label;

            string code = productCodeLabel.Text;

            List<GRNDetailEntity> grnDetails = ViewStateManager.state<GRNDetailEntity>(ViewState);
            foreach (GRNDetailEntity grnDetail in grnDetails)
            {
                if (grnDetail.product.code == code)
                {
                    grnDetails.Remove(grnDetail);
                    break;
                }
            }

            grnDetails = updateDataToGRNDetails(grnDetails);

            ViewStateManager.state(ViewState, grnDetails);
            PageUtils.bindData(gridView, grnDetails);
            totalAmountTextBox.Text = getTotalAmount(grnDetails).ToString();

            PageUtils.showMessage(productMessageLabel, "Xóa thành công", true);
        }


        protected void addButton_Click(object sender, EventArgs e)
        {

            string productCode = findTextBox.Text;

            List<GRNDetailEntity> grnDetails = ViewStateManager.state<GRNDetailEntity>(ViewState);
            grnDetails = updateDataToGRNDetails(grnDetails);
            ViewStateManager.state(ViewState, grnDetails);

            ProductEntity product = ProductService.findByCode(productCode);
            if (DataUtils.isNull(product))
            {
                PageUtils.bindData(gridView, grnDetails);
                totalAmountTextBox.Text = getTotalAmount(grnDetails).ToString();
                PageUtils.showMessage(productMessageLabel, "Mã sản phẩm không chính xác");
                return;
            }

            foreach (GRNDetailEntity grnDetail in grnDetails)
            {
                if (DataUtils.strCompare(grnDetail.product.code, productCode))
                {
                    PageUtils.bindData(gridView, grnDetails);
                    totalAmountTextBox.Text = getTotalAmount(grnDetails).ToString();
                    PageUtils.showMessage(productMessageLabel, "Sản phẩm đã tồn tại trong phiếu nhập");
                    return;
                }
            }

            GRNDetailEntity newGRNDetail = new GRNDetailEntity();
            newGRNDetail.product = product;
            grnDetails.Add(newGRNDetail);

            ViewStateManager.state(ViewState, grnDetails);
            PageUtils.bindData(gridView, grnDetails);
            totalAmountTextBox.Text = getTotalAmount(grnDetails).ToString();
            PageUtils.showMessage(productMessageLabel, "Thêm thành công", true);
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_GRN);

            string code = PageStatusManager.item(this);
            ResponseObject<GRNEntity> res = GRNService.delete(code);
            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }

            Response.Redirect("~/Pages/grn_page.aspx");
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