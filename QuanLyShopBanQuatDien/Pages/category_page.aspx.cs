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
    public partial class category_page : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticateAndAuthorize(this, SecurityManager.Permission.VIEW_CATEGORY);
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
            List<CategoryEntity> categories = CategoryService.findAll();
            ViewStateManager.state<CategoryEntity>(ViewState, categories);

            PageUtils.bindData(gridView, categories);

            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, categories.Count);
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            List<CategoryEntity> categories = CategoryService.findByName(findTextBox.Text);

            ViewStateManager.state<CategoryEntity>(ViewState, categories);

            PageUtils.bindData(gridView, categories);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, categories.Count);
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            string code = gridView.Rows[rowIndex].Cells[1].Text;

            Response.Redirect("~/Pages/category_info.aspx?code=" + code);
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