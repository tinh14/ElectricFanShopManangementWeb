<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="order_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.order_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thêm hóa đơn
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="../Resources/Libs/jquery-ui/jquery-ui.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h2" runat="server" Text="Thêm hóa đơn"></asp:Label>
    </div>
    <div id="body">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton ID="LinkButton1" href="order_page.aspx" class="btn shadow btn-secondary"
                runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>Hóa đơn
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
            <div class="form-row ml-3 mr-2 mt-4 border-bottom">
                <div class="col-12">
                    <div class="h6 text-secondary">
                        Thông tin hóa đơn</div>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-3">
                <div class="col-4">
                    <label for="codeTextBox">
                        Mã hóa đơn</label>
                    <asp:TextBox ID="codeTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="codeValidator" class="text-danger small" runat="server"
                        OnServerValidate="codeValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="orderDateTextBox">
                        Ngày lập</label>
                    <asp:TextBox ID="orderDateTextBox" ClientIDMode="Static" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="orderDateValidator" class="text-danger small" runat="server"
                        OnServerValidate="orderDateValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="customerDropDownList">
                        Mã khách hàng</label>
                    <asp:DropDownList ID="customerDropDownList" DataTextField="name" DataValueField="code"
                        class="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="customerValidator" class="text-danger small" runat="server"
                        OnServerValidate="customerValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-4">
                <div class="col-4">
                    <label for="userTextBox">
                        Mã người lập</label>
                    <asp:TextBox ID="userTextBox" disabled="disabled" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-4">
                    <label for="totalAmountTextBox">
                        Tổng tiền</label>
                    <asp:TextBox ID="totalAmountTextBox" disabled="disabled" Text="0" class="form-control"
                        runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-4 border-bottom">
                <div class="col-12">
                    <div class="h6 text-secondary mt-2">
                        Danh sách sản phẩm</div>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-3">
                <div class="col-8">
                    <div class="input-group rounded shadow">
                        <asp:TextBox ID="findTextBox" class="form-control" placeholder="Nhập mã sản phẩm..."
                            runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="addButton" class="btn btn-outline-primary" runat="server">
                                <i class="fa fa-plus mr-1"></i><span>Thêm</span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-4">
                <div class="col-12">
                    <asp:GridView ID="gridView" class="bg-white rounded shadow table table-hover table-bordered text-center"
                        runat="server" AutoGenerateEditButton="False" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                        EmptyDataText="Không có sản phẩm" EmptyDataRowStyle-CssClass="font-italic text-secondary h6">
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
                                    <asp:Image ID="image" runat="server" Width="40" Height="40" ImageUrl='<%# Eval("image") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="code" HeaderText="Mã" />
                            <asp:BoundField DataField="name" HeaderText="Tên" />
                            <asp:BoundField DataField="quantity" HeaderText="Số lượng" />
                            <asp:BoundField DataField="price" HeaderText="Đơn giá" />
                            <asp:BoundField DataField="discount" HeaderText="Chiếc khấu" />
                            <asp:BoundField DataField="subtotal" HeaderText="Tổng" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script src="../Resources/Libs/jquery-ui/jquery-ui.js"></script>
    <script>
        $('#orderDateTextBox').datepicker({
            dateFormat: 'dd/mm/yy'
        });
    </script>
</asp:Content>
