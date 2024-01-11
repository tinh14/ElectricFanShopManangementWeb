<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true"
    CodeBehind="products.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Sản phẩm
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="bg-danger px-4 py-3">
        <div class="h2">
            Sản phẩm</div>
    </div>
    <div id="body">
        <div class="row">
            <div class="col-4">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Tìm kiếm sản phẩm theo tên...">
                    <div class="input-group-append">
                        <button class="btn btn-outline-primary" type="button">
                            <i class="fa fa-search mr-1"></i><span>Tìm</span>
                        </button>
                    </div>
                </div>
            </div>
            <div class="col-8">
                <div class="d-flex justify-content-end pr-3">
                    <button class="btn btn btn-primary" id="addButton" runat="server">
                        <i class="fa fa-plus"></i>
                        <span>Thêm mới</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div id="footer">
    </div>
</asp:Content>
