using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.DTO;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class statistics_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                productGridView.Visible = false;
                customerGridView.Visible = false;

                List<RevenueByProductDTO> revenueByProductList = ViewStateManager.state<RevenueByProductDTO>(ViewState);
                List<RevenueByCustomerDTO> revenueByCustomerList = ViewStateManager.state<RevenueByCustomerDTO>(ViewState);

                ViewStateManager.state(ViewState, revenueByProductList);
                ViewStateManager.state(ViewState, revenueByCustomerList);
            }
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            string value = dropdownList.SelectedValue;
            string startDateStr = startDateTextBox.Text;
            string endDateStr = endDateTextBox.Text;

            DateTime startDate = TypeConverter.databaseMinDate();
            DateTime endDate = TypeConverter.databaseMaxDate();

            if (startDateStr != "")
            {
                startDate = TypeConverter.strToDate(startDateStr, TypeConverter.DateTimeConfig.DATE_PATTERN);
            }

            if (endDateStr != "")
            {
                endDate = TypeConverter.strToDate(endDateStr, TypeConverter.DateTimeConfig.DATE_PATTERN);
            }

            
            if (value == "product"){
                List<RevenueByProductDTO> revenueList = StatisticsService.findRevenueByProduct(startDate, endDate);
                PageUtils.bindData(productGridView, revenueList);
                PageUtils.updateTotalOfRecords(totalOfRecordsLabel, revenueList.Count);
                ViewStateManager.state(ViewState, revenueList);
                productGridView.Visible = true;
            }
            else if (value == "customer")
            {
                List<RevenueByCustomerDTO> revenueList = StatisticsService.findRevenueByCustomer(startDate, endDate);
                PageUtils.bindData(customerGridView, revenueList);
                PageUtils.updateTotalOfRecords(totalOfRecordsLabel, revenueList.Count);
                ViewStateManager.state(ViewState, revenueList);
                customerGridView.Visible = true;
            }

            ViewState["startDate"] = startDate;
            ViewState["endDate"] = endDate;
        }

        protected void startDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string startDateStr = startDateTextBox.Text;

            if (startDateStr == "")
            {
                args.IsValid = true;
                return;
            }

            if (!TypeConverter.isValidDate(startDateStr, TypeConverter.DateTimeConfig.DATE_PATTERN))
            {
                args.IsValid = false;
                startDateValidator.ErrorMessage = "Ngày bắt đầu không hợp lệ";
                return;
            }
            args.IsValid = true;
        }

        protected void endDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string endDateStr = endDateTextBox.Text;

            if (endDateStr == "")
            {
                args.IsValid = true;
                return;
            }

            if (!TypeConverter.isValidDate(endDateStr, TypeConverter.DateTimeConfig.DATE_PATTERN))
            {
                args.IsValid = false;
                endDateValidator.ErrorMessage = "Ngày kết thúc không hợp lệ";
                return;
            }

            args.IsValid = true;
        }

        protected void exportButton_Click(object sender, EventArgs e)
        {
            string value = dropdownList.SelectedValue;
            if (value == "product")
            {
                List<RevenueByProductDTO> revenueByProductList = ViewStateManager.state<RevenueByProductDTO>(ViewState);
                if (DataUtils.isEmpty(revenueByProductList))
                {
                    PageUtils.showMessage(messageLabel, "Không có dữ liệu thống kê");
                    return;
                }

                PageUtils.showMessage(messageLabel, "");
                DateTime startDate = TypeConverter.strToDate(ViewState["startDate"].ToString(), TypeConverter.DateTimeConfig.DATE_PATTERN);
                DateTime endDate = TypeConverter.strToDate(ViewState["endDate"].ToString(), TypeConverter.DateTimeConfig.DATE_PATTERN);

                ExcelExporter.export(Response, startDate, endDate, revenueByProductList);
            }
            else if (value == "customer")
            {
                List<RevenueByCustomerDTO> revenueByCustomerList = ViewStateManager.state<RevenueByCustomerDTO>(ViewState);
                if (DataUtils.isEmpty(revenueByCustomerList))
                {
                    PageUtils.showMessage(messageLabel, "Không có dữ liệu thống kê");
                    return;
                }

                PageUtils.showMessage(messageLabel, "");
                DateTime startDate = TypeConverter.strToDate(ViewState["startDate"].ToString(), TypeConverter.DateTimeConfig.DATE_PATTERN);
                DateTime endDate = TypeConverter.strToDate(ViewState["endDate"].ToString(), TypeConverter.DateTimeConfig.DATE_PATTERN);

                ExcelExporter.export(Response, startDate, endDate, revenueByCustomerList);
            }
        }
    }
}