using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class product_page : System.Web.UI.Page
    {
        
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticateAndAuthorize(this, SecurityManager.Permission.VIEW_PRODUCT);
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
            List<ProductEntity> products = ProductService.findAll();
            ViewStateManager.state<ProductEntity>(ViewState, products);
            
            List<CategoryEntity> categories = CategoryService.findAll();

            PageUtils.bindData(gridView, products);
            PageUtils.bindData(categoryFilterDropdownList, categories);

            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, products.Count);
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            List<ProductEntity> products = ProductService.findByName(findTextBox.Text);

            ViewStateManager.state<ProductEntity>(ViewState, products);

            PageUtils.bindData(gridView, products);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, products.Count);
        }

        protected void categoryFilterDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoryCode = categoryFilterDropdownList.SelectedValue;
            List<ProductEntity> products = ViewStateManager.state<ProductEntity>(ViewState);

            if (categoryCode == "all")
            {
                PageUtils.bindData(gridView, products);
                PageUtils.updateTotalOfRecords(totalOfRecordsLabel, products.Count);
                return;
            }

            List<ProductEntity> filteredProducts = ProductService.filterByCategoryCode(products, categoryCode);

            PageUtils.bindData(gridView, filteredProducts);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, filteredProducts.Count);
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            string code = gridView.Rows[rowIndex].Cells[2].Text;

            Response.Redirect("~/Pages/product_info.aspx?code=" + code);
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