<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="grn_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.grn_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thêm phiếu nhập
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="../Resources/Libs/jquery-ui/jquery-ui.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h2" runat="server" Text="Thêm phiếu nhập"></asp:Label>
    </div>
    <div id="body" class="overflow-auto">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton ID="LinkButton1" href="grn_page.aspx" class="btn shadow btn-secondary"
                runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>Phiếu nhập
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
            <div class="text-center">
                <asp:Label ID="messageLabel" class="" runat="server"></asp:Label>
            </div>
            <div class="form-row ml-3 mr-2 mt-4 bgrn-bottom">
                <div class="col-12">
                    <div class="h6 text-secondary">
                        Thông tin phiếu nhập</div>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-3">
                <div class="col-4">
                    <label for="codeTextBox">
                        Mã phiếu nhập</label>
                    <asp:TextBox ID="codeTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="codeValidator" class="text-danger small" runat="server"
                        OnServerValidate="codeValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="supplierDropDownList">
                        Mã nhà cung cấp</label>
                    <asp:DropDownList ID="supplierDropDownList" DataTextField="name" DataValueField="code"
                        class="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="supplierValidator" class="text-danger small" runat="server"
                        OnServerValidate="supplierValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-4">
                    <label for="grnDateTextBox">
                        Ngày lập</label>
                    <asp:TextBox ID="grnDateTextBox" ClientIDMode="Static" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="grnDateValidator" class="text-danger small" runat="server"
                        OnServerValidate="grnDateValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-4">
                <div class="col-4">
                    <label for="userTextBox">
                        Mã người lập</label>
                    <asp:TextBox ID="userTextBox" ReadOnly class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-4">
                    <label for="totalAmountTextBox">
                        Tổng tiền</label>
                    <asp:TextBox ID="totalAmountTextBox" ReadOnly ClientIDMode="Static" Text="0" class="form-control"
                        runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-4 bgrn-bottom">
                <div class="col-12">
                    <div class="h6 text-secondary mt-2">
                        Danh sách sản phẩm</div>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-3">
                <div class="col-8">
                    <div class="input-group rounded">
                        <asp:TextBox ID="findTextBox" class="form-control" placeholder="Nhập mã sản phẩm..."
                            runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="addButton" class="btn btn-outline-primary" runat="server" OnClick="addButton_Click"
                                CausesValidation="false">
                                <i class="fa fa-plus mr-1"></i><span>Thêm</span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="ml-4 mr-2 mt-1">
                <asp:Label ID="productMessageLabel" runat="server"></asp:Label>
            </div>
            <div class="mx-4 mr-2 mt-2 mb-5">
                <div class="table-responsive">
                    <asp:GridView ID="gridView" ClientIDMode="Static" class="bg-white rounded table table-hover table-bordered text-center"
                        runat="server" AutoGenerateEditButton="False" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                        EmptyDataText="Không có dữ liệu" EmptyDataRowStyle-CssClass="font-italic text-secondary h6"
                        OnRowCommand="gridView_RowCommand" OnRowDataBound="gridView_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CausesValidation="false" class="btn btn-danger"
                                        runat="server" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'>
                                    <i class="fa fa-times"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ảnh">
                                <ItemTemplate>
                                    <asp:Image ID="image" class="img-thumbnail" runat="server" Width="40" Height="40"
                                        ImageUrl='<%# Eval("product.image") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã">
                                <ItemTemplate>
                                    <asp:Label ID="productCodeLabel" runat="server" Text='<%# Eval("product.code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên">
                                <ItemTemplate>
                                    <%# Eval("product.name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số lượng">
                                <ItemTemplate>
                                    <asp:TextBox ID="quantityTextBox" ClientIDMode="Static" class="quantityTextBox form-control text-center mx-auto"
                                        Style="width: 70px" runat="server" Text='<%# Eval("quantity") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Đơn giá">
                                <ItemTemplate>
                                    <asp:TextBox ID="priceTextBox" ClientIDMode="Static" class="priceTextBox form-control text-center mx-auto"
                                        DataFormatString="{0:N}" Style="width: 150px" runat="server" Text='<%# Eval("price") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tổng">
                                <ItemTemplate>
                                    <asp:Label ID="subTotalLabel" ClientIDMode="Static" class="subTotalLabel" runat="server"
                                        Text='<%# Eval("subtotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="../Resources/Libs/jquery-ui/jquery-ui.js"></script>
    <script type="text/javascript" src="../Resources/Custom/Js/table-datasource-product-config.js"></script>
    <script type="text/javascript">

        $('#grnDateTextBox').datepicker({
            dateFormat: 'dd/mm/yy'
        });

        function getNumericValue(textbox) {
            var val = $(textbox).val();
            if (isNaN(val)) {
                val = val.replace(/\D/g, '');
            }
            return val;
        }

        function updateSubtotal(subtotalLabel) {
            var subtotal = $('.quantityTextBox').val() * $('.priceTextBox').val();
            subtotalLabel.text(subtotal);
        }

        $('.quantityTextBox').on('input', function () {
            val = getNumericValue(this)
            $(this).val(val);

            var priceTotalLabel = $(this).closest('td').next().find('input');
            var subTotalLabel = $(this).closest('td').next().next().find('.subTotalLabel');

            var quantity = val;
            var price = priceTotalLabel.val();

            var subtotal = quantity * price;
            subTotalLabel.text(subtotal);

            var sum = 0;
            $('#gridView tbody tr').each(function () {
                var lastTdValue = parseInt($('td:last span', this).text());
                sum += lastTdValue;
            });
            $('#totalAmountTextBox').val(sum);
        });

        $('.priceTextBox').on('input', function () {
            val = getNumericValue(this)
            $(this).val(val);

            var quantityTotalLabel = $(this).closest('td').prev().find('input');
            var subTotalLabel = $(this).closest('td').next().find('.subTotalLabel');

            var price = val;
            var quantity = quantityTotalLabel.val();

            var subtotal = quantity * price;
            subTotalLabel.text(subtotal);

            var sum = 0;
            $('#gridView tbody tr').each(function () {
                var lastTdValue = parseInt($('td:last span', this).text());
                sum += lastTdValue;
            });
            $('#totalAmountTextBox').val(sum);

        });

       

    </script>
</asp:Content>
