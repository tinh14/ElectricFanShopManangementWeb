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
    public partial class role_page : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticateAndAuthorize(this, SecurityManager.Permission.VIEW_ROLE);
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
            List<RoleEntity> roles = RoleService.findAll();
            ViewStateManager.state<RoleEntity>(ViewState, roles);

            PageUtils.bindData(gridView, roles);

            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, roles.Count);
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            List<RoleEntity> roles = RoleService.findByName(findTextBox.Text);

            ViewStateManager.state<RoleEntity>(ViewState, roles);

            PageUtils.bindData(gridView, roles);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, roles.Count);
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            string code = gridView.Rows[rowIndex].Cells[1].Text;

            Response.Redirect("~/Pages/role_info.aspx?code=" + code);
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