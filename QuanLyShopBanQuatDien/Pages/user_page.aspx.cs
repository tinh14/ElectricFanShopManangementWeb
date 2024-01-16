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
    public partial class user_page : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticateAndAuthorize(this, SecurityManager.Permission.VIEW_USER);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                return;
            }

            loadData();
        }

        private void loadData()
        {
            List<UserEntity> users = UserService.findAll();
            ViewStateManager.state<UserEntity>(ViewState, users);

            List<RoleEntity> roles = RoleService.findAll();

            PageUtils.bindData(gridView, users);
            PageUtils.bindData(filterDropdownList, roles);

            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, users.Count);
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            List<UserEntity> users = UserService.findByName(findTextBox.Text);

            ViewStateManager.state<UserEntity>(ViewState, users);

            PageUtils.bindData(gridView, users);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, users.Count);
        }

        protected void filterDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string roleCode = filterDropdownList.SelectedValue;
            List<UserEntity> users = ViewStateManager.state<UserEntity>(ViewState);

            if (roleCode == "all")
            {
                PageUtils.bindData(gridView, users);
                PageUtils.updateTotalOfRecords(totalOfRecordsLabel, users.Count);
                return;
            }

            List<UserEntity> filteredProducts = UserService.filterByRoleCode(users, roleCode);

            PageUtils.bindData(gridView, filteredProducts);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, filteredProducts.Count);
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            string code = gridView.Rows[rowIndex].Cells[2].Text;

            Response.Redirect("~/Pages/user_info.aspx?code=" + code);
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