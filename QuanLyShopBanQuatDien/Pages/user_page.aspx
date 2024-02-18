<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="user_page.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.user_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Nhân viên
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="bg-light px-4 py-3">
        <div class="h4">
            Nhân viên</div>
    </div>
    <div id="body" class="bg-light">
        <div class="d-flex justify-content-between pl-4 py-3">
            <div class="flex-grow-1 row">
                <div class="col-5">
                    <div class="input-group rounded shadow">
                        <asp:TextBox ID="findTextBox" class="form-control" placeholder="Tìm người dùng..."
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
                        <span class="input-group-text bg-outline-primary"><i class="fa fa-shield mr-2"></i>Vai
                            trò </span>
                        <asp:DropDownList ID="filterDropdownList" DataTextField="name" DataValueField="code"
                            class="custom-select" AppendDataBoundItems="true" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="filterDropdownList_SelectedIndexChanged">
                            <asp:ListItem Text="Tất cả" Value="all" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-end mr-4">
                <asp:LinkButton ID="addButton" href="user_info.aspx" class="btn shadow btn btn-primary"
                    runat="server">
                        <i class="fa fa-plus mr-2"></i><span>Thêm mới</span>
                </asp:LinkButton>
            </div>
        </div>
        <div class="px-4">
            <div class="table-responsive">
                <asp:GridView ID="gridView" class="bg-white rounded shadow table table-hover table-bordered text-center overflow-auto"
                    runat="server" AutoGenerateEditButton="False" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                    EmptyDataText="Không có dữ liệu" EmptyDataRowStyle-CssClass="font-italic text-secondary h6"
                    OnRowDataBound="gridView_RowDataBound" OnRowCommand="gridView_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" class="btn btn-primary" runat="server" CommandName="Select"
                                    CommandArgument='<%# Container.DataItemIndex %>'>
                                    <i class="fa fa-edit"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="image" runat="server" Width="40" Height="40" ImageUrl='<%# Eval("avatar") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="username" HeaderText="Tên tài khoản" />
                        <asp:BoundField DataField="fullName" HeaderText="Họ Tên" />
                        <asp:TemplateField HeaderText="Vai trò">
                            <ItemTemplate>
                                <%# Eval("Role.name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="ml-4 mt-2">
            <div class="small font-italic text-secondary">
                Tổng
                <asp:Label ID="totalOfRecordsLabel" runat="server"></asp:Label>
                bản ghi</div>
        </div>
    </div>
    <div id="footer">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="../Resources/Custom/Js/table-datasource-product-config.js"></script>
</asp:Content>
