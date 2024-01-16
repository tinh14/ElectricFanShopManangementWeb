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
    public partial class supplier_page : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticateAndAuthorize(this, SecurityManager.Permission.VIEW_SUPPLIER);
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
            List<SupplierEntity> customers = SupplierService.findAll();
            ViewStateManager.state<SupplierEntity>(ViewState, customers);

            PageUtils.bindData(gridView, customers);

            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, customers.Count);
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            List<SupplierEntity> customers = SupplierService.findByName(findTextBox.Text);

            ViewStateManager.state<SupplierEntity>(ViewState, customers);

            PageUtils.bindData(gridView, customers);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, customers.Count);
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            string code = gridView.Rows[rowIndex].Cells[1].Text;

            Response.Redirect("~/Pages/supplier_info.aspx?code=" + code);
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