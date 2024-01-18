<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="product_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.product_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thêm sản phẩm
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h4" runat="server" Text="Thêm sản phẩm"></asp:Label>
    </div>
    <div id="body">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton href="product_page.aspx" class="btn shadow btn-secondary" runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>  Sản phẩm
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
                    <label for="codeTextBox">
                        Mã sản phẩm</label>
                    <asp:TextBox ID="codeTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="codeValidator" class="text-danger small" runat="server"
                        OnServerValidate="codeValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="nameTextBox">
                        Tên sản phẩm</label>
                    <asp:TextBox ID="nameTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="nameValidator" class="text-danger small" runat="server"
                        OnServerValidate="nameValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="categoryDropDownList">
                        Loại sản phẩm</label>
                    <asp:DropDownList ID="categoryDropDownList" DataTextField="name" DataValueField="code"
                        class="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="categoryValidator" class="text-danger small" runat="server"
                        OnServerValidate="categoryValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-2">
                <div class="col-4">
                    <label for="brandTextBox">
                        Thương hiệu</label>
                    <asp:TextBox ID="brandTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="brandValidator" class="text-danger small" runat="server"
                        OnServerValidate="brandValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="powerTextBox">
                        Công suất tiêu thụ</label>
                    <asp:TextBox ID="powerTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="powerValidator" class="text-danger small" runat="server"
                        OnServerValidate="powerValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="sizeTextBox">
                        Kích thước</label>
                    <asp:TextBox ID="sizeTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="sizeValidator" class="text-danger small" runat="server"
                        OnServerValidate="sizeValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-2">
                <div class="col-4">
                    <label for="materialTextBox">
                        Chất liệu</label>
                    <asp:TextBox ID="materialTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="materialValidator" class="text-danger small" runat="server"
                        OnServerValidate="materialValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="colorTextBox">
                        Màu sắc</label>
                    <asp:TextBox ID="colorTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="colorValidator" class="text-danger small" runat="server"
                        OnServerValidate="colorValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="speedTextBox">
                        Tốc độ gió</label>
                    <asp:TextBox ID="speedTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="speedValidator" class="text-danger small" runat="server"
                        OnServerValidate="speedValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-2">
                <div class="col-12">
                    <label for="imageImage">
                        Hình ảnh</label>
                </div>
            </div>
            <div class="form-row ml-3 mr-2">
                <div class="col-4">
                    <input type="file" class="d-none" accept="image/*">
                    <asp:Image ID="imageImage" class="border rounded w-100" Height="200" runat="server" />
                    <asp:CustomValidator ID="imageValidator" class="text-danger small" runat="server"
                        OnServerValidate="imageValidator_ServerValidate"></asp:CustomValidator>
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
