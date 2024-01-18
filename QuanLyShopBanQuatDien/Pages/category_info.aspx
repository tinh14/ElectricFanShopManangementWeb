<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="category_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.category_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thêm loại sản phẩm
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h4" runat="server" Text="Thêm loại sản phẩm"></asp:Label>
    </div>
    <div id="body">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton ID="LinkButton1" href="category_page.aspx" class="btn shadow btn-secondary"
                runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>Loại sản phẩm
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
                        Mã loại sản phẩm</label>
                    <asp:TextBox ID="codeTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="codeValidator" class="text-danger small" runat="server"
                        OnServerValidate="codeValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="nameTextBox">
                        Tên loại sản phẩm</label>
                    <asp:TextBox ID="nameTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="nameValidator" class="text-danger small" runat="server"
                        OnServerValidate="nameValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    
</asp:Content>
