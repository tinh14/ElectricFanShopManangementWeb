<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="activity_log_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.activity_log_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Chi tiết nhật ký hoạt động
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h4" runat="server" Text="Chi tiết nhật ký hoạt động"></asp:Label>
    </div>
    <div id="body">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton ID="LinkButton1" href="activities_log_page.aspx" class="btn shadow btn-secondary"
                runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>Nhật ký hoạt động
            </asp:LinkButton>
        </div>
        <div class="form-row ml-3 mr-2 mt-4">
            <div class="col-4">
                <label for="codeTextBox">
                    Mã bản ghi</label>
                <asp:TextBox ID="codeTextBox" ReadOnly class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-4">
                <label for="usernameTextBox">
                    Tên đăng nhập</label>
                <asp:TextBox ID="usernameTextBox" ReadOnly class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-4">
                <label for="statusTextBox">
                    Trạng thái</label>
                <asp:TextBox ID="statusTextBox" ReadOnly class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row ml-3 mr-2 mt-2">
            <div class="col-4">
                <label for="timestampTextBox">
                    Thời gian</label>
                <asp:TextBox ID="timestampTextBox" ReadOnly class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-4">
                <label for="ipTextBox">
                    Địa chỉ ip</label>
                <asp:TextBox ID="ipTextBox" ReadOnly class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row ml-3 mr-2 mt-2">
            <div class="col-12">
                <label for="deviceInfoTextBox">
                    Thông tin thiết bị</label>
                <asp:TextBox ID="deviceInfoTextBox" ReadOnly TextMode="MultiLine" class="form-control" runat="server" ></asp:TextBox>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
</asp:Content>
