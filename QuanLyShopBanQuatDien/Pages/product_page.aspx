<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="product_page.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.product_page" %>

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
            <div class="flex-grow-1 row">
                <div class="col-5">
                    <div class="input-group rounded shadow">
                        <asp:TextBox ID="findProductTextBox" class="form-control" placeholder="Tìm sản phẩm..."
                            runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="findButton" class="btn btn-outline-primary" runat="server" OnClick="findButton_Click">
                                <i class="fa fa-search mr-1"></i><span>Tìm</span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-4">
                    <div class="input-group shadow">
                        <span class="input-group-text bg-outline-primary"><i class="fa fa-tags mr-2"></i>Loại
                        </span>
                        <asp:DropDownList ID="categoryFilterDropdownList" DataTextField="name" DataValueField="code"
                            class="custom-select" AppendDataBoundItems="true" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="categoryFilterDropdownList_SelectedIndexChanged">
                            <asp:ListItem Text="Tất cả" Value="all" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-end mr-4">
                <asp:LinkButton ID="addButton" href="product_info.aspx" class="btn shadow btn btn-primary"
                    runat="server">
                        <i class="fa fa-plus mr-2"></i><span>Thêm mới</span>
                </asp:LinkButton>
            </div>
        </div>
        <div class="row px-4">
            <div class="col-12">
                <asp:GridView ID="productGridView" class="bg-white rounded shadow table table-hover table-responsive table-bordered text-center overflow-auto"
                    runat="server" AutoGenerateEditButton="False" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="Không có sản phẩm" EmptyDataRowStyle-CssClass="font-italic text-secondary h6"
                    OnRowDataBound="productGridView_RowDataBound" OnRowCommand="productGridView_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton class="btn btn-outline-primary" runat="server" CommandName="Select"
                                    CommandArgument='<%# Container.DataItemIndex %>'>
                                    <i class="fa fa-edit"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="image" runat="server" Width="40" Height="40" ImageUrl='<%# Eval("image") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="code" HeaderText="Mã" />
                        <asp:BoundField DataField="name" HeaderText="Tên" />
                        <asp:TemplateField HeaderText="Loại">
                            <ItemTemplate>
                                <%# Eval("Category.name") %>
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
        <div class="row ml-2 mt-2">
            <div class="col-12">
                <div class="small font-italic">
                    Tổng
                    <asp:Label ID="totalOfRecordsLabel" runat="server"></asp:Label>
                    bản ghi</div>
            </div>
        </div>
    </div>
    <div id="footer">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="../Resources/Custom/Js/table-datasource-config.js"></script>
</asp:Content>
