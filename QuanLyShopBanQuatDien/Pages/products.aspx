<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true"
    CodeBehind="products.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Sản phẩm
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="bg-light px-4 py-3">
        <div class="h2">
            Sản phẩm</div>
    </div>
    <div id="body" class="bg-light">
        <div class="d-flex justify-content-between pl-4 py-3">
            <div class="row">
                <div class="col-6">
                    <div class="input-group rounded shadow">
                        <input type="text" class="form-control" placeholder="Tìm theo tên...">
                        <div class="input-group-append">
                            <button class="btn btn-outline-primary" type="button">
                                <i class="fa fa-search mr-1"></i><span>Tìm</span>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="input-group shadow">
                        <span class="input-group-text bg-outline-primary"><i class="fa fa-tags mr-2"></i>Loại
                        </span>
                        <asp:DropDownList ID="categoryFilterDropdownList" class="custom-select" runat="server">
                            <asp:ListItem Value="all" Text="Tất cả"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="d-flex">
                <div class="d-flex justify-content-end mr-3">
                    <button class="btn shadow btn btn-primary" id="addButton" runat="server">
                        <i class="fa fa-plus mr-2"></i><span>Thêm mới</span>
                    </button>
                </div>
                <div class="d-flex justify-content-end mr-4">
                    <button class="btn shadow btn btn-outline-danger" id="Button1" runat="server">
                        <i class="fa fa-trash mr-2"></i><span>Xóa</span>
                    </button>
                </div>
            </div>
        </div>
        <div class="row px-4">
            <div class="col-12">
                <asp:GridView ID="productGridView" class="bg-white rounded shadow table table-hover table-responsive table-bordered text-center overflow-auto"
                    runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" OnRowDataBound="productGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <HeaderTemplate>
                                <asp:CheckBox ID="HeaderCheckBox" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="image" runat="server" Width="40" Height="40" ImageUrl='<%# Eval("Image") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="code" HeaderText="Mã" />
                        <asp:BoundField DataField="name" HeaderText="Tên" />
                        <asp:TemplateField HeaderText="Loại">
                            <ItemTemplate>
                                <%# Eval("Category.Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="brand" HeaderText="Thương hiệu" />
                        <asp:BoundField DataField="power" HeaderText="Công suất" />
                        <asp:BoundField DataField="size" HeaderText="Kích thước" />
                        <asp:BoundField DataField="material" HeaderText="Chất liệu" />
                        <asp:BoundField DataField="color" HeaderText="Màu sắc" />
                        <asp:BoundField DataField="speed" HeaderText="Tốc độ gió" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row ml-2 mr-2 mt-2 d-flex align-items-center">
            <div class="col-9">
                <div class="small font-italic">
                    Tổng
                    <asp:Label ID="numberOfRecordLabel" runat="server"></asp:Label>
                    bản ghi</div>
            </div>
            <div class="col-3">
                <div class="input-group shadow">
                    <span class="input-group-text">Trang</span>
                    <asp:TextBox ID="currentPageTextBox" class="form-control text-center" runat="server"></asp:TextBox>
                    <span class="input-group-text">/
                        <asp:Label ID="numberOfPagesLabel" runat="server"></asp:Label>
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div id="footer">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="../Resources/Custom/Js/table-datasource-config.js"></script>
</asp:Content>
