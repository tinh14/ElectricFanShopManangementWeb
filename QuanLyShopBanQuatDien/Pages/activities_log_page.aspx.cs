using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Service;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class activities_log_page : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticateAndAuthorize(this, SecurityManager.Permission.VIEW_ACTIVITY_LOG);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            loadData();
        }

        public void loadData()
        {
            List<ActivityLogEntity> activityLogs = ActivityLogService.findAll();
            ViewStateManager.state<ActivityLogEntity>(ViewState, activityLogs);
            PageUtils.bindData(gridView, activityLogs);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, activityLogs.Count);
        }

      
        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            string code = gridView.Rows[rowIndex].Cells[1].Text;

            Response.Redirect("~/Pages/activity_log_info.aspx?code=" + code);
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void startDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string startDateStr = startDateTextBox.Text;

            if (startDateStr == "")
            {
                args.IsValid = true;
                return;
            }

            if (!TypeConverter.isValidDate(startDateStr))
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

            if (!TypeConverter.isValidDate(endDateStr))
            {
                args.IsValid = false;
                endDateValidator.ErrorMessage = "Ngày kết thúc không hợp lệ";
                return;
            }

            args.IsValid = true;
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            string startDateStr = startDateTextBox.Text;
            string endDateStr = endDateTextBox.Text;

            DateTime startDate = new DateTime(1753, 1, 1);
            DateTime endDate = new DateTime(9999, 12, 31);

            if (startDateStr != "")
            {
                startDate = TypeConverter.strToDate(startDateStr);
            }

            if (endDateStr != "")
            {
                endDate = TypeConverter.strToDate(endDateStr);
            }


            List<ActivityLogEntity> activityLogs = ActivityLogService.findByStartDateAndEndDate(startDate, endDate);

            ViewStateManager.state<ActivityLogEntity>(ViewState, activityLogs);
            PageUtils.bindData(gridView, activityLogs);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, activityLogs.Count);
        }

    }
}