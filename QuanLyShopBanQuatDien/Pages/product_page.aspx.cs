using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class product_page : System.Web.UI.Page
    {
        private List<ProductEntity> products
        {
            get
            {
                if (ViewState["products"] == null)
                {
                    ViewState["products"] = new List<ProductEntity>();
                }
                return (List<ProductEntity>)ViewState["products"];
            }
            set
            {
                ViewState["products"] = value;
            }
        }

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
            products = ProductService.findAll();
            List<CategoryEntity> categories = CategoryService.findAll();

            PageUtils.bindData(productGridView, products);
            PageUtils.bindData(categoryFilterDropdownList, categories);

            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, products.Count);
        }

        protected void productGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            products = ProductService.findByName(findProductTextBox.Text);

            PageUtils.bindData(productGridView, products);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, products.Count);
        }

        protected void categoryFilterDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoryCode = categoryFilterDropdownList.SelectedValue;

            if (categoryCode == "all")
            {
                PageUtils.bindData(productGridView, products);
                PageUtils.updateTotalOfRecords(totalOfRecordsLabel, products.Count);
                return;
            }

            List<ProductEntity> filteredProducts = ProductService.filterByCategoryCode(products, categoryCode);
            PageUtils.bindData(productGridView, filteredProducts);
            PageUtils.updateTotalOfRecords(totalOfRecordsLabel, filteredProducts.Count);
        }

        protected void productGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);

            string code = productGridView.Rows[rowIndex].Cells[2].Text;

            Response.Redirect("~/Pages/product_info.aspx?code=" + code);
        }
    }
}