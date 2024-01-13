<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="access_denied.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.access_denied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Truy cập thất bại
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="body" class="flex-grow-1 text-center d-flex flex-column align-content-center "
        style="padding-top: 15%">
        <i class="fa fa-times-circle text-danger" style="font-size: 150px" aria-hidden="true"></i>
        <div class="h2 mt-4 mb-3 text-secondary font-weight-bold">Truy cập bị từ chối</div> 
        <div class="text-secondary mt-4">Bạn không có quyền truy cập vào tài nguyên này.</div>
        <div class="text-secondary mt-3">Vui lòng liên hệ với quản trị viên và thử lại.</div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
</asp:Content>
