<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="user_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.user_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thêm sản phẩm
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h4" runat="server" Text="Thêm người dùng"></asp:Label>
    </div>
    <div id="body">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton ID="LinkButton1" href="user_page.aspx" class="btn shadow btn-secondary"
                runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>  Người dùng
            </asp:LinkButton>
            <div>
                <asp:LinkButton ID="saveLinkButton" class="shadow btn btn-primary mr-3" runat="server"
                    OnClick="saveLinkButton_Click">
                    <i class="fa fa-save mr-2" aria-hidden="true"></i> Lưu
                </asp:LinkButton>
                <asp:LinkButton ID="deleteLinkButton" Visible="false" OnClientClick="return confirm('Bạn chắc chắn xóa?');"
                    runat="server" class="shadow btn btn-outline-danger mr-3" OnClick="deleteLinkButton_Click">
                    <i class="fa fa-times mr-2" aria-hidden="true"></i> Xóa
                </asp:LinkButton>
            </div>
        </div>
        <div>
            <div class="form-row">
                <div class="col-12 text-center">
                    <asp:Label ID="messageLabel" class="" runat="server"></asp:Label>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-4">
                <div class="col-4">
                    <label for="usernameTextBox">
                        Tên đăng nhập</label>
                    <asp:TextBox ID="usernameTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="usernameValidator" class="text-danger small" runat="server"
                        OnServerValidate="usernameValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="passwordTextBox">
                        Mật khẩu</label>
                    <asp:TextBox ID="passwordTextBox" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="passwordValidator" class="text-danger small" runat="server"
                        OnServerValidate="passwordValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="fullNameTextBox">
                        Họ tên</label>
                    <asp:TextBox ID="fullNameTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="fullNameValidator" class="text-danger small" runat="server"
                        OnServerValidate="fullNameValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-2">
                <div class="col-4">
                    <label for="roleDropdownList">
                        Vai trò</label>
                    <asp:DropDownList ID="roleDropdownList" DataTextField="name" DataValueField="code"
                        class="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="roleValidator" class="text-danger small" runat="server"
                        OnServerValidate="roleValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-2">
                <div class="col-12">
                    <label for="avatarImage">
                        Hình ảnh</label>
                </div>
            </div>
            <div class="form-row ml-3 mr-2">
                <div class="col-4">
                    <input type="file" class="d-none" accept="image/*">
                    <asp:Image ID="avatarImage" class="border rounded w-100" Height="200" runat="server" />
                    <asp:CustomValidator ID="avatarValidator" class="text-danger small" runat="server"
                        OnServerValidate="avatarValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mt-3">
                <div class="col-4">
                    <div class="custom-file">
                        <asp:FileUpload ID="imageFileUpload" onchange="$('#uploadImageButton').click()" class="custom-file-input"
                            runat="server" />
                        <asp:Button ID="uploadImageButton" ClientIDMode="Static" class="d-none" CausesValidation="false"
                            runat="server" OnClientClick="this.form.submit()" />
                        <label class="custom-file-label" for="inputGroupFile01">
                            Chọn ảnh</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
</asp:Content>
