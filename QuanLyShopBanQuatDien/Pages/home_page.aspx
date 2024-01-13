<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="home_page.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.home_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Trang chủ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="body" class="flex-grow-1 text-center d-flex flex-column align-content-center "
        style="padding-top: 25%">
        <span class="h1 mb-3 text-primary">Chào mừng đến với ManyFans</span> <small>Tối ưu hóa
            hoạt động kinh doanh của bạn với công cụ quản lý hiệu quả, đồng thời tăng cường
            tương tác và quản lý khách hàng</small>
        <div class="mt-5">
            <asp:LinkButton ID="LinkButton1" class="mr-5" runat="server" OnClientClick="window.open('https://github.com/gaconlontoni21', '_blank'); return false;"><i class="fa fa-lg fa-github" aria-hidden="true"></i></asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" class="mr-5" runat="server" OnClientClick="window.open('https://www.facebook.com/61552512084013', '_blank'); return false;"><i class="fa fa-lg fa-facebook" aria-hidden="true"></i></asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" class="mr-5" runat="server" OnClientClick="window.open('https://www.instagram.com/tinhlam533', '_blank'); return false;"><i class="fa fa-lg fa-instagram" aria-hidden="true"></i></asp:LinkButton>
        </div>
    </div>
</asp:Content>
