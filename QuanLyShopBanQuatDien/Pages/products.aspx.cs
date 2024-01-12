using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProductEntity> a = new List<ProductEntity>();
            for (int i = 0; i < 5; i++)
            {
                ProductEntity product = new ProductEntity();

                // Set values for the properties
                product.Id = (i+1);
                product.Code = "ABC123" + (i + 1);
                product.Name = "ProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProduct Name" + (i + 1);
                product.Power = 100 + i;
                product.Brand = "ProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProduct" + (i + 1);
                product.Size = 5.0 + i ;
                product.Material = "ProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProductProduct" + (i + 1);
                product.Color = "Red" + (i + 1);
                product.Speed = 50 + i;
                product.Image = null;
                product.Status = true;

                // Create an instance of CategoryEntity and set its values
                CategoryEntity category = new CategoryEntity();
                category.Id = 101;
                category.Code = "Category Code";
                category.Name = "Electronics" + (i + 1);

                // Set the Category property of the product
                product.Category = category;

                a.Add(product);
            }
 

            productGridView.DataSource = a;
            productGridView.DataBind();
        }

        protected void productGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}