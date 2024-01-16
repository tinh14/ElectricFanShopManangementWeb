using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Service;
using QuanLyShopBanQuatDien.DTO;
using System.Web.UI.HtmlControls;

namespace QuanLyShopBanQuatDien.Pages
{
    public partial class role_info : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            SecurityManager.authenticate(this);

            SecurityManager.Permission permission = SecurityManager.Permission.CREATE_ROLE;

            if (PageStatusManager.isUpdate(this))
            {
                permission = SecurityManager.Permission.UPDATE_ROLE;
            }

            SecurityManager.authorize(this, permission);
        }

        private Dictionary<string, List<PermissionEntity>> getSortedPermissionDictionary()
        {
            List<PermissionEntity> permissions = PermissionService.findAll();
            Dictionary<string, List<PermissionEntity>> sortedPermissions = new Dictionary<string, List<PermissionEntity>>();

            foreach (var permission in permissions)
            {
                string name = permission.name;
                string resource = name.Split(new[] { ' ' }, 2)[1];
                string upperedCaseResource = char.ToUpper(resource[0]) + resource.Substring(1);

                if (!sortedPermissions.ContainsKey(upperedCaseResource))
                {
                    sortedPermissions[upperedCaseResource] = new List<PermissionEntity>();
                }

                sortedPermissions[upperedCaseResource].Add(permission);
            }
            return sortedPermissions;
        }

        private void updatePageConfig()
        {
            RoleEntity role = RoleService.findByCode(PageStatusManager.item(this));

            if (DataUtils.isNull(role))
            {
                Response.Redirect("~/Pages/role_page.aspx");
            }

            // Updation status
            pageNameLabel.Text = "Sửa vai trò";
            deleteLinkButton.Visible = true;
            codeTextBox.Attributes["disabled"] = "disabled";

            ViewStateManager.state<RolePermissionEntity>(ViewState, role.rolePermissions);

            codeTextBox.Text = role.code;
            nameTextBox.Text = role.name;

            if (role.code == "ADMIN")
            {
                GridView1.Enabled = false;
                nameTextBox.Attributes["disabled"] = "disabled";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check page status and handle page
            if (PageStatusManager.isUpdate(this))
            {
                updatePageConfig();
            }
            PageUtils.bindData(GridView1, getSortedPermissionDictionary());
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            SecurityManager.authorize(this, SecurityManager.Permission.DELETE_ROLE);

            string code = PageStatusManager.item(this);

            ResponseObject<RoleEntity> res = RoleService.delete(code);
            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }

            Response.Redirect("~/Pages/role_page.aspx");
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            RoleEntity role = new RoleEntity();
            role.code = codeTextBox.Text;
            role.name = nameTextBox.Text;

            List<RolePermissionEntity> rolePermissions = new List<RolePermissionEntity>();

            foreach (GridViewRow row in GridView1.Rows)
            {
                PlaceHolder checkBoxPlaceHolder = row.FindControl("checkBoxPlaceHolder") as PlaceHolder;

                foreach (Control control in checkBoxPlaceHolder.Controls)
                {
                    if (control is Panel)
                    {
                        Panel panel = control as Panel;
                        foreach (Control subcontrol in panel.Controls)
                        {
                            if (subcontrol is CheckBox)
                            {
                                CheckBox checkBox = subcontrol as CheckBox;
                                if (checkBox.Checked)
                                {
                                    RolePermissionEntity rolePermission = new RolePermissionEntity();
                                    rolePermission.permission.code = checkBox.ID;
                                    rolePermissions.Add(rolePermission);
                                }
                            }
                        }
                    }
                }
            }

            role.rolePermissions = rolePermissions;

            ResponseObject<RoleEntity> res = null;

            if (!PageStatusManager.isUpdate(this))
            {
                res = RoleService.create(role);
            }
            else
            {
                res = RoleService.update(role);
            }

            if (!res.isSuccess)
            {
                PageUtils.showMessage(messageLabel, res.errorMessage);
                return;
            }
            PageUtils.showMessage(messageLabel, "Lưu thành công", true);
        }

        protected void codeValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string code = codeTextBox.Text;

            if (!PageStatusManager.isUpdate(this))
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    args.IsValid = false;
                    codeValidator.ErrorMessage = "Mã vai trò không được rỗng";
                    return;
                }
            }

            if (code.Length > 15)
            {
                args.IsValid = false;
                codeValidator.ErrorMessage = "Mã vai trò phải ít hơn 15 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void nameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            return;
            string name = nameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên vai trò không được rỗng";
                return;
            }

            if (name.Length > 50)
            {
                args.IsValid = false;
                nameValidator.ErrorMessage = "Tên vai trò phải ít hơn 50 ký tự";
                return;
            }

            args.IsValid = true;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HashSet<string> set = new HashSet<string>();

                if (PageStatusManager.isUpdate(this))
                {
                    List<RolePermissionEntity> rolePermissions = ViewStateManager.state<RolePermissionEntity>(ViewState);
                    foreach (RolePermissionEntity rolePermission in rolePermissions)
                    {
                        set.Add(rolePermission.permission.code);
                    }
                }

                var kvp = (KeyValuePair<string, List<PermissionEntity>>)e.Row.DataItem;

                CheckBox checkAll = e.Row.FindControl("checkAll") as CheckBox;
                PlaceHolder checkBoxPlaceHolder = (PlaceHolder)e.Row.FindControl("checkBoxPlaceHolder");

                int cnt = 0;
                foreach (var permission in kvp.Value)
                {

                    Panel panel = new Panel();
                    CheckBox checkBox = new CheckBox();
                    Label label = new Label();


                    if (set.Contains(permission.code))
                    {
                        cnt++;
                        checkBox.Checked = true;
                    }

                    panel.CssClass = "col-3";

                    checkBox.ID = permission.code;
                    label.Text = permission.name;

                    label.AssociatedControlID = checkBox.ID;
                    label.CssClass = "ml-2";

                    panel.Controls.Add(checkBox);
                    panel.Controls.Add(label);

                    checkBoxPlaceHolder.Controls.Add(panel);
                }
                checkAll.Checked = cnt == kvp.Value.Count;
            }

        }
    }
}