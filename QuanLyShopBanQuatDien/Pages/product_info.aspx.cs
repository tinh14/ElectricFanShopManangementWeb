using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.Pages;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class product_info : System.Web.UI.Page
    {


        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_PRODUCT;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_PRODUCT;
            }

            SecurityManager.authorize(this, permission);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // For upload image
                if (imageFileUpload.HasFile)
                {
                    bool isValidImage = imageFileUpload.PostedFile.ContentType.StartsWith("image/");
                    imageImage.ImageUrl = !isValidImage ? "" : DataUtils.base64(imageFileUpload.FileBytes);
                }

                return;
            }

            // Categories
            List<CategoryEntity> categories = CategoryService.findAll();

            PageUtils.bindData(categoryDropDownList, categories);
            
            // Check page status and handle page
            if (!PageStatusManager.isUpdate(this))
            {
                return;
            }

            // Updation status
            pageNameLabel.Text = "Sửa sản phẩm";
            deleteLinkButton.Visible = true;
            codeTextBox.Attributes["readonly "] = "readonly";
            ProductEntity product = ProductService.findByCode(PageStatusManager.item(this));
            
            if (DataUtils.isNull(product))
            {
                return;
            }

            codeTextBox.Text = product.code;
            nameTextBox.Text = product.name;
            priceTextBox.Text = product.price.ToString();
            brandTextBox.Text = product.brand;
            powerTextBox.Text = product.power;
            sizeTextBox.Text = product.size;
            materialTextBox.Text = product.material;
            colorTextBox.Text = product.color;
            speedTextBox.Text = product.speed;
            imageImage.ImageUrl = product.image;
            categoryDropDownList.SelectedValue = product.category.code;

        }

        protected void codeValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string code = codeTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    args.IsValid = false;
                    codeValidator.ErrorMessage = "Mã sản phẩm không được rỗng";
                    return;
                }
            }

            if (code.Length > 15)
            {
                args.IsValid = false;
                codeValidator.ErrorMessage = "Mã sản phẩm phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void nameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = nameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên sản phẩm không được rỗng";
                return;
            }

            if (name.Length > 50)
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên sản phẩm phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void categoryValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string categoryCode = categoryDropDownList.SelectedValue;

            if (string.IsNullOrEmpty(categoryCode))
            {
                args.IsValid = false;
                categoryValidator.ErrorMessage = "Loại sản phẩm không được rỗng";
                return;
            }

            args.IsValid = true;
        }

        protected void brandValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string brand = brandTextBox.Text;

            if (string.IsNullOrWhiteSpace(brand))
            {
                args.IsValid = false;
                brandValidator.ErrorMessage = "Thương hiệu không được rỗng";
                return;
            }

            if (brand.Length > 50)
            {
                args.IsValid = false;
                brandValidator.ErrorMessage = "Thương hiệu phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void powerValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string power = powerTextBox.Text;

            if (string.IsNullOrWhiteSpace(power))
            {
                args.IsValid = false;
                powerValidator.ErrorMessage = "Công suất tiêu thụ không được rỗng";
                return;
            }

            if (power.Length > 50)
            {
                args.IsValid = false;
                powerValidator.ErrorMessage = "Công suất tiêu thụ phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void sizeValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string size = sizeTextBox.Text;

            if (string.IsNullOrWhiteSpace(size))
            {
                args.IsValid = false;
                sizeValidator.ErrorMessage = "Kích thước không được rỗng";
                return;
            }

            if (size.Length > 50)
            {
                args.IsValid = false;
                sizeValidator.ErrorMessage = "Kích thước phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void materialValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string material = materialTextBox.Text;

            if (string.IsNullOrWhiteSpace(material))
            {
                args.IsValid = false;
                materialValidator.ErrorMessage = "Chất liệu không được rỗng";
                return;
            }

            if (material.Length > 50)
            {
                args.IsValid = false;
                materialValidator.ErrorMessage = "Chất liệu phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void colorValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string color = colorTextBox.Text;

            if (string.IsNullOrWhiteSpace(color))
            {
                args.IsValid = false;
                colorValidator.ErrorMessage = "Màu sắc không được rỗng";
                return;
            }

            if (color.Length > 50)
            {
                args.IsValid = false;
                colorValidator.ErrorMessage = "Màu sắc phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void speedValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string speed = speedTextBox.Text;

            if (string.IsNullOrWhiteSpace(speed))
            {
                args.IsValid = false;
                speedValidator.ErrorMessage = "Tốc độ gió không được rỗng";
                return;
            }

            if (speed.Length > 50)
            {
                args.IsValid = false;
                speedValidator.ErrorMessage = "Tốc độ gió phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void imageValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (imageImage.ImageUrl == "")
            {
                args.IsValid = false;
                imageValidator.ErrorMessage = "Hình ảnh không hợp lệ";
                return;
            }
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            ProductEntity product = new ProductEntity();
            product.code = codeTextBox.Text;
            product.name = nameTextBox.Text;
            product.price = int.Parse(priceTextBox.Text);
            product.brand = brandTextBox.Text;
            product.power = powerTextBox.Text;
            product.size = sizeTextBox.Text;
            product.material = materialTextBox.Text;
            product.color = colorTextBox.Text;
            product.speed = speedTextBox.Text;
            product.image = imageImage.ImageUrl;
            product.category.code = categoryDropDownList.SelectedValue;

            if (!PageStatusManager.isUpdate(this))
            {
                if (!ProductService.create(product))
                {
                    PageUtils.showMessage(messageLabel, "Mã sản phẩm đã tồn tại");
                    return;
                }
            }
            else
            {
                if (!ProductService.update(product))
                {
                    PageUtils.showMessage(messageLabel, "Mã sản phẩm không tồn tại");
                    return;
                }
            }

            PageUtils.showMessage(messageLabel, "Lưu thành công", true);
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_PRODUCT);

            string code = PageStatusManager.item(this);
            if (!ProductService.delete(code))
            {
                PageUtils.showMessage(messageLabel, "Mã sản phẩm không tồn tại");
                return;
            }

            Response.Redirect("~/Pages/product_page.aspx");
        }

        protected void priceValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string price = priceTextBox.Text;

            if (string.IsNullOrWhiteSpace(price))
            {
                args.IsValid = false;
                priceValidator.ErrorMessage = "Giá không được rỗng";
                return;
            }

            if (!TypeConverter.isValidInt(price))
            {
                args.IsValid = false;
                priceValidator.ErrorMessage = "Giá không hợp lệ";
                return;
            }

            int validPrice = TypeConverter.strToInt(price);

            if (validPrice <= 0)
            {
                args.IsValid = false;
                priceValidator.ErrorMessage = "Giá phải là số nguyên dương";
                return;
            }

            args.IsValid = true;
        }
    }
}