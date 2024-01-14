<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="supplier_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.supplier_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thêm nhà cung cấp
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h2" runat="server" Text="Thêm nhà cung cấp"></asp:Label>
    </div>
    <div id="body">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton ID="LinkButton1" href="supplier_page.aspx" class="btn shadow btn-secondary"
                runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>Nhà cung cấp
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
                        Mã nhà cung cấp</label>
                    <asp:TextBox ID="codeTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="codeValidator" class="text-danger small" runat="server"
                        OnServerValidate="codeValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="nameTextBox">
                        Tên nhà cung cấp</label>
                    <asp:TextBox ID="nameTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="nameValidator" class="text-danger small" runat="server"
                        OnServerValidate="nameValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="contactPersonTextBox">
                        Người liên hệ</label>
                    <asp:TextBox ID="contactPersonTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="contactPersonValidator" class="text-danger small" runat="server"
                        OnServerValidate="contactPersonValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="phoneNumberTextBox">
                        Số điện thoại</label>
                    <asp:TextBox ID="phoneNumberTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="phoneNumberValidator" class="text-danger small" runat="server"
                        OnServerValidate="phoneNumberValidator_ServerValidate"></asp:CustomValidator>
                </div>
                
            </div>
            <div class="form-row ml-3 mr-2 mt-4">
                <div class="col-8">
                    <label for="addressTextBox">
                        Địa chỉ</label>
                    <asp:TextBox ID="addressTextBox" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="addressValidator" class="text-danger small" runat="server"
                        OnServerValidate="addressValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
</asp:Content>
